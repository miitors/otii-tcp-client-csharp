namespace OtiiTcpClient {

    /// <summary>
    /// Represents digital channel data.
    /// </summary>
    public class DigitalData {

        /// <summary>
        /// Gets or sets the timestamp of the first sample in seconds.
        /// </summary>
        public double Timestamp { get; }

        /// <summary>
        /// Gets or sets the digital value.
        /// </summary>
        public bool Value { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="DigitalData"/>
        /// </summary>
        /// <param name="timestamp">The timestamp of the first sample.</param>
        /// <param name="value">The sample value.</param>
        public DigitalData(double timestamp, bool value) {
            Timestamp = timestamp;
            Value = value;
        }
    }
}