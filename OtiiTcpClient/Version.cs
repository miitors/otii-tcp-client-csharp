namespace OtiiTcpClient {

    /// <summary>
    /// Represents version information of a device.
    /// </summary>
    public class Version {

        /// <summary>
        /// Gets the hardware version.
        /// </summary>
        public string HardwareVersion { get; }

        /// <summary>
        /// Gets the software version.
        /// </summary>
        public string FirmwareVersion { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="Version"/>.
        /// </summary>
        /// <param name="hardwareVersion">The hardware version.</param>
        /// <param name="firmwareVersion">The software version.</param>
        public Version(string hardwareVersion, string firmwareVersion) {
            HardwareVersion = hardwareVersion;
            FirmwareVersion = firmwareVersion;
        }
    }
}