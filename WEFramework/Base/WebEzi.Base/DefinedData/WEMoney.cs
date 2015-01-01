using System;
using WebEzi.Base.Exception;


namespace WebEzi.Base.DefinedData
{
    [Serializable]
    public struct WEMoney : IComparable<WEMoney>
    {
        private readonly decimal? money;

        public WEMoney(decimal? value)
        {
            this.money = value;
        }

        #region Implicit Operator WebEziMoney

        public static implicit operator WEMoney(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return new WEMoney(null);
            }
            else
            {
                decimal money;

                string newMoney = value.Replace("$", string.Empty);
                
                if (newMoney.Equals("NaN.00"))
                {
                    throw new DefinedDataException("The $NaN.00 which you input is invalid.", null);
                }
                if (decimal.TryParse(newMoney, out money))
                {
                    return new WEMoney(money);
                }
                else
                {
                    throw new DefinedDataException("The source value is " + value);
                }
            }
        }

        public static implicit operator WEMoney(decimal? value)
        {
            return new WEMoney(value);
        }

        #endregion

        #region Implicit Operator Other

        public static implicit operator string(WEMoney value)
        {
            if(value.money.HasValue)
            {
                return value.money.Value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static implicit operator decimal(WEMoney value)
        {
            if (!value.money.HasValue)
            {
                return 0;
            }

            return value.money.Value;
        }

        public static implicit operator decimal?(WEMoney value)
        {
            return value.money;
        }

        #endregion

        #region Implicit Operator

        public static decimal operator +(WEMoney x, WEMoney y)
        {
            decimal newX = 0;
            decimal newY = 0;
            if(!x.IsNull())
            {
                newX = x.money.Value;
            }
            if(!y.IsNull())
            {
                newY = y.money.Value;
            }

            return newX + newY;
        }

        public static decimal operator -(WEMoney x, WEMoney y)
        {
            decimal newX = 0;
            decimal newY = 0;
            if (!x.IsNull())
            {
                newX = x.money.Value;
            }
            if (!y.IsNull())
            {
                newY = y.money.Value;
            }

            return newX - newY;
        }

        public static decimal operator *(WEMoney x, WEMoney y)
        {
            decimal newX = 0;
            decimal newY = 0;
            if (!x.IsNull())
            {
                newX = x.money.Value;
            }
            if (!y.IsNull())
            {
                newY = y.money.Value;
            }

            return newX * newY;
        }

        public static decimal operator *(WEMoney x, int y)
        {
            decimal newX = 0;
            if (!x.IsNull())
            {
                newX = x.money.Value;
            }

            return newX * y;
        }

        public static decimal operator *(WEMoney x, double y)
        {
            decimal newX = 0;
            if (!x.IsNull())
            {
                newX = x.money.Value;
            }

            return newX * decimal.Parse(y.ToString());
        }
        public static decimal operator -(WEMoney x, double y)
        {
            decimal newX = 0;
            if (!x.IsNull())
            {
                newX = x.money.Value;
            }

            return newX - decimal.Parse(y.ToString());
        }
        public static decimal operator -(double x, WEMoney y)
        {
            decimal newY = 0;
            if (!y.IsNull())
            {
                newY = y.money.Value;
            }

            return decimal.Parse(x.ToString()) - newY;
        }

        public static decimal operator /(WEMoney x, WEMoney y)
        {
            decimal newX = 0;
            decimal newY = 0;
            if (!x.IsNull())
            {
                newX = x.money.Value;
            }
            if (!y.IsNull())
            {
                newY = y.money.Value;
            }

            return newX / newY;
        }

        public static bool operator ==(WEMoney x, WEMoney y)
        {
            return x.money == y.money;
        }

        public static bool operator !=(WEMoney x, WEMoney y)
        {
            return x.money != y.money;
        }

        public static bool operator ==(WEMoney x, int y)
        {
            return x.money == decimal.Parse(y.ToString());
        }

        public static bool operator !=(WEMoney x, int y)
        {
            return x.money != decimal.Parse(y.ToString());
        }

        public static bool operator ==(WEMoney x, double y)
        {
            return x.money == decimal.Parse(y.ToString());
        }

        public static bool operator !=(WEMoney x, double y)
        {
            return x.money != decimal.Parse(y.ToString());
        }

        public static bool operator >(WEMoney x, double y)
        {
            return x.money > decimal.Parse(y.ToString());
        }

        public static bool operator <(WEMoney x, double y)
        {
            return x.money < decimal.Parse(y.ToString());
        }

        #endregion

        /// <summary>
        /// Return the value is null
        /// </summary>
        /// <returns>The value is null</returns>
        public bool IsNull()
        {
            return !money.HasValue;
        }

        public override string ToString()
        {
            if(money.HasValue)
            {
                return money.Value.ToString("C");
            }
            else
            {
                return decimal.Parse("0").ToString("C");
            }
        }

        public string ToNoRoundingString()
        {
            if (money.HasValue)
            {
                var tmpValue = (Math.Truncate(money.Value*100)/100).ToString();
                return decimal.Parse(tmpValue).ToString("C");
            }
            else
            {
                return decimal.Parse("0").ToString("C");
            }
        }

        #region IComparable<WebEziMoney> Members

        public int CompareTo(WEMoney other)
        {
            if (money.HasValue)
            {
                return money.Value.CompareTo(other.money);
            }
            else if (!other.money.HasValue)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        #endregion

        public bool Equals(WEMoney obj)
        {
            return obj.money.Equals(money);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (WEMoney)) return false;
            return Equals((WEMoney) obj);
        }

        public override int GetHashCode()
        {
            return (money.HasValue ? money.Value.GetHashCode() : 0);
        }
    }
}
