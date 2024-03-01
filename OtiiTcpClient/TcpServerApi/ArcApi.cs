using Newtonsoft.Json;

namespace OtiiTcpClient {

    public partial class Arc {

        private class ArcRequestData {

            [JsonProperty("device_id")]
            public string DeviceId { get; set; }

            public ArcRequestData(string deviceId) {
                DeviceId = deviceId;
            }
        }

        private class EnableRequestData : ArcRequestData {

            [JsonProperty("enable")]
            public bool Enable { get; set; }

            public EnableRequestData(string deviceId, bool enable) : base(deviceId) {
                Enable = enable;
            }
        }

        private sealed class SetDoubleRequestData : ArcRequestData {

            [JsonProperty("value")]
            public double Value { get; set; }

            public SetDoubleRequestData(string deviceId, double value) : base(deviceId) {
                Value = value;
            }
        }

        private sealed class SupplyData {

            [JsonProperty("supply_id")]
            public int SupplyId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("manufacturer")]
            public string Manufacturer { get; set; }

            [JsonProperty("model")]
            public string Model { get; set; }
        }

        private sealed class CalibrateRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public CalibrateRequest(string deviceId) : base("arc_calibrate") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class Enable5VRequest : Request {

            [JsonProperty("data")]
            public EnableRequestData Data { get; set; }

            public Enable5VRequest(string deviceId, bool enable) : base("arc_enable_5v") {
                Data = new EnableRequestData(deviceId, enable);
            }
        }

        private sealed class EnableExpPortRequest : Request {

            [JsonProperty("data")]
            public EnableRequestData Data { get; set; }

            public EnableExpPortRequest(string deviceId, bool enable) : base("arc_enable_exp_port") {
                Data = new EnableRequestData(deviceId, enable);
            }
        }

        private sealed class EnableChannelRequest : Request {

            public sealed class EnableChannelData : EnableRequestData {

                [JsonProperty("channel")]
                public Channel Channel { get; set; }

                public EnableChannelData(string deviceId, Channel channel, bool enable) : base(deviceId, enable) {
                    Channel = channel;
                }
            }

            [JsonProperty("data")]
            public EnableChannelData Data { get; set; }

            public EnableChannelRequest(string deviceId, Channel channel, bool enable) : base("arc_enable_channel") {
                Data = new EnableChannelData(deviceId, channel, enable);
            }
        }

        private sealed class EnableUartRequest : Request {

            public sealed class EnableUartRequestData : ArcRequestData {

                [JsonProperty("enable")]
                public bool Enable { get; set; }

                public EnableUartRequestData(string deviceId, bool enable) : base(deviceId) {
                    Enable = enable;
                }
            }

            [JsonProperty("data")]
            public EnableUartRequestData Data { get; set; }

            public EnableUartRequest(string deviceId, bool enable) : base("arc_enable_uart") {
                Data = new EnableUartRequestData(deviceId, enable);
            }
        }

        private sealed class Get4WireRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public Get4WireRequest(string deviceId) : base("arc_get_4wire") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class Get4WireResponse : Response {

            public sealed class Get4WireResponseData {

                [JsonProperty("value")]
                public Arc4WireState Value { get; set; }
            }

            [JsonProperty("data")]
            public Get4WireResponseData Data { get; set; }
        }

        private sealed class GetAdcResistorRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetAdcResistorRequest(string deviceId) : base("arc_get_adc_resistor") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetAdcResistorResponse : Response {

            public sealed class GetAdcResistorResponseData {

                [JsonProperty("value")]
                public double Value { get; set; }
            }

            [JsonProperty("data")]
            public GetAdcResistorResponseData Data { get; set; }
        }

        private sealed class GetExpVoltageRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetExpVoltageRequest(string deviceId) : base("arc_get_exp_voltage") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetExpVoltageResponse : Response {

            public sealed class GetExpVoltageResponseData {

                [JsonProperty("value")]
                public double Value { get; set; }
            }

            [JsonProperty("data")]
            public GetExpVoltageResponseData Data { get; set; }
        }

        private sealed class GetGpiRequest : Request {

            public sealed class GetGpiRequestData : ArcRequestData {

                [JsonProperty("pin")]
                public int Pin { get; set; }

                public GetGpiRequestData(string deviceId, int pin) : base(deviceId) {
                    Pin = pin;
                }
            }

            [JsonProperty("data")]
            public GetGpiRequestData Data { get; set; }

            public GetGpiRequest(string deviceId, int pin) : base("arc_get_gpi") {
                Data = new GetGpiRequestData(deviceId, pin);
            }
        }

