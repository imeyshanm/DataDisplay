using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess
{
    public interface IDataContext
    {
        int Insert(string commandText, params object[] parameters);
        int Update(string commandText, params object[] parameters);
        int Delete(string commandText, params object[] parameters);
        DataSet Get(CommandType commandType, string commandText);
        DataSet Get(CommandType commandType, string commandText, params object[] parameters);
        IEnumerable<T> Read<T>(string commandText, Func<IDataReader, T> projection, params object[] parameters);
        IEnumerable<T> Read<T>(string commandText, Func<IDataReader, T> projection);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> Read<T1, T2, T3>(string commandText, Func<IDataReader, T1> projection1, Func<IDataReader, T2> projection2, Func<IDataReader, T3> projection3);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> Read<T1, T2, T3, T4>(string commandText, Func<IDataReader, T1> projection1, Func<IDataReader, T2> projection2, Func<IDataReader, T3> projection3, Func<IDataReader, T4> projection4);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>> Read<T1, T2, T3, T4, T5>(string commandText, Func<IDataReader, T1> projection1, Func<IDataReader, T2> projection2, Func<IDataReader, T3> projection3, Func<IDataReader, T4> projection4, Func<IDataReader, T5> projection5);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>> Read<T1, T2, T3, T4, T5, T6, T7>(string commandText, Func<IDataReader, T1> projection1, Func<IDataReader, T2> projection2, Func<IDataReader, T3> projection3, Func<IDataReader, T4> projection4, Func<IDataReader, T5> projection5, Func<IDataReader, T6> projection6, Func<IDataReader, T7> projection7);
        Tuple<IEnumerable<T1>, IEnumerable<T2>> Read<T1, T2>(string commandText, Func<IDataReader, T1> projection1, Func<IDataReader, T2> projection2);

    }
}
