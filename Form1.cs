using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wildlife_Rehabilitation_Program.Classes;

namespace Wildlife_Rehabilitation_Program
{
    public partial class Form1 : Form
    {
        private List<Animal> animalList = new List<Animal>();

        public Form1()
        {
            InitializeComponent();

            this.dgvDataDisplay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataDisplay_CellClick);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

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
            txtAnimalID.ReadOnly = true;
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

        private void dgvDataDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDataDisplay.Rows.Count)
            {
                DataGridViewRow row = dgvDataDisplay.Rows[e.RowIndex];

                if (row.Cells[0].Value != null)
                {
                    txtAnimalID.Text = row.Cells["AnimalID"]?.Value?.ToString() ?? row.Cells[0].Value.ToString();
                    txtName.Text = row.Cells["Name"]?.Value?.ToString() ?? row.Cells[1].Value.ToString();
                    txtSpecies.Text = row.Cells["Species"]?.Value?.ToString() ?? row.Cells[2].Value.ToString();
                    txtAge.Text = row.Cells["Age"]?.Value?.ToString() ?? row.Cells[3].Value.ToString();
                    txtScore.Text = row.Cells["RecoveryScore"]?.Value?.ToString() ?? row.Cells[4].Value.ToString();
                    txtStatus.Text = row.Cells["Status"]?.Value?.ToString() ?? row.Cells[5].Value.ToString();
                    txtHousing.Text = row.Cells["HousingUnit"]?.Value?.ToString() ?? row.Cells[6].Value.ToString();

                    SetEditMode();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtAnimalID.Text.Trim();

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please select a record to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSpecies.Text))
            {
                MessageBox.Show("Name and Species fields cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtAge.Text.Trim(), out int age) || age < 0)
            {
                MessageBox.Show("Please enter a valid non-negative integer for Age.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtScore.Text.Trim(), out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Recovery Score must be an integer between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Animal targetAnimal = animalList.FirstOrDefault(a => a.AnimalID.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (targetAnimal != null)
            {
                targetAnimal.Name = txtName.Text.Trim();
                targetAnimal.Species = txtSpecies.Text.Trim();
                targetAnimal.Age = age;
                targetAnimal.RecoveryScore = score;
                targetAnimal.Status = txtStatus.Text.Trim();
                targetAnimal.HousingUnit = txtHousing.Text.Trim();

                RefreshGridDisplay();
                MessageBox.Show($"Record for {targetAnimal.Name} ({targetAnimal.AnimalID}) updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SetAddMode();
            }
            else
            {
                MessageBox.Show("Target animal record not found in system memory.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGridDisplay()
        {
            dgvDataDisplay.DataSource = null;
            dgvDataDisplay.DataSource = animalList;
        }
    }
}
