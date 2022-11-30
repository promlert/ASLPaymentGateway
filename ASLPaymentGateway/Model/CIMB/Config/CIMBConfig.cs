namespace ASLPaymentGateway.Model.CIMB.Config
{
    public class CIMBConfig
    {
        public string customer_identity { get; set; }
        public string passcode { get; set; }
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string client_ref_id { get; set; }
        public string Key64 { get; set; }
        public string VI64 { get; set; }
        public string public_key { get; set; }
        public string channel_id { get; set; }
        public string exponent { get; set;}
    }
}
