namespace OtiiTcpClient {

    /// <summary>
    /// Represents an Otii license.
    /// </summary>
    public class License {

        /// <summary>
        /// Gets or sets the unique identifier for the license.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or sets the license type.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets or sets the available status of the license.
        /// </summary>
        public bool Available { get; }

        /// <summary>
        /// Gets or sets reserved to.
        /// </summary>
        public string ReservedTo { get; }

        /// <summary>
        /// Gets or sets the hostname.
        /// </summary>
        public string Hostname { get; }

        /// <summary>
        /// Gets or sets the license addons.
        /// </summary>
        public string[] AddonTypes { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="License"/>.
        /// </summary>
        /// <param name="id">The unique identifier for a license.</param>
        /// <param name="type">The type of license.</param>
        /// <param name="available">The available status.</param>
        /// <param name="reservedTo">The specifications of whom its reserved to.</param>
        /// <param name="hostname">The hostname.</param>
        /// <param name="addonTypes">The license addons.</param>
        public License(int id, string type, bool available, string reservedTo, string hostname, string[] addonTypes) {
            Id = id;
            Type = type;
            Available = available;
            ReservedTo = reservedTo;
            Hostname = hostname;
            AddonTypes = addonTypes;
        }
    }
}