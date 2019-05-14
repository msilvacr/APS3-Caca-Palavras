namespace APS3_CacaPalavras.View
{
    partial class FormJogoControles
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJogoControles));
            this.dataGridPalavrasJogo = new System.Windows.Forms.DataGridView();
            this.Palavras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPause = new System.Windows.Forms.Button();
            this.txtDuracao = new System.Windows.Forms.TextBox();
            this.timerJogo = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPalavrasJogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPalavrasJogo
            // 
            this.dataGridPalavrasJogo.AllowUserToAddRows = false;
            this.dataGridPalavrasJogo.AllowUserToDeleteRows = false;
            this.dataGridPalavrasJogo.AllowUserToResizeColumns = false;
            this.dataGridPalavrasJogo.AllowUserToResizeRows = false;
            this.dataGridPalavrasJogo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridPalavrasJogo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPalavrasJogo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridPalavrasJogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPalavrasJogo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Palavras});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridPalavrasJogo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridPalavrasJogo.Location = new System.Drawing.Point(12, 170);
            this.dataGridPalavrasJogo.Name = "dataGridPalavrasJogo";
            this.dataGridPalavrasJogo.ReadOnly = true;
            this.dataGridPalavrasJogo.RowHeadersVisible = false;
            this.dataGridPalavrasJogo.Size = new System.Drawing.Size(307, 504);
            this.dataGridPalavrasJogo.TabIndex = 0;
            // 
            // Palavras
            // 
            this.Palavras.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Palavras.HeaderText = "Palavras";
            this.Palavras.Name = "Palavras";
            this.Palavras.ReadOnly = true;
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(73, 106);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(187, 48);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pausar";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // txtDuracao
            // 
            this.txtDuracao.BackColor = System.Drawing.SystemColors.Control;
            this.txtDuracao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDuracao.Cursor = System.Windows.Forms.Cursors.No;
            this.txtDuracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuracao.Location = new System.Drawing.Point(12, 26);
            this.txtDuracao.Name = "txtDuracao";
            this.txtDuracao.Size = new System.Drawing.Size(307, 62);
            this.txtDuracao.TabIndex = 2;
            this.txtDuracao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerJogo
            // 
            this.timerJogo.Interval = 1000;
            this.timerJogo.Tick += new System.EventHandler(this.timerJogo_Tick);
            // 
            // FormJogoControles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 686);
            this.Controls.Add(this.txtDuracao);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.dataGridPalavrasJogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJogoControles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Painel";
            this.Load += new System.EventHandler(this.FormJogoControles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPalavrasJogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPalavrasJogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Palavras;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Timer timerJogo;
        private System.Windows.Forms.TextBox txtDuracao;
    }
}