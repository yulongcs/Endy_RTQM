using System;
using WebEzi.Base.Exception;


namespace WebEzi.Base.DefinedData
{
    [System.Serializable]
    public struct WEInteger : IComparable<WEInteger>
    {
        private readonly int? number;

        public WEInteger(int? value)
        {
            this.number = value;
        }

        #region Implicit Operator WebEziInteger

        public static implicit operator WEInteger(string value)
        {
            if(String.IsNullOrEmpty(value))
            {
                return new WEInteger(null);
            }
            else
            {
                int tempNumber;
                if(int.TryParse(value, out tempNumber))
                {
                    return new WEInteger(tempNumber);
                }
                else
                {
                    throw new DefinedDataException("The source value is" + value);
                }
            }
        }

        public static implicit operator WEInteger(int? value)
        {
            return new WEInteger(value);
        }

        public static implicit operator WEInteger(short? value)
        {
            return new WEInteger(value);
        }

        public static implicit operator WEInteger(byte? value)
        {
            return new WEInteger(value);
        }

        #endregion

        #region Implicit Operator Other

        public static implicit operator string(WEInteger value)
        {
            return value.number.ToString();
        }

        public static implicit operator int(WEInteger value)
        {
            if (value.number.HasValue)
            {
                int tempValue;
                if (int.TryParse(value.number.Value.ToString(), out tempValue))
                {
                    return tempValue;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.number.Value + ",can't convert to int.");
                }
            }
            else
            {
                return 0;
            }
        }

        public static implicit operator int?(WEInteger value)
        {
            return value.number;
        }

        public static implicit operator short(WEInteger value)
        {
            if (value.number.HasValue)
            {
                short tempValue;
                if(short.TryParse(value.number.Value.ToString(), out tempValue))
                {
                    return tempValue;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.number.Value + ",can't convert to short.");
                }
            }
            else
            {
                return 0;
            }
        }

        public static implicit operator short?(WEInteger value)
        {
            if(value.number.HasValue)
            {
                short tempValue;
                if (short.TryParse(value.number.Value.ToString(), out tempValue))
                {
                    return tempValue;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.number.Value + ",can't convert to short.");
                }
            }
            else
            {
                return null;
            }
        }

        public static implicit operator byte(WEInteger value)
        {
            if (value.number.HasValue)
            {
                byte tempValue;
                if (byte.TryParse(value.number.Value.ToString(), out tempValue))
                {
                    return tempValue;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.number.Value + ",can't convert to byte.");
                }
            }
            else
            {
                return 0;
            }
        }

        public static implicit operator byte?(WEInteger value)
        {
            if (value.number.HasValue)
            {
                byte tempValue;
                if (byte.TryParse(value.number.Value.ToString(), out tempValue))
                {
                    return tempValue;
                }
                else
                {
                    throw new DefinedDataException("The number is " + value.number.Value + ",can't convert to byte.");
                }
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Implicit Operator

        public static bool operator ==(WEInteger x, WEInteger y)
        {
            return x.number == y.number;
        }

        public static bool operator !=(WEInteger x, WEInteger y)
        {
            return x.number != y.number;
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

        #region IComparable<WebEziInteger> Members

        public int CompareTo(WEInteger other)
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

        public bool Equals(WEInteger obj)
        {
            return obj.number.Equals(number);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (WEInteger)) return false;
            return Equals((WEInteger) obj);
        }

        public override int GetHashCode()
        {
            return (number.HasValue ? number.Value : 0);
        }
    }
}
