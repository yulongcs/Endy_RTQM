using System;
using WebEzi.Base.Exception;


namespace WebEzi.Base.DefinedData
{
    [Serializable]
    public struct WEDateTime : IComparable<WEDateTime>
    {
        private readonly DateTime? dateTime;

        public WEDateTime(DateTime? value)
        {
            dateTime = value;
        }

        #region Implicit Operator WebEziDateTime

        public static implicit operator WEDateTime(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return new WEDateTime(null);
            }
            else
            {
                DateTime dateTime;
                if (DateTime.TryParse(value, out dateTime))
                {
                    return new WEDateTime(DateTime.Parse(value));
                }
                else
                {
                    throw new DefinedDataException("The source value is " + value);
                }
            }
        }

        public static implicit operator WEDateTime(DateTime? value)
        {
            return new WEDateTime(value);
        }

        #endregion

        #region Implicit Operator Other

        public static implicit operator DateTime?(WEDateTime value)
        {
            return value.dateTime;
        }

        public static implicit operator DateTime(WEDateTime value)
        {
            if (!value.dateTime.HasValue)
            {
                throw new DefinedDataException("The datetime is null, can't convert to datetime.");
            }

            return value.dateTime.Value;
        }

        public static implicit operator string(WEDateTime value)
        {
            if (value.dateTime.HasValue)
            {
                return value.dateTime.Value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        #region Implicit Operator

        public static bool operator ==(WEDateTime x, WEDateTime y)
        {
            return x.dateTime == y.dateTime;
        }

        public static bool operator !=(WEDateTime x, WEDateTime y)
        {
            return x.dateTime != y.dateTime;
        }

        public static bool operator <(WEDateTime x, WEDateTime y)
        {
            return x.dateTime < y.dateTime;
        }

        public static bool operator >(WEDateTime x, WEDateTime y)
        {
            return x.dateTime > y.dateTime;
        }

        public static bool operator <=(WEDateTime x, WEDateTime y)
        {
            return x.dateTime <= y.dateTime;
        }

        public static bool operator >=(WEDateTime x, WEDateTime y)
        {
            return x.dateTime >= y.dateTime;
        }

        public static bool operator ==(WEDateTime x, DateTime y)
        {
            return x.dateTime == y;
        }

        public static bool operator !=(WEDateTime x, DateTime y)
        {
            return x.dateTime != y;
        }

        public static bool operator <(WEDateTime x, DateTime y)
        {
            return x.dateTime < y;
        }

        public static bool operator >(WEDateTime x, DateTime y)
        {
            return x.dateTime > y;
        }

        public static bool operator <=(WEDateTime x, DateTime y)
        {
            return x.dateTime <= y;
        }

        public static bool operator >=(WEDateTime x, DateTime y)
        {
            return x.dateTime >= y;
        }

        #endregion

        /// <summary>
        /// Return the value is null or empty
        /// </summary>
        /// <returns>The value is null or empty</returns>
        public bool IsNull()
        {
            return !dateTime.HasValue;
        }

        public override string ToString()
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public string ToString(string format)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToString(format);
            }
            else
            {
                return string.Empty;
            }
        }

        public string ToShortDateString()
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToShortDateString();
            }
            else
            {
                return string.Empty;
            }
        }

        public string ToShortTimeString()
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToShortTimeString();
            }
            else
            {
                return string.Empty;
            }
        }

        public string ToLongDateString()
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToLongDateString();
            }
            else
            {
                return string.Empty;
            }
        }

        public string ToLongTimeString()
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToLongTimeString();
            }
            else
            {
                return string.Empty;
            }
        }

        public DateTime ToDateTime()
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value;
            }
            else
            {
                return new DateTime();
            }
        }

        #region IComparable<WebEziDateTime> Members

        public int CompareTo(WEDateTime other)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.CompareTo(other.dateTime);
            }
            else if (!other.dateTime.HasValue)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        #endregion

        public bool Equals(WEDateTime obj)
        {
            return obj.dateTime.Equals(dateTime);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (WEDateTime)) return false;
            return Equals((WEDateTime) obj);
        }

        public override int GetHashCode()
        {
            return (dateTime.HasValue ? dateTime.Value.GetHashCode() : 0);
        }
    }
}
