using System;
using System.IO;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace OtiiTcpClient {

    /// <summary>
    /// OtiiClient is used to create a connection to an Otii TCP server using Connect.
    /// When connected the Otii API can be accessed through the property Otii.
    /// </summary>
    public class OtiiClient : IDisposable {
        private const string DefaultServer = "localhost";
        private const int DefaultPort = 1905;
        private TcpClient _client;
        private NetworkStream _stream;
        private Otii _otii;
        private int transId;
        private bool Disposed;

        /// <summary>
        /// The Otii API.
        /// </summary>
        public Otii Otii { get { return _otii; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="OtiiClient"/> and creates a new instance of <see cref="OtiiTcpClient.Otii"/>.
        /// </summary>
        public OtiiClient() {
            _otii = new Otii(this);
        }

        /// <summary>
        /// Connect to an Otii TCP Server.
        /// </summary>
        /// <param name="server">The server address (default localhost).</param>
        /// <param name="port">The port number (default 1905).</param>
        public string Connect(string server = DefaultServer, int port = DefaultPort) {
            _client = new TcpClient(server, port);
            _stream = _client.GetStream();

            using (StreamReader streamReader = new StreamReader(_stream, System.Text.Encoding.UTF8, false, 1024, true)) {
                var responseData = streamReader.ReadLine();
                ServerStatus status = JsonConvert.DeserializeObject<ServerStatus>(responseData);
                return status.ToString();
            }
        }

        /// <summary>
        /// Close the connection.
        /// </summary>
        public void Close() {
            _stream.Dispose();
            _client.Close();

            _stream = null;
            _client = null;
        }

        /// <summary>
        /// Exception thrown when the server is unexcepctedly disconnected.
        /// </summary>
        public class DisconnectedException : Exception {
        }

        internal U PostRequest<T, U>(T request, bool log = false) where T : Request where U : Response {
            request.TransId = $"{++transId}";
            var jsonString = JsonConvert.SerializeObject(request) + "\n";
            if (log) {
                Console.Write(jsonString);
            }
            var data = System.Text.Encoding.UTF8.GetBytes(jsonString);
            _stream.Write(data, 0, data.Length);

            var responseData = string.Empty;
            using (StreamReader streamReader = new StreamReader(_stream, System.Text.Encoding.UTF8, false, 1024, true)) {
                responseData = streamReader.ReadLine() ?? throw new DisconnectedException();
            }

            if (log) {
                Console.Write(responseData.Substring(0, Math.Min(responseData.Length, 256)));
            }

            var response = JsonConvert.DeserializeObject<U>(responseData);
            if (response.Type == "error") {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseData);
                throw new ErrorResponseException(errorResponse);
            }
            if (response.Type == "progress") {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseData);
            }
            if (response.Type == "information") {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseData);
            }
            if (response.TransId != request.TransId) {
                throw new ArgumentException("Trans id mismatch");
            }
            return response;
        }

        internal void PostRequest<T>(T request, bool log = false) where T : Request {
            PostRequest<T, Response>(request, log);
        }

        /// <inheritdoc cref="IDisposable.Dispose"/>
        /// <param name="disposing">
        /// <see langword="true"/> if both managed and unmanaged resources should be disposed;
        /// <see langword="false"/> if only unmanaged resources should be disposed.
        /// </param>
        protected virtual void Dispose(bool disposing) {
            if (Disposed) {
                return;
            }

            if (disposing) {
                Close();
            }

            Disposed = true;
        }

        /// <inheritdoc/>
        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private sealed class ServerStatus {

            public sealed class ServerStatusData {

                [JsonProperty("otii_version")]
                public string OtiiVersion { get; set; }

                [JsonProperty("protocol_version")]
                public string ProtocolVersion { get; set; }

                [JsonProperty("server")]
                public string Server { get; set; }

                public override string ToString() {
                    return $"Otii Version: {OtiiVersion}, Protocol¨Version: {ProtocolVersion}, Server: {Server}";
                }
            }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("info")]
            public string Info { get; set; }

            [JsonProperty("data")]
            public ServerStatusData Data { get; set; }

            public override string ToString() {
                return $"Type: {Type}, Info: {Info}, Data: {Data}";
            }
        }
    }

    internal class Request {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("cmd")]
        public string Cmd { get; set; }

        [JsonProperty("trans_id")]
        public string TransId { get; set; }

        public Request(string cmd) {
            Type = "request";
            Cmd = cmd;
            TransId = "";
        }
    }

    internal class Response {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("cmd")]
        public string Cmd { get; set; }

        [JsonProperty("trans_id")]
        public string TransId { get; set; }
    }
}