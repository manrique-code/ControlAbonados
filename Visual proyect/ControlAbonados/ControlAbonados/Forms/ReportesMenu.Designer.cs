﻿
namespace ControlAbonados.Forms
{
    partial class ReportesMenu
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
            this.pnlAbonados = new System.Windows.Forms.Panel();
            this.btnAbonado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAbonados = new System.Windows.Forms.Label();
            this.lblTituloAbonados = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnActivos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.btnMes = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.btnEstado = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pgbTodoAbonados = new System.Windows.Forms.ProgressBar();
            this.pgbAbonadosActivos = new System.Windows.Forms.ProgressBar();
            this.pgbMes = new System.Windows.Forms.ProgressBar();
            this.pgbEstado = new System.Windows.Forms.ProgressBar();
            this.pnlAbonados.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAbonados
            // 
            this.pnlAbonados.BackColor = System.Drawing.Color.White;
            this.pnlAbonados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAbonados.Controls.Add(this.btnAbonado);
            this.pnlAbonados.Controls.Add(this.label1);
            this.pnlAbonados.Controls.Add(this.lblAbonados);
            this.pnlAbonados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAbonados.Location = new System.Drawing.Point(38, 89);
            this.pnlAbonados.Name = "pnlAbonados";
            this.pnlAbonados.Size = new System.Drawing.Size(300, 200);
            this.pnlAbonados.TabIndex = 6;
            // 
            // btnAbonado
            // 
            this.btnAbonado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbonado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAbonado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbonado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbonado.Font = new System.Drawing.Font("Product Sans Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbonado.ForeColor = System.Drawing.Color.White;
            this.btnAbonado.Location = new System.Drawing.Point(148, 128);
            this.btnAbonado.Name = "btnAbonado";
            this.btnAbonado.Size = new System.Drawing.Size(130, 50);
            this.btnAbonado.TabIndex = 2;
            this.btnAbonado.Text = "Generar";
            this.btnAbonado.UseVisualStyleBackColor = false;
            this.btnAbonado.Click += new System.EventHandler(this.btnAbonado_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Product Sans Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(22, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 61);
            this.label1.TabIndex = 1;
            this.label1.Text = "Todos los abonados existentes";
            // 
            // lblAbonados
            // 
            this.lblAbonados.AutoSize = true;
            this.lblAbonados.Font = new System.Drawing.Font("Product Sans Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbonados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblAbonados.Location = new System.Drawing.Point(20, 20);
            this.lblAbonados.Name = "lblAbonados";
            this.lblAbonados.Size = new System.Drawing.Size(227, 34);
            this.lblAbonados.TabIndex = 0;
            this.lblAbonados.Text = "Listado abonados";
            // 
            // lblTituloAbonados
            // 
            this.lblTituloAbonados.AutoSize = true;
            this.lblTituloAbonados.Font = new System.Drawing.Font("Product Sans Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAbonados.Location = new System.Drawing.Point(32, 32);
            this.lblTituloAbonados.Name = "lblTituloAbonados";
            this.lblTituloAbonados.Size = new System.Drawing.Size(241, 34);
            this.lblTituloAbonados.TabIndex = 7;
            this.lblTituloAbonados.Text = "Control abonados";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnActivos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(365, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 200);
            this.panel1.TabIndex = 7;
            // 
            // btnActivos
            // 
            this.btnActivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnActivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivos.Font = new System.Drawing.Font("Product Sans Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivos.ForeColor = System.Drawing.Color.White;
            this.btnActivos.Location = new System.Drawing.Point(148, 128);
            this.btnActivos.Name = "btnActivos";
            this.btnActivos.Size = new System.Drawing.Size(130, 50);
            this.btnActivos.TabIndex = 2;
            this.btnActivos.Text = "Generar";
            this.btnActivos.UseVisualStyleBackColor = false;
            this.btnActivos.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Product Sans Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(22, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Solo abonados activos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Product Sans Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label3.Location = new System.Drawing.Point(20, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 34);
            this.label3.TabIndex = 0;
            this.label3.Text = "Reporte activos";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cboMes);
            this.panel2.Controls.Add(this.btnMes);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(692, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 200);
            this.panel2.TabIndex = 7;
            // 
            // cboMes
            // 
            this.cboMes.BackColor = System.Drawing.Color.White;
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMes.Font = new System.Drawing.Font("Product Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(26, 90);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(254, 29);
            this.cboMes.TabIndex = 9;
            // 
            // btnMes
            // 
            this.btnMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnMes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMes.Font = new System.Drawing.Font("Product Sans Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMes.ForeColor = System.Drawing.Color.White;
            this.btnMes.Location = new System.Drawing.Point(148, 128);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(130, 50);
            this.btnMes.TabIndex = 2;
            this.btnMes.Text = "Generar";
            this.btnMes.UseVisualStyleBackColor = false;
            this.btnMes.Click += new System.EventHandler(this.btnMes_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Product Sans Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(22, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Abonados que tengan pagado hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Product Sans Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label5.Location = new System.Drawing.Point(20, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 34);
            this.label5.TabIndex = 0;
            this.label5.Text = "Reporte mes";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cboEstado);
            this.panel3.Controls.Add(this.btnEstado);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(1019, 89);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 200);
            this.panel3.TabIndex = 8;
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.White;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEstado.Font = new System.Drawing.Font("Product Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(23, 86);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(254, 29);
            this.cboEstado.TabIndex = 10;
            // 
            // btnEstado
            // 
            this.btnEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstado.Font = new System.Drawing.Font("Product Sans Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstado.ForeColor = System.Drawing.Color.White;
            this.btnEstado.Location = new System.Drawing.Point(148, 128);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(130, 50);
            this.btnEstado.TabIndex = 2;
            this.btnEstado.Text = "Generar";
            this.btnEstado.UseVisualStyleBackColor = false;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Product Sans Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(22, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Abonados que están:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Product Sans Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label7.Location = new System.Drawing.Point(20, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 34);
            this.label7.TabIndex = 0;
            this.label7.Text = "Reporte estado";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::ControlAbonados.Properties.Resources.home_negro_512;
            this.pictureBox1.Location = new System.Drawing.Point(1279, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pgbTodoAbonados
            // 
            this.pgbTodoAbonados.Location = new System.Drawing.Point(38, 295);
            this.pgbTodoAbonados.Name = "pgbTodoAbonados";
            this.pgbTodoAbonados.Size = new System.Drawing.Size(300, 24);
            this.pgbTodoAbonados.TabIndex = 9;
            this.pgbTodoAbonados.Visible = false;
            // 
            // pgbAbonadosActivos
            // 
            this.pgbAbonadosActivos.Location = new System.Drawing.Point(365, 295);
            this.pgbAbonadosActivos.Name = "pgbAbonadosActivos";
            this.pgbAbonadosActivos.Size = new System.Drawing.Size(300, 24);
            this.pgbAbonadosActivos.TabIndex = 10;
            this.pgbAbonadosActivos.Visible = false;
            // 
            // pgbMes
            // 
            this.pgbMes.Location = new System.Drawing.Point(692, 295);
            this.pgbMes.Name = "pgbMes";
            this.pgbMes.Size = new System.Drawing.Size(300, 24);
            this.pgbMes.TabIndex = 11;
            this.pgbMes.Visible = false;
            // 
            // pgbEstado
            // 
            this.pgbEstado.Location = new System.Drawing.Point(1019, 295);
            this.pgbEstado.Name = "pgbEstado";
            this.pgbEstado.Size = new System.Drawing.Size(300, 24);
            this.pgbEstado.TabIndex = 12;
            this.pgbEstado.Visible = false;
            // 
            // ReportesMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.pgbEstado);
            this.Controls.Add(this.pgbMes);
            this.Controls.Add(this.pgbAbonadosActivos);
            this.Controls.Add(this.pgbTodoAbonados);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTituloAbonados);
            this.Controls.Add(this.pnlAbonados);
            this.Name = "ReportesMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportesMenu";
            this.Load += new System.EventHandler(this.ReportesMenu_Load);
            this.pnlAbonados.ResumeLayout(false);
            this.pnlAbonados.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAbonados;
        private System.Windows.Forms.Button btnAbonado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAbonados;
        private System.Windows.Forms.Label lblTituloAbonados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnActivos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnEstado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.ProgressBar pgbTodoAbonados;
        private System.Windows.Forms.ProgressBar pgbAbonadosActivos;
        private System.Windows.Forms.ProgressBar pgbMes;
        private System.Windows.Forms.ProgressBar pgbEstado;
    }
}