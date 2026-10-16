using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wildlife_Rehabilitation_Program.Classes;

namespace Wildlife_Rehabilitation_Program
{
    internal class DeleteAnimal
    {
        public DeleteAnimal() { }
        public string _file = "animals.txt";
        List<string> animals = new List<string>();

        //METHOD: Delete
        //If the row selection is valid, the dialog box will ensure the user is sure of the removal of the given ID's row. If the user selects yes, the removal process will continue, else it will be terminated.
        public void Delete(string ID, int rowIndex)
        {
            if (rowIndex >= 0)                                  
            {
                string animalName = getAnimalName(ID);
                DialogResult answer = MessageBox.Show($"Are you sure you want to delete Animal {animalName} with ID: {ID}?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)                     //confirms the users choice of deleting a row
                {
                    ReadAndWrite(ID);                               //pre-made method
                    MessageBox.Show($"Animal {ID} is removed");     
                }
                else
                {
                    MessageBox.Show("Delete Cancled");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid row to be deleted");
            }
        }

        //METHOD: ReadAndWrite
        //The StreamReader reads the animal textfile and records each line in a list, removing the given ID row. Then the updated list is re-written to the animal textfile
        private void ReadAndWrite(string ID)
        {
            try
            {
                animals.Clear();

                using (StreamReader reader = new StreamReader(_file))
                {
                    string text;
                    while ((text = reader.ReadLine()) != null)
                    {
                        if (text.StartsWith(ID))
                        {
                            continue;                  //disallow adding the chosen row from the ID, to the new list of updated animals
                        }
                        else
                        {
                            animals.Add(text);
                        }
                    }
                }
                File.WriteAllLines(_file, animals); // write new list of animals to the textfile, without the selected one
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message );
            }
            
        }

        //METHOD: getAnimalName
        //This method executes if the file exists and reads each line till it finds the line containing the given ID, then returns the name associated with that ID
        public string getAnimalName(string ID)
        {
            try
            {
                if (File.Exists(_file))
                {
                    using (StreamReader reader = new StreamReader(_file))       
                    {
                        string text;
                        while ((text = reader.ReadLine()) != null)          
                        {
                            if (text.StartsWith(ID))                        //if the row starts with the selected ID then that row is evaluated
                            {
                                string[] parts = text.Split('|');         //split row input to get the second item, array index 0, the animal name

                                if (parts.Length > 1)
                                {
                                    return parts[1];                   
                                }

                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                return "Unknown Animal";
            }
            return "Unknown Animal";
        }
    }
}
