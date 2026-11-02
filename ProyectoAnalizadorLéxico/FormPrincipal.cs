using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ProyectoAnalizadorLéxico.logica;
using System;
using System.IO;
using System.Windows.Forms;

namespace ProyectoAnalizadorLéxico
{
    public partial class FormPrincipal : Form
    {
        
        private AnalizadorLexico analizadorLexico;

        public FormPrincipal()
        {
            InitializeComponent();
            analizadorLexico = new AnalizadorLexico();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            if (dvgTokens != null) dvgTokens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvErrores != null) dgvErrores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            string codigoFuente =txtCodigoFuente.Text;

            if(string.IsNullOrWhiteSpace(codigoFuente) )
            {
                MessageBox.Show("por favor, ingresa o carga codigo fuente para analizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            analizadorLexico.Analizar(codigoFuente);

            var listaTokens = analizadorLexico.ObtenerTokens();
            var listaErrores = analizadorLexico.ObtenerErrores();

            dgvErrores.DataSource = null;
            dgvErrores .DataSource = listaErrores;

            dvgTokens.DataSource = null;
            dvgTokens .DataSource = listaTokens;

            dgvSimbolos.DataSource = null;
            dgvSimbolos.DataSource = analizadorLexico.ObtenerTablaSimbolos().ObtenerLista();

            if (listaErrores != null && listaErrores.Count > 0)
            {
                MessageBox.Show($"El análisis finalizó con {listaErrores.Count} error(es) léxico(s).",
                                "Análisis Finalizado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("El análisis léxico se completó con éxito sin errores.",
                                "Análisis Exitoso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                ofd.Title = "Seleccionar archivo de código fuente";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string contenido = System.IO.File.ReadAllText(ofd.FileName);
                        txtCodigoFuente.Text = contenido;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al leer el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
            sfd.FileName = "Reporte_Analizador_Lexico.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    Document doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    
                    Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    Paragraph titulo = new Paragraph("Reporte de Análisis Léxico\n\n", fontTitulo);
                    titulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(titulo);

                    doc.Add(new Paragraph("Código Fuente Analizado:\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));

                    Font fontCodigo = FontFactory.GetFont(FontFactory.COURIER, 10);
                    Paragraph parrafoCodigo = new Paragraph(txtCodigoFuente.Text + "\n\n", fontCodigo);
                    doc.Add(parrafoCodigo);

                    doc.Add(new Paragraph("1. Tabla de Tokens:\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                    doc.Add(ConvertirDataGridAPdf(dvgTokens));

                   
                    doc.Add(new Paragraph("\n2. Tabla de Símbolos:\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                    doc.Add(ConvertirDataGridAPdf(dgvSimbolos));

                  
                    doc.Add(new Paragraph("\n3. Tabla de Errores:\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                    doc.Add(ConvertirDataGridAPdf(dgvErrores));

                    doc.Close();
                    MessageBox.Show("Reporte exportado con éxito.", "PDF Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private PdfPTable ConvertirDataGridAPdf(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0)
                return new PdfPTable(1); 

            PdfPTable tablaPdf = new PdfPTable(dgv.Columns.Count);
            tablaPdf.WidthPercentage = 100;

            
            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                PdfPCell celda = new PdfPCell(new Phrase(columna.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                celda.BackgroundColor = new BaseColor(220, 220, 220);
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                tablaPdf.AddCell(celda);
            }

            
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (!fila.IsNewRow) 
                {
                    foreach (DataGridViewCell celdaGrid in fila.Cells)
                    {
                        string valor = celdaGrid.Value != null ? celdaGrid.Value.ToString() : "";
                        PdfPCell celdaPdf = new PdfPCell(new Phrase(valor, FontFactory.GetFont(FontFactory.HELVETICA, 9)));
                        tablaPdf.AddCell(celdaPdf);
                    }
                }
            }

            return tablaPdf;
        }

        private void btnDiccionario_Click(object sender, EventArgs e)
        {
            this.Hide();
            Diccionario formDic = new Diccionario();
            formDic.ShowDialog();

            analizadorLexico = new AnalizadorLexico();
            this.Show();
        }

        private void btnExpExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
            sfd.FileName = "Reporte_Analizador_Lexico.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    using (var workbook = new XLWorkbook())
                    {
                        var hoja = workbook.Worksheets.Add("Reporte Analizador");

                        int filaActual = 1;


                        hoja.Cell(filaActual, 1).Value = "REPORTE DE ANÁLISIS LÉXICO Y SINTÁCTICO";
                        hoja.Cell(filaActual, 1).Style.Font.Bold = true;
                        hoja.Cell(filaActual, 1).Style.Font.FontSize = 14;
                        filaActual += 2;

                        hoja.Cell(filaActual, 1).Value = "CÓDIGO FUENTE ANALIZADO:";
                        hoja.Cell(filaActual, 1).Style.Font.Bold = true;
                        filaActual++;

                        hoja.Cell(filaActual, 1).Value = txtCodigoFuente.Text;
                        hoja.Cell(filaActual, 1).Style.Alignment.WrapText = true;
                        filaActual += 3;

                        hoja.Cell(filaActual, 1).Value = "1. TABLA DE TOKENS";
                        hoja.Cell(filaActual, 1).Style.Font.Bold = true;
                        filaActual++;
                        filaActual = ExportarDataGridViewAExcel(hoja, dvgTokens, filaActual);
                        filaActual += 2;

  
                        hoja.Cell(filaActual, 1).Value = "2. TABLA DE SÍMBOLOS";
                        hoja.Cell(filaActual, 1).Style.Font.Bold = true;
                        filaActual++;
                        filaActual = ExportarDataGridViewAExcel(hoja, dgvSimbolos, filaActual);
                        filaActual += 2;

      
                        hoja.Cell(filaActual, 1).Value = "3. TABLA DE ERRORES";
                        hoja.Cell(filaActual, 1).Style.Font.Bold = true;
                        filaActual++;
                        ExportarDataGridViewAExcel(hoja, dgvErrores, filaActual);


                        hoja.Columns().AdjustToContents();


                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("¡Reporte exportado a Excel con éxito!", "Archivo Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private int ExportarDataGridViewAExcel(IXLWorksheet hoja, DataGridView dgv, int filaInicio)
        {

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                var celda = hoja.Cell(filaInicio, i + 1);
                celda.Value = dgv.Columns[i].HeaderText;
                celda.Style.Font.Bold = true;
                celda.Style.Fill.BackgroundColor = XLColor.LightGray;
            }
            filaInicio++;


            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (!fila.IsNewRow)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        hoja.Cell(filaInicio, i + 1).Value = fila.Cells[i].Value?.ToString() ?? "";
                    }
                    filaInicio++;
                }
            }

            return filaInicio;
        }
    }
}
