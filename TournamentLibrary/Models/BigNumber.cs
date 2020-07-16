using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TournamentLibrary.Models
{
    public struct BigNumber : IComparable<BigNumber>
    {
        public float Amount 
        { 
            get { return _amount; }
            set { _amount = value; }
        }
        public int Discharge 
        { 
            get { return _discharge; }
            set 
            {
                if (_discharge < 0) 
                    throw new ArgumentOutOfRangeException("Discharge should be greater than 0!");
                _discharge = value; 
            }
        }

        public static BigNumber Zero = new BigNumber(0, 0);
        public static BigNumber One = new BigNumber(1, 0);

        private float _amount;
        private int _discharge;
        private static Dictionary<int, string> dischargeNames = new Dictionary<int, string>()
        {
            { 0, ""},
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
            if (discharge < 0)
            {
                throw new ArgumentOutOfRangeException("Discharge cannot be lower than 0!");
            }
            while (Math.Abs(amount) >= 1000)
            {
                amount /= 1000f;
                discharge++;
            }
            while (discharge > 1 && amount < 1f)
            {
                amount *= 1000f;
                discharge--;
            }
            _amount = amount;
            _discharge = discharge;
        }
        public BigNumber(BigNumber score)
        {
            score = MinifyDischarge(score);
            _amount = score.Amount;
            _discharge = score.Discharge;
        }
        public BigNumber(int i)
        {
            var score = new BigNumber(i, 0);
            score = MinifyDischarge(score);
            _amount = score.Amount;
            _discharge = score.Discharge;
        }
        public BigNumber(float f)
        {
            var score = new BigNumber(f, 0);
            score = MinifyDischarge(score);
            _amount = score.Amount;
            _discharge = score.Discharge;
        }

        public override string ToString()
        {
            return $"({ Amount } { DigitToLetter(Discharge) })";
        }

        public override bool Equals(object obj)
        {
            if (obj is BigNumber bigNumber)
            {
                return Discharge == bigNumber.Discharge && Amount == bigNumber.Amount;
            }
            else if (obj is int i)
            {
                var newBigNum = new BigNumber(i);
                return (newBigNum.Discharge == Discharge && newBigNum.Amount == Amount);
            }
            else if (obj is float f)
            {
                var newBigNum = new BigNumber(f);
                return (newBigNum.Discharge == Discharge && newBigNum.Amount == Amount);
            }
            return false;
        }

        public static bool operator <=(BigNumber a, BigNumber b)
        {
            return a.CompareTo(b) > 0 == false;
        }
        public static bool operator >=(BigNumber a, BigNumber b)
        {
            return a.CompareTo(b) < 0 == false;
        }
        public static bool operator <(BigNumber a, BigNumber b)
        {
            return a.CompareTo(b) < 0;
        }
        public static bool operator >(BigNumber a, BigNumber b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator ==(BigNumber a, BigNumber b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(BigNumber a, BigNumber b)
        {
            return a.Equals(b) == false;
        }
        public static BigNumber operator -(BigNumber first)
        {
            return new BigNumber(first.Amount - 1, first.Discharge);
        }
        public static BigNumber operator +(BigNumber first)
        {
            return new BigNumber(first.Amount + 1, first.Discharge);
        }
        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            MakeSameDischarge(ref a, ref b);
            var x = new BigNumber(a.Amount + b.Amount, a.Discharge);
            return MinifyDischarge(x);
        }
        public static BigNumber operator +(BigNumber a, float b)
        {
            var second = new BigNumber(b);
            MakeSameDischarge(ref a, ref second);
            var x = new BigNumber(a.Amount + second.Amount, a.Discharge);
            return MinifyDischarge(x);
        }
        public static BigNumber operator +(BigNumber a, int b)
        {
            var second = new BigNumber(b);
            MakeSameDischarge(ref a, ref second);
            var x = new BigNumber(a.Amount + second.Amount, a.Discharge);
            return MinifyDischarge(x);
        }
        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            MakeSameDischarge(ref a, ref b);
            var x = new BigNumber(a.Amount - b.Amount, a.Discharge);
            return MinifyDischarge(x);
        }
        public static BigNumber operator -(BigNumber a, float b)
        {
            var second = new BigNumber(b);
            MakeSameDischarge(ref a, ref second);
            var x = new BigNumber(a.Amount - second.Amount, a.Discharge);
            return MinifyDischarge(x);
        }
        public static BigNumber operator -(BigNumber a, int b)
        {
            var second = new BigNumber(b);
            MakeSameDischarge(ref a, ref second);
            var x = new BigNumber(a.Amount - second.Amount, a.Discharge);
            return MinifyDischarge(x);
        }
        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            MakeSameDischarge(ref a, ref b);
            var x = new BigNumber(a.Amount * b.Amount, a.Discharge + a.Discharge);
            return MinifyDischarge(x);
        }
        public static BigNumber operator *(BigNumber a, float b)
        {
            var second = new BigNumber(b);
            MakeSameDischarge(ref a, ref second);
            var x = new BigNumber(a.Amount * second.Amount, a.Discharge + second.Discharge);
            return MinifyDischarge(x);
        }
        public static BigNumber operator *(BigNumber a, int b)
        {
            var second = new BigNumber(b);
            MakeSameDischarge(ref a, ref second);
            var x = new BigNumber(a.Amount * second.Amount, a.Discharge + second.Discharge);
            return MinifyDischarge(x);
        }
        public static BigNumber operator /(BigNumber a, BigNumber b)
        {
            MakeSameDischarge(ref a, ref b);
            var x = new BigNumber(a.Amount / b.Amount, a.Discharge - b.Discharge);
            return MinifyDischarge(x);
        }
        public static BigNumber operator /(BigNumber a, float b)
        {
            var second = new BigNumber(b);
            MakeSameDischarge(ref a, ref second);
            var x = new BigNumber(a.Amount / second.Amount, a.Discharge - second.Discharge);
            return MinifyDischarge(x);
        }
        public static BigNumber operator /(BigNumber a, int b)
        {
            var second = new BigNumber(b);
            MakeSameDischarge(ref a, ref second);
            var x = new BigNumber(a.Amount / second.Amount, a.Discharge - second.Discharge);
            return MinifyDischarge(x);
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode() + Discharge.GetHashCode();
        }
        public int CompareTo(BigNumber other)
        {
            if (Discharge == other.Discharge)
            {
                if (Amount > other.Amount)
                    return 1;
                else if (Amount < other.Amount)
                    return -1;
                else return 0;
            }
            else if (Discharge > other.Discharge)
                return 1;
            else
                return -1;
        }


        public static BigNumber MinifyDischarge(BigNumber newScore)
        {
            if (newScore.Discharge >= 0)
            {
                while (Math.Abs(newScore.Amount) >= 1000)
                {
                    newScore.Amount /= 1000;
                    newScore.Discharge += 1;
                }
                while (Math.Abs(newScore.Amount) < 1 && newScore.Discharge > 0)
                {
                    newScore.Amount *= 1000;
                    newScore.Discharge -= 1;
                }

            }
            else
            {
                throw new ArgumentOutOfRangeException("Discharge cannot be lower than 0!");
            }
            return newScore;
        }

        public static implicit operator BigNumber(float f)
        {
            BigNumber newScore = new BigNumber(f, 0);
            return MinifyDischarge(newScore);
        }
        public static implicit operator BigNumber(int i)
        {
            BigNumber newScore = new BigNumber(i, 0);
            return MinifyDischarge(newScore);
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
            if (digitName.Length > 2) return $"{digitName[0]}{digitName[1]}";
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

    }
}
