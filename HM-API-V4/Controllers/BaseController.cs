using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HM_API_V4.Controllers
{
    public class BaseController : ApiController
    {
        public static string GetMessageFromExceptionObject(Exception ex)
        {
            String message = ex.Message;
            if (ex is DbEntityValidationException)
            {
                var errorMessages = ((DbEntityValidationException)ex).EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);
                return string.Concat(ex.Message, "<br />The validation errors are: ", fullErrorMessage);
            }
            message += (ex.InnerException != null) ? ("<br />" + ex.InnerException.Message) : "";
            message += (ex.InnerException != null && ex.InnerException.InnerException != null) ? ("<br />" + ex.InnerException.InnerException.Message) : "";
            return message;
        }

        public static void updateAllAccountBalance(HMEntities1 entities)
        {
            List<Account> acs = entities.Accounts.ToList<Account>();
            foreach (var ac in acs)
            {
                ac.Balance = ac.Transactions.Sum(x => x.Amount);
                entities.SaveChanges();
            }
            
        }
    }
}
