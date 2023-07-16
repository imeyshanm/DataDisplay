using SPILGlass.Jobs.DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Threading;
using System.IO;

namespace DataDisplay.UI
{
    public partial class frmEmployee : Form
    {
        EmployeeDAO employee = new EmployeeDAO();

        public frmEmployee()
        {
            InitializeComponent();
            GetEmployees();
           
           
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEmployeeAdd frm = new frmEmployeeAdd();
            frm.ShowDialog();
            GetEmployees();
        }

        private void GetEmployees()
        {
            try
            {
                gridControl.DataSource = null;
                gridControl.DataSource = employee.GetEmployees("Id ASC");
                string path = SPIL_Glass.modCommonVar.strAppPath + "\\" + SPIL_Glass.modCommonVar.strUserName + "EmployeeGrid.xml";
                if (File.Exists(path))
                {
                    gridControl.MainView.RestoreLayoutFromXml(path);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnColse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetEmployees();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int empId = Convert.ToInt32(gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["Id"]));

            if (empId > 0)
            {
                frmEmployeeAdd frm = new frmEmployeeAdd(empId);
                frm.ShowDialog();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int empId = Convert.ToInt32(gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["Id"]));

            if (empId > 0)
            {
                DialogResult res = XtraMessageBox.Show("Are you sure?", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    var emp = employee.GetEmployeeById(empId);
                    if (employee.InReference(empId))
                    {
                        XtraMessageBox.Show("Employee is in use, Cannot be Deleted", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    employee.DeleteEmployee(emp);

                    XtraMessageBox.Show("Employee delete successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                GetEmployees();

            }
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            int empId = Convert.ToInt32(gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["Id"]));

            if (empId > 0)
            {
                frmEmployeeAdd frm = new frmEmployeeAdd(empId);
                frm.ShowDialog();
            }
            GetEmployees();

        }



        private void btnEmpType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEmployeeType frm = new frmEmployeeType();
            frm.ShowDialog();
        }

        private void btnEmpDesig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEmployeeDesignation frm = new frmEmployeeDesignation();
            frm.ShowDialog();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridControl.IsPrintingAvailable)
            {
                gridControl.ShowPrintPreview();
            }
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Thread threadGetFile = new Thread(new ThreadStart(SaveFile));
            threadGetFile.SetApartmentState(ApartmentState.STA);
            threadGetFile.Start();
        }

        private void SaveFile()
        {
            System.Windows.Forms.SaveFileDialog saveDlg = new System.Windows.Forms.SaveFileDialog();
            saveDlg.Filter = "Excel files (*.xls)|*.xls";
            saveDlg.FilterIndex = 0;
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Export Excel File To";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {

                Invoke((MethodInvoker)delegate
                {
                    string path = saveDlg.FileName;
                    gridControl.ExportToXls(path);
                });
            }
        }

        private void btnSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            gridControl.MainView.SaveLayoutToXml(SPIL_Glass.modCommonVar.strAppPath + "\\" + SPIL_Glass.modCommonVar.strUserName + "EmployeeGrid.xml");
        }

        private void btncustermization_Click(object sender, EventArgs e)
        {
            gridView.ShowCustomization();
        }

    }
}
 