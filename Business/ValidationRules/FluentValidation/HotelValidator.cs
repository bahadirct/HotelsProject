using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class HotelValidator : AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(p=>p.Stars).InclusiveBetween(0,5);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.Contact).NotEmpty();
           // RuleFor(p => p.Stars).NotEmpty();
            RuleFor(p => p.Name).Must(BeValidUtf8).WithMessage(Messages.StarsInvalid);
            RuleFor(p => p.Url).Must(BeValidUrl).WithMessage(Messages.UrlInvalid);
        }


        private bool BeValidUtf8(string arg)
        {
            for (int i = 0; i < arg.Length; i++)
            {
                var unicode = char.GetUnicodeCategory(arg, i);
                if (unicode == UnicodeCategory.OtherNotAssigned) return false;
            }
            return true;
        }

        string ValidUrlRegex = @"/(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:\/?#[\]@!\$&\'\(\)\*\+,;=.]+/";
        private bool BeValidUrl(string arg) {

            if (Regex.IsMatch(arg, ValidUrlRegex)) {
                return true;
            }else return false;
        }
    }
}
