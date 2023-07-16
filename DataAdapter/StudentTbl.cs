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

                string SQL = @"
                  
INSERT INTO [dbo].[Student]
           ([FirstName]
           ,[LastName]
           ,[DateofBirth]
           ,[StreetAddress]
           ,[City]
           ,[Sate]
           ,[ZipCode]
           ,[ContactNo]
           ,[Email]
           ,[Active])
     VALUES
           (@FirstName
           ,@LastName
           ,@DateofBirth
           ,@StreetAddress
           ,@City
           ,@Sate
           ,@ZipCode
           ,@ContactNo
           ,@Email
           ,@Active) ";
                return _dataContext.Insert(SQL, Extract(student));
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
               
                string SQL = @"UPDATE [dbo].[Student]
   SET [FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[DateofBirth] = @DateofBirth
      ,[StreetAddress] = @StreetAddress
      ,[City] = @City
      ,[Sate] = @Sate
      ,[ZipCode] = @ZipCode
      ,[ContactNo] = @ContactNo
      ,[Email] = @Email
      ,[Active] = @Active
 WHERE StudentID=@StudentID";
                return _dataContext.Update(SQL, Extract(student));

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
