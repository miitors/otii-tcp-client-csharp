using System.Runtime.Serialization;

namespace OtiiTcpClient {

    /// <summary>
    /// Represents an Otii message.
    /// </summary>
    [DataContract]
    public class Message : MessageBase {

        /// <summary>
        /// Gets or sets the message command.
        /// </summary>
        [DataMember(Name = "cmd")]
        public string Command { get; set; }

        /// <summary>
        /// Gets or sets the message transaction ID.
        /// </summary>
        [DataMember(Name = "trans_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        public Message() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="type">The message type.</param>
        /// <param name="command">The message command.</param>
        public Message(MessageType type, string command)
            : base(type) {
            Command = command;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="type">The message type.</param>
        /// <param name="command">The message command.</param>
        /// <param name="transactionId">The transaction ID.</param>
        public Message(MessageType type, string command, string transactionId)
            : base(type) {
            Command = command;
            TransactionId = transactionId;
        }

        /// <inheritdoc/>
        public override string ToString() {
            return $"[Type: {Type}, Command: {Command}, TransactionId: {TransactionId}]";
        }
    }
}