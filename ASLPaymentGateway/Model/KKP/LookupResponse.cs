namespace ASLPaymentGateway.Model.KKP
{
    public class LookupResponse
    {
        public HeaderTrans Header { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public LookupDataResponse Data { get; set; }
        public ResponseFault fault { get; set; }
    }
    public class LookupDataResponse
    {
        public string ReceivingAccountNumber { get; set; }
        public string ReceivingAccountEnName { get; set; }
        public string ReceivingAccountName { get; set; }
        public string TxnReferenceNo { get; set; }

    }
}
