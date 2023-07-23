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
                var parameters = new object[] { "@StudentID", StudentID};
                string SQL = @"SPGetStudents";
                var lsit = _dataContext.Read(CommandType.StoredProcedure,SQL, MakeStudent,parameters);
               

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
                var parameters = new object[] { "@StudentID",-1 };
                string SQL = @"SPGetStudents";
                var lsit = _dataContext.Read(CommandType.StoredProcedure,SQL, MakeStudent, parameters).ToList();


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
            Student.DateofBirth = oReader["DateofBirth"].AsDateTime();
            Student.Sate = oReader["Sate"].AsString();
            Student.StreetAddress = oReader["StreetAddress"].AsString();
            Student.ZipCode = oReader["ZipCode"].AsString();
            Student.Active = oReader["Active"].AsBool();
            Student.City = oReader["City"].AsString();
            Student.ContactNo = oReader["ContactNo"].AsString();
            Student.Email = oReader["Email"].AsString();
            return Student;
        };

        public int SaveStudent(Student student)
        {
            try
            {

                string SQL = @"SPSaveStudent";
                return _dataContext.Insert(CommandType.StoredProcedure,SQL, Extract(student));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public int UpdateStudent(Student student)
        {
            try
            {
               
                string SQL = @"SPSaveStudent";
                return _dataContext.Update(CommandType.StoredProcedure,SQL, Extract(student));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        private object[] Extract(Student Student)
        {
            return new object[] { "@StudentID", Student.StudentID, "@FirstName", Student.FirstName, "@LastName", Student.LastName, "@DateofBirth", Student.DateofBirth
            , "@StreetAddress", Student.StreetAddress, "@City", Student.City, "@Sate", Student.Sate, "@ZipCode", Student.ZipCode
           , "@ContactNo", Student.ContactNo, "@Email", Student.Email, "@Active", Student.Active };
        }



    }
}
