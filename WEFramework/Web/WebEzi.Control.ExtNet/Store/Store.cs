using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web.UI;
using WebEzi.Base.DefinedData;


namespace WebEzi.Control.ExtNet
{
    [ToolboxData("<{0}:Store runat=server></{0}:Store>")]
    public class Store : Ext.Net.Store
    {
        public void DataBind(DataView dataView)
        {
            if (dataView == null)
            {
                this.DataSource = new DataView();
            }
            else
            {
                this.DataSource = dataView;
            }
            
            this.DataBind();
        }

        public void DataBind<T>(IList<T> dataSource) 
        {
            if (dataSource.Count == 0)
            {
                this.DataSource = dataSource;
                this.DataBind();
            }
            else
            {
                this.DataSource = ConvertToDataTable(dataSource);
                this.DataBind();
            }
        }

        private DataTable ConvertToDataTable<T>(IList<T> dataSource) 
        {
            Type t = typeof(T);

            var dt = new DataTable();
            var ps = t.GetProperties();

            foreach (var p in ps)
            {
                if (p.PropertyType == typeof(Boolean))
                {
                    dt.Columns.Add(p.Name, typeof(Boolean));
                }
                else if (p.PropertyType == typeof(WEDateTime))
                {
                    dt.Columns.Add(p.Name, typeof(DateTime));
                }
                else
                {
                    dt.Columns.Add(p.Name);
                }
            }

            foreach (var item in dataSource)
            {
                DataRow dr = dt.NewRow();

                foreach (var p in ps)
                {
                    if (p.PropertyType == typeof(WEDateTime))
                    {
                        var obj = p.GetValue(item, null);

                        if (obj != null)
                        {
                            var dateTime = (WEDateTime)obj;

                            if (!dateTime.IsNull())
                            {
                                dr[p.Name] = (DateTime)dateTime;
                            }
                        }
                    }
                    else
                    {
                        dr[p.Name] = p.GetValue(item, null);
                    }
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
