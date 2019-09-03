using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace PlotByCoordinate.ViewModels
{
    class InputRuleViewModel:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null && Regex.IsMatch(value.ToString(), @"^[+-]?\d*[.]?\d*$"))
            {
                return new ValidationResult(true,null);
            }
            return new ValidationResult(false,"无效输入");
        }
    }
}
