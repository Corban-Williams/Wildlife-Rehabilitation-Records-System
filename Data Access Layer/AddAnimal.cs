using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wildlife_Rehabilitation_Program.Classes;

namespace Wildlife_Rehabilitation_Program.Data_Access_Layer
{
    internal class AddAnimal
    {
        public string _file = "../../animals.txt";
        List<string> animals = new List<string>();
        public void CreateAnimalFile()
        {
            if (!File.Exists(_file))
            {
                File.Create(_file).Close();
            }
        }
        public void Add(Animal animal)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(_file, true))
                {
                    sw.WriteLine($"{animal.AnimalID}|{animal.Name}|{animal.Species}|{animal.Age}|{animal.RecoveredScore}|{animal.Status}|{animal.HousingUnit}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the animal: " + ex.Message);
            }
        }
    }
}
