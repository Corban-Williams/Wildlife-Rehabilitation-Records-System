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
        public Form1()
        {
            InitializeComponent();
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
    }
}
