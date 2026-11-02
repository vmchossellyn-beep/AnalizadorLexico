using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ProyectoAnalizadorLéxico.modelos;

namespace ProyectoAnalizadorLéxico.logica
{
    public class AnalizadorLexico
    {
        private List<Token> listaTokens;
        private List<ErrorLexico> listaErrores;

        private TablaDeSimbolos tablaSimbolos;
        private Dictionary<string, string> palabrasReservadas;
        private Dictionary<string, string> signos;

        public AnalizadorLexico()
        {
            listaErrores = new List<ErrorLexico>();
            listaTokens = new List<Token>();
            tablaSimbolos = new TablaDeSimbolos();

            palabrasReservadas = new Dictionary<string, string>();
            signos = new Dictionary<string, string>();

            CargarDiccionario("palabras_reservadas.txt", palabrasReservadas);
            CargarDiccionario("signos.txt", signos);
        }

        private void CargarDiccionario(string rutaArchivo, Dictionary<string, string> diccionario)
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    string[] lineas = File.ReadAllLines(rutaArchivo);
                    foreach (string linea in lineas)
                    {
                        if (string.IsNullOrWhiteSpace(linea)) continue;

                        string[] partes = linea.Split(',');
                        if (partes.Length == 2)
                        {
                            diccionario[partes[0].Trim()] = partes[1].Trim();
                        }
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("¡ALERTA! El archivo " + rutaArchivo + " no está en bin\\Debug\\");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar diccionario: " + ex.Message);
            }
        }

        public void Analizar(string codigoFuente)
        {
            listaTokens.Clear();
            listaErrores.Clear();
            tablaSimbolos = new TablaDeSimbolos();

            int linea = 1;
            int columna = 1;
            int i = 0;

            string ultimoTipoVisto = "Desconocido";

            while (i < codigoFuente.Length)
            {
                char c = codigoFuente[i];

                if (c == '\n')
                {
                    linea++;
                    columna = 1;
                    i++;
                    continue;
                }

                if (Char.IsWhiteSpace(c))
                {
                    columna++;
                    i++;
                    continue;
                }

                if (char.IsLetter(c) || c == '_')
                {
                    string lexema = "";
                    while (i < codigoFuente.Length && (char.IsLetterOrDigit(codigoFuente[i]) || codigoFuente[i] == '_'))
                    {
                        lexema += codigoFuente[i];
                        columna++;
                        i++;
                    }

                    string tipo = "TKN_ID";
                    if (palabrasReservadas.ContainsKey(lexema))
                    {
                        tipo = palabrasReservadas[lexema];
                    }

                    listaTokens.Add(new Token(lexema, tipo, linea, columna - lexema.Length));

                    if (tipo == "TKN_TYPE_PRIMITIVO")
                    {
                        ultimoTipoVisto = lexema;
                    }
                    else if (tipo == "TKN_ID")
                    {
                        if (tablaSimbolos.BuscarSimbolo(lexema) == null)
                        {
                            if (ultimoTipoVisto == "Desconocido")
                            {
                                listaErrores.Add(new ErrorLexico(lexema, linea, columna - lexema.Length, "Error Semántico: Variable usada sin declararse previamente"));

                                Simbolo simboloAnomalo = new Simbolo
                                {
                                    Name = lexema,
                                    Line = linea,
                                    Column = columna - lexema.Length,
                                    SymbolKind = "Variable",
                                    DataType = "No declarado"
                                };
                                tablaSimbolos.AgregarSimbolo(simboloAnomalo);
                            }
                            else
                            {
                                Simbolo nuevoSimbolo = new Simbolo
                                {
                                    Name = lexema,
                                    Line = linea,
                                    Column = columna - lexema.Length,
                                    SymbolKind = "Variable",
                                    DataType = ultimoTipoVisto
                                };
                                tablaSimbolos.AgregarSimbolo(nuevoSimbolo);
                            }
                        }
                        ultimoTipoVisto = "Desconocido";
                    }
                }
                else if (char.IsDigit(c))
                {
                    string lexema = "";
                    bool tienePunto = false;

                    while (i < codigoFuente.Length && (char.IsDigit(codigoFuente[i]) || codigoFuente[i] == '.'))
                    {
                        if (codigoFuente[i] == '.')
                        {
                            if (tienePunto) break;
                            tienePunto = true;
                        }

                        lexema += codigoFuente[i];
                        columna++;
                        i++;
                    }
                    string tipoToken = tienePunto ? "TKN_NUM_DEC" : "TKN_NUM_INT";
                    listaTokens.Add(new Token(lexema, tipoToken, linea, columna - lexema.Length));
                }
                else if (c == '"')
                {
                    string lexema = c.ToString();
                    int columnaInicio = columna;
                    columna++;
                    i++;

                    while (i < codigoFuente.Length && codigoFuente[i] != '"' && codigoFuente[i] != '\n')
                    {
                        lexema += codigoFuente[i];
                        columna++;
                        i++;
                    }

                    if (i < codigoFuente.Length && codigoFuente[i] == '"')
                    {
                        lexema += codigoFuente[i];
                        columna++;
                        i++;
                        listaTokens.Add(new Token(lexema, "TKN_CADENA_TEXTO", linea, columnaInicio));
                    }
                    else
                    {
                        listaErrores.Add(new ErrorLexico(lexema, linea, columnaInicio, "Cadena de texto sin cerrar"));
                    }
                }
                else if (c == '\'')
                {
                    string lexema = c.ToString();
                    int columnaInicio = columna;
                    columna++;
                    i++;

                    while (i < codigoFuente.Length && codigoFuente[i] != '\'' && codigoFuente[i] != '\n')
                    {
                        lexema += codigoFuente[i];
                        columna++;
                        i++;
                    }

                    if (i < codigoFuente.Length && codigoFuente[i] == '\'')
                    {
                        lexema += codigoFuente[i];
                        columna++;
                        i++;
                        listaTokens.Add(new Token(lexema, "TKN_CARACTER", linea, columnaInicio));
                    }
                    else
                    {
                        listaErrores.Add(new ErrorLexico(lexema, linea, columnaInicio, "Caracter literal sin cerrar"));
                    }
                }
                else
                {
                    string lexemaDoble = "";
                    if (i + 1 < codigoFuente.Length)
                    {
                        lexemaDoble = codigoFuente.Substring(i, 2);
                    }

                    string lexema = c.ToString();
                    int columnaInicio = columna;

                    if (lexemaDoble != "" && signos.ContainsKey(lexemaDoble))
                    {
                        listaTokens.Add(new Token(lexemaDoble, signos[lexemaDoble], linea, columnaInicio));
                        columna += 2;
                        i += 2;
                    }
                    else if (signos.ContainsKey(lexema))
                    {
                        listaTokens.Add(new Token(lexema, signos[lexema], linea, columnaInicio));
                        columna++;
                        i++;
                    }
                    else
                    {
                        listaErrores.Add(new ErrorLexico(c.ToString(), linea, columnaInicio, "caracter no reconocido por el lenguaje"));
                        columna++;
                        i++;
                    }
                }
            }


            ValidarEstructuraSintactica();
        }

