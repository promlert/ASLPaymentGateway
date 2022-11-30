namespace ASLPaymentGateway.Model.KKP
{
    public class InquiryAccountCorpRequest
    {
        public HeaderTrans Header { get; set; }
        public InquiryAccountCorpDataRequest Data { get; set; }
    }
    public class InquiryAccountCorpDataRequest
    {
        public string CorporateAccountNo { get; set; }
    }
}
