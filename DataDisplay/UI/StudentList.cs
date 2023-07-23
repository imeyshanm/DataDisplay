using DataAccess;
using DataAdapter;
using Domain;
using NLog;
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
        ILogger _logger;

        public StudentList(IDataContext dataContext, ILogger logger)
        {
            InitializeComponent();
            _dataContext = dataContext;
            _logger = logger;
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            try
            {
                var StudentTbl = new StudentTbl(_dataContext);
                IList<Student> students = StudentTbl.GetStudents();
                dgStudentList.DataSource = students;
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occurred.", this.Text, MessageBoxButtons.OK);
                _logger.Error(ex);
            }

        }

        private void dgStudentList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgStudentList.SelectedRows.Count > 0)
            {
                var Student = (Student)this.dgStudentList.SelectedRows[0].DataBoundItem;
                if (Student != null)
                {
                    var EditStudent = new EditStudent(Student, _dataContext, _logger);
                    EditStudent.ShowDialog();
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudentData();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var EditStudent = new EditStudent(null, _dataContext, _logger);
            EditStudent.ShowDialog();
        }
    }
}
