using ExamenPractico.Controlador;
using ExamenPractico.Modelo;
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
    public partial class FormularioContactos : Form
    {
        private ContactoController contactoController;
        private int usuarioId;
        public FormularioContactos()
        {
            InitializeComponent();
            contactoController = new ContactoController();
        }

        private void FormularioContactos_Load(object sender, EventArgs e)
        {
            CargarContactos();
        }

        private void dgvContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void CargarContactos()
        {
            dgvContactos.Rows.Clear();

            List<Contacto> contactos = contactoController.ObtenerContactos();

            foreach (Contacto contacto in contactos)
            {
                dgvContactos.Rows.Add(contacto.Id, contacto.FechaRegistro, contacto.NumeroTelefono);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            Contacto nuevoContacto = new Contacto
            {
                Id = contactoController.ObtenerProximoId(), 
                FechaRegistro = DateTime.Now,
                NumeroTelefono = dgvContactos.CurrentRow.Cells["numero_telefono"].Value.ToString() 
            };

            contactoController.AgregarContacto(nuevoContacto);
            dgvContactos.Rows.Add(nuevoContacto.Id, nuevoContacto.FechaRegistro, nuevoContacto.NumeroTelefono);
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvContactos.SelectedRows.Count > 0)
            {
                int contactoId = Convert.ToInt32(dgvContactos.SelectedRows[0].Cells["id"].Value);

            
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar este contacto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    
                    contactoController.EliminarContacto(contactoId);
                    CargarContactos(); 
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
