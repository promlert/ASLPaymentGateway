namespace ASLPaymentGateway.Model.KKP
{
    public class InquiryResultResponse
    {
        public HeaderTrans Header { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public InquiryResultDataResponse Data { get; set; }
        public ResponseFault fault { get; set; }
    }
    public class InquiryResultDataResponse
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string FeeAmount { get; set; }

    }
}
