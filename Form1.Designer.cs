namespace Wildlife_Rehabilitation_Program
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBanner = new System.Windows.Forms.Label();
            this.dgvDataDisplay = new System.Windows.Forms.DataGridView();
            this.txtAnimalID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSpecies = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtHousing = new System.Windows.Forms.TextBox();
            this.lblAnimalID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSpecies = new System.Windows.Forms.Label();
            this.lblHousing = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBanner
            // 
            this.lblBanner.AutoSize = true;
            this.lblBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanner.Location = new System.Drawing.Point(25, 28);
            this.lblBanner.Name = "lblBanner";
            this.lblBanner.Size = new System.Drawing.Size(835, 37);
            this.lblBanner.TabIndex = 0;
            this.lblBanner.Text = "Baobab Ridge Wildlife Rehabilitation Records System ";
            // 
            // dgvDataDisplay
            // 
            this.dgvDataDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataDisplay.Location = new System.Drawing.Point(419, 94);
            this.dgvDataDisplay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDataDisplay.Name = "dgvDataDisplay";
            this.dgvDataDisplay.RowHeadersWidth = 51;
            this.dgvDataDisplay.RowTemplate.Height = 24;
            this.dgvDataDisplay.Size = new System.Drawing.Size(704, 549);
            this.dgvDataDisplay.TabIndex = 1;
            this.dgvDataDisplay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataDisplay_CellClick);
            // 
            // txtAnimalID
            // 
            this.txtAnimalID.Location = new System.Drawing.Point(190, 119);
            this.txtAnimalID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAnimalID.Name = "txtAnimalID";
            this.txtAnimalID.Size = new System.Drawing.Size(189, 24);
            this.txtAnimalID.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(190, 166);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(189, 24);
            this.txtName.TabIndex = 3;
            // 
            // txtSpecies
            // 
            this.txtSpecies.Location = new System.Drawing.Point(190, 216);
            this.txtSpecies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSpecies.Name = "txtSpecies";
            this.txtSpecies.Size = new System.Drawing.Size(189, 24);
            this.txtSpecies.TabIndex = 4;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(190, 265);
            this.txtAge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(189, 24);
            this.txtAge.TabIndex = 5;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(190, 315);
            this.txtScore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(189, 24);
            this.txtScore.TabIndex = 6;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(190, 363);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(189, 24);
            this.txtStatus.TabIndex = 7;
            // 
            // txtHousing
            // 
            this.txtHousing.Location = new System.Drawing.Point(190, 412);
            this.txtHousing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHousing.Name = "txtHousing";
            this.txtHousing.Size = new System.Drawing.Size(189, 24);
            this.txtHousing.TabIndex = 8;
            // 
            // lblAnimalID
            // 
            this.lblAnimalID.AutoSize = true;
            this.lblAnimalID.Location = new System.Drawing.Point(27, 122);
            this.lblAnimalID.Name = "lblAnimalID";
            this.lblAnimalID.Size = new System.Drawing.Size(74, 18);
            this.lblAnimalID.TabIndex = 9;
            this.lblAnimalID.Text = "Animal ID:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(29, 169);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 18);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Name:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(29, 268);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(37, 18);
            this.lblAge.TabIndex = 11;
            this.lblAge.Text = "Age:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(29, 318);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(128, 18);
            this.lblScore.TabIndex = 12;
            this.lblScore.Text = "Recovered Score:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(29, 366);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 18);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status:";
            // 
            // lblSpecies
            // 
            this.lblSpecies.AutoSize = true;
            this.lblSpecies.Location = new System.Drawing.Point(27, 222);
            this.lblSpecies.Name = "lblSpecies";
            this.lblSpecies.Size = new System.Drawing.Size(65, 18);
            this.lblSpecies.TabIndex = 14;
            this.lblSpecies.Text = "Species:";
            // 
            // lblHousing
            // 
            this.lblHousing.AutoSize = true;
            this.lblHousing.Location = new System.Drawing.Point(29, 415);
            this.lblHousing.Name = "lblHousing";
            this.lblHousing.Size = new System.Drawing.Size(97, 18);
            this.lblHousing.TabIndex = 15;
            this.lblHousing.Text = "Housing Unit:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 463);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(192, 71);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Save New Record";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 553);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(190, 71);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update Record";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(210, 463);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(188, 71);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete Record";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSummary
            // 
            this.btnSummary.Location = new System.Drawing.Point(210, 553);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(188, 71);
            this.btnSummary.TabIndex = 20;
            this.btnSummary.Text = "Create Summary";
            this.btnSummary.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 656);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblHousing);
            this.Controls.Add(this.lblSpecies);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAnimalID);
            this.Controls.Add(this.txtHousing);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtSpecies);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtAnimalID);
            this.Controls.Add(this.dgvDataDisplay);
            this.Controls.Add(this.lblBanner);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "DashBoard";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBanner;
        private System.Windows.Forms.DataGridView dgvDataDisplay;
        private System.Windows.Forms.TextBox txtAnimalID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSpecies;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtHousing;
        private System.Windows.Forms.Label lblAnimalID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSpecies;
        private System.Windows.Forms.Label lblHousing;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSummary;
    }
}

