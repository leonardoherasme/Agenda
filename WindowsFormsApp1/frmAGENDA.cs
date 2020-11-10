using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaDatos;

namespace WindowsFormsApp1
{
    public partial class frmAGENDA : Form
    {
        private string idontacto;
        private bool editarse = false;

        E_Agenda objEntidad = new E_Agenda();
        N_Agenda objNegocio = new N_Agenda();

        public frmAGENDA()
        {
            InitializeComponent();
        }

        private void exiticon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmAGENDA_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }
        public void mostrarBuscarTabla(string buscar)// -------------------BUSCAR
        {
            N_Agenda objNegocio = new N_Agenda();
            tablaAgenda.DataSource = objNegocio.ListarAgenda(buscar);
        }

        private void TextboxBUSCAR_OnTextChange(object sender, EventArgs e)
        {
            mostrarBuscarTabla(TextboxBUSCAR.text);
        }
        private void LimpiarCaja()// -------------------LIMPIAR CAJA
        {
            editarse = false;
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxCedula.Text = "";
            textBoxCorreo.Text = "";
            textBoxDireccion.Text = "";
            textBoxNombre.Focus();
        }
        public void Accionestabla()// -------------------ACCIONES
        {
            tablaAgenda.ClearSelection();
        }
        private void btnNuevo_Click(object sender, EventArgs e)// -------------------NUEVO
        {
            LimpiarCaja();
        }

        private void btnEditar_Click(object sender, EventArgs e)// -------------------EDITAR
        {
            if(tablaAgenda.SelectedRows.Count > 0)
            {
                if (tablaAgenda.SelectedRows.Count > 0)
                {
                    editarse = true;
                    idontacto = tablaAgenda.CurrentRow.Cells[0].Value.ToString();
                    textBoxNombre.Text = tablaAgenda.CurrentRow.Cells[1].Value.ToString();
                    textBoxApellido.Text = tablaAgenda.CurrentRow.Cells[2].Value.ToString();
                    textBoxCedula.Text = tablaAgenda.CurrentRow.Cells[3].Value.ToString();
                    textBoxCorreo.Text = tablaAgenda.CurrentRow.Cells[3].Value.ToString();
                    textBoxDireccion.Text = tablaAgenda.CurrentRow.Cells[3].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Seleccione la fila que desea editar");
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)// -------------------GUARDAR
        {
            if (editarse == false)
            {
                try
                {
                    objEntidad.Anombre = textBoxNombre.Text.ToUpper();
                    objEntidad.Aapellido = textBoxApellido.Text.ToUpper();
                    objEntidad.Acedula = textBoxCedula.Text.ToUpper();
                    objEntidad.Acorreo = textBoxCorreo.Text.ToUpper();
                    objEntidad.Adireccion = textBoxDireccion.Text.ToUpper();

                    objNegocio.InsertandoAgenda(objEntidad);
                    MessageBox.Show("Se guardo el registro");
                    mostrarBuscarTabla("");
                    editarse = false;
                    LimpiarCaja();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
            if (editarse == true)
            {
                try
                {
                    objEntidad.Idagenda = Convert.ToInt32(idontacto);
                    objEntidad.Anombre = textBoxNombre.Text.ToUpper();
                    objEntidad.Aapellido = textBoxApellido.Text.ToUpper();
                    objEntidad.Acedula = textBoxCedula.Text.ToUpper();
                    objEntidad.Acorreo = textBoxCorreo.Text.ToUpper();
                    objEntidad.Adireccion = textBoxDireccion.Text.ToUpper();

                    objNegocio.EditandoAgenda(objEntidad);
                    MessageBox.Show("Se edito el registro");
                    mostrarBuscarTabla("");
                    editarse = false;
                    LimpiarCaja();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro" + ex);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)// -------------------ELIMINAR
        {
            if(tablaAgenda.SelectedRows.Count > 0)
            {
                objEntidad.Idagenda = Convert.ToInt32(tablaAgenda.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminarAgenda(objEntidad);
                MessageBox.Show("Se ha eliminado el registro");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar");
            }
        }
    }
}
