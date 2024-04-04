using Newtonsoft.Json;

namespace OtiiTcpClient {

    public partial class Recording {

        private class RecordingRequestData {

            [JsonProperty("recording_id")]
            public int RecordingId { get; set; }

            public RecordingRequestData(int recordingId) {
                RecordingId = recordingId;
            }
        }

        private class ChannelRequestData : RecordingRequestData {

            [JsonProperty("device_id")]
            public string DeviceId { get; set; }

            [JsonProperty("channel")]
            public Channel Channel { get; set; }

            public ChannelRequestData(int recordingId, string deviceId, Channel channel) : base(recordingId) {
                DeviceId = deviceId;
                Channel = channel;
            }
        }

        private sealed class DeleteRequest : Request {

            [JsonProperty("data")]
            public RecordingRequestData Data { get; set; }

            public DeleteRequest(int recordingId) : base("recording_delete") {
                Data = new RecordingRequestData(recordingId);
            }
        }

        private sealed class DownsampleChannelRequest : Request {

            public sealed class DownsampleChannelRequestData : ChannelRequestData {

                [JsonProperty("factor")]
                public int Factor { get; set; }

                public DownsampleChannelRequestData(int recordingId, string deviceId, Channel channel, int factor) : base(recordingId, deviceId, channel) {
                    Factor = factor;
                }
            }

            [JsonProperty("data")]
            public DownsampleChannelRequestData Data { get; set; }

            public DownsampleChannelRequest(int recordingId, string deviceId, Channel channel, int factor) : base("recording_downsample_channel") {
                Data = new DownsampleChannelRequestData(recordingId, deviceId, channel, factor);
            }
        }

        private sealed class GetChannelDataCountRequest : Request {

            [JsonProperty("data")]
            public ChannelRequestData Data { get; set; }

            public GetChannelDataCountRequest(int recordingId, string deviceId, Channel channel) : base("recording_get_channel_data_count") {
                Data = new ChannelRequestData(recordingId, deviceId, channel);
            }
        }

        private sealed class GetChannelDataCountResponse : Response {

            public sealed class GetChannelDataCountResponseData {

                [JsonProperty("count")]
                public long Count { get; set; }
            }

            [JsonProperty("data")]
            public GetChannelDataCountResponseData Data { get; set; }
        }

        private sealed class GetChannelDataIndexRequest : Request {

            public sealed class GetChannelDataIndexRequestData : ChannelRequestData {

                [JsonProperty("timestamp")]
                public double Timestamp { get; set; }

                public GetChannelDataIndexRequestData(int recordingId, string deviceId, Channel channel, double timestamp) : base(recordingId, deviceId, channel) {
                    Timestamp = timestamp;
                }
            }

            [JsonProperty("data")]
            public GetChannelDataIndexRequestData Data { get; set; }

            public GetChannelDataIndexRequest(int recordingId, string deviceId, Channel channel, double timestamp) : base("recording_get_channel_data_index") {
                Data = new GetChannelDataIndexRequestData(recordingId, deviceId, channel, timestamp);
            }
        }

        private sealed class GetChannelDataIndexResponse : Response {

            public sealed class GetChannelDataIndexResponseData {

                [JsonProperty("index")]
                public long Index { get; set; }
            }

            [JsonProperty("data")]
            public GetChannelDataIndexResponseData Data { get; set; }
        }

        private sealed class GetChannelDataRequest : Request {

            public sealed class GetChannelDataRequestData : ChannelRequestData {

                [JsonProperty("index")]
                public long Index { get; set; }

                [JsonProperty("count")]
                public long Count { get; set; }

                public GetChannelDataRequestData(int recordingId, string deviceId, Channel channel, long index, long count) : base(recordingId, deviceId, channel) {
                    Index = index;
                    Count = count;
                }
            }

            [JsonProperty("data")]
            public GetChannelDataRequestData Data { get; set; }

            public GetChannelDataRequest(int recordingId, string deviceId, Channel channel, long index, long count) : base("recording_get_channel_data") {
                Data = new GetChannelDataRequestData(recordingId, deviceId, channel, index, count);
            }
        }

        private sealed class GetAnalogChannelDataResponse : Response {

