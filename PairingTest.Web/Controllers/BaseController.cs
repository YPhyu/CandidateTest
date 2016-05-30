using System.Web.Mvc;
using System.Linq;
using PairingTest.Helpers;

namespace PairingTest.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public BetterJsonResult<T> BetterJson<T>(T model)
        {
            return new BetterJsonResult<T>() { Data = model };
        }

        protected BetterJsonResult JsonValidationError()
        {
            var result = new BetterJsonResult();

            foreach (var validationError in ModelState.Values.SelectMany(v => v.Errors))
            {
                result.AddError(validationError.ErrorMessage);
            }
            return result;
        }

        protected BetterJsonResult JsonError(string errorMessage)
        {
            var result = new BetterJsonResult();

            result.AddError(errorMessage);

            return result;
        }
    }
}