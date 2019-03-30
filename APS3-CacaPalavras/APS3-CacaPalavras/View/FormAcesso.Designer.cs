namespace APS3_CacaPalavras.View
{
    partial class FormAcesso
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textboxMarcaDAgua1 = new APS3_CacaPalavras.Util.TextboxMarcaDAgua();
            this.textboxMarcaDAgua2 = new APS3_CacaPalavras.Util.TextboxMarcaDAgua();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(305, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(305, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textboxMarcaDAgua1
            // 
            this.textboxMarcaDAgua1.ColorTextoVacio = System.Drawing.Color.Gray;
            this.textboxMarcaDAgua1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxMarcaDAgua1.Location = new System.Drawing.Point(12, 83);
            this.textboxMarcaDAgua1.Name = "textboxMarcaDAgua1";
            this.textboxMarcaDAgua1.Size = new System.Drawing.Size(305, 29);
            this.textboxMarcaDAgua1.TabIndex = 2;
            this.textboxMarcaDAgua1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textboxMarcaDAgua1.TextoVacio = "Email";
            // 
            // textboxMarcaDAgua2
            // 
            this.textboxMarcaDAgua2.ColorTextoVacio = System.Drawing.Color.Gray;
            this.textboxMarcaDAgua2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxMarcaDAgua2.Location = new System.Drawing.Point(12, 127);
            this.textboxMarcaDAgua2.Name = "textboxMarcaDAgua2";
            this.textboxMarcaDAgua2.Size = new System.Drawing.Size(305, 29);
            this.textboxMarcaDAgua2.TabIndex = 3;
            this.textboxMarcaDAgua2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textboxMarcaDAgua2.TextoVacio = "Senha";
            // 
            // FormAcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 342);
            this.Controls.Add(this.textboxMarcaDAgua2);
            this.Controls.Add(this.textboxMarcaDAgua1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FormAcesso";
            this.Text = "FormÃcesso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Util.TextboxMarcaDAgua textboxMarcaDAgua1;
        private Util.TextboxMarcaDAgua textboxMarcaDAgua2;
    }
}