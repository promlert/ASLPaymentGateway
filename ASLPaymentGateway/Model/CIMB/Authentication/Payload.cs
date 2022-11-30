namespace ASLPaymentGateway.Model.CIMB.Authentication
{
    public class Payload
    {
        public string payload { set; get; }
        public string aes_key { set; get; }
        public string iv { set; get; }
        public string data { set; get; }
    }
}
