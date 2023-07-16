using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class DataContext : IDataContext
    {
        #region Property
        public string ConnectionString { get; set; }
        #endregion



        #region Constructors

        public DataContext(string ConnectionStringName)
        {
            ConnectionString = ConnectionStringName;
        }


        #endregion

        /// <summary>
        /// CreateConnection
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection CreateConnection()
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// CreateCommand
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="sqlCoonection"></param>
        /// <returns>SqlCommand</returns>
        SqlCommand CreateCommand(CommandType commandType, string commandText, SqlConnection sqlCoonection, params object[] Parameters)
        {

            SqlCommand command = new SqlCommand();
            command.Connection = sqlCoonection;
            command.CommandType = commandType;
            command.CommandText = commandText;
            command.AddParameters(Parameters);


            return command;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int Insert(string commandText, params object[] parameters)
        {
            using (SqlConnection connection = CreateConnection())
            {
                commandText += ";SELECT SCOPE_IDENTITY()";
                using (SqlCommand command = CreateCommand(CommandType.Text, commandText, connection, parameters))
                {

                    int lastInsertedID = 0;
                    lastInsertedID = (int)command.ExecuteScalar();
                    return lastInsertedID;
                }
            }

        }
        /// <summary>
        /// //
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int Update(string commandText, params object[] parameters)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(CommandType.Text, commandText, connection, parameters))
                {
                    var last = command.ExecuteScalar();
                    Console.WriteLine(last);
                    int lastInsertedID = 0;
                    lastInsertedID = (int)command.ExecuteScalar();
                    return lastInsertedID;
                }
            }

        }

        public int Delete(string commandText, params object[] parameters)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(CommandType.Text, commandText, connection, parameters))
                {
                    var last = command.ExecuteScalar();
                    Console.WriteLine(last);
                    int lastInsertedID = 0;
                    lastInsertedID = (int)command.ExecuteScalar();
                    return lastInsertedID;
                }
            }

        }
        /// <summary>
        /// //
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataSet Get(CommandType commandType, string commandText, params object[] parameters)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(commandType, commandText, connection, parameters))
                {
                    using (SqlDataAdapter adpter = new SqlDataAdapter(command))
                    {
                        using (DataSet dataset = new DataSet())
                        {
                            adpter.Fill(dataset);
                            return dataset;
                        }

                    }
                }
            }

        }

        /// <summary>
        /// //
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public DataSet Get(CommandType commandType, string commandText)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(commandType, commandText, connection))
                {
                    using (SqlDataAdapter adpter = new SqlDataAdapter(command))
                    {
                        using (DataSet dataset = new DataSet())
                        {
                            adpter.Fill(dataset);
                            return dataset;
                        }

                    }
                }
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="projection"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<T> Read<T>(string commandText, Func<IDataReader, T> projection, params object[] parameters)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(CommandType.Text, commandText, connection, parameters))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            yield return projection(reader);
                        }


                    }
                }
            }

        }
        public IEnumerable<T> Read<T>(string commandText, Func<IDataReader, T> projection)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(CommandType.Text, commandText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return projection(reader);
                        }
                    }
                }
            }

        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> Read<T1, T2, T3>(string commandText, Func<IDataReader, T1> projection1, Func<IDataReader, T2> projection2, Func<IDataReader, T3> projection3)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(CommandType.Text, commandText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var result1 = ExecuteReader(projection1, reader).ToList();
                        var result2 = ExecuteReader(projection2, reader).ToList();
                        var result3 = ExecuteReader(projection3, reader).ToList();
                        return Tuple.Create<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(result1, result2, result3);
                    }
                }
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> Read<T1, T2, T3, T4>(string commandText, Func<IDataReader, T1> projection1, Func<IDataReader, T2> projection2, Func<IDataReader, T3> projection3, Func<IDataReader, T4> projection4)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(CommandType.Text, commandText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var result1 = ExecuteReader(projection1, reader).ToList();
                        var result2 = ExecuteReader(projection2, reader).ToList();
                        var result3 = ExecuteReader(projection3, reader).ToList();
                        var result4 = ExecuteReader(projection4, reader).ToList();
                        return Tuple.Create<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>(result1, result2, result3, result4);
                    }
                }
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>> Read<T1, T2, T3, T4, T5>(string commandText, Func<IDataReader, T1> projection1, Func<IDataReader, T2> projection2, Func<IDataReader, T3> projection3, Func<IDataReader, T4> projection4, Func<IDataReader, T5> projection5)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(CommandType.Text, commandText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var result1 = ExecuteReader(projection1, reader).ToList();
                        var result2 = ExecuteReader(projection2, reader).ToList();
                        var result3 = ExecuteReader(projection3, reader).ToList();
                        var result4 = ExecuteReader(projection4, reader).ToList();
                        var result5 = ExecuteReader(projection5, reader).ToList();
                        return Tuple.Create<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>(result1, result2, result3, result4, result5);
                    }
                }
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>> Read<T1, T2, T3, T4, T5, T6>(string commandText, Func<IDataReader, T1> projection1, Func<IDataReader, T2> projection2, Func<IDataReader, T3> projection3, Func<IDataReader, T4> projection4, Func<IDataReader, T5> projection5, Func<IDataReader, T6> projection6)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(CommandType.Text, commandText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var result1 = ExecuteReader(projection1, reader).ToList();
                        var result2 = ExecuteReader(projection2, reader).ToList();
                        var result3 = ExecuteReader(projection3, reader).ToList();
                        var result4 = ExecuteReader(projection4, reader).ToList();
                        var result5 = ExecuteReader(projection5, reader).ToList();
                        var result6 = ExecuteReader(projection6, reader).ToList();
                        return Tuple.Create<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>(result1, result2, result3, result4, result5, result6);
                    }
                }
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>> Read<T1, T2, T3, T4, T5, T6, T7>(string commandText, Func<IDataReader, T1> projection1, Func<IDataReader, T2> projection2, Func<IDataReader, T3> projection3, Func<IDataReader, T4> projection4, Func<IDataReader, T5> projection5, Func<IDataReader, T6> projection6, Func<IDataReader, T7> projection7)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(CommandType.Text, commandText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var result1 = ExecuteReader(projection1, reader).ToList();
                        var result2 = ExecuteReader(projection2, reader).ToList();
                        var result3 = ExecuteReader(projection3, reader).ToList();
                        var result4 = ExecuteReader(projection4, reader).ToList();
                        var result5 = ExecuteReader(projection5, reader).ToList();
                        var result6 = ExecuteReader(projection6, reader).ToList();
                        var result7 = ExecuteReader(projection7, reader).ToList();
                        return Tuple.Create<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>(result1, result2, result3, result4, result5, result6, result7);
                    }
                }
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> Read<T1, T2>(string commandText, Func<IDataReader, T1> projection1, Func<IDataReader, T2> projection2)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(CommandType.Text, commandText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var result1 = ExecuteReader(projection1, reader).ToList();
                        var result2 = ExecuteReader(projection2, reader).ToList();
                        return Tuple.Create<IEnumerable<T1>, IEnumerable<T2>>(result1, result2);
                    }
                }
            }
        }

        private IEnumerable<T> ExecuteReader<T>(Func<IDataReader, T> CreateObject, SqlDataReader reader)
        {
            while (reader.Read())
            {
                yield return CreateObject(reader);
            }
            reader.NextResult();
        }

    }
}
