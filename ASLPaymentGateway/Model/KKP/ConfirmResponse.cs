namespace ASLPaymentGateway.Model.KKP
{
    public class ConfirmResponse
    {
        public HeaderTrans Header { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public ConfirmDataResponse Data { get; set; }
        public ResponseFault fault { get; set; }
    }
    public class ConfirmDataResponse
    {
        public decimal FeeAmount { get; set; }
        public decimal AvailableBalance { get; set; }
    }
}
