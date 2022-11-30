using ASLPaymentGateway.Model;
using ASLPaymentGateway.Model.KKP;
using System.Net;
using System.Net.Http.Headers;

namespace ASLPaymentGateway.Service
{
    public class PaymentKKPService
    {
        public string Url { get; set; }
        public ResponsePayment SendPayment(RequestPayment request)
        {
            ResponsePayment response = new ResponsePayment();
            using (HttpClient client = new HttpClient() )
            {
                client.BaseAddress = new Uri(Url);
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(
                //    new MediaTypeWithQualityHeaderValue("application/json"));
            }
            return response;
        }
    }
}
