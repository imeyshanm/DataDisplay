using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Student
	{
		public int StudentID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateofBirth { get; set; }
		public string StreetAddress { get; set; }
		public string City { get; set; }
		public string Sate { get; set; }
		public string ZipCode { get; set; }
		public string ContactNo { get; set; }
		public string Email { get; set; }
		public bool Active { get; set; }
	}
}