            public sealed class GetAnalogChannelDataResponseData {

                [JsonProperty("data_type")]
                public string DataType { get; set; }

                [JsonProperty("timestamp")]
                public double Timestamp { get; set; }

                [JsonProperty("interval")]
                public double Interval { get; set; }

                [JsonProperty("values")]
                public double[] Values { get; set; }
            }

            [JsonProperty("data")]
            public GetAnalogChannelDataResponseData Data { get; set; }
        }

        private sealed class GetDigitalChannelDataResponse : Response {

            public sealed class DigitalValue {

                [JsonProperty("timestamp")]
                public double Timestamp { get; set; }

                [JsonProperty("value")]
                public bool Value { get; set; }
            }

            public sealed class GetDigitalChannelDataResponseData {

                [JsonProperty("data_type")]
                public string DataType { get; set; }

                [JsonProperty("values")]
                public DigitalValue[] Values { get; set; }
            }

            [JsonProperty("data")]
            public GetDigitalChannelDataResponseData Data { get; set; }
        }

        private sealed class GetLogChannelDataResponse : Response {

            public sealed class LogValue {

                [JsonProperty("timestamp")]
                public double Timestamp { get; set; }

                [JsonProperty("value")]
                public string Value { get; set; }
            }

            public sealed class GetLogChannelDataResponseData {

                [JsonProperty("data_type")]
                public string DataType { get; set; }

                [JsonProperty("values")]
                public LogValue[] Values { get; set; }
            }

            [JsonProperty("data")]
            public GetLogChannelDataResponseData Data { get; set; }
        }

        private sealed class GetChannelInfoRequest : Request {

            [JsonProperty("data")]
            public ChannelRequestData Data { get; set; }

            public GetChannelInfoRequest(int recordingId, string deviceId, Channel channel) : base("recording_get_channel_info") {
                Data = new ChannelRequestData(recordingId, deviceId, channel);
            }
        }

        private sealed class GetIChannelnfoResponse : Response {

            public sealed class GetChannelInfoResponseData {

                [JsonProperty("offset")]
                public double Offset { get; set; }

                [JsonProperty("from")]
                public double From { get; set; }

                [JsonProperty("to")]
                public double To { get; set; }

                [JsonProperty("sample_rate")]
                public long SampleRate { get; set; }
            }

            [JsonProperty("data")]
            public GetChannelInfoResponseData Data { get; set; }
        }

        private sealed class GetChannelStatisticsRequest : Request {

            public sealed class GetChannelStatisticsRequestData : ChannelRequestData {

                [JsonProperty("from")]
                public double From { get; set; }

                [JsonProperty("to")]
                public double To { get; set; }

                public GetChannelStatisticsRequestData(int recordingId, string deviceId, Channel channel, double from, double to) : base(recordingId, deviceId, channel) {
                    From = from;
                    To = to;
                }
            }

            [JsonProperty("data")]
            public GetChannelStatisticsRequestData Data { get; set; }

            public GetChannelStatisticsRequest(int recordingId, string deviceId, Channel channel, double from, double to) : base("recording_get_channel_statistics") {
                Data = new GetChannelStatisticsRequestData(recordingId, deviceId, channel, from, to);
            }
        }

        private sealed class GetChannelStatisticsResponse : Response {

            public sealed class GetChannelStatisticsResponseData {

                [JsonProperty("min")]
                public double Min { get; set; }

                [JsonProperty("max")]
                public double Max { get; set; }

                [JsonProperty("average")]
                public double Average { get; set; }

                [JsonProperty("energy")]
                public double Energy { get; set; }
            }

            [JsonProperty("data")]
            public GetChannelStatisticsResponseData Data { get; set; }
        }

        private sealed class GetLogOffsetRequest : Request {

            [JsonProperty("data")]
            public ChannelRequestData Data { get; set; }

            public GetLogOffsetRequest(int recordingId, string deviceId, Channel channel) : base("recording_get_log_offset") {
                Data = new ChannelRequestData(recordingId, deviceId, channel);
            }
        }

        private sealed class GetLogOffsetResponse : Response {

            public sealed class GetLogOffsetResponseData {

                [JsonProperty("offset")]
                public long Offset { get; set; }
            }

