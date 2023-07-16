using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Exam
	{
		public int ExamID { get; set; }
		public int StudentID { get; set; }
		public int SubjectID { get; set; }
		public int Marks { get; set; }
	}
}
