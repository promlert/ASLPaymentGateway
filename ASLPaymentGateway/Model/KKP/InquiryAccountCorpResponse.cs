namespace ASLPaymentGateway.Model.KKP
{
    public class InquiryAccountCorpResponse
    {
        public HeaderTrans Header { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public InquiryAccountCorpDataResponse Data { get; set; }
        public ResponseFault fault { get; set; }
    }
    public class InquiryAccountCorpDataResponse
    {
      public decimal  LedgerBalance { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal FloatAmount { get; set; }
        public decimal DrawingLimit { get; set; }
        public decimal EarmarkAmount { get; set; }
        public string AccountStatus { get; set; }
    }
}
