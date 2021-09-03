namespace MedicAPP
{
    partial class frmConsultas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultas));
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevaConsulta = new System.Windows.Forms.Button();
            this.btnConsultaporCita = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.label1.Location = new System.Drawing.Point(39, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "CONSULTAS";
            // 
            // btnNuevaConsulta
            // 
            this.btnNuevaConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnNuevaConsulta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnNuevaConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaConsulta.Font = new System.Drawing.Font("Century Gothic", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaConsulta.ForeColor = System.Drawing.Color.White;
            this.btnNuevaConsulta.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaConsulta.Image")));
            this.btnNuevaConsulta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevaConsulta.Location = new System.Drawing.Point(132, 123);
            this.btnNuevaConsulta.Margin = new System.Windows.Forms.Padding(0);
            this.btnNuevaConsulta.Name = "btnNuevaConsulta";
            this.btnNuevaConsulta.Size = new System.Drawing.Size(196, 123);
            this.btnNuevaConsulta.TabIndex = 12;
            this.btnNuevaConsulta.Text = "NUEVA CONSULTA";
            this.btnNuevaConsulta.UseVisualStyleBackColor = false;
            // 
            // btnConsultaporCita
            // 
            this.btnConsultaporCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnConsultaporCita.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.btnConsultaporCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaporCita.Font = new System.Drawing.Font("Century Gothic", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultaporCita.ForeColor = System.Drawing.Color.White;
            this.btnConsultaporCita.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultaporCita.Image")));
            this.btnConsultaporCita.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConsultaporCita.Location = new System.Drawing.Point(606, 123);
            this.btnConsultaporCita.Margin = new System.Windows.Forms.Padding(0);
            this.btnConsultaporCita.Name = "btnConsultaporCita";
            this.btnConsultaporCita.Size = new System.Drawing.Size(196, 123);
            this.btnConsultaporCita.TabIndex = 13;
            this.btnConsultaporCita.Text = "CONSULTA POR CITA";
            this.btnConsultaporCita.UseVisualStyleBackColor = false;
            // 
            // frmConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 665);
            this.Controls.Add(this.btnConsultaporCita);
            this.Controls.Add(this.btnNuevaConsulta);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConsultas";
            this.Text = "frmConsultas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNuevaConsulta;
        private System.Windows.Forms.Button btnConsultaporCita;
    }
}