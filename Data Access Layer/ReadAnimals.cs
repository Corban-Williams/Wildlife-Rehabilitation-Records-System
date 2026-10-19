using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wildlife_Rehabilitation_Program.Classes;

namespace Wildlife_Rehabilitation_Program.Data_Access_Layer
{
    public class ReadAnimals
    {
        public static List<Animal> ReadAnimalFile()
        {
            List<Animal> animals = new List<Animal>();
            string[] lines = File.ReadAllLines("../../animals.txt");
            foreach (string line in lines)
            {
                string[] items = line.Split('|');
                Animal animal = new Animal(items[0], items[1], items[2], int.Parse(items[3]), int.Parse(items[4]), items[5], items[6]);
                animals.Add(animal);
            }
            return animals;
        }
    }
}