        private sealed class GetGpiResponse : Response {

            public sealed class GetGpiResponseData {

                [JsonProperty("value")]
                public bool Value { get; set; }
            }

            [JsonProperty("data")]
            public GetGpiResponseData Data { get; set; }
        }

        private sealed class GetMainVoltageRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetMainVoltageRequest(string deviceId) : base("arc_get_main_voltage") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetMainVoltageResponse : Response {

            public sealed class GetMainVoltageResponseData {

                [JsonProperty("value")]
                public double Value { get; set; }
            }

            [JsonProperty("data")]
            public GetMainVoltageResponseData Data { get; set; }
        }

        private sealed class GetMaxCurrentRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetMaxCurrentRequest(string deviceId) : base("arc_get_max_current") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetMaxCurrentResponse : Response {

            public sealed class GetMaxCurrentResponseData {

                [JsonProperty("value")]
                public double Value { get; set; }
            }

            [JsonProperty("data")]
            public GetMaxCurrentResponseData Data { get; set; }
        }

        private sealed class GetRangeRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetRangeRequest(string deviceId) : base("arc_get_range") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetRangeResponse : Response {

            public sealed class GetRangeResponseData {

                [JsonProperty("range")]
                public MeasurementRange Range { get; set; }
            }

            [JsonProperty("data")]
            public GetRangeResponseData Data { get; set; }
        }

        private sealed class GetRxRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetRxRequest(string deviceId) : base("arc_get_rx") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetRxResponse : Response {

            public sealed class GetRxResponseData {

                [JsonProperty("value")]
                public bool Value { get; set; }
            }

            [JsonProperty("data")]
            public GetRxResponseData Data { get; set; }
        }

        private sealed class GetSourceCurrentLimitEnabledRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetSourceCurrentLimitEnabledRequest(string deviceId) : base("arc_get_src_cur_limit_enabled") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetSourceCurrentLimitEnabledResponse : Response {

            public sealed class GetSourceCurrentLimitEnabledResponseData {

                [JsonProperty("enabled")]
                public bool Enabled { get; set; }
            }

            [JsonProperty("data")]
            public GetSourceCurrentLimitEnabledResponseData Data { get; set; }
        }

        private sealed class GetSuppliesRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetSuppliesRequest(string deviceId) : base("arc_get_supplies") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetSuppliesResponse : Response {

            public sealed class GetSuppliesResponseData {

                [JsonProperty("supplies")]
                public SupplyData[] Supplies { get; set; }
            }

            [JsonProperty("data")]
            public GetSuppliesResponseData Data { get; set; }
        }

        private sealed class GetSupplyRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetSupplyRequest(string deviceId) : base("arc_get_supply") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetSupplyResponse : Response {

            public sealed class GetSupplyResponseData {

                [JsonProperty("supply_id")]
                public int SupplyId { get; set; }
            }

            [JsonProperty("data")]
            public GetSupplyResponseData Data { get; set; }
        }

        private sealed class GetSupplyParallelRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetSupplyParallelRequest(string deviceId) : base("arc_get_supply_parallel") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetSupplyParallelResponse : Response {

            public sealed class GetSupplyParallelResponseData {

                [JsonProperty("value")]
                public int Value { get; set; }
            }

            [JsonProperty("data")]
            public GetSupplyParallelResponseData Data { get; set; }
        }

        private sealed class GetSupplySeriesRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetSupplySeriesRequest(string deviceId) : base("arc_get_supply_series") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetSupplySeriesResponse : Response {

            public sealed class GetSupplySeriesResponseData {

                [JsonProperty("value")]
                public int Value { get; set; }
            }

            [JsonProperty("data")]
            public GetSupplySeriesResponseData Data { get; set; }
        }

        private sealed class GetUartBaudrateRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetUartBaudrateRequest(string deviceId) : base("arc_get_uart_baudrate") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetUartBaudrateResponse : Response {

            public sealed class GetUartBaudrateResponseData {

                [JsonProperty("value")]
                public int Value { get; set; }
            }

            [JsonProperty("data")]
            public GetUartBaudrateResponseData Data { get; set; }
        }

        private sealed class GetValueRequest : Request {

            public sealed class GetValueRequestData : ArcRequestData {

                [JsonProperty("channel")]
                public Channel Channel { get; set; }

                public GetValueRequestData(string deviceId, Channel channel) : base(deviceId) {
                    Channel = channel;
                }
            }

            [JsonProperty("data")]
            public GetValueRequestData Data { get; set; }

