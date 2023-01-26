using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Sid.bookStore.Helpers
{
    public class AppValidations:ValidationAttribute 
    {
        private IenmValidatorType ienmValidatorType { get; set; }
        int iintMinLen;
        int iintMaxLen;
        public AppValidations(IenmValidatorType aenmValidatorType,int minLen=-1,int maxLen =-1)
        {
            ienmValidatorType = aenmValidatorType;
            iintMaxLen= minLen;
            iintMinLen= maxLen;
        }
        public AppValidations()
        {
            ienmValidatorType = IenmValidatorType.Required;
            iintMaxLen = -1;
            iintMinLen = -1;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            switch (ienmValidatorType)
            {
                case IenmValidatorType.Length:
                   return LengthConstraints(value.ToString());
                case IenmValidatorType.Required:
                    if(value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        return new ValidationResult("The "+validationContext.DisplayName +" field is required.");
                    }
                    break;
            }
            return ValidationResult.Success;
        }
        private ValidationResult? LengthConstraints(string astrVal)
        {
            int lLen = astrVal.ToString().Length;
            if (iintMinLen != -1 && lLen < iintMinLen && iintMaxLen != -1 && lLen>iintMaxLen)
            {
                return new ValidationResult("Minmimum and Maximum length should be "+iintMinLen +" &"+iintMaxLen+".");
            }
            else if(iintMinLen != -1 && lLen < iintMinLen )
            {
                return new ValidationResult("Minmimum length should be " + iintMinLen + ".");
            }
            else if (iintMaxLen != -1 && lLen > iintMaxLen)
            {
                return new ValidationResult("Maximum length should be " +  iintMaxLen + ".");
            }
            return ValidationResult.Success;
        }
    }
    public enum IenmValidatorType
    {
        Length,
        Required,
    }
}

