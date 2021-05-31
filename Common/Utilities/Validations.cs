using System.Linq;
using System.Text.RegularExpressions;

namespace Common.Utilities
{
    public static class Validations
    {
        public static bool IsMobliePhoneNumberValid(string phoneNumber)
        {
            var isAllCharactersNumeric = IsAllCharactersNumeric(phoneNumber);
            var isValidPhoneNumber = (phoneNumber ?? "").StartsWith("09") && (phoneNumber?.Length ?? 0) == 11;
            return string.IsNullOrEmpty(phoneNumber) || (isAllCharactersNumeric && isValidPhoneNumber);
        }

        public static bool IsTelePhoneNumberValid(string phoneNumber)
        {
            var isAllCharactersNumeric = IsAllCharactersNumeric(phoneNumber);
            var isValidPhoneNumber = (phoneNumber ?? "").StartsWith("0") && (phoneNumber?.Length ?? 0) == 11;
            return string.IsNullOrEmpty(phoneNumber) || (isAllCharactersNumeric && isValidPhoneNumber);
        }

        public static bool IsBirthYearValid(int? year)
        {
            var isValid = Enumerable.Range(1320, 78).Contains(year.GetValueOrDefault());
            return isValid || year == null;
        }

        public static bool IsMonthValid(int? month)
        {
            var isValid = Enumerable.Range(1, 12).Contains(month.GetValueOrDefault());
            return (isValid || month == null);
        }

        public static bool IsCalendarDayValid(int? month, int? day)
        {
            if (!IsMonthValid(month) || day == null || month == null)
            {
                return true;
            }
            else if (Enumerable.Range(1, 6).Contains(month.GetValueOrDefault()))
            {
                return Enumerable.Range(1, 31).Contains(day.GetValueOrDefault());
            }
            else if (Enumerable.Range(7, 6).Contains(month.GetValueOrDefault()))
            {
                return Enumerable.Range(1, 30).Contains(day.GetValueOrDefault());
            }
            else
            {
                return false;
            }
        }

        public static bool IsPostalCodeValid(string postalCode)
        {
            return string.IsNullOrEmpty(postalCode) || postalCode.Length == 10;
        }

        public static bool IsAllCharactersPersian(string text)
        {
            var regex = new Regex("^[\u0622\u0627\u0628\u067E\u062A-\u062C\u0686\u062D-\u0632\u0698\u0633-\u063A\u0641\u0642\u06A9\u06AF\u0644-\u0648\u06CC ]+$");
            return string.IsNullOrEmpty(text) || regex.IsMatch(text);
        }

        public static bool IsAllCharactersPersianOrNumeric(string text)
        {
            var regex = new Regex("^[\u0622\u0627\u0628\u067E\u062A-\u062C\u0686\u062D-\u0632\u0698\u0633-\u063A\u0641\u0642\u06A9\u06AF\u0644-\u0648\u06CC0-9 ]+$");
            return string.IsNullOrEmpty(text) || regex.IsMatch(text);
        }

        public static bool IsAllCharactersNumeric(string text)
        {
            var regex = new Regex(@"^\d+$");
            return string.IsNullOrEmpty(text) || regex.IsMatch(text);
        }
    }
}