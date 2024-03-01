namespace OtiiTcpClient {

    /// <summary>
    /// Represents channel info.
    /// </summary>
    public class ChannelInfo {

        /// <summary>
        /// Gets or sets the offset of the recording in seconds.
        /// </summary>
        public double Offset { get; }

        /// <summary>
        /// Gets or sets the start of the recording in seconds.
        /// </summary>
        public double From { get; }

        /// <summary>
        /// Gets or sets the end of the recording in seconds.
        /// </summary>
        public double To { get; }

        /// <summary>
        /// Gets or sets the sample rate of the recording.
        /// </summary>
        public long SampleRate { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ChannelInfo"/>.
        /// </summary>
        /// <param name="offset">The offset of the recording in seconds.</param>
        /// <param name="from">The start of the recording in seconds. </param>
        /// <param name="to">The end of the recording in seconds.</param>
        /// <param name="sampleRate">The sample rate of the recording.</param>
        public ChannelInfo(double offset, double from, double to, long sampleRate) {
            Offset = offset;
            From = from;
            To = to;
            SampleRate = sampleRate;
        }
    }
}