            public GetValueRequest(string deviceId, Channel channel) : base("arc_get_value") {
                Data = new GetValueRequestData(deviceId, channel);
            }
        }

        private sealed class GetValueResponse : Response {

            public sealed class GetValueResponseData {

                [JsonProperty("value")]
                public double Value { get; set; }
            }

            [JsonProperty("data")]
            public GetValueResponseData Data { get; set; }
        }

        private sealed class GetVersionRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public GetVersionRequest(string deviceId) : base("arc_get_version") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class GetVersionResponse : Response {

            public sealed class GetVersionResponseData {

                [JsonProperty("hw_version")]
                public string HardwareVersion { get; set; }

                [JsonProperty("fw_version")]
                public string FirmwareVersion { get; set; }
            }

            [JsonProperty("data")]
            public GetVersionResponseData Data { get; set; }
        }

        private sealed class IsConnectedRequest : Request {

            [JsonProperty("data")]
            public ArcRequestData Data { get; set; }

            public IsConnectedRequest(string deviceId) : base("arc_is_connected") {
                Data = new ArcRequestData(deviceId);
            }
        }

        private sealed class IsConnectedResponse : Response {

            public sealed class IsConnectedResponseData {

                [JsonProperty("connected")]
                public bool Connected { get; set; }
            }

            [JsonProperty("data")]
            public IsConnectedResponseData Data { get; set; }
        }

        private sealed class Set4WireRequest : Request {

            [JsonProperty("data")]
            public EnableRequestData Data { get; set; }

            public Set4WireRequest(string deviceId, bool enable) : base("arc_set_4wire") {
                Data = new EnableRequestData(deviceId, enable);
            }
        }

        private sealed class SetAdcResistorRequest : Request {

            [JsonProperty("data")]
            public SetDoubleRequestData Data { get; set; }

            public SetAdcResistorRequest(string deviceId, double value) : base("arc_set_adc_resistor") {
                Data = new SetDoubleRequestData(deviceId, value);
            }
        }

        private sealed class SetExpVoltageRequest : Request {

            [JsonProperty("data")]
            public SetDoubleRequestData Data { get; set; }

            public SetExpVoltageRequest(string deviceId, double value) : base("arc_set_exp_voltage") {
                Data = new SetDoubleRequestData(deviceId, value);
            }
        }

        private sealed class SetGpoRequest : Request {

            public sealed class SetGpoRequestData : ArcRequestData {

                [JsonProperty("pin")]
                public int Pin { get; set; }

                [JsonProperty("value")]
                public bool Value { get; set; }

                public SetGpoRequestData(string deviceId, int pin, bool value) : base(deviceId) {
                    Pin = pin;
                    Value = value;
                }
            }

            [JsonProperty("data")]
            public SetGpoRequestData Data { get; set; }

            public SetGpoRequest(string deviceId, int pin, bool value) : base("arc_set_gpo") {
                Data = new SetGpoRequestData(deviceId, pin, value);
            }
        }

        private sealed class SetMainRequest : Request {

            [JsonProperty("data")]
            public EnableRequestData Data { get; set; }

            public SetMainRequest(string deviceId, bool enable) : base("arc_set_main") {
                Data = new EnableRequestData(deviceId, enable);
            }
        }

        private sealed class SetMainCurrentRequest : Request {

            public sealed class SetMainCurrentData : ArcRequestData {

                [JsonProperty("value")]
                public double Value { get; set; }

                public SetMainCurrentData(string deviceId, double voltage) : base(deviceId) {
                    Value = voltage;
                }
            }

            [JsonProperty("data")]
            public SetMainCurrentData Data { get; set; }

            public SetMainCurrentRequest(string deviceId, double voltage) : base("arc_set_main_current") {
                Data = new SetMainCurrentData(deviceId, voltage);
            }
        }

        private sealed class SetMainVoltageRequest : Request {

            public sealed class SetMainVoltageData : ArcRequestData {

                [JsonProperty("value")]
                public double Value { get; set; }

                public SetMainVoltageData(string deviceId, double voltage) : base(deviceId) {
                    Value = voltage;
                }
            }

            [JsonProperty("data")]
            public SetMainVoltageData Data { get; set; }

            public SetMainVoltageRequest(string deviceId, double voltage) : base("arc_set_main_voltage") {
                Data = new SetMainVoltageData(deviceId, voltage);
            }
        }

        private sealed class SetMaxCurrentRequest : Request {

            public sealed class SetMaxCurrentData : ArcRequestData {

                [JsonProperty("value")]
                public double Value { get; set; }

