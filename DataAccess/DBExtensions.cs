using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public static class DBExtensions
    {
        public static void AddParameters(this SqlCommand Command, object[] parms)
        {
            if (parms != null && parms.Length > 0)
            {
                for (int i = 0; i < parms.Length; i += 2)
                {
                    string name = parms[i].ToString();

                    if (parms[i + 1] is string && (string)parms[i + 1] == "")
                    {
                        parms[i + 1] = null;
                    }

                    object value = parms[i + 1] ?? DBNull.Value;
                    var dbParameter = Command.CreateParameter();
                    dbParameter.ParameterName = name;
                    dbParameter.Value = value;
                    Command.Parameters.Add(dbParameter);

                }

            }

        }
    }
}
