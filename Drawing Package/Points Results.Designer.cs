﻿namespace Drawing_Package
{
    partial class Points_Results
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableResults = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(482, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 9;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 8;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 7;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 6;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tableResults
            // 
            this.tableResults.ColumnCount = 4;
            this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableResults.Location = new System.Drawing.Point(63, 48);
            this.tableResults.Name = "tableResults";
            this.tableResults.RowCount = 1;
            this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableResults.Size = new System.Drawing.Size(712, 887);
            this.tableResults.TabIndex = 5;
            this.tableResults.Paint += new System.Windows.Forms.PaintEventHandler(this.tableResults_Paint);
            // 
            // Points_Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 983);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableResults);
            this.Name = "Points_Results";
            this.Text = "Points_Results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableResults;
    }
}