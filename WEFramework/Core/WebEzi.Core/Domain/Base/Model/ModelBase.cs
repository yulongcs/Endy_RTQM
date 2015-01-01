using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using WebEzi.Core.Domain.DefinedAttribute;
using WebEzi.Base.Const;
using WebEzi.Core.Domain.Base.Application;
using WebEzi.Core.Exception.Domain;
using WebEzi.Base.DefinedData;
using WebEzi.Core.Domain.Base.Repository;

namespace WebEzi.Core.Domain.Base.Model
{
    /// <summary>
    /// The base of the model
    /// </summary>
    public abstract class ModelBase : IModel
    {
        public void CheckStructure()
        {
            var properties = this.GetType().GetProperties();
            foreach (var propertyInfo in properties)
            {
                var propertyAttributes =
                    propertyInfo.GetCustomAttributes(typeof (ModelPropertyCheckAttribute), false);
                try
                {
                    if (propertyAttributes.Length > 0 && !propertyInfo.PropertyType.IsSubclassOf(typeof(AggregateRootModelBase)))
                    {
                        // Check custom attribute
                        this.CheckCustomAttribute(propertyInfo);

                        if (propertyInfo.PropertyType.BaseType == typeof (ModelBase))
                        {
                            var propertyValue = propertyInfo.GetValue(this, null);
                            if (propertyValue != null)
                            {
                                (propertyValue as ModelBase).CheckStructure();
                            }
                        }
                        else
                        {
                            if (propertyInfo.PropertyType.GetInterface(typeof(IList).Name, true) != null)
                            {
                                var propertyValue = propertyInfo.GetValue(this, null);

                                var count = (int)propertyValue.GetType().GetProperty("Count").GetValue(propertyValue, null);
                                for (int i = 0; i < count; i++)
                                {
                                    var item = propertyValue.GetType()
                                                            .GetMethod("get_Item")
                                                            .Invoke(propertyValue, new object[] { i });

                                    var itemType = item.GetType();
                                    if (itemType.IsSubclassOf(typeof(ModelBase)) &&
                                        !itemType.IsSubclassOf(typeof(AggregateRootModelBase)))
                                    {
                                        ((ModelBase)item).CheckStructure();
                                    }
                                }
                            }
                        }
                    }
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException is StopUsingModelException)
                    {
                        // Do nonthing, beacuse some properties can't be get
                    }
                }
            }

            CheckModel();
        }

        protected abstract void CheckModel();

        #region Check Custom Attribute

        private void CheckCustomAttribute(PropertyInfo propertyInfo)
        {
            var propertyValue = propertyInfo.GetValue(this, null);

            string className = this.GetType().Name;
            string propertyName = propertyInfo.Name;
            var propertyAttributes =
            propertyInfo.GetCustomAttributes(typeof(ModelPropertyCheckAttribute), false);

            foreach (ModelPropertyCheckAttribute attribute in propertyAttributes)
            {
                this.CheckAllowNull(propertyInfo, propertyValue, attribute, propertyName, className);

                this.CheckMinValue(propertyInfo, propertyValue, attribute, propertyName, className);

                this.CheckMaxValue(propertyInfo, propertyValue, attribute, propertyName, className);

                this.CheckMaxLength(propertyInfo, propertyValue, attribute, propertyName, className);
            }
        }

