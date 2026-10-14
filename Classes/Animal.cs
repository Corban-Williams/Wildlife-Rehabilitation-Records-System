using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wildlife_Rehabilitation_Program.Classes
{
    internal class Animal
    {
        private string AnimalID;
        private string Name;
        private string Species;
        private int Age;
        private int RecoveredScore;
        private string Status;
        private string HousingUnit;

        public Animal(string animalID1, string name1, string species1, int age1, int recoveredScore1, string status1, string housingUnit1)
        {
            AnimalID1 = animalID1;
            Name1 = name1;
            Species1 = species1;
            Age1 = age1;
            RecoveredScore1 = recoveredScore1;
            Status1 = status1;
            HousingUnit1 = housingUnit1;
        }

        public string AnimalID1 { get => AnimalID; set => AnimalID = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string Species1 { get => Species; set => Species = value; }
        public int Age1 { get => Age; set => Age = value; }
        public int RecoveredScore1 { get => RecoveredScore; set => RecoveredScore = value; }
        public string Status1 { get => Status; set => Status = value; }
        public string HousingUnit1 { get => HousingUnit; set => HousingUnit = value; }
    }
}
