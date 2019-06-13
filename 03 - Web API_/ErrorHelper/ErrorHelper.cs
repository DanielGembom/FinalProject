using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace FinalProject
{
    public static class ErrorHelper
    {
        public static ErrorModel GetError(ModelStateDictionary ms)
        {
            ErrorModel error = new ErrorModel();
            foreach (var v in ms.Values)
                foreach (var e in v.Errors)
                    error.AddError(e.ErrorMessage);
            return error;
        }

        public static ErrorModel GetError(Exception e)
        {
            ErrorModel error = new ErrorModel();
            error.AddError(
#if DEBUG
                GetMessage(e)
#else
                "Oops... it looks we have some problems in our system. Please tell us, so we can solve it as soon as possible."
#endif
                );
            return error;
        }

        private static string GetMessage(Exception e)
        {
            if (e.InnerException == null)
                return e.Message;
            return GetMessage(e.InnerException);
        }
    }
}
