namespace ASLPaymentGateway.Model.KKP
{
    public class ReferenceInfo
    {
        public string referenceNo1 { get; set; }
        public string referenceNo2 { get; set; }
        public string referenceNo3 { get; set; }
        public string referenceNo4 { get; set; }
    }

    public class PaymentInfo
    {
        public string paymentType { get; set; }
        public string paymentDate { get; set; }
        public int paymentAmount { get; set; }
        public string customerName { get; set; }
    }

    public class CompanyAccountInfo
    {
        public string accountNumber { get; set; }
        public string accountBankCode { get; set; }
        public string accountBranchCode { get; set; }
    }

    public class Body
    {
        public ReferenceInfo referenceInfo { get; set; }
        public PaymentInfo paymentInfo { get; set; }
        public CompanyAccountInfo companyAccountInfo { get; set; }
    }

    public class RequestPayment
    {
        public Header Header { get; set; }
        public Body body { get; set; }
    }

}
