using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wildlife_Rehabilitation_Program
{
    public partial class SummaryForm : Form
    {
        public SummaryForm()
        {
            InitializeComponent();
        }

        private void btnExitSummary_Click(object sender, EventArgs e)
        {
            //Closes the Summary report form
            this.Close();
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            //instantiate summaryReport object to capture the values and run the method in this class
            SummaryReport summaryReport = new SummaryReport();
            var (totalAnimals, avgAge, avgRecoveryScore, criticalCount, seriousCount, stableCount, recoveryCount, releaseReadyCount) = summaryReport.sumReport();

            //put values from method into lists to view
            lblTimeDisplay.Text = DateTime.Now.ToString();
            lblTotalAnimalDisplay.Text = totalAnimals.ToString();
            lblAvgAgeDisplay.Text = avgAge.ToString();
            lblAvgRecoveryDisplay.Text = avgRecoveryScore.ToString();
            lblCriticalDisplay.Text = criticalCount.ToString();
            lblSeriousDisplay.Text = seriousCount.ToString();
            lblStableDisplay.Text = stableCount.ToString();
            lblRecoveringDisplay.Text = recoveryCount.ToString();
            lblReleaseDisplay.Text = releaseReadyCount.ToString();
        
        }
    }
}
