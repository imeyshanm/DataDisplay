using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdapter
{
    public class SubjectTbl
    {
        private readonly IDataContext _dataContext;

        public SubjectTbl(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public Subject GetSubject(int SubjectID)
        {
            try
            {

                string SQL = @" SELECT [SubjectID]
                            ,[Name]
                             FROM [dbo].[Subject] WHERE SubjectID="+ SubjectID + " ";
                var lsit = _dataContext.Read(CommandType.Text,SQL, MakeSubject);


                return lsit.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        private static Func<IDataReader, Subject> MakeSubject = oReader =>
        {
            var Subject = new Subject();
            Subject.SubjectID = oReader["SubjectID"].AsInt();
            Subject.Name = oReader["Marks"].AsString();
            return Subject;
        };




    }
}