        private void ValidarEstructuraSintactica()
        {
            int llavesAbiertas = 0;
            int parentesisAbiertos = 0;
            int corchetesAbiertos = 0;
            Token tokenAnterior = null;

            foreach (Token token in listaTokens)
            {
                if (token.Valor == "{") llavesAbiertas++;
                if (token.Valor == "}") llavesAbiertas--;
                if (token.Valor == "(") parentesisAbiertos++;
                if (token.Valor == ")") parentesisAbiertos--;
                if (token.Valor == "[") corchetesAbiertos++;
                if (token.Valor == "]") corchetesAbiertos--;

                if (tokenAnterior != null && token.Linea > tokenAnterior.Linea)
                {
                    if (tokenAnterior.Valor != ";" &&
                        tokenAnterior.Valor != "{" &&
                        tokenAnterior.Valor != "}" &&
                        tokenAnterior.Valor != "(" &&
                        tokenAnterior.Valor != ")" &&
                        tokenAnterior.Valor != "[" &&
                        tokenAnterior.Valor != "]" &&
                        tokenAnterior.Valor != "," &&
                        tokenAnterior.Valor != ":")
                    {
                        bool lineaYaTieneError = listaErrores.Any(e => e.Linea == tokenAnterior.Linea);

                        // Faltaba este if para que solo lo agregue si NO hay error previo
                        if (!lineaYaTieneError)
                        {
                            listaErrores.Add(new ErrorLexico("Salto de línea", tokenAnterior.Linea, tokenAnterior.Columna, "Error Sintáctico: Posible falta de punto y coma (;) al final de esta instrucción"));
                        }
                    }
                }
                tokenAnterior = token;
            }

            if (llavesAbiertas > 0)
            {
                listaErrores.Add(new ErrorLexico("{", 0, 0, $"Error Sintáctico: Falta cerrar {llavesAbiertas} llave(s) '}}' en el código"));
            }
            else if (llavesAbiertas < 0)
            {
                listaErrores.Add(new ErrorLexico("}", 0, 0, $"Error Sintáctico: Hay {Math.Abs(llavesAbiertas)} llave(s) '}}' de más que no abren nada"));
            }

            if (parentesisAbiertos != 0)
            {
                listaErrores.Add(new ErrorLexico("()", 0, 0, "Error Sintáctico: Paréntesis desbalanceados (falta abrir o cerrar un paréntesis)"));
            }

            if (corchetesAbiertos != 0)
            {
                listaErrores.Add(new ErrorLexico("[]", 0, 0, "Error Sintáctico: Corchetes desbalanceados (falta abrir o cerrar un corchete '[ ]')"));
            }

            if (listaTokens.Count > 0)
            {
                Token ultimoToken = listaTokens[listaTokens.Count - 1];
                if (ultimoToken.Valor != ";" && ultimoToken.Valor != "}" && ultimoToken.Valor != "{")
                {
                    listaErrores.Add(new ErrorLexico("Fin de archivo", ultimoToken.Linea, ultimoToken.Columna, "Error Sintáctico: Falta punto y coma (;) al final de la última instrucción"));
                }
            }
        }

        public List<Token> ObtenerTokens() => listaTokens;
        public List<ErrorLexico> ObtenerErrores() => listaErrores;
        public TablaDeSimbolos ObtenerTablaSimbolos() => tablaSimbolos;
    }
}