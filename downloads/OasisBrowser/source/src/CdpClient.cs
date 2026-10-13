using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OasisBrowser;

public sealed class CdpClient : IDisposable
{
	private readonly ClientWebSocket socket = new ClientWebSocket();

	private readonly SemaphoreSlim send = new SemaphoreSlim(1, 1);

	private readonly ConcurrentDictionary<int, TaskCompletionSource<JObject>> pending = new ConcurrentDictionary<int, TaskCompletionSource<JObject>>();

	private readonly CancellationTokenSource stop = new CancellationTokenSource();

	private int sequence;

	public event Action<JObject>? EventReceived;

	public async Task ConnectAsync(Uri endpoint, CancellationToken cancellation)
	{
        socket.Options.Proxy=null; // validated loopback endpoint only
		await socket.ConnectAsync(endpoint, cancellation).ConfigureAwait(continueOnCapturedContext: false);
		Task.Run((Func<Task>)Receive);
	}

	public async Task<JObject> CallAsync(string method, object? parameters, CancellationToken cancellation)
	{
		int id = Interlocked.Increment(ref sequence);
		TaskCompletionSource<JObject> answer = new TaskCompletionSource<JObject>(TaskCreationOptions.RunContinuationsAsynchronously);
		pending[id] = answer;
		using CancellationTokenSource timeout = CancellationTokenSource.CreateLinkedTokenSource(stop.Token, cancellation);
		timeout.CancelAfter(TimeSpan.FromSeconds(15.0));
		using (timeout.Token.Register(delegate
		{
			answer.TrySetCanceled();
		}))
		{
			_ = 2;
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(new JObject
				{
					["id"] = id,
					["method"] = method,
					["params"] = ((parameters == null) ? new JObject() : JObject.FromObject(parameters))
				}.ToString(Formatting.None));
				await send.WaitAsync(timeout.Token).ConfigureAwait(continueOnCapturedContext: false);
				try
				{
					await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, timeout.Token).ConfigureAwait(continueOnCapturedContext: false);
				}
				finally
				{
					send.Release();
				}
				JObject obj = await answer.Task.ConfigureAwait(continueOnCapturedContext: false);
				if (obj["error"] != null)
				{
					throw new InvalidOperationException("Chrome odmítl příkaz prohlížeče.");
				}
				return (obj["result"] as JObject) ?? new JObject();
			}
			finally
			{
				pending.TryRemove(id, out TaskCompletionSource<JObject> _);
			}
		}
	}

	private async Task Receive()
	{
		byte[] buffer = new byte[65536];
		try
		{
			while (!stop.IsCancellationRequested)
			{
				using MemoryStream message = new MemoryStream();
				WebSocketReceiveResult webSocketReceiveResult;
				do
				{
					webSocketReceiveResult = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), stop.Token).ConfigureAwait(continueOnCapturedContext: false);
					if (webSocketReceiveResult.MessageType == WebSocketMessageType.Close)
					{
						throw new IOException();
					}
					if (message.Length + webSocketReceiveResult.Count > 8388608)
					{
						throw new IOException();
					}
					message.Write(buffer, 0, webSocketReceiveResult.Count);
				}
				while (!webSocketReceiveResult.EndOfMessage);
				JObject jObject = JObject.Parse(Encoding.UTF8.GetString(message.ToArray()));
				if (jObject["method"] != null) EventReceived?.Invoke(jObject);
				JToken? jToken = jObject["id"];
				if (jToken != null && jToken.Type == JTokenType.Integer && pending.TryGetValue((int)jObject["id"], out TaskCompletionSource<JObject> value))
				{
					value.TrySetResult(jObject);
				}
			}
		}
		catch
		{
			foreach (TaskCompletionSource<JObject> value2 in pending.Values)
			{
				value2.TrySetException(new IOException("Spojení s Chrome skončilo."));
			}
		}
	}

	public void Dispose()
	{
		stop.Cancel();
		socket.Abort();
		socket.Dispose();
		foreach (TaskCompletionSource<JObject> value in pending.Values)
		{
			value.TrySetCanceled();
		}
	}
}
