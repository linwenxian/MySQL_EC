﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace MySQL_EC
{
    public class ObjToJSON
    {
        public static string GetJSON(Object obj) {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            Stream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            stream.Position = 0;
            StreamReader streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }
        public static string DataTableToJsonWithJavaScriptSerializer(DataTable table) { 
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach(DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach(DataColumn col in table.Columns)
                    childRow.Add(col.ColumnName, row[col]);
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }
    }
}