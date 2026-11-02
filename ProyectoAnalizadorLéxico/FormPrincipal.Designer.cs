namespace ProyectoAnalizadorLéxico
{
    partial class FormPrincipal
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
            this.txtCodigoFuente = new System.Windows.Forms.RichTextBox();
            this.dvgTokens = new System.Windows.Forms.DataGridView();
            this.dgvErrores = new System.Windows.Forms.DataGridView();
            this.dgvSimbolos = new System.Windows.Forms.DataGridView();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.lblTokens = new System.Windows.Forms.Label();
            this.lblSimbolos = new System.Windows.Forms.Label();
            this.lblErrores = new System.Windows.Forms.Label();
            this.lblCodigoFuente = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnDiccionario = new System.Windows.Forms.Button();
            this.btnExpExcel = new System.Windows.Forms.Button();
            this.grpTablas = new System.Windows.Forms.GroupBox();
            this.grpExportaciones = new System.Windows.Forms.GroupBox();
            this.grpSistema = new System.Windows.Forms.GroupBox();
            this.grpEstadistica = new System.Windows.Forms.GroupBox();
            this.lblTiempoTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).BeginInit();
            this.grpTablas.SuspendLayout();
            this.grpExportaciones.SuspendLayout();
            this.grpSistema.SuspendLayout();
            this.grpEstadistica.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCodigoFuente
            // 
            this.txtCodigoFuente.Location = new System.Drawing.Point(12, 35);
            this.txtCodigoFuente.Name = "txtCodigoFuente";
            this.txtCodigoFuente.Size = new System.Drawing.Size(510, 667);
            this.txtCodigoFuente.TabIndex = 0;
            this.txtCodigoFuente.Text = "";
            // 
            // dvgTokens
            // 
            this.dvgTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgTokens.Location = new System.Drawing.Point(31, 51);
            this.dvgTokens.Name = "dvgTokens";
            this.dvgTokens.RowHeadersWidth = 51;
            this.dvgTokens.RowTemplate.Height = 24;
            this.dvgTokens.Size = new System.Drawing.Size(560, 180);
            this.dvgTokens.TabIndex = 1;
            // 
            // dgvErrores
            // 
            this.dgvErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrores.Location = new System.Drawing.Point(31, 487);
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.RowHeadersWidth = 51;
            this.dgvErrores.Size = new System.Drawing.Size(560, 180);
            this.dgvErrores.TabIndex = 2;
            // 
            // dgvSimbolos
            // 
            this.dgvSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimbolos.Location = new System.Drawing.Point(31, 276);
            this.dgvSimbolos.Name = "dgvSimbolos";
            this.dgvSimbolos.RowHeadersWidth = 51;
            this.dgvSimbolos.Size = new System.Drawing.Size(560, 180);
            this.dgvSimbolos.TabIndex = 3;
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAnalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalizar.Location = new System.Drawing.Point(47, 32);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(142, 64);
            this.btnAnalizar.TabIndex = 4;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = false;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCargarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarArchivo.Location = new System.Drawing.Point(195, 32);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(142, 64);
            this.btnCargarArchivo.TabIndex = 5;
            this.btnCargarArchivo.Text = "Archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = false;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // lblTokens
            // 
            this.lblTokens.AutoSize = true;
            this.lblTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokens.Location = new System.Drawing.Point(27, 28);
            this.lblTokens.Name = "lblTokens";
            this.lblTokens.Size = new System.Drawing.Size(75, 20);
            this.lblTokens.TabIndex = 6;
            this.lblTokens.Text = "Tokens:";
            // 
            // lblSimbolos
            // 
            this.lblSimbolos.AutoSize = true;
            this.lblSimbolos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimbolos.Location = new System.Drawing.Point(27, 253);
            this.lblSimbolos.Name = "lblSimbolos";
            this.lblSimbolos.Size = new System.Drawing.Size(86, 20);
            this.lblSimbolos.TabIndex = 7;
            this.lblSimbolos.Text = "Símbolos";
            this.lblSimbolos.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblErrores
            // 
            this.lblErrores.AutoSize = true;
            this.lblErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrores.Location = new System.Drawing.Point(27, 464);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(78, 20);
            this.lblErrores.TabIndex = 8;
            this.lblErrores.Text = "Errores:";
            // 
            // lblCodigoFuente
            // 
            this.lblCodigoFuente.AutoSize = true;
            this.lblCodigoFuente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblCodigoFuente.Location = new System.Drawing.Point(13, 13);
            this.lblCodigoFuente.Name = "lblCodigoFuente";
            this.lblCodigoFuente.Size = new System.Drawing.Size(218, 20);
            this.lblCodigoFuente.TabIndex = 9;
            this.lblCodigoFuente.Text = "Editor de Código Fuente:";
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Location = new System.Drawing.Point(79, 33);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(197, 50);
            this.btnExportar.TabIndex = 10;
            this.btnExportar.Text = "Exportar a PDF";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnDiccionario
            // 
            this.btnDiccionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiccionario.Location = new System.Drawing.Point(119, 113);
            this.btnDiccionario.Name = "btnDiccionario";
            this.btnDiccionario.Size = new System.Drawing.Size(142, 64);
            this.btnDiccionario.TabIndex = 11;
            this.btnDiccionario.Text = "Diccionario";
            this.btnDiccionario.UseVisualStyleBackColor = true;
            this.btnDiccionario.Click += new System.EventHandler(this.btnDiccionario_Click);
            // 
            // btnExpExcel
            // 
            this.btnExpExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpExcel.Location = new System.Drawing.Point(79, 83);
            this.btnExpExcel.Name = "btnExpExcel";
            this.btnExpExcel.Size = new System.Drawing.Size(197, 50);
            this.btnExpExcel.TabIndex = 12;
            this.btnExpExcel.Text = "Exportar a Excel";
            this.btnExpExcel.UseVisualStyleBackColor = true;
            this.btnExpExcel.Click += new System.EventHandler(this.btnExpExcel_Click);
            // 
            // grpTablas
            // 
            this.grpTablas.Controls.Add(this.lblTokens);
            this.grpTablas.Controls.Add(this.dvgTokens);
            this.grpTablas.Controls.Add(this.dgvErrores);
            this.grpTablas.Controls.Add(this.dgvSimbolos);
            this.grpTablas.Controls.Add(this.lblSimbolos);
            this.grpTablas.Controls.Add(this.lblErrores);
            this.grpTablas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.grpTablas.Location = new System.Drawing.Point(929, 19);
            this.grpTablas.Name = "grpTablas";
            this.grpTablas.Size = new System.Drawing.Size(615, 683);
            this.grpTablas.TabIndex = 13;
            this.grpTablas.TabStop = false;
            this.grpTablas.Text = "Tablas";
            // 
            // grpExportaciones
            // 
            this.grpExportaciones.Controls.Add(this.btnExportar);
            this.grpExportaciones.Controls.Add(this.btnExpExcel);
            this.grpExportaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.grpExportaciones.Location = new System.Drawing.Point(555, 551);
            this.grpExportaciones.Name = "grpExportaciones";
            this.grpExportaciones.Size = new System.Drawing.Size(360, 151);
            this.grpExportaciones.TabIndex = 14;
            this.grpExportaciones.TabStop = false;
            this.grpExportaciones.Text = "Exportar Código";
            // 
            // grpSistema
            // 
            this.grpSistema.Controls.Add(this.btnCargarArchivo);
            this.grpSistema.Controls.Add(this.btnAnalizar);
            this.grpSistema.Controls.Add(this.btnDiccionario);
            this.grpSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.grpSistema.Location = new System.Drawing.Point(544, 19);
            this.grpSistema.Name = "grpSistema";
            this.grpSistema.Size = new System.Drawing.Size(379, 195);
            this.grpSistema.TabIndex = 15;
            this.grpSistema.TabStop = false;
            this.grpSistema.Text = "Sistema";
            // 
            // grpEstadistica
            // 
            this.grpEstadistica.Controls.Add(this.lblTiempoTotal);
            this.grpEstadistica.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.grpEstadistica.Location = new System.Drawing.Point(544, 232);
            this.grpEstadistica.Name = "grpEstadistica";
            this.grpEstadistica.Size = new System.Drawing.Size(379, 287);
            this.grpEstadistica.TabIndex = 16;
            this.grpEstadistica.TabStop = false;
            this.grpEstadistica.Text = "Estadísticas";
            // 
            // lblTiempoTotal
            // 
            this.lblTiempoTotal.AutoSize = true;
            this.lblTiempoTotal.Location = new System.Drawing.Point(21, 40);
            this.lblTiempoTotal.Name = "lblTiempoTotal";
            this.lblTiempoTotal.Size = new System.Drawing.Size(216, 20);
            this.lblTiempoTotal.TabIndex = 0;
            this.lblTiempoTotal.Text = "Tiempo total de análisis:";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 714);
            this.Controls.Add(this.grpEstadistica);
            this.Controls.Add(this.grpSistema);
            this.Controls.Add(this.grpExportaciones);
            this.Controls.Add(this.grpTablas);
            this.Controls.Add(this.lblCodigoFuente);
            this.Controls.Add(this.txtCodigoFuente);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).EndInit();
            this.grpTablas.ResumeLayout(false);
            this.grpTablas.PerformLayout();
            this.grpExportaciones.ResumeLayout(false);
            this.grpSistema.ResumeLayout(false);
            this.grpEstadistica.ResumeLayout(false);
            this.grpEstadistica.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtCodigoFuente;
        private System.Windows.Forms.DataGridView dvgTokens;
        private System.Windows.Forms.DataGridView dgvErrores;
        private System.Windows.Forms.DataGridView dgvSimbolos;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.Label lblTokens;
        private System.Windows.Forms.Label lblSimbolos;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.Label lblCodigoFuente;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnDiccionario;
        private System.Windows.Forms.Button btnExpExcel;
        private System.Windows.Forms.GroupBox grpTablas;
        private System.Windows.Forms.GroupBox grpExportaciones;
        private System.Windows.Forms.GroupBox grpSistema;
        private System.Windows.Forms.GroupBox grpEstadistica;
        private System.Windows.Forms.Label lblTiempoTotal;
    }
}

