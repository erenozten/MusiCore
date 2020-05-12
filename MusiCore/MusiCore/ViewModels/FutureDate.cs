using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCore.ViewModels
{
    public class FutureDate: ValidationAttribute
    {
        public override bool IsValid(object arrivedDateOfDateTime)
        {
            DateTime newDateOfDateTime;

            var isValid = DateTime.TryParseExact(Convert.ToString(arrivedDateOfDateTime),
                "D MMM YYYY", 
                CultureInfo.CurrentCulture, 
                DateTimeStyles.None,
                out newDateOfDateTime);

            return (isValid && newDateOfDateTime > DateTime.Now);

        }
    }
}
