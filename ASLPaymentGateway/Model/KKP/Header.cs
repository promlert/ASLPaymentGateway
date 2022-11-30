namespace ASLPaymentGateway.Model.KKP
{
    public class Header
    {
        public string TransactionID { get; set; }
        public string TransactionDateTime { get; set; }
        public string ServiceName { get; set; }
        public string SystemCode { get; set; }
        public string ChannelID { get; set; }
    }
}
