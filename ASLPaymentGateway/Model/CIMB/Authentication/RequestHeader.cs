namespace ASLPaymentGateway.Model.CIMB.Authentication
{
    public class RequestHeader
    {
        public string Contenttype { set; get; }
        public string client_id { set; get; }
        public string request_id { set; get; }
        public string client_ref_id { set; get; }
        public string message { set; get; }
    }
}
