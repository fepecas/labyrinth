namespace Form_Laberinto
{
    partial class Autoconstruir
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlControles = new System.Windows.Forms.Panel();
            this.cbxRetardo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxObjetivos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxTamanoCasilla = new System.Windows.Forms.ComboBox();
            this.cbxRecorrer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxAlto = new System.Windows.Forms.ComboBox();
            this.cbxAncho = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnVRML = new System.Windows.Forms.Button();
            this.btnResolver = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlControles
            // 
            this.pnlControles.Controls.Add(this.cbxRetardo);
            this.pnlControles.Controls.Add(this.label6);
            this.pnlControles.Controls.Add(this.cbxObjetivos);
            this.pnlControles.Controls.Add(this.label5);
            this.pnlControles.Controls.Add(this.label4);
            this.pnlControles.Controls.Add(this.cbxTamanoCasilla);
            this.pnlControles.Controls.Add(this.cbxRecorrer);
            this.pnlControles.Controls.Add(this.label3);
            this.pnlControles.Controls.Add(this.cbxAlto);
            this.pnlControles.Controls.Add(this.cbxAncho);
            this.pnlControles.Controls.Add(this.btnGenerar);
            this.pnlControles.Controls.Add(this.label2);
            this.pnlControles.Controls.Add(this.label1);
            this.pnlControles.Location = new System.Drawing.Point(182, 109);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(319, 248);
            this.pnlControles.TabIndex = 10;
            // 
            // cbxRetardo
            // 
            this.cbxRetardo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRetardo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRetardo.FormattingEnabled = true;
            this.cbxRetardo.Items.AddRange(new object[] {
            "500",
            "1000",
            "2000",
            "4000"});
            this.cbxRetardo.Location = new System.Drawing.Point(84, 180);
            this.cbxRetardo.Name = "cbxRetardo";
            this.cbxRetardo.Size = new System.Drawing.Size(197, 28);
            this.cbxRetardo.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(4, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Retardo:";
            // 
            // cbxObjetivos
            // 
            this.cbxObjetivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxObjetivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxObjetivos.FormattingEnabled = true;
            this.cbxObjetivos.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbxObjetivos.Location = new System.Drawing.Point(84, 112);
            this.cbxObjetivos.Name = "cbxObjetivos";
            this.cbxObjetivos.Size = new System.Drawing.Size(197, 28);
            this.cbxObjetivos.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Objetivos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Longitud:";
            // 
            // cbxTamanoCasilla
            // 
            this.cbxTamanoCasilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTamanoCasilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTamanoCasilla.FormattingEnabled = true;
            this.cbxTamanoCasilla.Items.AddRange(new object[] {
            "30",
            "25",
            "20",
            "15",
            "10",
            "5"});
            this.cbxTamanoCasilla.Location = new System.Drawing.Point(84, 10);
            this.cbxTamanoCasilla.Name = "cbxTamanoCasilla";
            this.cbxTamanoCasilla.Size = new System.Drawing.Size(197, 28);
            this.cbxTamanoCasilla.TabIndex = 19;
            this.cbxTamanoCasilla.SelectedIndexChanged += new System.EventHandler(this.cbxTamanoCasilla_SelectedIndexChanged);
            // 
            // cbxRecorrer
            // 
            this.cbxRecorrer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRecorrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRecorrer.FormattingEnabled = true;
            this.cbxRecorrer.Items.AddRange(new object[] {
            "Arriba/Abajo",
            "Izquierda/Derecha"});
            this.cbxRecorrer.Location = new System.Drawing.Point(84, 146);
            this.cbxRecorrer.Name = "cbxRecorrer";
            this.cbxRecorrer.Size = new System.Drawing.Size(197, 28);
            this.cbxRecorrer.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Recorrer:";
            // 
            // cbxAlto
            // 
            this.cbxAlto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAlto.FormattingEnabled = true;
            this.cbxAlto.Items.AddRange(new object[] {
            "4",
            "6",
            "8",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22"});
            this.cbxAlto.Location = new System.Drawing.Point(84, 78);
            this.cbxAlto.Name = "cbxAlto";
            this.cbxAlto.Size = new System.Drawing.Size(197, 28);
            this.cbxAlto.TabIndex = 16;
            // 
            // cbxAncho
            // 
            this.cbxAncho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAncho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAncho.FormattingEnabled = true;
            this.cbxAncho.Items.AddRange(new object[] {
            "4",
            "6",
            "8",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "30",
            "32",
            "34",
            "36",
            "38",
            "40",
            "42"});
            this.cbxAncho.Location = new System.Drawing.Point(84, 44);
            this.cbxAncho.Name = "cbxAncho";
            this.cbxAncho.Size = new System.Drawing.Size(197, 28);
            this.cbxAncho.TabIndex = 15;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerar.Location = new System.Drawing.Point(184, 214);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(97, 23);
            this.btnGenerar.TabIndex = 14;
            this.btnGenerar.Text = "Generar laberinto";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Alto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ancho:";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(8, 2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(68, 23);
            this.btnVolver.TabIndex = 11;
            this.btnVolver.Text = "<- Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Visible = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnVRML
            // 
            this.btnVRML.Location = new System.Drawing.Point(156, 2);
            this.btnVRML.Name = "btnVRML";
            this.btnVRML.Size = new System.Drawing.Size(81, 23);
            this.btnVRML.TabIndex = 12;
            this.btnVRML.Text = "Exportar 3D";
            this.btnVRML.UseVisualStyleBackColor = true;
            this.btnVRML.Visible = false;
            this.btnVRML.Click += new System.EventHandler(this.btnVRML_Click);
            // 
            // btnResolver
            // 
            this.btnResolver.Location = new System.Drawing.Point(82, 2);
            this.btnResolver.Name = "btnResolver";
            this.btnResolver.Size = new System.Drawing.Size(68, 23);
            this.btnResolver.TabIndex = 13;
            this.btnResolver.Text = "Resolver";
            this.btnResolver.UseVisualStyleBackColor = true;
            this.btnResolver.Visible = false;
            this.btnResolver.Click += new System.EventHandler(this.btnResolver_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = global::Form_Laberinto.Properties.Resources.titulo2;
            this.picLogo.Location = new System.Drawing.Point(97, 45);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(501, 58);
            this.picLogo.TabIndex = 14;
            this.picLogo.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(599, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "By: @fepecas";
            // 
            // Autoconstruir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(671, 369);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnResolver);
            this.Controls.Add(this.btnVRML);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.pnlControles);
            this.MaximizeBox = false;
            this.Name = "Autoconstruir";
            this.Text = "Laberinto Autoconstruido";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxAlto;
        private System.Windows.Forms.ComboBox cbxAncho;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cbxRecorrer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxTamanoCasilla;
        private System.Windows.Forms.ComboBox cbxObjetivos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxRetardo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVRML;
        private System.Windows.Forms.Button btnResolver;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label label7;


    }
}

