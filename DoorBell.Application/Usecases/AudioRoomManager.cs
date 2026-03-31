using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases
{
    public class AudioRoomManager
    {
        private static readonly Dictionary<string, List<WebSocket>> _rooms = new();

        public static async Task HandleConnection(string roomId, WebSocket socket)
        {
            if (!_rooms.ContainsKey(roomId))
                _rooms[roomId] = new List<WebSocket>();

            _rooms[roomId].Add(socket);

            var buffer = new byte[2048];

            try
            {
                while (socket.State == WebSocketState.Open)
                {
                    var result = await socket.ReceiveAsync(buffer, CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                        break;

                    // 🔥 forward audio tới các client khác
                    await Broadcast(roomId, buffer, result.Count, socket);
                }
            }
            finally
            {
                _rooms[roomId].Remove(socket);
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed", CancellationToken.None);
            }
        }

        private static async Task Broadcast(string roomId, byte[] buffer, int count, WebSocket sender)
        {
            if (!_rooms.ContainsKey(roomId)) return;

            var tasks = _rooms[roomId]
                .Where(s => s != sender && s.State == WebSocketState.Open)
                .Select(s => s.SendAsync(
                    new ArraySegment<byte>(buffer, 0, count),
                    WebSocketMessageType.Binary,
                    true,
                    CancellationToken.None));

            await Task.WhenAll(tasks);
        }
    }
}
