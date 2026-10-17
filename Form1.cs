using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wildlife_Rehabilitation_Program
{
   public partial class Form1 : Form
    {
        public int selectedRowIndex;
        public string selectedID;
        public Form1()
        {
            InitializeComponent();

            this.dgvDataDisplay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataDisplay_CellClick);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            
            SetAddMode();
        }

        private void SetAddMode()
        {
            txtAnimalID.ReadOnly = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            
            ClearInputFields();
        }

        private void SetEditMode()
        {
            txtAnimalID.ReadOnly = true; // Animal ID cannot be modified in edit mode
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
        }

        private void ClearInputFields()
        {
            txtAnimalID.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtScore.Clear();
            txtStatus.Clear();
            txtHousing.Clear();
            
            if (dgvDataDisplay != null && dgvDataDisplay.Rows.Count > 0)
            {
                dgvDataDisplay.ClearSelection();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAnimal deleteManager = new DeleteAnimal();
            deleteManager.Delete(selectedID,selectedRowIndex);
        }

        private void dgvDataDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDataDisplay.Rows.Count)
            {
               return;
            }
         
            DataGridViewRow row = dgvDataDisplay.Rows[e.RowIndex];
         
            if (row.IsNewRow || row.Cells[0].Value == null || string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
            {
               SetAddMode();
               return;
            }
         
            txtAnimalID.Text = row.Cells["AnimalID"]?.Value?.ToString() ?? row.Cells[0].Value?.ToString() ?? "";
            txtName.Text = row.Cells["Name"]?.Value?.ToString() ?? row.Cells[1].Value?.ToString() ?? "";
            txtSpecies.Text = row.Cells["Species"]?.Value?.ToString() ?? row.Cells[2].Value?.ToString() ?? "";
            txtAge.Text = row.Cells["Age"]?.Value?.ToString() ?? row.Cells[3].Value?.ToString() ?? "";
            txtScore.Text = row.Cells["RecoveryScore"]?.Value?.ToString() ?? row.Cells[4].Value?.ToString() ?? "";
            txtStatus.Text = row.Cells["Status"]?.Value?.ToString() ?? row.Cells[5].Value?.ToString() ?? "";
            txtHousing.Text = row.Cells["HousingUnit"]?.Value?.ToString() ?? row.Cells[6].Value?.ToString() ?? "";
         
            SetEditMode();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvDataDisplay.MultiSelect = false;
        }

       private void btnSummary_Click(object sender, EventArgs e)
       {
          SetAddMode();
       }
    }
}
