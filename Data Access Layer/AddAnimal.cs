using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wildlife_Rehabilitation_Program.Data_Access_Layer
{
    internal class AddAnimal
    {
        public AddAnimal() { }
        public string _file = "animals.txt";
        List<string> animals = new List<string>();
        public void CreateAnimalFile()
        {
            if (!File.Exists("../../animals.txt"))
            {
                File.Create("../../animals.txt").Close();
            }
        }
    }
}
