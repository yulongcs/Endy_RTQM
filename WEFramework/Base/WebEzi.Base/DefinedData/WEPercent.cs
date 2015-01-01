using System;
using WebEzi.Base.Exception;


namespace WebEzi.Base.DefinedData
{
    public struct WEPercent : IComparable<WEPercent>
    {
        private readonly decimal? percent;

        public WEPercent(decimal? value)
        {
            this.percent = value;
        }

        #region Implicit Operator WebEziPercent

        public static implicit operator WEPercent(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return new WEPercent(null);
            }
            else
            {
                decimal tempPercent;

                if (decimal.TryParse(value, out tempPercent))
                {
                    return new WEPercent(tempPercent);
                }
                else
                {
                    throw new DefinedDataException("The source value is " + value);
                }
            }
        }

        public static implicit operator WEPercent(decimal? value)
        {
            return new WEPercent(value);
        }

        public static implicit operator WEPercent(double? value)
        {
            if(value.HasValue)
            {
                decimal tempPercent;
                if (decimal.TryParse(value.ToString(), out tempPercent))
                {
                    return new WEPercent(tempPercent);
                }
                else
                {
                    throw new DefinedDataException("The number is " + value + ", can't convert to decimal.");
                }
            }
            else
            {
                return  new WEPercent(null);
            }
        }

        public static implicit operator WEPercent(float? value)
        {
            if (value.HasValue)
            {
                decimal tempPercent;
                if (decimal.TryParse(value.ToString(), out tempPercent))
                {
                    return new WEPercent(tempPercent);
                }
                else
                {
                    throw new DefinedDataException("The number is " + value + ", can't convert to decimal.");
                }
            }
            else
            {
                return new WEPercent(null);
            }
        }

        #endregion

        #region Implicit Operator Other

        public static implicit operator string(WEPercent value)
        {
            return value.percent.ToString();
        }

        public static implicit operator decimal(WEPercent value)
        {
            if (!value.percent.HasValue)
            {
                throw new DefinedDataException("The money is null, can't convert to decmail.");
            }

            return value.percent.Value;
        }

        public static implicit operator decimal?(WEPercent value)
        {
            return value.percent;
        }

        public static implicit operator double(WEPercent value)
        {
            if (value.percent.HasValue)
            {
                double tempPercent;
                if (double.TryParse(value.percent.Value.ToString(), out tempPercent))
                {
                    return tempPercent;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.percent.Value + ",can't convert to double.");
                }
            }
            else
            {
                throw new DefinedDataException("The number is null,can't convert to double.");
            }
        }

        public static implicit operator double?(WEPercent value)
        {
            if (value.percent.HasValue)
            {
                double tempPercent;
                if (double.TryParse(value.percent.Value.ToString(), out tempPercent))
                {
                    return tempPercent;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.percent.Value + ",can't convert to double.");
                }
            }
            else
            {
                return null;
            }
        }

        public static implicit operator float(WEPercent value)
        {
            if (value.percent.HasValue)
            {
                float tempPercent;
                if (float.TryParse(value.percent.Value.ToString(), out tempPercent))
                {
                    return tempPercent;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.percent.Value + ",can't convert to float.");
                }
            }
            else
            {
                throw new DefinedDataException("The number is null,can't convert to byte.");
            }
        }

        public static implicit operator float?(WEPercent value)
        {
            if (value.percent.HasValue)
            {
                float tempPercent;
                if (float.TryParse(value.percent.Value.ToString(), out tempPercent))
                {
                    return tempPercent;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.percent.Value + ",can't convert to float.");
                }
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Implicit Operator

        public static bool operator ==(WEPercent x, WEPercent y)
        {
            return x.percent == y.percent;
        }

        public static bool operator !=(WEPercent x, WEPercent y)
        {
            return x.percent != y.percent;
        }

        #endregion

        public override string ToString()
        {
            return percent.ToString();
        }

        /// <summary>
        /// Return the value is null
        /// </summary>
        /// <returns>The value is null</returns>
        public bool IsNull()
        {
            return !percent.HasValue;
        }

        #region IComparable<WebEziPercent> Members

        public int CompareTo(WEPercent other)
        {
            if (percent.HasValue)
            {
                return percent.Value.CompareTo(other.percent);
            }
            else if (!other.percent.HasValue)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        #endregion

        public bool Equals(WEPercent obj)
        {
            return obj.percent.Equals(percent);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (WEPercent)) return false;
            return Equals((WEPercent) obj);
        }

        public override int GetHashCode()
        {
            return (percent.HasValue ? percent.Value.GetHashCode() : 0);
        }
    }
}