            [JsonProperty("data")]
            public GetLogOffsetResponseData Data { get; set; }
        }

        private sealed class GetOffsetRequest : Request {

            [JsonProperty("data")]
            public RecordingRequestData Data { get; set; }

            public GetOffsetRequest(int recordingId) : base("recording_get_offset") {
                Data = new RecordingRequestData(recordingId);
            }
        }

        private sealed class GetOffsetResponse : Response {

            public sealed class GetOffsetResponseData {

                [JsonProperty("offset")]
                public long Offset { get; set; }
            }

            [JsonProperty("data")]
            public GetOffsetResponseData Data { get; set; }
        }

        private sealed class ImportLogRequest : Request {

            public sealed class ImportLogRequestData : RecordingRequestData {

                [JsonProperty("filename")]
                public string Filename { get; set; }

                [JsonProperty("converter")]
                public string Converter { get; set; }

                public ImportLogRequestData(int recordingId, string filename, string converter) : base(recordingId) {
                    Filename = filename;
                    Converter = converter;
                }
            }

            [JsonProperty("data")]
            public ImportLogRequestData Data { get; set; }

            public ImportLogRequest(int recordingId, string filename, string converter) : base("recording_import_log") {
                Data = new ImportLogRequestData(recordingId, filename, converter);
            }
        }

        private sealed class IsRunningRequest : Request {

            [JsonProperty("data")]
            public RecordingRequestData Data { get; set; }

            public IsRunningRequest(int recordingId) : base("recording_is_running") {
                Data = new RecordingRequestData(recordingId);
            }
        }

        private sealed class IsRunningResponse : Response {

            public sealed class IsRunningResponseData {

                [JsonProperty("running")]
                public bool Running { get; set; }
            }

            [JsonProperty("data")]
            public IsRunningResponseData Data { get; set; }
        }

        private sealed class LogRequest : Request {

            public sealed class LogRequestData : RecordingRequestData {

                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonProperty("timestamp")]
                public long Timestamp { get; set; }

                public LogRequestData(int recordingId, string text, long timestamp) : base(recordingId) {
                    Text = text;
                    Timestamp = timestamp;
                }
            }

            [JsonProperty("data")]
            public LogRequestData Data { get; set; }

            public LogRequest(int recordingId, string text, long timestamp) : base("recording_log") {
                Data = new LogRequestData(recordingId, text, timestamp);
            }
        }

        private sealed class RenameRequest : Request {

            public sealed class RenameRequestData : RecordingRequestData {

                [JsonProperty("name")]
                public string Name { get; set; }

                public RenameRequestData(int recordingId, string name) : base(recordingId) {
                    Name = name;
                }
            }

            [JsonProperty("data")]
            public RenameRequestData Data { get; set; }

            public RenameRequest(int recordingId, string name) : base("recording_rename") {
                Data = new RenameRequestData(recordingId, name);
            }
        }

        private sealed class SetLogOffsetRequest : Request {

            public sealed class SetLogOffsetRequestData : ChannelRequestData {

                [JsonProperty("offset")]
                public long Offset { get; set; }

                public SetLogOffsetRequestData(int recordingId, string deviceId, Channel channel, long offset) : base(recordingId, deviceId, channel) {
                    Offset = offset;
                }
            }

            [JsonProperty("data")]
            public SetLogOffsetRequestData Data { set; get; }

            public SetLogOffsetRequest(int recordingId, string deviceId, Channel channel, long offset) : base("recording_set_log_offset") {
                Data = new SetLogOffsetRequestData(recordingId, deviceId, channel, offset);
            }
        }

        private sealed class SetOffsetRequest : Request {

            public sealed class SetOffsetRequestData : RecordingRequestData {

                [JsonProperty("offset")]
                public long Offset { get; set; }

                public SetOffsetRequestData(int recordingId, long offset) : base(recordingId) {
                    Offset = offset;
                }
            }

            [JsonProperty("data")]
            public SetOffsetRequestData Data { get; set; }

            public SetOffsetRequest(int recordingId, long offset) : base("recording_set_offset") {
                Data = new SetOffsetRequestData(recordingId, offset);
            }
        }
    }
}