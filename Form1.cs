using ExamenPractico.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenPractico
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            UsuarioForm registroForm = new UsuarioForm();
            registroForm.ShowDialog();
        }

        private void btnContactos_Click(object sender, EventArgs e)
        {
            FormularioContactos formularioContactos = new FormularioContactos();
            formularioContactos.ShowDialog();
        }
    }
}
