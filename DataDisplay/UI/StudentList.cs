using DataAccess;
using DataAdapter;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataDisplay.UI
{
    public partial class StudentList : Form
    {

        IDataContext _dataContext;

        public StudentList(IDataContext dataContext)
        {
            InitializeComponent();
                        _dataContext = dataContext;
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            var StudentTbl = new StudentTbl(_dataContext);
            IList<Student> students = StudentTbl.GetStudents();
            dgStudentList.DataSource = students;
        }

        private void dgStudentList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgStudentList.SelectedRows.Count>0)
            {
                var Student = (Student)this.dgStudentList.SelectedRows[0].DataBoundItem;
                if (Student != null)
                {
                    var EditStudent = new EditStudent(Student, _dataContext);
                    EditStudent.ShowDialog();
                }

            }
        }
    }
}
