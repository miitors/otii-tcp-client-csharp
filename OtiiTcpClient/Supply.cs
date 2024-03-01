namespace OtiiTcpClient {

    /// <summary>
    /// Represents a supply.
    /// </summary>
    public class Supply {

        /// <summary>
        /// Gets the supply ID.
        /// </summary>
        public int SupplyId { get; }

        /// <summary>
        /// Gets the supply name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the supply manufacturer.
        /// </summary>
        public string Manufacturer { get; }

        /// <summary>
        /// Gets the supply model.
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="Supply"/>.
        /// </summary>
        /// <param name="supplyId">The supply ID.</param>
        /// <param name="name">The supply name.</param>
        /// <param name="manufacturer">The supply manufacturer.</param>
        /// <param name="model">The supply model.</param>
        public Supply(int supplyId, string name, string manufacturer, string model) {
            SupplyId = supplyId;
            Name = name;
            Manufacturer = manufacturer;
            Model = model;
        }
    }
}