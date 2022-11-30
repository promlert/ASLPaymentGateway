namespace ASLPaymentGateway.Model.KKP
{
    public class LookupRequest
    {
        public HeaderTrans Header { get; set; }
        public LookupRequestData Data { get; set; }
    }
    public class LookupRequestData
    { 
        public string EffectiveDate { get; set; }
        public string TransferAmount { get; set; }
        public string SendingAccountNo { get; set; }
        public string ScanFlag { get; set; }
        public string ReceivingType { get; set; }
        public string ReceivingID { get; set; }
        public string ReceivingBankCode { get; set; }
        public string Currency { get; set; }
        public string RTPReferenceNo { get; set; }
    }
}
