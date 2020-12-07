
namespace ControlAbonados
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlAbonados = new System.Windows.Forms.Panel();
            this.btnAbonado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAbonados = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTituloAbonados = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReportes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblReportes = new System.Windows.Forms.Label();
            this.lblHeaderDatos = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAbonadosCisterna = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblAbonadosNormales = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAbonadosTercerEdad = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblAbonadosInactivos = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblAbonadosActivos = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblPorcentajeAbonadosPago = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlAbonados.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAbonados
            // 
            this.pnlAbonados.BackColor = System.Drawing.Color.White;
            this.pnlAbonados.Controls.Add(this.btnAbonado);
            this.pnlAbonados.Controls.Add(this.label1);
            this.pnlAbonados.Controls.Add(this.lblAbonados);
            this.pnlAbonados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAbonados.Location = new System.Drawing.Point(46, 90);
            this.pnlAbonados.Name = "pnlAbonados";
            this.pnlAbonados.Size = new System.Drawing.Size(300, 200);
            this.pnlAbonados.TabIndex = 5;
            this.pnlAbonados.Click += new System.EventHandler(this.pnlAbonados_Click);
            // 
            // btnAbonado
            // 
            this.btnAbonado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbonado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAbonado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbonado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbonado.Font = new System.Drawing.Font("Product Sans Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbonado.ForeColor = System.Drawing.Color.White;
            this.btnAbonado.Location = new System.Drawing.Point(150, 130);
            this.btnAbonado.Name = "btnAbonado";
            this.btnAbonado.Size = new System.Drawing.Size(130, 50);
            this.btnAbonado.TabIndex = 2;
            this.btnAbonado.Text = "Entrar";
            this.btnAbonado.UseVisualStyleBackColor = false;
            this.btnAbonado.Click += new System.EventHandler(this.btnAbonado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Product Sans Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(21, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ver listados o añadir abonados";
            // 
            // lblAbonados
            // 
            this.lblAbonados.AutoSize = true;
            this.lblAbonados.Font = new System.Drawing.Font("Product Sans Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbonados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblAbonados.Location = new System.Drawing.Point(20, 20);
            this.lblAbonados.Name = "lblAbonados";
            this.lblAbonados.Size = new System.Drawing.Size(138, 34);
            this.lblAbonados.TabIndex = 0;
            this.lblAbonados.Text = "Abonados";
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Product Sans Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(1172, 32);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(126, 34);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "[FECHA]";
            // 
            // lblTituloAbonados
            // 
            this.lblTituloAbonados.AutoSize = true;
            this.lblTituloAbonados.Font = new System.Drawing.Font("Product Sans Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAbonados.Location = new System.Drawing.Point(40, 32);
            this.lblTituloAbonados.Name = "lblTituloAbonados";
            this.lblTituloAbonados.Size = new System.Drawing.Size(241, 34);
            this.lblTituloAbonados.TabIndex = 3;
            this.lblTituloAbonados.Text = "Control abonados";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnReportes);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblReportes);
            this.panel1.Location = new System.Drawing.Point(434, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 200);
            this.panel1.TabIndex = 6;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Product Sans Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(150, 130);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(130, 50);
            this.btnReportes.TabIndex = 2;
            this.btnReportes.Text = "Entrar";
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Product Sans Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(21, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ver listados o añadir abonados";
            // 
            // lblReportes
            // 
            this.lblReportes.AutoSize = true;
            this.lblReportes.Font = new System.Drawing.Font("Product Sans Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblReportes.Location = new System.Drawing.Point(20, 20);
            this.lblReportes.Name = "lblReportes";
            this.lblReportes.Size = new System.Drawing.Size(126, 34);
            this.lblReportes.TabIndex = 0;
            this.lblReportes.Text = "Reportes";
            // 
            // lblHeaderDatos
            // 
            this.lblHeaderDatos.AutoSize = true;
            this.lblHeaderDatos.Font = new System.Drawing.Font("Product Sans Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderDatos.Location = new System.Drawing.Point(40, 333);
            this.lblHeaderDatos.Name = "lblHeaderDatos";
            this.lblHeaderDatos.Size = new System.Drawing.Size(221, 34);
            this.lblHeaderDatos.TabIndex = 7;
            this.lblHeaderDatos.Text = "Datos abonados";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblAbonadosCisterna);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.lblAbonadosNormales);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.lblAbonadosTercerEdad);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.lblAbonadosInactivos);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.lblAbonadosActivos);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.lblPorcentajeAbonadosPago);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(46, 390);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1252, 300);
            this.panel2.TabIndex = 8;
            // 
            // lblAbonadosCisterna
            // 
            this.lblAbonadosCisterna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAbonadosCisterna.AutoSize = true;
            this.lblAbonadosCisterna.Font = new System.Drawing.Font("Product Sans Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbonadosCisterna.ForeColor = System.Drawing.Color.Black;
            this.lblAbonadosCisterna.Location = new System.Drawing.Point(1027, 70);
            this.lblAbonadosCisterna.Name = "lblAbonadosCisterna";
            this.lblAbonadosCisterna.Size = new System.Drawing.Size(175, 34);
            this.lblAbonadosCisterna.TabIndex = 16;
            this.lblAbonadosCisterna.Text = "[0] abonados";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Product Sans Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Gray;
            this.label14.Location = new System.Drawing.Point(1029, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 24);
            this.label14.TabIndex = 15;
            this.label14.Text = "Cisterna";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel7.BackColor = System.Drawing.Color.Silver;
            this.panel7.Location = new System.Drawing.Point(1008, 30);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1, 85);
            this.panel7.TabIndex = 7;
            // 
            // lblAbonadosNormales
            // 
            this.lblAbonadosNormales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAbonadosNormales.AutoSize = true;
            this.lblAbonadosNormales.Font = new System.Drawing.Font("Product Sans Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbonadosNormales.ForeColor = System.Drawing.Color.Black;
            this.lblAbonadosNormales.Location = new System.Drawing.Point(796, 201);
            this.lblAbonadosNormales.Name = "lblAbonadosNormales";
            this.lblAbonadosNormales.Size = new System.Drawing.Size(175, 34);
            this.lblAbonadosNormales.TabIndex = 14;
            this.lblAbonadosNormales.Text = "[0] abonados";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Product Sans Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(798, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 24);
            this.label12.TabIndex = 13;
            this.label12.Text = "Normales";
            // 
            // lblAbonadosTercerEdad
            // 
            this.lblAbonadosTercerEdad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAbonadosTercerEdad.AutoSize = true;
            this.lblAbonadosTercerEdad.Font = new System.Drawing.Font("Product Sans Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbonadosTercerEdad.ForeColor = System.Drawing.Color.Black;
            this.lblAbonadosTercerEdad.Location = new System.Drawing.Point(796, 70);
            this.lblAbonadosTercerEdad.Name = "lblAbonadosTercerEdad";
            this.lblAbonadosTercerEdad.Size = new System.Drawing.Size(175, 34);
            this.lblAbonadosTercerEdad.TabIndex = 12;
            this.lblAbonadosTercerEdad.Text = "[0] abonados";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Product Sans Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(798, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 24);
            this.label10.TabIndex = 11;
            this.label10.Text = "Tercera edad";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.Location = new System.Drawing.Point(802, 133);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(400, 1);
            this.panel6.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Location = new System.Drawing.Point(754, 23);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 250);
            this.panel5.TabIndex = 6;
            // 
            // lblAbonadosInactivos
            // 
            this.lblAbonadosInactivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbonadosInactivos.AutoSize = true;
            this.lblAbonadosInactivos.Font = new System.Drawing.Font("Product Sans Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbonadosInactivos.ForeColor = System.Drawing.Color.Black;
            this.lblAbonadosInactivos.Location = new System.Drawing.Point(454, 201);
            this.lblAbonadosInactivos.Name = "lblAbonadosInactivos";
            this.lblAbonadosInactivos.Size = new System.Drawing.Size(175, 34);
            this.lblAbonadosInactivos.TabIndex = 10;
            this.lblAbonadosInactivos.Text = "[0] abonados";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Product Sans Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(456, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 24);
            this.label8.TabIndex = 9;
            this.label8.Text = "Inactivos";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Location = new System.Drawing.Point(460, 133);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 1);
            this.panel4.TabIndex = 8;
            // 
            // lblAbonadosActivos
            // 
            this.lblAbonadosActivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbonadosActivos.AutoSize = true;
            this.lblAbonadosActivos.Font = new System.Drawing.Font("Product Sans Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbonadosActivos.ForeColor = System.Drawing.Color.Black;
            this.lblAbonadosActivos.Location = new System.Drawing.Point(454, 70);
            this.lblAbonadosActivos.Name = "lblAbonadosActivos";
            this.lblAbonadosActivos.Size = new System.Drawing.Size(175, 34);
            this.lblAbonadosActivos.TabIndex = 7;
            this.lblAbonadosActivos.Text = "[0] abonados";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Product Sans Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(456, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Activos";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(413, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 250);
            this.panel3.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(34, 235);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(334, 18);
            this.progressBar1.TabIndex = 4;
            // 
            // lblPorcentajeAbonadosPago
            // 
            this.lblPorcentajeAbonadosPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorcentajeAbonadosPago.Font = new System.Drawing.Font("Product Sans Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeAbonadosPago.ForeColor = System.Drawing.Color.Black;
            this.lblPorcentajeAbonadosPago.Location = new System.Drawing.Point(28, 101);
            this.lblPorcentajeAbonadosPago.Name = "lblPorcentajeAbonadosPago";
            this.lblPorcentajeAbonadosPago.Size = new System.Drawing.Size(340, 75);
            this.lblPorcentajeAbonadosPago.TabIndex = 3;
            this.lblPorcentajeAbonadosPago.Text = "0% de los abonados van al día.";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Product Sans Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(30, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 55);
            this.label3.TabIndex = 2;
            this.label3.Text = "Porcentaje de abonados que van al día.";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1350, 727);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblHeaderDatos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAbonados);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTituloAbonados);
            this.Font = new System.Drawing.Font("Product Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Abonados";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.pnlAbonados.ResumeLayout(false);
            this.pnlAbonados.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAbonados;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTituloAbonados;
        private System.Windows.Forms.Button btnAbonado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAbonados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReportes;
        private System.Windows.Forms.Label lblHeaderDatos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAbonadosCisterna;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblAbonadosNormales;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAbonadosTercerEdad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblAbonadosInactivos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblAbonadosActivos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblPorcentajeAbonadosPago;
        private System.Windows.Forms.Label label3;
    }
}

