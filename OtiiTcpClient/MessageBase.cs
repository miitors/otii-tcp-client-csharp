using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace OtiiTcpClient {

    /// <summary>
    /// Base class for Otii messages.
    /// </summary>
    [DataContract]
    public abstract class MessageBase {

        /// <summary>
        /// Gets or sets the message type.
        /// </summary>
        public MessageType Type { get; set; }

        [DataMember(Name = "type")]
        private string TypeString {
            get => JsonConvert.SerializeObject(Type);
            set => Type = JsonConvert.DeserializeObject<MessageType>(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBase"/> class.
        /// </summary>
        protected MessageBase() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBase"/> class.
        /// </summary>
        /// <param name="type">The message type.</param>
        protected MessageBase(MessageType type) {
            Type = type;
        }
    }
}