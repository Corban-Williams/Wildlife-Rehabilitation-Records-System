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
        public string _file = "animals.txt";
        List<string> animals = new List<string>();

        //name bysit
        public void Delete(string ID, int rowIndex)
        {
            if (rowIndex >= 0)                                  //only accepts a valid row selection. This prevents that non-rows or headings are selected
            {
                string animalName = getAnimalName(ID);
                DialogResult answer = MessageBox.Show($"Are you sure you want to delete Animal {animalName} with ID: {ID}?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)                     //The Dialog box confirms the users choice of deleting a row. The user can select yes and the deletion process will continue
                {
                    ReadAndWrite(ID);                               //run method with input id
                    MessageBox.Show($"Animal {ID} is removed");     //deletion confirmation message to user
                }
                else
                {
                    MessageBox.Show("Delete Cancled");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid row to be deleted");     //invalid rows are identified and a message informs the user
            }
        }

        private void ReadAndWrite(string ID)
        {
            try
            {
                animals.Clear();

                using (StreamReader reader = new StreamReader(_file))
                {
                    string text;
                    while ((text = reader.ReadLine()) != null)  //while there is still rows in the textfile, the reader will read and bring back the values
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

        public string getAnimalName(string ID)
        {
            try
            {
                if (File.Exists(_file))
                {
                    using (StreamReader reader = new StreamReader(_file))       //read from the animals.txt file only if the file exists
                    {
                        string text;
                        while ((text = reader.ReadLine()) != null)          //while it is not the end of the textfile
                        {
                            if (text.StartsWith(ID))                        //if the row starts with the selected ID then that row is evaluated
                            {
                                string[] parts = text.Split('|');         //split row inout to get the second item, array index 0, the animal name

                                if (parts.Length > 1)
                                {
                                    return parts[1];                    //returns the animal name from the input ID
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
