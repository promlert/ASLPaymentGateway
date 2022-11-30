namespace ASLPaymentGateway.Model.CIMB.Authentication
{
    public class RawRequestBody
    {
        public string customer_identity { set; get; }
        public string passcode { set; get; }
        public string grant_type { set; get; }
        public string client_secret { set; get; }
    }
}
