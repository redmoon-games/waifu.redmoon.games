using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redmoon.WebClickerLib.Models
{
    public struct BigNumber : IComparable<BigNumber>
    {
        public float Amount { get { return _amount; } }
        public int Discharge
        {
            get
            {
                if (Amount < 0.000001)
                {
                    _discharge = 0;
                }
                return _discharge;
            }
        }

        private float _amount;
        private int _discharge;

        public BigNumber(float number, int digit)
        {
            _amount = number;
            _discharge = digit;
        }

        public override bool Equals(object obj)
        {
            if (obj is BigNumber bigNumber)
            {
                return Discharge == bigNumber.Discharge && Amount == bigNumber.Amount;
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
            return new BigNumber(a.Amount + b.Amount, a.Discharge);
        }
        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            MakeSameDischarge(ref a, ref b);
            return new BigNumber(a.Amount - b.Amount, a.Discharge);
        }
        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            MakeSameDischarge(ref a, ref b);
            return new BigNumber(a.Amount * b.Amount, a.Discharge);
        }
        public static BigNumber operator *(BigNumber a, float b)
        {
            return new BigNumber(a.Amount * b, a.Discharge);
        }
        public static BigNumber operator /(BigNumber a, BigNumber b)
        {
            MakeSameDischarge(ref a, ref b);
            return new BigNumber(a.Amount / b.Amount, a.Discharge);
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode() + Discharge.GetHashCode();
        }
        public override string ToString()
        {
            return $"{Amount} : {Discharge}";
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

        public static BigNumber ConverToMaxDischarge(BigNumber newScore)
        {
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
