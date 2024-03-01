using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace OtiiTcpClient {
    /// <summary>
    /// 
    /// </summary>
    public class ErrorResponse {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("errorcode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cmd")]
        public string Cmd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("trans_id")]
        public string TransId { get; set; }
    }
}
