using DataAccess;
using Domain;
using System;
using System.Windows.Forms;
using DataAdapter;



namespace DataDisplay.UI
{
    public partial class EditStudent : Form
    {
        private Student _student;
        IDataContext _dataContext;
        public EditStudent(Student student, IDataContext dataContext)
        {
            InitializeComponent();
            _student = student;
            _dataContext = dataContext;
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            if (_student!=null)
            {
                txtFirstName.Text = _student.FirstName;
                txtLastName.Text = _student.LastName;
                dpDOB.Value = _student.DateofBirth;
                txtStreetAddress.Text = _student.StreetAddress;
                txtCity.Text = _student.City;
                txtState.Text = _student.Sate;
                txtZipCode.Text = _student.ZipCode;
                txtContactNo.Text = _student.ContactNo;
                txtEmail.Text = _student.Email;
                cbActive.Checked = _student.Active;
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "Required");
                return;
            }

            if (_student==null)
            {
                _student = new Student();
            }

            _student.FirstName= txtFirstName.Text;
            _student.LastName = txtLastName.Text;
            _student.DateofBirth=Convert.ToDateTime(dpDOB.Value);
            _student.StreetAddress = txtStreetAddress.Text;
             _student.City= txtCity.Text;
           _student.Sate = txtState.Text;
            _student.ZipCode= txtZipCode.Text;
            _student.ContactNo= txtContactNo.Text;
             _student.Email=txtEmail.Text ;
            _student.Active= cbActive.Checked;

            var StudentTbl = new StudentTbl(_dataContext);
            if (_student.StudentID>0)
            {
                int update = StudentTbl.UpdateStudent(_student);
                if (update==1)
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                int save = StudentTbl.SaveStudent(_student);
                if (save>0)
                {
                    DialogResult = DialogResult.OK;
                }
            }
           
            

        }
    }
}
