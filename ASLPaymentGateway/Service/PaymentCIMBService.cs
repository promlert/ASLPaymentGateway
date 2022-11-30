using ASLPaymentGateway.Model.CIMB.Authentication;
using ASLPaymentGateway.Model.CIMB.Config;
using ASLPaymentGateway.Model.KKP;
using ASLPaymentGateway.Utility;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace ASLPaymentGateway.Service
{
    public class PaymentCIMBService
    {
        private readonly ILogger<PaymentCIMBService> _logger;
        CIMBConfig _config;
        public PaymentCIMBService(ILogger<PaymentCIMBService> logger, CIMBConfig config) {
            _logger = logger;
            _config = config;
        } 
        public string Url { get; set; }
        public ResponsePayment Login()
        {
            ResponsePayment response = new ResponsePayment();
            string aes = "";
            var head = setHeader(ref aes);
            var data = SetRawRequestBody(aes);
            _logger.LogInformation(JsonConvert.SerializeObject(head));
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("client_id", head.client_id);
                client.DefaultRequestHeaders.Add("request_id", head.request_id);
                client.DefaultRequestHeaders.Add("client_ref_id", head.client_ref_id);
                client.DefaultRequestHeaders.Add("message", head.message);
                client.BaseAddress = new Uri(Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var myContent = JsonConvert.SerializeObject(data.data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(head.Contenttype);
                var result = client.PostAsync("", byteContent).Result;
              
            }
            return response;
        }

        private RequestHeader setHeader(ref string res)
        {
            //Generate RequestId
            var requestId = DataGenerator.GetUniqueKeyOriginal_BIASED(32);
           
            RequestHeader header = new RequestHeader();
            header.Contenttype = "application/json";
            header.request_id = requestId;
            header.client_ref_id = _config.client_ref_id;
            header.client_id = _config.client_id;
            Message ms = new Message();
            ms.timestamp = DataGenerator.GetCurrentUnixTimestampMillis().ToString();
            ms.aes_key = res = DataGenerator.GetUniqueKeyOriginal_BIASED(32);
            ms.message_value = ms.aes_key+"|"+ms.timestamp;
            ms.module = _config.public_key;
            ms.exponent =_config.exponent;

            RSAParameters result = new RSAParameters()
            {
                // If the following is working on your system:
                Modulus = Encoding.ASCII.GetBytes(ms.module),
                // And since it is not working on my environment:
                // Modulus = HexStringToByteArray("2300390628194771408193341387836525451597015696221789757208536408666375284454638593644682232941275886695496919815219303101886882336539607933936400106970078080774351758702967468432028807817634715669744462664061419557982409302217085934996440348778438619829029613247928036453961948727"),
                Exponent = DataGenerator.HexStringToByteArray(ms.exponent)
            };

            byte[] bytes = Encoding.ASCII.GetBytes(ms.message_value);

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportParameters(result);
                var encryptedData = RSA.Encrypt(bytes, false);
               // Console.WriteLine(encryptedData);
                header.message = Encoding.ASCII.GetString(encryptedData);
            }
           
            return header;

         }
        private Payload SetRawRequestBody(string aes)
        {
            RawRequestBody data = new RawRequestBody();
            data.client_secret = _config.client_secret;
            data.grant_type = _config.grant_type;
            data.passcode = _config.passcode;
            data.customer_identity = _config.customer_identity;  
            var pay = new Payload();
            pay.payload= JsonConvert.SerializeObject(data);
            pay.aes_key= aes;
            pay.iv = aes.Substring(0, 16);
   
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(pay.aes_key);
                aesAlg.IV = Encoding.UTF8.GetBytes(pay.iv);
                aesAlg.KeySize = 256;
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor();

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(pay.payload);
                        }
                        pay.data = System.Text.Encoding.UTF8.GetString(msEncrypt.ToArray());
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return pay;
        }
    }
}