        private void CheckAllowNull(PropertyInfo propertyInfo, object value,
                                              ModelPropertyCheckAttribute attribute, string propertyName, string className)
        {
            var propertyType = propertyInfo.PropertyType;

            bool isNeedCheck = !attribute.AllowNull;

            if (isNeedCheck)
            {
                if (value == null)
                {
                    throw new ModelException(
                        string.Format("{0} of {1} required.", propertyName, className));
                }

                if (propertyType == typeof(String))
                {
                    if (string.IsNullOrEmpty(value.ToString()))
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} required.", propertyName, className));
                    }
                }
                else if (propertyType.IsEnum)
                {
                    if (ConstFactory.ConvertToString(value) == string.Empty)
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} required.", propertyName, className));
                    }
                }
                else if (propertyType == typeof(Boolean))
                {
                    if (string.IsNullOrEmpty(value.ToString()))
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} required.", propertyName, className));
                    }
                }
                else if (propertyType == typeof(WEDateTime))
                {
                    if (((WEDateTime)value).IsNull())
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} required.", propertyName, className));
                    }
                }
                else if (propertyType == typeof(WEKey))
                {
                    if (((WEKey)value).IsNull())
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} required.", propertyName, className));
                    }
                }
                else if (propertyType == typeof(WEFloat))
                {
                    if (((WEFloat)value).IsNull())
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} required.", propertyName, className));
                    }
                }
                else if (propertyType == typeof(WEInteger))
                {
                    if (((WEInteger)value).IsNull())
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} required.", propertyName, className));
                    }
                }
                else if (propertyType == typeof(WEMoney))
                {
                    if (((WEMoney)value).IsNull())
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} required.", propertyName, className));
                    }
                }
                else if (propertyType == typeof(WEPercent))
                {
                    if (((WEPercent)value).IsNull())
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} required.", propertyName, className));
                    }
                }
                else if (propertyInfo.PropertyType.GetInterface(typeof(IList).Name, true) != null)
                {
                    var count = (int)value.GetType().GetProperty("Count").GetValue(value, null);
                    if (count == 0)
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} required.", propertyName, className));
                    }
                }
                else if (propertyType.IsSubclassOf(typeof(ModelBase)))
                {
                    if (value == null)
                    {
                        throw new ModelException(
                           string.Format("{0} of {1} required.", propertyName, className));
                    }
                }
                else
                {
                    throw new System.Exception("Don't find corresponding data type. Current data type is " +
                                               propertyInfo.Name);
                }
            }
        }

        private void CheckMinValue(PropertyInfo propertyInfo, object value,
                                              ModelPropertyCheckAttribute attribute, string propertyName, string className)
        {
            var propertyType = propertyInfo.PropertyType;

            object obj = attribute.MinValue;

            if (obj != null)
            {
                if (value == null)
                {
                    throw new ModelException(
                        string.Format("{0} of {1} required.", propertyName, className));
                }

                if (propertyType == typeof(WEInteger))
                {
                    if (int.Parse(value.ToString()) < int.Parse(obj.ToString()))
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} smaller than min value.", propertyName, className));
                    }
                }
                else if (propertyType == typeof(WEFloat))
                {
                    if (float.Parse(value.ToString()) < float.Parse(obj.ToString()))
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} smaller than min value.", propertyName, className));
                    }
                }
                else if (propertyType == typeof(WEMoney))
                {
                    if (decimal.Parse(value.ToString()) < decimal.Parse(obj.ToString()))
                    {
                        throw new ModelException(
                        string.Format("{0} of {1} smaller than min value.", propertyName, className));
                    }
                }
                else
                {
                    throw new System.Exception("Don't find corresponding data type. Current data type is " +
                                        propertyInfo.Name);
                }
            }

        }

        private void CheckMaxValue(PropertyInfo propertyInfo, object value,
                                              ModelPropertyCheckAttribute attribute, string propertyName, string className)
        {
            var propertyType = propertyInfo.PropertyType;

            object obj = attribute.MaxValue;

            if (obj != null)
            {
                if (value == null)
                {
                    throw new ModelException(
                        string.Format("{0} of {1} required.", propertyName, className));
                }

                if (propertyType == typeof(WEInteger))
                {
                    if (int.Parse(value.ToString()) > int.Parse(obj.ToString()))
                    {
                        throw new ModelException(
                        string.Format("{0} of {1} bigger than max value.", propertyName, className));
                    }
                }
                else if (propertyType == typeof(WEFloat))
                {
                    if (float.Parse(value.ToString()) > float.Parse(obj.ToString()))
                    {
                        throw new ModelException(
                        string.Format("{0} of {1} bigger than max value.", propertyName, className));
                    }
                }
                else if (propertyType == typeof(WEMoney))
                {
                    if (decimal.Parse(value.ToString()) > decimal.Parse(obj.ToString()))
                    {
                        throw new ModelException(
                        string.Format("{0} of {1} bigger than max value.", propertyName, className));
                    }
                }
                else
                {
                    throw new System.Exception("Don't find corresponding data type. Current data type is " +
                                        propertyInfo.Name);
                }
            }

        }

        private void CheckMaxLength(PropertyInfo propertyInfo, object value,
                                              ModelPropertyCheckAttribute attribute, string propertyName, string className)
        {
            var propertyType = propertyInfo.PropertyType;

            int length = attribute.MaxLength;

            if (length > 0)
            {
                if (value == null)
                {
                    throw new ModelException(
                        string.Format("{0} of {1} required.", propertyName, className));
                }

                if (propertyType == typeof(String))
                {
                    if ((value.ToString()).Length > length)
                    {
                        throw new ModelException(
                            string.Format("{0} of {1} beyond the maximum length.", propertyName, className));
                    }
                }
                else
                {
                    throw new System.Exception("Don't find corresponding data type. Current data type is " +
                                               propertyInfo.Name);
                }
            }
        }

        #endregion

        #region Build Domain

        protected T BuildApplication<T>() where T : IApplication
        {
            return DomainFactory.GetInstance().GetApplication<T>();
        }

        #endregion
    }
}
