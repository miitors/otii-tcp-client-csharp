namespace OtiiTcpClient {

    /// <summary>
    /// Represents analog channel data.
    /// </summary>
    public class AnalogData {

        /// <summary>
        /// Gets or sets the timestamp of the first sample in seconds.
        /// </summary>
        public double Timestamp { get; }

        /// <summary>
        /// Gets or sets the interval between each sample.
        /// </summary>
        public double Interval { get; }

        /// <summary>
        /// Gets or sets the list of analog sample values.
        /// </summary>
        public double[] Values { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="AnalogData"/>
        /// </summary>
        /// <param name="timestamp">The timestamp of the first sample.</param>
        /// <param name="interval">The interval between each sample.</param>
        /// <param name="values">The list of sample values.</param>
        public AnalogData(double timestamp, double interval, double[] values) {
            Timestamp = timestamp;
            Interval = interval;
            Values = values;
        }
    }
}