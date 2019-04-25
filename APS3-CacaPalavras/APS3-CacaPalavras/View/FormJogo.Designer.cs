namespace APS3_CacaPalavras.View
{
    partial class FormJogo
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
            this.dataGridJogo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridJogo
            // 
            this.dataGridJogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridJogo.ColumnHeadersVisible = false;
            this.dataGridJogo.Location = new System.Drawing.Point(12, 50);
            this.dataGridJogo.Name = "dataGridJogo";
            this.dataGridJogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridJogo.Size = new System.Drawing.Size(622, 412);
            this.dataGridJogo.TabIndex = 0;
            this.dataGridJogo.SelectionChanged += new System.EventHandler(this.dataGridJogo_SelectionChanged);
            // 
            // FormJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 474);
            this.Controls.Add(this.dataGridJogo);
            this.Name = "FormJogo";
            this.Text = "FrmJogo";
            this.Load += new System.EventHandler(this.FrmJogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridJogo;
    }
}