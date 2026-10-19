using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wildlife_Rehabilitation_Program.Classes;

namespace Wildlife_Rehabilitation_Program.Data_Access_Layer
{
    internal class ReadAnimals
    {
        public List<Animal> ReadAnimalFile()
        {
            List<Animal> animals = new List<Animal>();
            string[] lines = File.ReadAllLines("Animals.txt");
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                Animal animal = new Animal(fields[0], fields[1], fields[2], int.Parse(fields[3]), int.Parse(fields[4]), fields[5], fields[6]);
                animals.Add(animal);
            }
            return animals;
        }
    }
}
