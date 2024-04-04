namespace OtiiTcpClient {

    /// <summary>
    /// Represents log data received from UART.
    /// </summary>
    public class LogData {

        /// <summary>
        /// Gets or sets the timestamp in seconds.
        /// </summary>
        public double Timestamp { get; }

        /// <summary>
        /// Gets or sets the log text.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="LogData"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp in seconds.</param>
        /// <param name="value">The log text.</param>
        public LogData(double timestamp, string value) {
            Timestamp = timestamp;
            Value = value;
        }
    }
}