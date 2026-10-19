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
        public int selectedRowIndex = -1;
        public string selectedID;

        public Form1()
        {
            InitializeComponent();

            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            

            SetAddMode();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void SetAddMode()
        {
            selectedRowIndex = -1;
            selectedID = string.Empty;
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
            if (e.RowIndex < 0) return;
        
            Animal animal = dgvDataDisplay.Rows[e.RowIndex].DataBoundItem as Animal;
            if (animal == null)
            {
                SetAddMode();
                return;
            }
        
            selectedRowIndex = e.RowIndex;
            selectedID = animal.AnimalID;
        
            txtAnimalID.Text = animal.AnimalID;
            txtName.Text     = animal.Name;
            txtSpecies.Text  = animal.Species;
            txtAge.Text      = animal.Age.ToString();
            txtScore.Text    = animal.RecoveredScore.ToString();
            txtStatus.Text   = animal.Status;
            txtHousing.Text  = animal.HousingUnit;
        
            SetEditMode();
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

              Animal targetAnimal = animalList.FirstOrDefault(a => string.Equals(a.AnimalID, id, StringComparison.OrdinalIgnoreCase));

            if (targetAnimal != null)
            {
                targetAnimal.Name = txtName.Text.Trim();
                targetAnimal.Species = txtSpecies.Text.Trim();
                targetAnimal.Age = age;
                targetAnimal.RecoveredScore = score;
                targetAnimal.Status = string.IsNullOrWhiteSpace(txtStatus.Text) ? targetAnimal.Status : txtStatus.Text.Trim();
                targetAnimal.HousingUnit = string.IsNullOrWhiteSpace(txtHousing.Text) ? targetAnimal.HousingUnit : txtHousing.Text.Trim();

                RefreshGridDisplay();
                MessageBox.Show($"Record for {targetAnimal.Name} ({targetAnimal.AnimalID}) updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SetAddMode();
            }
            else
            {
                MessageBox.Show("Target animal record not found in system memory.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            SummaryForm summary = new SummaryForm();
            summary.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvDataDisplay.ReadOnly = true;
            dgvDataDisplay.AllowUserToAddRows = false;
            dgvDataDisplay.AllowUserToDeleteRows = false;
            dgvDataDisplay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RefreshGridDisplay();
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || selectedRowIndex >= animalList.Count)
            {
                MessageBox.Show("Please select a record to delete.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        
            animalList.RemoveAt(selectedRowIndex);
            RefreshGridDisplay();
            SetAddMode();
        }

        private void RefreshGridDisplay()
        {
            dgvDataDisplay.DataSource = null;
            dgvDataDisplay.DataSource = animalList;
        }

    }
}
