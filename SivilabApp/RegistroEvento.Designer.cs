
namespace SivilabApp
{
    partial class RegistroEvento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroEvento));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.Responsable_evento = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.Tipo = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.Escuela = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.Descripcion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Fecha_registro = new System.Windows.Forms.DateTimePicker();
            this.Fecha_evento = new System.Windows.Forms.DateTimePicker();
            this.NombreEvento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Direccion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Contrasena_usuario = new System.Windows.Forms.TextBox();
            this.Observaciones = new System.Windows.Forms.TextBox();
            this.Observaciones_evento = new System.Windows.Forms.TextBox();
            this.Direccion_evento = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(21, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(107, 45);
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(377, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "REGISTRAR EVENTO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(402, 534);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 42);
            this.button1.TabIndex = 92;
            this.button1.Text = "GUARDAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label22.Location = new System.Drawing.Point(540, 353);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 13);
            this.label22.TabIndex = 86;
            // 
            // Responsable_evento
            // 
            this.Responsable_evento.AutoCompleteCustomSource.AddRange(new string[] {
            "NINGUNA",
            "PRIMARIA",
            "SECUNDARIA",
            "SUPERIOR"});
            this.Responsable_evento.FormattingEnabled = true;
            this.Responsable_evento.Items.AddRange(new object[] {
            "MILITAR",
            "NINGUNA"});
            this.Responsable_evento.Location = new System.Drawing.Point(181, 330);
            this.Responsable_evento.Name = "Responsable_evento";
            this.Responsable_evento.Size = new System.Drawing.Size(122, 21);
            this.Responsable_evento.TabIndex = 85;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label21.Location = new System.Drawing.Point(85, 330);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 13);
            this.label21.TabIndex = 84;
            this.label21.Text = "Responsable:";
            // 
            // Tipo
            // 
            this.Tipo.AutoCompleteCustomSource.AddRange(new string[] {
            "NINGUNA",
            "PRIMARIA",
            "SECUNDARIA",
            "SUPERIOR"});
            this.Tipo.FormattingEnabled = true;
            this.Tipo.Items.AddRange(new object[] {
            "FEMENINO",
            "MASCULINO",
            "AMBOS"});
            this.Tipo.Location = new System.Drawing.Point(181, 277);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(122, 21);
            this.Tipo.TabIndex = 81;
            this.Tipo.SelectedIndexChanged += new System.EventHandler(this.cbxGenero_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label19.Location = new System.Drawing.Point(79, 277);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 13);
            this.label19.TabIndex = 80;
            this.label19.Text = "Tipo de Evento:";
            // 
            // Escuela
            // 
            this.Escuela.AutoCompleteCustomSource.AddRange(new string[] {
            "NINGUNA",
            "PRIMARIA",
            "SECUNDARIA",
            "SUPERIOR"});
            this.Escuela.FormattingEnabled = true;
            this.Escuela.Items.AddRange(new object[] {
            "SOLTERO",
            "CASADO",
            "UNION LIBRE"});
            this.Escuela.Location = new System.Drawing.Point(181, 380);
            this.Escuela.Name = "Escuela";
            this.Escuela.Size = new System.Drawing.Size(122, 21);
            this.Escuela.TabIndex = 79;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label18.Location = new System.Drawing.Point(105, 380);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 13);
            this.label18.TabIndex = 78;
            this.label18.Text = "Escuela:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label17.Location = new System.Drawing.Point(82, 214);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 13);
            this.label17.TabIndex = 76;
            this.label17.Text = "Unidad Enlace:";
            // 
            // Descripcion
            // 
            this.Descripcion.Location = new System.Drawing.Point(181, 155);
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new System.Drawing.Size(291, 20);
            this.Descripcion.TabIndex = 66;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(90, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Descripción:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(511, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "Fecha de Evento";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(92, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Fecha de Registro";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Fecha_registro
            // 
            this.Fecha_registro.Location = new System.Drawing.Point(190, 106);
            this.Fecha_registro.Name = "Fecha_registro";
            this.Fecha_registro.Size = new System.Drawing.Size(210, 20);
            this.Fecha_registro.TabIndex = 93;
            // 
            // Fecha_evento
            // 
            this.Fecha_evento.Location = new System.Drawing.Point(602, 105);
            this.Fecha_evento.Name = "Fecha_evento";
            this.Fecha_evento.Size = new System.Drawing.Size(210, 20);
            this.Fecha_evento.TabIndex = 94;
            // 
            // NombreEvento
            // 
            this.NombreEvento.AutoCompleteCustomSource.AddRange(new string[] {
            "NINGUNA",
            "PRIMARIA",
            "SECUNDARIA",
            "SUPERIOR"});
            this.NombreEvento.FormattingEnabled = true;
            this.NombreEvento.Items.AddRange(new object[] {
            "FEMENINO",
            "MASCULINO",
            "AMBOS"});
            this.NombreEvento.Location = new System.Drawing.Point(181, 214);
            this.NombreEvento.Name = "NombreEvento";
            this.NombreEvento.Size = new System.Drawing.Size(202, 21);
            this.NombreEvento.TabIndex = 95;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(75, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 96;
            this.label2.Text = "Observaciones:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(38, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(841, 440);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Direccion
            // 
            this.Direccion.AutoSize = true;
            this.Direccion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Direccion.Location = new System.Drawing.Point(661, 403);
            this.Direccion.Name = "Direccion";
            this.Direccion.Size = new System.Drawing.Size(103, 13);
            this.Direccion.TabIndex = 99;
            this.Direccion.Text = "Direccion de evento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(623, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 101;
            this.label3.Text = "Contraseña";
            // 
            // Contrasena_usuario
            // 
            this.Contrasena_usuario.Location = new System.Drawing.Point(690, 159);
            this.Contrasena_usuario.Name = "Contrasena_usuario";
            this.Contrasena_usuario.Size = new System.Drawing.Size(126, 20);
            this.Contrasena_usuario.TabIndex = 102;
            // 
            // Observaciones
            // 
            this.Observaciones.Location = new System.Drawing.Point(162, 432);
            this.Observaciones.Multiline = true;
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Size = new System.Drawing.Size(291, 63);
            this.Observaciones.TabIndex = 103;
            // 
            // Observaciones_evento
            // 
            this.Observaciones_evento.Location = new System.Drawing.Point(163, 443);
            this.Observaciones_evento.Multiline = true;
            this.Observaciones_evento.Name = "Observaciones_evento";
            this.Observaciones_evento.Size = new System.Drawing.Size(291, 63);
            this.Observaciones_evento.TabIndex = 103;
            // 
            // Direccion_evento
            // 
            this.Direccion_evento.Location = new System.Drawing.Point(568, 432);
            this.Direccion_evento.Multiline = true;
            this.Direccion_evento.Name = "Direccion_evento";
            this.Direccion_evento.Size = new System.Drawing.Size(291, 74);
            this.Direccion_evento.TabIndex = 104;
            // 
            // RegistroEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 588);
            this.Controls.Add(this.Direccion_evento);
            this.Controls.Add(this.Observaciones_evento);
            this.Controls.Add(this.Observaciones);
            this.Controls.Add(this.Contrasena_usuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Direccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NombreEvento);
            this.Controls.Add(this.Fecha_evento);
            this.Controls.Add(this.Fecha_registro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.Responsable_evento);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.Tipo);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.Escuela);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.Descripcion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "RegistroEvento";
            this.Text = "RegistroEvento";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox Responsable_evento;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox Tipo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox Escuela;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox Descripcion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker Fecha_registro;
        private System.Windows.Forms.DateTimePicker Fecha_evento;
        private System.Windows.Forms.ComboBox NombreEvento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Direccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Contrasena_usuario;
        private System.Windows.Forms.TextBox Observaciones;
        private System.Windows.Forms.TextBox Observaciones_evento;
        private System.Windows.Forms.TextBox Direccion_evento;
    }
}