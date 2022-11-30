namespace ASLPaymentGateway.Model.KKP
{
    public class ResponsePayment
    {
        public Header Header { get; set; }
        public ResponsePaymentStatus ResponseStatus { get; set; }
    }

    public class ResponsePaymentStatus
    {
        public string OriginalResponseCode { get; set; }
        public string OriginalResponseMessage { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}