                public SetMaxCurrentData(string deviceId, double voltage) : base(deviceId) {
                    Value = voltage;
                }
            }

            [JsonProperty("data")]
            public SetMaxCurrentData Data { get; set; }

            public SetMaxCurrentRequest(string deviceId, double voltage) : base("arc_set_max_current") {
                Data = new SetMaxCurrentData(deviceId, voltage);
            }
        }

        private sealed class SetPowerRegulationRequest : Request {

            public sealed class SetPowerRegulationRequestData : ArcRequestData {

                [JsonProperty("mode")]
                public PowerRegulationMode Mode { get; set; }

                public SetPowerRegulationRequestData(string deviceId, PowerRegulationMode mode) : base(deviceId) {
                    Mode = mode;
                }
            }

            [JsonProperty("data")]
            public SetPowerRegulationRequestData Data { get; set; }

            public SetPowerRegulationRequest(string deviceId, PowerRegulationMode mode) : base("arc_set_power_regulation") {
                Data = new SetPowerRegulationRequestData(deviceId, mode);
            }
        }

        private sealed class SetRangeRequest : Request {

            public sealed class SetRangeRequestData : ArcRequestData {

                [JsonProperty("range")]
                public MeasurementRange Range { get; set; }

                public SetRangeRequestData(string deviceId, MeasurementRange range) : base(deviceId) {
                    Range = range;
                }
            }

            [JsonProperty("data")]
            public SetRangeRequestData Data { get; set; }

            public SetRangeRequest(string deviceId, MeasurementRange range) : base("arc_set_range") {
                Data = new SetRangeRequestData(deviceId, range);
            }
        }

        private sealed class SetTxRequest : Request {

            public sealed class SetTxRequestData : ArcRequestData {

                [JsonProperty("value")]
                public bool Value { get; set; }

                public SetTxRequestData(string deviceId, bool value) : base(deviceId) {
                    Value = value;
                }
            }

            [JsonProperty("data")]
            public SetTxRequestData Data { get; set; }

            public SetTxRequest(string deviceId, bool value) : base("arc_set_tx") {
                Data = new SetTxRequestData(deviceId, value);
            }
        }

        private sealed class SetSourceCurrentLimitEnabledRequest : Request {

            public sealed class SetSourceCurrentLimitEnabledRequestData : ArcRequestData {

                [JsonProperty("enable")]
                public bool Enable { get; set; }

                public SetSourceCurrentLimitEnabledRequestData(string deviceId, bool enable) : base(deviceId) {
                    Enable = enable;
                }
            }

            [JsonProperty("data")]
            public SetSourceCurrentLimitEnabledRequestData Data { get; set; }

            public SetSourceCurrentLimitEnabledRequest(string deviceId, bool enable) : base("arc_set_src_cur_limit_enabled") {
                Data = new SetSourceCurrentLimitEnabledRequestData(deviceId, enable);
            }
        }

        private sealed class SetSupplyRequest : Request {

            public sealed class SetSupplyRequestData : ArcRequestData {

                [JsonProperty("supply_id")]
                public int SupplyId { get; set; }

                public SetSupplyRequestData(string deviceId, int supplyId) : base(deviceId) {
                    SupplyId = supplyId;
                }
            }

            [JsonProperty("data")]
            public SetSupplyRequestData Data { get; set; }

            public SetSupplyRequest(string deviceId, int supplyId) : base("arc_set_supply") {
                Data = new SetSupplyRequestData(deviceId, supplyId);
            }
        }

        private sealed class SetUartBaudrateRequest : Request {

            public sealed class SetUartBaudrateRequestData : ArcRequestData {

                [JsonProperty("value")]
                public int Value { get; set; }

                public SetUartBaudrateRequestData(string deviceId, int value) : base(deviceId) {
                    Value = value;
                }
            }

            [JsonProperty("data")]
            public SetUartBaudrateRequestData Data { get; set; }

            public SetUartBaudrateRequest(string deviceId, int value) : base("arc_set_uart_baudrate") {
                Data = new SetUartBaudrateRequestData(deviceId, value);
            }
        }

        private sealed class WriteTxRequest : Request {

            public sealed class WriteTxRequestData : ArcRequestData {

                [JsonProperty("value")]
                public string Value { get; set; }

                public WriteTxRequestData(string deviceId, string value) : base(deviceId) {
                    Value = value;
                }
            }

            [JsonProperty("data")]
            public WriteTxRequestData Data { get; set; }

            public WriteTxRequest(string deviceId, string value) : base("arc_write_tx") {
                Data = new WriteTxRequestData(deviceId, value);
            }
        }
    }
}