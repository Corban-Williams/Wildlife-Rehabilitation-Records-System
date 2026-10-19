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
    }
}
