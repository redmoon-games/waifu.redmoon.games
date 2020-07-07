using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TournamentLibrary.Models
{
    public struct BigNumber : IEquatable<BigNumber>, IComparable<BigNumber>
    {
        public float Amount { get { return _amount; } }
        public int Discharge { get { return _discharge; } }

        public static BigNumber Zero = new BigNumber(0, 0);
        public static BigNumber One = new BigNumber(1, 0);

        private float _amount;
        private int _discharge;
        private static Dictionary<int, string> dischargeNames = new Dictionary<int, string>()
        {
            { 1, "Thousand"},
            { 2, "Million"},
            { 3, "Billion"},
            { 4, "Trillion"},
            { 5, "Quadrillion"},
            { 6, "Quintillion"},
            { 7, "Sextillion"},
            { 8, "Septillion"},
            { 9, "Octillion"},
            { 10, "Nonillion"},
            { 11, "Decillion"},
            { 12, "Undecillion"},
            { 13, "Duodecillion"},
            { 14, "Tredecillion"},
            { 15, "Quatttuor-decillion"},
            { 16, "Quindecillion"},
            { 17, "Sexdecillion"},
            { 18, "Septen-decillion"},
            { 19, "Octodecillion"},
            { 20, "Novemdecillion"},
            { 21, "Vigintillion"},
            { 22, "Centillion"},
            { 23, "MAX"},
        };

        public BigNumber(float amount, int discharge)
        {
            _amount = amount;
            _discharge = discharge;
        }
        public BigNumber(BigNumber score)
        {
            _amount = score.Amount;
            _discharge = score.Discharge;
        }

        public override string ToString()
        {
            string beautyAmount = _amount.ToString("N", CultureInfo.InvariantCulture);
            string dischargeName = DigitToLetter(_discharge);
            return $"({ beautyAmount } { dischargeName })";
        }

        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            MakeSameDischarge(ref a, ref b);
            BigNumber newScore = new BigNumber(a.Amount + b.Amount, a.Discharge);
            return ConverToMaxDischarge(newScore);
        }
        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            MakeSameDischarge(ref a, ref b);
            BigNumber newScore = new BigNumber(a.Amount - b.Amount, a.Discharge);
            return ConverToMaxDischarge(newScore);
        }
        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            MakeSameDischarge(ref a, ref b);
            BigNumber newScore = new BigNumber(a.Amount * b.Amount, a.Discharge);
            return ConverToMaxDischarge(newScore);
        }
        public static BigNumber operator *(BigNumber a, float b)
        {
            BigNumber newScore = new BigNumber(a.Amount * b, a.Discharge);
            return ConverToMaxDischarge(newScore);
        }
        public static BigNumber operator *(BigNumber a, int b)
        {
            BigNumber newScore = new BigNumber(a.Amount * b, a.Discharge);
            return ConverToMaxDischarge(newScore);
        }
        public static BigNumber operator /(BigNumber a, float b)
        {
            BigNumber newScore = new BigNumber(a.Amount / b, a.Discharge);
            return ConverToMaxDischarge(newScore);
        }

        public static bool operator ==(BigNumber a, BigNumber b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(BigNumber a, BigNumber b)
        {
            return !a.Equals(b);
        }
        public static bool operator >(BigNumber a, BigNumber b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator <(BigNumber a, BigNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        public static BigNumber ConverToMaxDischarge(BigNumber newScore)
        {
            while (Math.Abs(newScore.Amount) >= 1000)
                newScore = new BigNumber(newScore.Amount / 1000, newScore.Discharge + 1);
            return newScore;
        }
        public static BigNumber ConverToMaxDischarge(float score)
        {
            BigNumber newScore = new BigNumber(score, 0);
            while (Math.Abs(newScore.Amount) >= 1000)
                newScore = new BigNumber(newScore.Amount / 1000, newScore.Discharge + 1);
            return newScore;
        }
        public static BigNumber ConverToMaxDischarge(int score)
        {
            BigNumber newScore = new BigNumber(score, 0);
            while (Math.Abs(newScore.Amount) >= 1000)
                newScore = new BigNumber(newScore.Amount / 1000, newScore.Discharge + 1);
            return newScore;
        }

        private static void MakeSameDischarge(ref BigNumber a, ref BigNumber b)
        {
            if (b.Discharge >= a.Discharge)
                a = ChangeToDigit(a, b.Discharge);
            else
                b = ChangeToDigit(b, a.Discharge);
        }

        private static string DigitToLetter(int digit)
        {
            const int KNOWN_DIGITS = 23;
            const int ASCII_FIRST_LETTERS = 65 - 1;
            string digitName;
            if (digit > KNOWN_DIGITS)
            {
                int letterNum = digit + (ASCII_FIRST_LETTERS - KNOWN_DIGITS);
                digitName = ((char)letterNum).ToString().ToLower();
                digitName += digitName;
            }
            else
                dischargeNames.TryGetValue(digit, out digitName);
            return digitName;
        }

        private static BigNumber ChangeToDigit(BigNumber score, int newDigit)
        {
            const int THOUSAND_DIGIT = 3; //1000
            int oldDigit = score.Discharge;
            float oldAmount = score.Amount;

            double difference = Math.Pow(10, (oldDigit - newDigit) * THOUSAND_DIGIT);
            float newAmount = (float)(oldAmount * difference);
            return new BigNumber() { _amount = newAmount, _discharge = newDigit };
        }

        public bool Equals(BigNumber other)
        {
            return Amount != other.Amount || Discharge != other.Discharge;
        }

        public int CompareTo(BigNumber other)
        {
            if (Discharge > other.Discharge ||
                (Discharge == other.Discharge && Amount > other.Amount))
            {
                return 1;
            }
            else if (Discharge == other.Discharge && Amount == other.Amount)
            {
                return 0;
            }
            else 
                return -1;
        }
    }
}
