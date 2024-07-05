using ExamenPractico.Controlador;
using ExamenPractico.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExamenPractico
{
    public partial class UsuarioForm : Form
    {
        private UsuarioController usuarioController;
        private Usuario usuarioActual;
        public UsuarioForm()
        {
            InitializeComponent();
            usuarioController = new UsuarioController();
        }

        public void CargarUsuario(int usuarioId)
        {
            usuarioActual = usuarioController.ObtenerUsuarioPorId(usuarioId);

            if (usuarioActual != null)
            {
                txtId.Text = usuarioActual.Id.ToString();
                txtNickName.Text = usuarioActual.Nickname;
                txtCorreo.Text = usuarioActual.Correo;
                cboxEstatus.Checked = usuarioActual.Estatus;
            }
            else
            {
                MessageBox.Show("No se pudo cargar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (usuarioActual == null)
                {

                    usuarioActual = new Usuario
                    {
                        Nickname = txtNickName.Text,
                        Correo = txtCorreo.Text,
                        Contraseña = txtContrasenia.Text,
                        Estatus = cboxEstatus.Checked
                    };

                    try
                    {
                        usuarioController.CrearUsuario(usuarioActual);
                        MessageBox.Show("Usuario creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al crear usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                    usuarioActual.Nickname = txtNickName.Text;
                    usuarioActual.Correo = txtCorreo.Text;
                    usuarioActual.Contraseña = txtContrasenia.Text;
                    usuarioActual.Estatus = cboxEstatus.Checked;

                    try
                    {
                        usuarioController.ActualizarUsuario(usuarioActual);
                        MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNickName.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtContrasenia.Text = string.Empty;
            txtId.Text = string.Empty;
            cboxEstatus.Checked = false;
            usuarioActual = null;
        }

        private bool ValidarDatos()
        {
            
            if (string.IsNullOrWhiteSpace(txtNickName.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtContrasenia.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void cboxEstatus_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioActual != null && !string.IsNullOrEmpty(txtId.Text))
            {
                int usuarioId = int.Parse(txtId.Text);

                DialogResult result = MessageBox.Show("¿Estás seguro que deseas eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        usuarioController.EliminarUsuario(usuarioId);
                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay ningún usuario seleccionado para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {

        }
    }
}
