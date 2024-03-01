namespace OtiiTcpClient {

    /// <summary>
    /// Represent statistics of a channel.
    /// </summary>
    public class ChannelStatistics {

        /// <summary>
        /// Gets or sets the minimum value in the selected interval.
        /// </summary>
        public double Min { get; }

        /// <summary>
        /// Gets or sets the maximum value in the selected interval.
        /// </summary>
        public double Max { get; }

        /// <summary>
        /// Gets or sets the average value in the selected interval.
        /// </summary>
        public double Average { get; }

        /// <summary>
        /// Gets or sets the energy consumed in the interval (if applicable).
        /// </summary>
        public double Energy { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelStatistics"/>.
        /// </summary>
        /// <param name="min">The minimum value in the selected interval.</param>
        /// <param name="max">The maximum value in the selected interval.</param>
        /// <param name="average">The average value in the selected interval.</param>
        /// <param name="energy">The energy consumed in the interval (if applicable).</param>
        public ChannelStatistics(double min, double max, double average, double energy) {
            Min = min;
            Max = max;
            Average = average;
            Energy = energy;
        }
    }
}