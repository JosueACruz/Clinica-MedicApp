namespace MedicAPP
{
    partial class frmMedicamentoNuevo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicamentoNuevo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.btnPresentacion = new System.Windows.Forms.Button();
            this.btnLaboratorio = new System.Windows.Forms.Button();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnListaMedicamentos = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.label1.Location = new System.Drawing.Point(64, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "NUEVO MEDICAMENTO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.label2.Location = new System.Drawing.Point(64, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "*Nombres de Medicamento:";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 10.25F);
            this.txtNombre.Location = new System.Drawing.Point(300, 93);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(464, 33);
            this.txtNombre.TabIndex = 14;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(568, 376);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(196, 33);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.label3.Location = new System.Drawing.Point(64, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "Laboratorio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.label4.Location = new System.Drawing.Point(64, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "Presentacion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.label5.Location = new System.Drawing.Point(64, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "Categoria:";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(300, 175);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(464, 28);
            this.comboBox1.TabIndex = 76;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(300, 233);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(464, 28);
            this.comboBox2.TabIndex = 77;
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(300, 300);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(464, 28);
            this.comboBox3.TabIndex = 78;
            // 
            // btnPresentacion
            // 
            this.btnPresentacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnPresentacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnPresentacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresentacion.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.btnPresentacion.ForeColor = System.Drawing.Color.White;
            this.btnPresentacion.Image = ((System.Drawing.Image)(resources.GetObject("btnPresentacion.Image")));
            this.btnPresentacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPresentacion.Location = new System.Drawing.Point(786, 230);
            this.btnPresentacion.Margin = new System.Windows.Forms.Padding(0);
            this.btnPresentacion.Name = "btnPresentacion";
            this.btnPresentacion.Size = new System.Drawing.Size(196, 33);
            this.btnPresentacion.TabIndex = 79;
            this.btnPresentacion.Text = "BUSCAR PRESENTACION";
            this.btnPresentacion.UseVisualStyleBackColor = false;
            // 
            // btnLaboratorio
            // 
            this.btnLaboratorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnLaboratorio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnLaboratorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaboratorio.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.btnLaboratorio.ForeColor = System.Drawing.Color.White;
            this.btnLaboratorio.Image = ((System.Drawing.Image)(resources.GetObject("btnLaboratorio.Image")));
            this.btnLaboratorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaboratorio.Location = new System.Drawing.Point(786, 172);
            this.btnLaboratorio.Margin = new System.Windows.Forms.Padding(0);
            this.btnLaboratorio.Name = "btnLaboratorio";
            this.btnLaboratorio.Size = new System.Drawing.Size(196, 33);
            this.btnLaboratorio.TabIndex = 80;
            this.btnLaboratorio.Text = "BUSCAR LABORATORIO";
            this.btnLaboratorio.UseVisualStyleBackColor = false;
            this.btnLaboratorio.Click += new System.EventHandler(this.btnLaboratorio_Click);
            // 
            // btnCategoria
            // 
            this.btnCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnCategoria.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoria.Font = new System.Drawing.Font("Century Gothic", 9.25F);
            this.btnCategoria.ForeColor = System.Drawing.Color.White;
            this.btnCategoria.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoria.Image")));
            this.btnCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoria.Location = new System.Drawing.Point(786, 295);
            this.btnCategoria.Margin = new System.Windows.Forms.Padding(0);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(196, 33);
            this.btnCategoria.TabIndex = 81;
            this.btnCategoria.Text = "BUSCAR CATEGORIA";
            this.btnCategoria.UseVisualStyleBackColor = false;
            // 
            // btnListaMedicamentos
            // 
            this.btnListaMedicamentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnListaMedicamentos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnListaMedicamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListaMedicamentos.Font = new System.Drawing.Font("Century Gothic", 9.25F);
            this.btnListaMedicamentos.ForeColor = System.Drawing.Color.White;
            this.btnListaMedicamentos.Image = ((System.Drawing.Image)(resources.GetObject("btnListaMedicamentos.Image")));
            this.btnListaMedicamentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListaMedicamentos.Location = new System.Drawing.Point(348, 376);
            this.btnListaMedicamentos.Margin = new System.Windows.Forms.Padding(0);
            this.btnListaMedicamentos.Name = "btnListaMedicamentos";
            this.btnListaMedicamentos.Size = new System.Drawing.Size(196, 33);
            this.btnListaMedicamentos.TabIndex = 82;
            this.btnListaMedicamentos.Text = "LISTA MEDICAMENTOS";
            this.btnListaMedicamentos.UseVisualStyleBackColor = false;
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnAtras.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Century Gothic", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras.Image")));
            this.btnAtras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtras.Location = new System.Drawing.Point(941, 9);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(0);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(41, 33);
            this.btnAtras.TabIndex = 83;
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // frmMedicamentoNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 665);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnListaMedicamentos);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.btnLaboratorio);
            this.Controls.Add(this.btnPresentacion);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMedicamentoNuevo";
            this.Text = "frmMedicamentoNuevo";
            this.Load += new System.EventHandler(this.frmMedicamentoNuevo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button btnPresentacion;
        private System.Windows.Forms.Button btnLaboratorio;
        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Button btnListaMedicamentos;
        private System.Windows.Forms.Button btnAtras;
    }
}