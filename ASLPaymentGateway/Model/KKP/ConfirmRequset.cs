namespace ASLPaymentGateway.Model.KKP
{
    public class ConfirmRequset
    {
        public HeaderTrans Header { get; set; }
        public ConfirmDataRequset Data { get; set; }
    }
    public class ConfirmDataRequset
    {
        public string TxnReferenceNo { get; set; }
        public string SendingAccountNo { get; set; }

    }
}