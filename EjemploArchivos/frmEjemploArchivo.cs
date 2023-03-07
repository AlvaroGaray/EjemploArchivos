using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploArchivos
{
    public partial class frmEjemploArchivo : Form
    {
        public frmEjemploArchivo()
        {
            InitializeComponent();
        }

        //Se invoca cuando el usuario oprime una tecla
        private void txtEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            //Determina si el usuario oprimio la Tecla intro
            if(e.KeyCode== Keys.Enter)
            {
                string nombreArchivo; //Nombre del Archivo o Directorio

                //obtiene el Archivo o Directorio especificado por el usuario
                nombreArchivo = txtEntrada.Text;

                //Determina si nombreArchivo es un archivo
                if (File.Exists(nombreArchivo))
                {
                    //Obtiene la fecha de creacion del archivo 
                    //Su fecha de Modificacion , etc...
                    txtSalida.Text = obtenerInformacion(nombreArchivo);

                    //Muestra el contenido del archivo a traves de StreamReader
                    try
                    {
                        StreamReader sr = new StreamReader(nombreArchivo);
                        txtSalida.Text += sr.ReadToEnd();
                    }catch (IOException)
                    {
                        MessageBox.Show("Error al leer el Archivo", "Error de Archivo" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }else if (Directory.Exists(nombreArchivo))
                {
                    string[] listaDirectorios; //Arreglo para los directorios

                    txtSalida.Text = obtenerInformacion(nombreArchivo);

                    //Obtiene la lista de archivos del directorio especificado por el usuario
                    listaDirectorios=Directory.GetDirectories(nombreArchivo);
                }
                else
                {
                    MessageBox.Show(txtEntrada.Text+ " No existe" , "Error de Archivo" ,MessageBoxButtons.OK , MessageBoxIcon.Error);
                }
            }
            
        }

        private string obtenerInformacion(string nombreArchivo)
        {
            //Imprime un mensaje indicanco que exise el archivo o directorio
            string informacion = nombreArchivo + " Existe\r\n\r\n  ";

            //Imprimir el pantalla la fecha y hora de Creacion del Archivo o Directorio
            informacion += " Creacion " + File.GetCreationTime(nombreArchivo) + "\r\n";

            //Imprimir el pantalla la fecha y hora de Modificacion del Archivo o Directorio
            informacion += " Ultima Modificacion " + File.GetLastWriteTime(nombreArchivo) + "\r\n";

            //Imprimir el pantalla la fecha y hora de Acceso del Archivo o Directorio
            informacion += "Ultimo Acceso " + File.GetLastAccessTime(nombreArchivo) + "\r\n";

            return informacion;
        }
    }
}
