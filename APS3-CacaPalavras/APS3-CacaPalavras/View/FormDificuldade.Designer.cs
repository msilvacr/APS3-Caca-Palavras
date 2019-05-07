namespace APS3_CacaPalavras.View
{
    partial class FormDificuldade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDificuldade));
            this.label2 = new System.Windows.Forms.Label();
            this.btnDificil = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFacil = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnInsano = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 80);
            this.label2.TabIndex = 23;
            this.label2.Text = "Selecione a\r\ndificuldade";
            // 
            // btnDificil
            // 
            this.btnDificil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(81)))), ((int)(((byte)(51)))));
            this.btnDificil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDificil.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDificil.ForeColor = System.Drawing.Color.White;
            this.btnDificil.Location = new System.Drawing.Point(12, 156);
            this.btnDificil.Name = "btnDificil";
            this.btnDificil.Size = new System.Drawing.Size(247, 46);
            this.btnDificil.TabIndex = 22;
            this.btnDificil.Text = "Dificil";
            this.btnDificil.UseVisualStyleBackColor = false;
            this.btnDificil.Click += new System.EventHandler(this.btnDificil_Click);
            this.btnDificil.MouseEnter += new System.EventHandler(this.btnDificil_MouseEnter);
            this.btnDificil.MouseLeave += new System.EventHandler(this.btnDificil_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::APS3_CacaPalavras.Properties.Resources.model1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnFacil
            // 
            this.btnFacil.BackColor = System.Drawing.Color.Green;
            this.btnFacil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFacil.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacil.ForeColor = System.Drawing.Color.White;
            this.btnFacil.Location = new System.Drawing.Point(12, 280);
            this.btnFacil.Name = "btnFacil";
            this.btnFacil.Size = new System.Drawing.Size(247, 46);
            this.btnFacil.TabIndex = 20;
            this.btnFacil.Text = "Fácil";
            this.btnFacil.UseVisualStyleBackColor = false;
            this.btnFacil.Click += new System.EventHandler(this.btnFacil_Click);
            this.btnFacil.MouseEnter += new System.EventHandler(this.btnFacil_MouseEnter);
            this.btnFacil.MouseLeave += new System.EventHandler(this.btnFacil_MouseLeave);
            // 
            // btnNormal
            // 
            this.btnNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(65)))), ((int)(((byte)(84)))));
            this.btnNormal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNormal.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNormal.ForeColor = System.Drawing.Color.White;
            this.btnNormal.Location = new System.Drawing.Point(12, 218);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(247, 46);
            this.btnNormal.TabIndex = 19;
            this.btnNormal.Text = "Normal";
            this.btnNormal.UseVisualStyleBackColor = false;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            this.btnNormal.MouseEnter += new System.EventHandler(this.btnNormal_MouseEnter);
            this.btnNormal.MouseLeave += new System.EventHandler(this.btnNormal_MouseLeave);
            // 
            // btnInsano
            // 
            this.btnInsano.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInsano.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInsano.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsano.ForeColor = System.Drawing.Color.White;
            this.btnInsano.Location = new System.Drawing.Point(12, 95);
            this.btnInsano.Name = "btnInsano";
            this.btnInsano.Size = new System.Drawing.Size(247, 46);
            this.btnInsano.TabIndex = 22;
            this.btnInsano.Text = "INSANO";
            this.btnInsano.UseVisualStyleBackColor = false;
            this.btnInsano.Click += new System.EventHandler(this.btnInsano_Click);
            this.btnInsano.MouseEnter += new System.EventHandler(this.btnInsano_MouseEnter);
            this.btnInsano.MouseLeave += new System.EventHandler(this.btnInsano_MouseLeave);
            // 
            // FormDificuldade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 345);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnInsano);
            this.Controls.Add(this.btnDificil);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFacil);
            this.Controls.Add(this.btnNormal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDificuldade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Woopy! - Novo Jogo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDificil;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnFacil;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnInsano;
    }
}