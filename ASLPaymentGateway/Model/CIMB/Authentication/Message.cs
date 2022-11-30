namespace ASLPaymentGateway.Model.CIMB.Authentication
{
    public class Message
    {
        public string timestamp { set; get; }
        public string aes_key { set; get; }
        public string message_value { set; get; }
        public string module { set; get; }
        public string exponent { set; get; }
        public string public_key { set; get; }
        public string message { set; get; }
    }
}
