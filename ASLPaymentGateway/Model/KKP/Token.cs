namespace ASLPaymentGateway.Model.KKP
{
    public class Token
    {
        public string access_token { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
        public string expires_in { set; get; }
        public string error_description { set; get; }
        public string error { set; get; }

    }
}
