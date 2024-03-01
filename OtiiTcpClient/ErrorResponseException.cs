using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace OtiiTcpClient {

    /// <summary>
    ///
    /// </summary>
    public class ErrorResponseException : Exception {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ErrorResponseException(string message) : base(message) {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ErrorResponseException(string message, Exception innerException) : base(message, innerException) {
        }
        /// <summary>
        /// 
        /// </summary>
        public ErrorResponseException() {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ErrorResponseException(ErrorResponse message) : base(FormatMessage(message)) {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ErrorResponseException(ErrorResponse message, Exception innerException) : base(FormatMessage(message), innerException) {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ErrorResponseException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            return base.Equals(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Exception GetBaseException() {
            return base.GetBaseException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            base.GetObjectData(info, context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return base.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string FormatMessage(ErrorResponse message) {
            if (message == null) {
                return "Error when processing error response.";
            }

            if (message.Data == null) {
                return $"[{message.Cmd}] {message.ErrorCode}.";
            }

            return $"[{message.Cmd}] {message.ErrorCode}: {message.Data}";
        }
    }
}