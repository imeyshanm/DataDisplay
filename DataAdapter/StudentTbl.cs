using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAdapter
{
    public class StudentTbl
    {
        private readonly IDataContext _dataContext;

        public StudentTbl(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public Student GetStudent(int StudentID)
        {
            try
            {

                string SQL = @"SELECT [StudentID]
      ,[FirstName]
      ,[LastName]
      ,[DateofBirth]
      ,[StreetAddress]
      ,[City]
      ,[Sate]
      ,[ZipCode]
      ,[ContactNo]
      ,[Email]
      ,[Active]
  FROM [dbo].[Student] WHERE  StudentID="+ StudentID + " ";
                var lsit = _dataContext.Read(SQL, MakeStudent);
               

                return lsit.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public IList<Student> GetStudents()
        {
            try
            {

                string SQL = @"SELECT [StudentID]
      ,[FirstName]
      ,[LastName]
      ,[DateofBirth]
      ,[StreetAddress]
      ,[City]
      ,[Sate]
      ,[ZipCode]
      ,[ContactNo]
      ,[Email]
      ,[Active]
  FROM [dbo].[Student] ";
                var lsit = _dataContext.Read(SQL, MakeStudent).ToList();


                return lsit;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        private static Func<IDataReader, Student> MakeStudent = oReader =>
        {
            var Student = new Student();
            Student.StudentID = oReader["StudentID"].AsInt();
            Student.FirstName = oReader["FirstName"].AsString();
            Student.LastName = oReader["LastName"].AsString();
            Student.Sate = oReader["Sate"].AsString();
            Student.StreetAddress = oReader["StreetAddress"].AsString();
            Student.ZipCode = oReader["ZipCode"].AsString();
            Student.Active = oReader["Active"].AsBool();
            Student.City = oReader["City"].AsString();
            Student.ContactNo = oReader["ContactNo"].AsString();
            Student.Email = oReader["Email"].AsString();
            return Student;
        };

       


    }
}
