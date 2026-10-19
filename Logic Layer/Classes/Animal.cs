using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wildlife_Rehabilitation_Program.Classes
{
    internal class Animal
    {
        private string animalID;
        private string name;
        private string species;
        private int age;
        private int recoveredScore;
        private string status;
        private string housingUnit;

        public Animal(string animalID, string name, string species, int age, int recoveredScore, string status, string housingUnit)
        {
            AnimalID = animalID;
            Name = name;
            Species = species;
            Age = age;
            RecoveredScore = recoveredScore;
            Status = status;
            HousingUnit = housingUnit;
        }

        public string AnimalID { get => animalID; set => animalID = value; }
        public string Name { get => name; set => name = value; }
        public string Species { get => species; set => species = value; }
        public int Age { get => age; set => age = value; }
        public int RecoveredScore { get => recoveredScore; set => recoveredScore = value; }
        public string Status { get => status; set => status = value; }
        public string HousingUnit { get => housingUnit; set => housingUnit = value; }

        public void Classification()
        { 
            if (RecoveredScore > 100 || RecoveredScore < 0)
            {
                throw new ArgumentOutOfRangeException("RecoveredScore must be between 0 and 100.");
            }
            else if (RecoveredScore >= 80)
            {
                Status = "Release-Ready";
                HousingUnit = "Pre-Release Camp";
            }
            else if (RecoveredScore >= 60)
            {
                Status = "Recovering";
                HousingUnit = "Outdoor Enclosure";
            }
            else if (RecoveredScore >= 40)
            {
                Status = "Stable";
                HousingUnit = "Recovery Ward";
            }
            else if (RecoveredScore >= 20)
            {
                Status = "Serious";
                HousingUnit = "High Dependancy Ward";
            }
            else if (RecoveredScore >= 0)
            {
                Status = "Critical";
                HousingUnit = "Intensive Care Unit";
            }
        }
    }
}
