using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaludDental
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DatosPaciente : Form
    {
        public DatosPaciente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que permite guardar los datos de un paciente
        /// </summary>
        /// <param name="sender">Control que desencadena el evento</param>
        /// <param name="e">Datos del evento</param>
        /// <remarks></remarks>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //TODO: 1. Recuperar los datos del formulario
            /*
             En este paso asignamos los valores de los controles a 
             variables locales
             */
            var primerNombre = txtPrimerNombre.Text;
            dynamic segundoNombre = txtSegundoNombre.Text;
            string primerApellido = txtPrimerApellido.Text;
            String segundoApellido = txtSegundoApellido.Text;
            var tipoDocumento = cboTiposDocumento.SelectedItem as string;
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            string telefono = txtTelefono.Text;
            string direccion = txtDireccion.Text;
            var departamento = cboDepartamento.SelectedItem as string;
            var ciudad = cboCiudad.SelectedItem as string;
            var sexo = rdbFemenino.Checked ? "Femenino" :
                       rdbMasculino.Checked ? "Masculino" :
                       rdbNoBinario.Checked ? "No Binario" : "";
            var titular = chkTitular.Checked;
            var salario = 0M;

            //TODO: 2. Validar los datos del formulario
            if(primerNombre.Trim() == "")
            {
                MessageBox.Show("El primer nombre no debe estar vacío", 
                    this.Text, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(primerApellido.Trim()))
            {
                MessageBox.Show("El primer apellido no debe estar vacío",
                   this.Text,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tipoDocumento))
            {
                MessageBox.Show("Debe seleccionar un tipo documento",
                  this.Text,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return;
            }
            if (fechaNacimiento > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no debe ser mayor a la fecha actual",
                  this.Text,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return;
            }

            if (telefono.Trim() == string.Empty)
            {
                MessageBox.Show("El teléfono no debe estar vacío",
                  this.Text,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return;
            }
            if (direccion.Trim() == string.Empty)
            {
                MessageBox.Show("La dirección no debe estar vacía",
                  this.Text,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return;
            }
            if (!rdbFemenino.Checked && rdbMasculino.Checked && !rdbNoBinario.Checked)
            {
                MessageBox.Show("El sexo no es válido",
                  this.Text,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtSalario.Text))
            {
                MessageBox.Show("El salario no debe estar vacío",
                  this.Text,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return;
            }
            else
            {
                salario = Convert.ToDecimal(txtSalario.Text);
            }
            //TODO: 3. Guardar los datos del formulario en un repositorio

            //TODO: 4. Mostrar mensaje de confirmación/negación de la operación
            var datos = @"Primer Nombre: " + primerNombre +
                             "Segundo Nombre: " + segundoNombre +
                             "Primer Apellido: " + primerApellido +
                             "Segundo Apellido: " + segundoApellido +
                             "Tipo Documento: " + tipoDocumento +
                             "Fecha Nacimiento: " + fechaNacimiento +
                             "Teléfono: " + telefono +
                             "Dirección: " + direccion +
                             "Departamento: " + departamento +
                             "Ciudad: " + ciudad +
                             "Sexo: " + sexo +
                             "Titular: " + titular +
                             "Salario: " + salario;
            MessageBox.Show(datos, "Datos Paciente",
                MessageBoxButtons.OK);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ValidarDatos()
        {

            return true;
        }

    }
}
