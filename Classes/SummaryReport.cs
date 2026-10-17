using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Wildlife_Rehabilitation_Program
{
    internal class SummaryReport
    {
        //Empty Constructor to instantiate a object without needing input values
        public SummaryReport() { }

        //File name animal.txt where data is being read from and summary.txt where the data is displayed in
        public string _file = "animal.txt";
        public string _fileSummary = "summary.txt";


        //METHOD: sumReport()
        //Captures all the data from other methods, does the final calculations and writes the summary report to the textfile
        public (int totalAnimals, double avgAge, double avgRecoveryScore, int criticalCount, int seriousCount, int stableCount, int recoveryCount, int releaseReadyCount) sumReport()
        {
            double avgAge;
            double avgRecoveryScore;
            int totalAnimals;

            try
            {
                if (!File.Exists(_file))
                {
                    MessageBox.Show("ERROR: File animal.txt does not exist");
                }
                totalAnimals = File.ReadAllLines(_file).Length;

                if (totalAnimals == 0)
                {
                    MessageBox.Show("ERROR: No data in animal.txt");
                }
                else
                {
                    var (ages, recoveryScores, criticalCount, seriousCount, stableCount, recoveryCount, releaseReadyCount) = ReadFileValues();

                    avgAge = Math.Round(ages / totalAnimals,2);
                    avgRecoveryScore = Math.Round(recoveryScores / totalAnimals,2);         //rounded to 2 decimals

                    string summaryContent =
            "BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE \r\n" +
            "ANIMAL SUMMARY REPORT \r\n" +
            $"Generated: {DateTime.Now} \r\n" +
            "---------------------------------------- \r\n" +
            $"Total animals:           {totalAnimals} \r\n" +
            $"Average age (years):     {avgAge} \r\n" +
            $"Average recovery score:  {avgRecoveryScore}\r\n" +
            "---------------------------------------- \r\n" +
            "Animals per status: \r\n" +
            $"Critical:                 {criticalCount} \r\n" +
            $"Serious:                  {seriousCount} \r\n" +
            $"Stable:                   {stableCount} \r\n" +
            $"Recovering:               {recoveryCount} \r\n" +
            $"Release-Ready:            {releaseReadyCount} ";

                    File.WriteAllText(_fileSummary, summaryContent);

                    return (totalAnimals, avgAge, avgRecoveryScore, criticalCount, seriousCount, stableCount, recoveryCount, releaseReadyCount);
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                return (0, 0, 0, 0, 0, 0, 0, 0);
            }

            return (0, 0, 0, 0, 0, 0, 0, 0);

        }
        

        //METHOD: ReadFileValues
        //This method reads the animal textfile and through iterations return the values needed to form the summary. It returns a series of values
        public (double ages, double recoveryScore, int critical, int serious, int stable, int recovering, int release) ReadFileValues()
        {
            double ages = 0;
            double recoveryScores = 0;
            int critical = 0;
            int serious = 0;
            int stable = 0;
            int recovering = 0;
            int release = 0;

            try
            {
                using (StreamReader reader = new StreamReader(_file))
                {
                    string text;
                    while ((text = reader.ReadLine()) != null)
                    {
                        string[] parts = text.Split('|');

                        ages += int.Parse(parts[3]);
                        recoveryScores += int.Parse(parts[4]);
                        int countStatus = int.Parse(parts[4]);

                        if (countStatus <= 19)
                        {
                            ++critical;
                        }
                        else if (countStatus > 20 && countStatus < 39)
                        {
                            ++serious;
                        }
                        else if (countStatus > 40 && countStatus < 59)
                        {
                            ++stable;
                        }
                        else if (countStatus > 60 && countStatus < 79)
                        {
                            ++recovering;
                        }
                        else if (countStatus > 80 && countStatus < 100)
                        {
                            ++release;
                        }
                        else
                        {
                            MessageBox.Show($"Invalid recovery status range detected for a animal");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            

            return (ages, recoveryScores, critical, serious, stable, recovering, release);              //spesified series of values returned
        }








    }
}
