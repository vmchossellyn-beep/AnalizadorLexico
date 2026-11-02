using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProyectoAnalizadorLéxico
{
    public partial class Diccionario : Form
    {
        private string rutaArchivoDiccionario = "palabras_reservadas.txt";
        public Diccionario()
        {
            InitializeComponent();
            dvgDiccionario.SelectionChanged += new EventHandler(dvgDiccionario_SelectionChanged);
        }

        private void Diccionario_Load(object sender, EventArgs e)
        {
            dvgDiccionario.Columns.Add("Palabra", "Palabra/Lexema");
            dvgDiccionario.Columns.Add("Token", "Tipo de Token");
            dvgDiccionario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgDiccionario.MultiSelect = false;
            dvgDiccionario.AllowUserToAddRows = true;
            dvgDiccionario.AllowUserToDeleteRows = true;

            dvgDetalles.Columns.Add("Atributo", "Atributo");
            dvgDetalles.Columns.Add("Valor", "Valor");
            dvgDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgDetalles.AllowUserToAddRows = false;
            dvgDetalles.ReadOnly = true;

            if (File.Exists(rutaArchivoDiccionario))
            {
                String[] lineas = File.ReadAllLines(rutaArchivoDiccionario);
                foreach (string linea in lineas)
                {
                    if(!string.IsNullOrWhiteSpace(linea)&& linea.Contains(","))
                    {
                        string[] partes = linea.Split(',');
                        dvgDiccionario.Rows.Add(partes[0].Trim(), partes[1].Trim());
                     
                    }
                }
            }
            else
            {
                MessageBox.Show("¡ALERTA! El archivo " + rutaArchivoDiccionario + " no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtBuscar.Text = "Buscar palabra o token";
            txtBuscar.ForeColor = System.Drawing.Color.Gray;

            txtBuscar.Enter += new EventHandler(txtBuscar_Enter);
            txtBuscar.Leave += new EventHandler(txtBuscar_Leave);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(rutaArchivoDiccionario,false))
            {
                foreach ( DataGridViewRow fila in dvgDiccionario.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        string palabra = fila.Cells[0].Value?.ToString();
                        string token = fila.Cells[1].Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(palabra) && !string.IsNullOrWhiteSpace(token))
                        {
                            sw.WriteLine($"{palabra},{token}");
                        }
                    }
                }
            }
            MessageBox.Show("Diccionario Actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private void dvgDiccionario_SelectionChanged(object sender, EventArgs e)
        {
            dvgDetalles.Rows.Clear();
            if (dvgDiccionario.CurrentRow != null && !dvgDiccionario.CurrentRow.IsNewRow)
            {
                var celdaPalabra = dvgDiccionario.CurrentRow.Cells[0].Value;
                var celdaToken = dvgDiccionario.CurrentRow.Cells[1].Value;
                
                string palabra = celdaPalabra != null ? celdaPalabra.ToString() : "";
                string token = celdaToken != null ? celdaToken.ToString() : "";

                dvgDetalles.Rows.Add("Lexema", palabra);
                dvgDetalles.Rows.Add("Tipo de Token", token);

               
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dvgDiccionario.CurrentRow != null && !dvgDiccionario.CurrentRow.IsNewRow)
            {
                dvgDiccionario.Rows.Remove(dvgDiccionario.CurrentRow);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una palabra válida para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtNuevaPalabra.Text) && !string.IsNullOrWhiteSpace(txtNuevoToken.Text))
            {

                dvgDiccionario.Rows.Add(txtNuevaPalabra.Text.Trim(), txtNuevoToken.Text.Trim());

                
                txtNuevaPalabra.Clear();
                txtNuevoToken.Clear();
      
                txtNuevaPalabra.Focus();
            }
            else
            {
                MessageBox.Show("Por favor, llena ambos campos (Palabra y Token) antes de añadir.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar palabra o token") return;

            string busqueda = txtBuscar.Text.Trim().ToLower();

            
            dvgDiccionario.CurrentCell = null;

      
            foreach (DataGridViewRow fila in dvgDiccionario.Rows)
            {
           
                if (fila.IsNewRow) continue;

        
                string palabra = fila.Cells[0].Value?.ToString().ToLower() ?? "";
                string token = fila.Cells[1].Value?.ToString().ToLower() ?? "";

         
                if (palabra.Contains(busqueda) || token.Contains(busqueda))
                {
                    fila.Visible = true;
                }
                else
                {
 
                    fila.Visible = false;
                }
            }
        }
        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar palabra o token")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar palabra o token";
                txtBuscar.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
    
}
