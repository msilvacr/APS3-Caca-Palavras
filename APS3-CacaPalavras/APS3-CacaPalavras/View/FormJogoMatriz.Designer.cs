﻿namespace APS3_CacaPalavras.View
{
    partial class FormJogoMatriz
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJogoMatriz));
            this.dataGridJogo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridJogo
            // 
            this.dataGridJogo.AllowUserToAddRows = false;
            this.dataGridJogo.AllowUserToDeleteRows = false;
            this.dataGridJogo.AllowUserToResizeColumns = false;
            this.dataGridJogo.AllowUserToResizeRows = false;
            this.dataGridJogo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridJogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridJogo.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridJogo.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridJogo.Location = new System.Drawing.Point(10, 10);
            this.dataGridJogo.Name = "dataGridJogo";
            this.dataGridJogo.ReadOnly = true;
            this.dataGridJogo.RowHeadersVisible = false;
            this.dataGridJogo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridJogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridJogo.Size = new System.Drawing.Size(635, 635);
            this.dataGridJogo.TabIndex = 0;
            this.dataGridJogo.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridJogo_CellMouseDown);
            this.dataGridJogo.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridJogo_CellMouseMove);
            this.dataGridJogo.SelectionChanged += new System.EventHandler(this.dataGridJogo_SelectionChanged);
            this.dataGridJogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridJogo_MouseUp);
            // 
            // FormJogoMatriz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 656);
            this.Controls.Add(this.dataGridJogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJogoMatriz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormJogoMatriz_FormClosing);
            this.Load += new System.EventHandler(this.FrmJogo_Load);
            this.LocationChanged += new System.EventHandler(this.FormJogoMatriz_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridJogo;
    }
}