using SMS.SMSService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS
{
    public class QuickSMS
    {
        public static string sendSMS(string number, string message)
        {
            var smsRequest = new QuickSMSResquest();
            smsRequest.Destination = number;
            smsRequest.loginId = "923143116197";
            smsRequest.loginPassword = "Pa$$w0rd";
            smsRequest.Mask = "HUSAINMOTOR";
            smsRequest.Message = message;
            smsRequest.ShortCodePrefered = "n";
            smsRequest.UniCode = "0";

            var client = new CorporateCBSClient("BasicHttpBinding_ICorporateCBS");
            return client.QuickSMS(smsRequest);
        }
    }
}
