using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wildlife_Rehabilitation_Program.Classes;
using Wildlife_Rehabilitation_Program.Data_Access_Layer;

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

            SetAddMode();
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
            LoadAnimalForEditing(animal);

            SetEditMode();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvDataDisplay.ReadOnly = true;
            dgvDataDisplay.AllowUserToAddRows = false;
            dgvDataDisplay.AllowUserToDeleteRows = false;
            dgvDataDisplay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DisplayAnimals();
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || selectedRowIndex >= animalList.Count)
            {
                MessageBox.Show("Please select a record to delete.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        
            //animalList.RemoveAt(selectedRowIndex);
            DeleteAnimal deleteAnimal = new DeleteAnimal();
            deleteAnimal.Delete(selectedID, selectedRowIndex);
            DisplayAnimals();
            SetAddMode();
        }

        private void RefreshGridDisplay()
        {
            dgvDataDisplay.DataSource = null;
            dgvDataDisplay.DataSource = animalList;
        }

        public void DisplayAnimals()
        {
            animalList = ReadAnimals.ReadAnimalFile();
            RefreshGridDisplay();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            SummaryForm summary = new SummaryForm();
            summary.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtAnimalID.Text.Trim().ToUpper();
            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();
            string ageText = txtAge.Text.Trim();
            string scoreText = txtScore.Text.Trim();

            if (!AnimalValidator.ValidateAnimalId(id))
            {
                MessageBox.Show("Invalid Animal ID. ID must start with 'WR-' and then have 4 alphanumeric characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!AnimalValidator.ValidateTextField(name))
            {
                MessageBox.Show("Invalid Name. It must be 1-30 characters long and cannot contain '|'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!AnimalValidator.ValidateTextField(species))
            {
                MessageBox.Show("Invalid Species. It must be 1-30 characters long and cannot contain '|'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!AnimalValidator.ValidateAge(ageText))
            {
                MessageBox.Show("Invalid Age. It must be a positive integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!AnimalValidator.ValidateRecoveryScore(scoreText))
            {
                MessageBox.Show("Invalid Score. It must be a positive integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!AnimalValidator.ValidateUniqueAnimalId(id, animalList))
            {
                MessageBox.Show("This Animal ID already exists. Please enter a unique ID.", "Duplicate Animal ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalID.Focus();
                return;
            }

            AddAnimal addAnimal = new AddAnimal();
            addAnimal.CreateAnimalFile();
            Animal animal = new Animal(id, name, species, int.Parse(ageText), int.Parse(scoreText), "", "");
            animal.Classification(int.Parse(scoreText));
            MessageBox.Show( $"Recovery Score: {animal.RecoveredScore}\n" + $"Status: {animal.Status}\n" + $"Housing Unit: {animal.HousingUnit}", "Animal Classification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            addAnimal.Add(animal);
            DisplayAnimals();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            SetAddMode();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (selectedRowIndex < 0 || selectedRowIndex >= animalList.Count)
            {
                MessageBox.Show("Please select a record to Update.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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

            DialogResult confirm = MessageBox.Show(
            $"Save changes to animal {id}?",
            "Confirm Update",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            Animal targetAnimal = animalList.FirstOrDefault(a => string.Equals(a.AnimalID, id, StringComparison.OrdinalIgnoreCase));

            if (targetAnimal != null)
            {
                targetAnimal.Name = txtName.Text.Trim();
                targetAnimal.Species = txtSpecies.Text.Trim();
                targetAnimal.Age = age;
                targetAnimal.RecoveredScore = score;
                targetAnimal.Classification(score);

                UpdateAnimal updateAnimal = new UpdateAnimal();
                updateAnimal.Update(id, selectedRowIndex, targetAnimal);

                DisplayAnimals();
                MessageBox.Show($"Record for {targetAnimal.Name} ({targetAnimal.AnimalID}) updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"Recovery Score: {targetAnimal.RecoveredScore}\n" + $"Status: {targetAnimal.Status}\n" + $"Housing Unit: {targetAnimal.HousingUnit}", "Animal Classification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SetAddMode();
            }
            else
            {
                MessageBox.Show("Target animal record not found in system memory.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAnimalForEditing(Animal animal)
        {
            selectedID = animal.AnimalID;

            txtAnimalID.Text = animal.AnimalID;
            txtName.Text = animal.Name;
            txtSpecies.Text = animal.Species;
            txtAge.Text = animal.Age.ToString();
            txtScore.Text = animal.RecoveredScore.ToString();
            txtStatus.Text = animal.Status;
            txtHousing.Text = animal.HousingUnit;

            SetEditMode();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchID = txtSearchAnimalID.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchID))
            {
                MessageBox.Show("Please enter an Animal ID to search for.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearchAnimalID.Focus();
                return;
            }

            Animal animal = animalList.FirstOrDefault(a => string.Equals(a.AnimalID, searchID, StringComparison.OrdinalIgnoreCase));

            if (animal == null)
            {
                MessageBox.Show( "No animal was found with that ID.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadAnimalForEditing(animal);
        }
    }
}
