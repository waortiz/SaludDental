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
            var salario = Convert.ToDecimal(txtSalario.Text);

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

            //TODO: 2. Validar los datos del formulario

            //TODO: 3. Guardar los datos del formulario en un repositorio

            //TODO: 4. Mostrar mensaje de confirmación/negación de la operación
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
