namespace NotasOracleWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvDatos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtNombre = new TextBox();
            txtNota1 = new TextBox();
            txtNota2 = new TextBox();
            txtNota3 = new TextBox();
            txtNota4 = new TextBox();
            txtNota5 = new TextBox();
            txtSuma = new TextBox();
            txtPromedio = new TextBox();
            btnCalcular = new Button();
            btnGuardar = new Button();
            btnConsultar = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // dgvDatos
            // 
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(25, 330);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.Size = new Size(740, 180);
            dgvDatos.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 25);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre Alumno :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 65);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Nota 1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 95);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 3;
            label3.Text = "Nota 2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 125);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 4;
            label4.Text = "Nota 3";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 155);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 5;
            label5.Text = "Nota 4";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 185);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 6;
            label6.Text = "Nota 5";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 225);
            label7.Name = "label7";
            label7.Size = new Size(40, 15);
            label7.TabIndex = 7;
            label7.Text = "SUMA";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(30, 260);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 8;
            label8.Text = "PROMEDIO";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(150, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtNota1
            // 
            txtNota1.Location = new Point(150, 62);
            txtNota1.Name = "txtNota1";
            txtNota1.Size = new Size(120, 23);
            txtNota1.TabIndex = 2;
            // 
            // txtNota2
            // 
            txtNota2.Location = new Point(150, 92);
            txtNota2.Name = "txtNota2";
            txtNota2.Size = new Size(120, 23);
            txtNota2.TabIndex = 3;
            // 
            // txtNota3
            // 
            txtNota3.Location = new Point(150, 122);
            txtNota3.Name = "txtNota3";
            txtNota3.Size = new Size(120, 23);
            txtNota3.TabIndex = 4;
            // 
            // txtNota4
            // 
            txtNota4.Location = new Point(150, 152);
            txtNota4.Name = "txtNota4";
            txtNota4.Size = new Size(120, 23);
            txtNota4.TabIndex = 5;
            // 
            // txtNota5
            // 
            txtNota5.Location = new Point(150, 182);
            txtNota5.Name = "txtNota5";
            txtNota5.Size = new Size(120, 23);
            txtNota5.TabIndex = 6;
            // 
            // txtSuma
            // 
            txtSuma.Location = new Point(150, 222);
            txtSuma.Name = "txtSuma";
            txtSuma.ReadOnly = true;
            txtSuma.Size = new Size(120, 23);
            txtSuma.TabIndex = 7;
            // 
            // txtPromedio
            // 
            txtPromedio.Location = new Point(150, 257);
            txtPromedio.Name = "txtPromedio";
            txtPromedio.ReadOnly = true;
            txtPromedio.Size = new Size(120, 23);
            txtPromedio.TabIndex = 8;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(30, 289);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(120, 35);
            btnCalcular.TabIndex = 9;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(165, 289);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 35);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(304, 289);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(120, 35);
            btnConsultar.TabIndex = 11;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(439, 289);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 35);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 540);
            Controls.Add(dgvDatos);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(txtNombre);
            Controls.Add(txtNota1);
            Controls.Add(txtNota2);
            Controls.Add(txtNota3);
            Controls.Add(txtNota4);
            Controls.Add(txtNota5);
            Controls.Add(txtSuma);
            Controls.Add(txtPromedio);
            Controls.Add(btnCalcular);
            Controls.Add(btnGuardar);
            Controls.Add(btnConsultar);
            Controls.Add(btnLimpiar);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Notas - Oracle 19c";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDatos;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;

        private TextBox txtNombre;
        private TextBox txtNota1;
        private TextBox txtNota2;
        private TextBox txtNota3;
        private TextBox txtNota4;
        private TextBox txtNota5;
        private TextBox txtSuma;
        private TextBox txtPromedio;

        private Button btnCalcular;
        private Button btnGuardar;
        private Button btnConsultar;
        private Button btnLimpiar;
    }
}
