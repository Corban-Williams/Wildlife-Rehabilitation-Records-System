using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Wildlife_Rehabilitation_Program.Classes

{

    // Validates the information entered for an animal.

    public class AnimalValidator
    {
        // Checks whether an Animal ID has the required format.

        public static bool ValidateAnimalId(string id)
        {
            
            if (string.IsNullOrWhiteSpace(id)) 
            { 
                return false; 
            }

            id = id.Trim().ToUpperInvariant();

            return Regex.IsMatch(id, @"^WR-\d{4}$");
        }

        // Checks that a name or species is valid.

        public static bool ValidateTextField(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) 
            { 
                return false; 
            }
            value = value.Trim();

            return value.Length >= 1 && value.Length <= 30 && !value.Contains("|");
        }

        // Checks whether age is a whole number from 0 to 100.

        public static bool ValidateAge(string value)
        {
            return int.TryParse(value, out int age) && age >= 0 && age <= 100;
        }


        // Checks whether the recovery score is a whole number from 0 to 100.

        public static bool ValidateRecoveryScore(string value)
        {
            return int.TryParse(value, out int score) && score >= 0 && score <= 100;
        }
    }
}