namespace APS3_CacaPalavras.View
{
    partial class FormAlterarDados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlterarDados));
            this.panelSteps1 = new System.Windows.Forms.Panel();
            this.labelNomeSteps1 = new System.Windows.Forms.Label();
            this.labelTelefoneSteps1 = new System.Windows.Forms.Label();
            this.labelDtNascimentoSteps1 = new System.Windows.Forms.Label();
            this.txtDtNascimento = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtNome = new APS3_CacaPalavras.Util.TextboxMarcaDAgua();
            this.panelSteps1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSteps1
            // 
            this.panelSteps1.Controls.Add(this.labelNomeSteps1);
            this.panelSteps1.Controls.Add(this.labelTelefoneSteps1);
            this.panelSteps1.Controls.Add(this.labelDtNascimentoSteps1);
            this.panelSteps1.Controls.Add(this.txtDtNascimento);
            this.panelSteps1.Controls.Add(this.btnCancelar);
            this.panelSteps1.Controls.Add(this.txtTelefone);
            this.panelSteps1.Controls.Add(this.btnSalvar);
            this.panelSteps1.Controls.Add(this.txtNome);
            this.panelSteps1.Location = new System.Drawing.Point(5, 7);
            this.panelSteps1.Name = "panelSteps1";
            this.panelSteps1.Size = new System.Drawing.Size(318, 295);
            this.panelSteps1.TabIndex = 18;
            // 
            // labelNomeSteps1
            // 
            this.labelNomeSteps1.AutoSize = true;
            this.labelNomeSteps1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeSteps1.Location = new System.Drawing.Point(3, 4);
            this.labelNomeSteps1.Name = "labelNomeSteps1";
            this.labelNomeSteps1.Size = new System.Drawing.Size(140, 20);
            this.labelNomeSteps1.TabIndex = 13;
            this.labelNomeSteps1.Text = "Atualize seu nome";
            // 
            // labelTelefoneSteps1
            // 
            this.labelTelefoneSteps1.AutoSize = true;
            this.labelTelefoneSteps1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTelefoneSteps1.Location = new System.Drawing.Point(6, 124);
            this.labelTelefoneSteps1.Name = "labelTelefoneSteps1";
            this.labelTelefoneSteps1.Size = new System.Drawing.Size(158, 20);
            this.labelTelefoneSteps1.TabIndex = 13;
            this.labelTelefoneSteps1.Text = "Atualize seu telefone";
            // 
            // labelDtNascimentoSteps1
            // 
            this.labelDtNascimentoSteps1.AutoSize = true;
            this.labelDtNascimentoSteps1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDtNascimentoSteps1.Location = new System.Drawing.Point(6, 64);
            this.labelDtNascimentoSteps1.Name = "labelDtNascimentoSteps1";
            this.labelDtNascimentoSteps1.Size = new System.Drawing.Size(240, 20);
            this.labelDtNascimentoSteps1.TabIndex = 13;
            this.labelDtNascimentoSteps1.Text = "Atualize sua data de nascimento";
            // 
            // txtDtNascimento
            // 
            this.txtDtNascimento.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDtNascimento.Location = new System.Drawing.Point(9, 89);
            this.txtDtNascimento.Name = "txtDtNascimento";
            this.txtDtNascimento.Size = new System.Drawing.Size(300, 29);
            this.txtDtNascimento.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(81)))), ((int)(((byte)(51)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(10, 242);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(299, 38);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.btnCancelar_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            // 
            // txtTelefone
            // 
            this.txtTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefone.Location = new System.Drawing.Point(10, 149);
            this.txtTelefone.Mask = "(99) 0 0000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(154, 29);
            this.txtTelefone.TabIndex = 3;
            this.txtTelefone.Enter += new System.EventHandler(this.txtTelefone_Enter);
            this.txtTelefone.Leave += new System.EventHandler(this.txtTelefone_Leave);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(65)))), ((int)(((byte)(84)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(10, 195);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(299, 38);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseEnter += new System.EventHandler(this.btnSalvar_MouseEnter_1);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave_1);
            // 
            // txtNome
            // 
            this.txtNome.ColorTextoVacio = System.Drawing.Color.Gray;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(9, 29);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 29);
            this.txtNome.TabIndex = 1;
            this.txtNome.TextoVacio = "Insira seu nome";
            this.txtNome.Enter += new System.EventHandler(this.txtNome_Enter);
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // FormAlterarDados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 309);
            this.Controls.Add(this.panelSteps1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAlterarDados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Woopy! - Alterar dados";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panelSteps1.ResumeLayout(false);
            this.panelSteps1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSteps1;
        private System.Windows.Forms.Label labelNomeSteps1;
        private System.Windows.Forms.Label labelTelefoneSteps1;
        private System.Windows.Forms.Label labelDtNascimentoSteps1;
        private System.Windows.Forms.DateTimePicker txtDtNascimento;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.Button btnSalvar;
        private Util.TextboxMarcaDAgua txtNome;
    }
}