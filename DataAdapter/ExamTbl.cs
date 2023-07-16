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
    public class ExamTbl
    {
        private readonly IDataContext _dataContext;

        public ExamTbl(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public Exam GetExam(int ExamID)
        {
            try
            {

                string SQL = @"SELECT [ExamID]
      ,[StudentID]
      ,[SubjectID]
      ,[Marks]
  FROM [dbo].[Exam] WHERE ExamID = " + ExamID + ";";
                var lsit = _dataContext.Read(SQL, MakeExam);


                return lsit.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        private static Func<IDataReader, Exam> MakeExam = oReader =>
        {
            var Exam = new Exam();
            Exam.StudentID = oReader["StudentID"].AsInt();
            Exam.ExamID = oReader["ExamID"].AsInt();
            Exam.SubjectID = oReader["SubjectID"].AsInt();
            Exam.Marks = oReader["Marks"].AsInt();
            return Exam;
        };




    }
}
