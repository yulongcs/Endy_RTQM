using System;
using WebEzi.Base.Exception;


namespace WebEzi.Base.DefinedData
{
    [Serializable]
    public struct WEKey : IComparable<WEKey>
    {
        private readonly string key;

        #region Defualt value
        public readonly static WEKey NullValue = new WEKey((string)null);
        public readonly static WEKey EmptyValue = new WEKey(string.Empty);
        #endregion

        #region Construction
   

        public WEKey(int? value)
        {
            this.key = value.HasValue ? value.ToString() : null;
        }

        public WEKey(long? value)
        {
            this.key = value.HasValue ? value.ToString() : null;
        }

        public WEKey(string value)
        {
            this.key = value;
        }
        #endregion

        #region IComparable<WebEziKey> Members

        public int CompareTo(WEKey other)
        {
            if (key != null)
            {
                return key.CompareTo(other.key);
            }
            else if (other.key == null)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        #endregion

        #region Implicit Operator WebEziKey

        public static implicit operator WEKey(string value)
        {
            return new WEKey(value);
        }

        public static implicit operator WEKey(long? value)
        {
            return new WEKey(value);
        }

        public static implicit operator WEKey(int? value)
        {
            return new WEKey(value);
        }

        #endregion

        #region Implicit Operator Other

        public static implicit operator string(WEKey value)
        {
            return value.key;
        }

        public static implicit operator long(WEKey value)
        {
            if (value.key != null)
            {
                long tempKey;
                if (long.TryParse(value, out tempKey))
                {
                    return tempKey;
                }
                else
                {
                    throw new DefinedDataException("Failed to parse key to long,The key value is " + value);
                }
            }
            else
            {
                throw new DefinedDataException("The key is null, can't convert to long.");
            }
        }

        public static implicit operator long?(WEKey value)
        {
            long tempValue = value;
            return tempValue;
        }

        public static implicit operator int(WEKey value)
        {
            if (value.key != null)
            {
                int tempKey;
                if (int.TryParse(value, out tempKey))
                {
                    return tempKey;
                }
                else
                {
                    throw new DefinedDataException("Failed to parse key to int,The key value is " + value);
                }
            }
            else
            {
                throw new DefinedDataException("The key is null, can't convert to int.");
            }
        }

        public static implicit operator int?(WEKey value)
        {
            int tempValue = value;
            return tempValue;
        }

        #endregion

        #region Implicit Operator

        public static bool operator ==(WEKey x, WEKey y)
        {
            return x.key == y.key;
        }

        public static bool operator !=(WEKey x, WEKey y)
        {
            return x.key != y.key;
        }

        #endregion

        public override string ToString()
        {
            return key;
        }

        /// <summary>
        /// Return the value is null
        /// </summary>
        /// <returns>The value is null</returns>
        public bool IsNull()
        {
            return key == null;
        }

        public bool IsEmpty()
        {
            return key == string.Empty;
        }

        public bool IsNullOrEmpty()
        {
            return IsNull() || IsEmpty();
        }

        public bool Equals(WEKey obj)
        {
            return obj.key.Equals(key);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (WEKey)) return false;
            return Equals((WEKey) obj);
        }

        public override int GetHashCode()
        {
            return (key!=null ? key.GetHashCode() : 0);
        }
    }
}
