using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Shrenky.SPQueryUtil
{
    public static class QueryHelper
    {
        public static string CheckAndRetunQueryWithFieldType(SPList list, string oldQuery)
        {
            string newQuery = oldQuery;
            XElement root = XElement.Parse(oldQuery);
            foreach (XElement ele in root.Descendants("Value"))
            {
                string fieldName = ele.Attribute("Type").Value;
                ele.SetAttributeValue("Type", GetValueType(list, fieldName));
            }

            newQuery = CleanString(root.ToString());
            return newQuery;
        }

        #region private

        private static string GetValueType(SPList list, string fieldName)
        {
            string valueType = "Text";
            SPField field = null;
            foreach (SPField f in list.Fields)
            {
                if (f.Title == fieldName || f.InternalName == fieldName)
                {
                    field = f;
                    break;
                }
            }

            if (field != null)
            {
                //http://www.cnblogs.com/li7125502/archive/2009/12/16/1625879.html
                switch (field.Type)
                { 
                    case SPFieldType.AllDayEvent:
                        valueType = SPFieldType.AllDayEvent.ToString();
                        break;
                    case SPFieldType.Attachments:
                        valueType = SPFieldType.Attachments.ToString();
                        break;
                    case SPFieldType.Boolean:
                        valueType = SPFieldType.Boolean.ToString();
                        break;
                    case SPFieldType.Calculated:
                        valueType = SPFieldType.Calculated.ToString();
                        break;
                    case SPFieldType.Choice:
                        valueType = SPFieldType.Choice.ToString();
                        break;
                    case SPFieldType.Computed:
                        valueType = SPFieldType.Computed.ToString();
                        break;
                    case SPFieldType.ContentTypeId:
                        valueType = SPFieldType.ContentTypeId.ToString();
                        break;
                    case SPFieldType.Counter:
                        valueType = SPFieldType.Counter.ToString();
                        break;
                    case SPFieldType.Currency:
                        valueType = SPFieldType.Currency.ToString();
                        break;
                    case SPFieldType.DateTime:
                        valueType = SPFieldType.DateTime.ToString();
                        break;
                    case SPFieldType.File:
                        valueType = SPFieldType.File.ToString();
                        break;
                    case SPFieldType.GridChoice:
                        valueType = SPFieldType.GridChoice.ToString();
                        break;
                    case SPFieldType.Guid:
                        valueType = SPFieldType.Guid.ToString();
                        break;
                    case SPFieldType.Integer:
                        valueType = SPFieldType.Integer.ToString();
                        break;
                    case SPFieldType.Lookup:
                        valueType = SPFieldType.Lookup.ToString();
                        break;
                    case SPFieldType.ModStat:
                        valueType = SPFieldType.ModStat.ToString();
                        break;
                    case SPFieldType.MultiChoice:
                        valueType = SPFieldType.MultiChoice.ToString();
                        break;
                    case SPFieldType.Note:
                        valueType = SPFieldType.Note.ToString();
                        break;
                    case SPFieldType.Number:
                        valueType = SPFieldType.Number.ToString();
                        break;
                    case SPFieldType.PageSeparator:
                        valueType = SPFieldType.PageSeparator.ToString();
                        break;
                    case SPFieldType.Recurrence:
                        valueType = SPFieldType.Recurrence.ToString();
                        break;
                    case SPFieldType.Text:
                        valueType = SPFieldType.Text.ToString();
                        break;
                    case SPFieldType.ThreadIndex:
                        valueType = SPFieldType.ThreadIndex.ToString();
                        break;
                    case SPFieldType.Threading:
                        valueType = SPFieldType.Threading.ToString();
                        break;
                    case SPFieldType.URL:
                        valueType = SPFieldType.URL.ToString();
                        break;
                    case SPFieldType.User:
                        valueType = SPFieldType.User.ToString();
                        break;
                    case SPFieldType.WorkflowEventType:
                        valueType = SPFieldType.WorkflowEventType.ToString();
                        break;
                    case SPFieldType.WorkflowStatus:
                        valueType = SPFieldType.WorkflowStatus.ToString();
                        break;

                    default:
                        valueType = "Text";
                        break;
                }
            }
            else
            {
                throw new ArgumentException(string.Format("field {0} does not exist", fieldName));
            }

            return valueType;
        }

        private static string CleanString(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                StringBuilder sb = new StringBuilder();
                string[] newStr = str.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < newStr.Length; i++)
                {
                    sb.Append(newStr[i].Trim());
                }
                return sb.ToString();
            }
            else
            {
                return null;
            }
        }

        #endregion
        

    }


}
