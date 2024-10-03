using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace amartech.Services
{
    public class WhatsAppService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromWhatsAppNumber;
        private readonly string _toWhatsAppNumber;

        public WhatsAppService(string accountSid, string authToken, string fromWhatsAppNumber, string toWhatsAppNumber)
        {
            _accountSid = accountSid;
            _authToken = authToken;
            _fromWhatsAppNumber = fromWhatsAppNumber;
            _toWhatsAppNumber = toWhatsAppNumber;

            TwilioClient.Init(_accountSid, _authToken);
        }

        public async Task SendContactUsWhatsAppMessage(string message)
        {
            var messageOptions = new CreateMessageOptions(new PhoneNumber($"whatsapp:{_toWhatsAppNumber}"))
            {
                From = new PhoneNumber($"whatsapp:{_fromWhatsAppNumber}"),
                Body = message,
            };

            await MessageResource.CreateAsync(messageOptions);
        }

        public async Task SendPricingRequestWhatsAppMessageAsync(string message)
        {
            var messageOptions = new CreateMessageOptions(new PhoneNumber($"whatsapp:{_toWhatsAppNumber}"));
            messageOptions.From = new PhoneNumber($"whatsapp:{_fromWhatsAppNumber}");
            messageOptions.Body = message;

            var messageResource = await MessageResource.CreateAsync(messageOptions);
        }
    }
}
