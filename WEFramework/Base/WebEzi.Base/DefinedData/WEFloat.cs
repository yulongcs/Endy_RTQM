using System;
using WebEzi.Base.Exception;


namespace WebEzi.Base.DefinedData
{
    public struct WEFloat : IComparable<WEFloat>
    {
        private readonly decimal? number;

        public WEFloat(decimal? value)
        {
            this.number = value;
        }

        #region Implicit Operator WebEziFloat

        public static implicit operator WEFloat(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return new WEFloat(null);
            }
            else
            {
                decimal tempNumber;

                if (decimal.TryParse(value, out tempNumber))
                {
                    return new WEFloat(tempNumber);
                }
                else
                {
                    throw new DefinedDataException("The source value is " + value);
                }
            }
        }

        public static implicit operator WEFloat(decimal? value)
        {
            return new WEFloat(value);
        }

        public static implicit operator WEFloat(double? value)
        {
            if(value.HasValue)
            {
                decimal tempNumber;
                if(decimal.TryParse(value.ToString(), out tempNumber))
                {
                    return new WEFloat(tempNumber);
                }
                else
                {
                    throw new DefinedDataException("The number is " + value + ", can't convert to decimal.");
                }
            }
            else
            {
                return  new WEFloat(null);
            }
        }

        public static implicit operator WEFloat(float? value)
        {
            if (value.HasValue)
            {
                decimal tempNumber;
                if (decimal.TryParse(value.ToString(), out tempNumber))
                {
                    return new WEFloat(tempNumber);
                }
                else
                {
                    throw new DefinedDataException("The number is " + value + ", can't convert to decimal.");
                }
            }
            else
            {
                return new WEFloat(null);
            }
        }

        #endregion

        #region Implicit Operator Other

        public static implicit operator string(WEFloat value)
        {
            return value.number.ToString();
        }

        public static implicit operator decimal(WEFloat value)
        {
            if (!value.number.HasValue)
            {
                return 0;
            }

            return value.number.Value;
        }

        public static implicit operator decimal?(WEFloat value)
        {
            return value.number;
        }

        public static implicit operator double(WEFloat value)
        {
            if (value.number.HasValue)
            {
                double tempValue;
                if (double.TryParse(value.number.Value.ToString(), out tempValue))
                {
                    return tempValue;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.number.Value + ",can't convert to double.");
                }
            }
            else
            {
                return 0;
            }
        }

        public static implicit operator double?(WEFloat value)
        {
            if (value.number.HasValue)
            {
                double tempValue;
                if (double.TryParse(value.number.Value.ToString(), out tempValue))
                {
                    return tempValue;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.number.Value + ",can't convert to double.");
                }
            }
            else
            {
                return null;
            }
        }

        public static implicit operator float(WEFloat value)
        {
            if (value.number.HasValue)
            {
                float tempValue;
                if (float.TryParse(value.number.Value.ToString(), out tempValue))
                {
                    return tempValue;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.number.Value + ",can't convert to float.");
                }
            }
            else
            {
                return 0;
            }
        }

        public static implicit operator float?(WEFloat value)
        {
            if (value.number.HasValue)
            {
                float tempValue;
                if (float.TryParse(value.number.Value.ToString(), out tempValue))
                {
                    return tempValue;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.number.Value + ",can't convert to float.");
                }
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Implicit Operator

        public static bool operator ==(WEFloat x, WEFloat y)
        {
            return x.number == y.number;
        }

        public static bool operator !=(WEFloat x, WEFloat y)
        {
            return x.number != y.number;
        }

        public static bool operator <(WEFloat x, WEFloat y)
        {
            return x.number < y.number;
        }

        public static bool operator >(WEFloat x, WEFloat y)
        {
            return x.number > y.number;
        }

        public static bool operator <= (WEFloat x, WEFloat y)
        {
            return x.number <= y.number;
        }

        public static bool operator >= (WEFloat x, WEFloat y)
        {
            return x.number >= y.number;
        }

        #endregion

        public override string ToString()
        {
            return number.ToString();
        }

        /// <summary>
        /// Return the value is null
        /// </summary>
        /// <returns>The value is null</returns>
        public bool IsNull()
        {
            return !number.HasValue;
        }

        #region IComparable<WebEziFloat> Members

        public int CompareTo(WEFloat other)
        {
            if (number.HasValue)
            {
                return number.Value.CompareTo(other.number);
            }
            else if (!other.number.HasValue)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        #endregion

        public bool Equals(WEFloat obj)
        {
            return obj.number.Equals(number);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (WEFloat)) return false;
            return Equals((WEFloat) obj);
        }

        public override int GetHashCode()
        {
            return (number.HasValue ? number.Value.GetHashCode() : 0);
        }
    }
}
