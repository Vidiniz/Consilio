using ConsilioServices.Domain.Enums;
using System;
using System.Text.RegularExpressions;

namespace ConsilioServices.Application.Validations
{
    public class UtilValidation
    {       
        public static PasswordPower GetPasswordPower(string password)
        {
            int score = GeneratePointsPassword(password);

            if (score < 50)
                return PasswordPower.MuitoFraca;
            else if (score < 60)
                return PasswordPower.Fraca;
            else if (score < 80)
                return PasswordPower.Aceitavel;
            else if (score < 100)
                return PasswordPower.Forte;
            else
                return PasswordPower.MuitoForte;
        }

        private static int GeneratePointsPassword(string password)
        {
            if (password == null) return 0;
            int pointsForLength = GetPointsForLength(password);
            int pointsForLowerCase = GetPointForLowerCase(password);
            int pointsForUpperCase = GetPointForUpperCase(password);
            int pointsForDigits = GetPointForDigits(password);
            int pointsForSymbols = GetPointForSymbols(password);
            int pointsForRepeat = GetPointForRepeat(password);
            return pointsForLength + pointsForLowerCase + pointsForUpperCase + pointsForDigits + pointsForSymbols - pointsForRepeat;
        }


        private static int GetPointsForLength(string password)
        {
            return Math.Min(10, password.Length) * 7;
        }

        private static int GetPointForLowerCase(string password)
        {
            int rawplacar = password.Length - Regex.Replace(password, "[a-z]", "").Length;
            return Math.Min(2, rawplacar) * 5;
        }

        private static int GetPointForUpperCase(string password)
        {
            int rawplacar = password.Length - Regex.Replace(password, "[A-Z]", "").Length;
            return Math.Min(2, rawplacar) * 5;
        }

        private static int GetPointForDigits(string password)
        {
            int rawplacar = password.Length - Regex.Replace(password, "[0-9]", "").Length;
            return Math.Min(2, rawplacar) * 6;
        }

        private static int GetPointForSymbols(string password)
        {
            int rawplacar = Regex.Replace(password, "[a-zA-Z0-9]", "").Length;
            return Math.Min(2, rawplacar) * 5;
        }

        private static int GetPointForRepeat(string password)
        {
            Regex regex = new Regex(@"(\w)*.*\1");
            bool repeat = regex.IsMatch(password);
            if (repeat)
                return 30;            
            else
                return 0;            
        }
        
    }
}
