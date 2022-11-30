namespace ASLPaymentGateway.Model.KKP
{
    public class InquiryResultRequest
    {
        public HeaderTrans Header { get; set; }
        public InquiryResultDataRequest Data { get; set; }
    }
    public class InquiryResultDataRequest
    {
        public string TxnReferenceNo { get; set; }
        public string SendingAccountNo { get; set; }

    }
}
