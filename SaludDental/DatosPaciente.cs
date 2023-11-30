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
            if (ValidarDatos())
            {
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
            else
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ValidarDatos()
        {
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

            if (primerNombre.Trim() == "")
            {
                MessageBox.Show("El primer nombre no debe estar vacío",
                    this.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(primerApellido.Trim()))
            {
                MessageBox.Show("El primer apellido no debe estar vacío",
                   this.Text,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(tipoDocumento))
            {
                MessageBox.Show("Debe seleccionar un tipo documento",
                  this.Text,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return false;
            }
            if (fechaNacimiento > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no debe ser mayor a la fecha actual",
                  this.Text,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return false;
            }

            if (telefono.Trim() == string.Empty)
            {
                MessageBox.Show("El teléfono no debe estar vacío",
                  this.Text,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return false;
            }
            if (direccion.Trim() == string.Empty)
            {
                MessageBox.Show("La dirección no debe estar vacía",
                  this.Text,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return false;
            }
            if (!rdbFemenino.Checked && rdbMasculino.Checked && !rdbNoBinario.Checked)
            {
                MessageBox.Show("El sexo no es válido",
                  this.Text,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtSalario.Text))
            {
                MessageBox.Show("El salario no debe estar vacío",
                  this.Text,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return false;
            }
            else
            {
                int i = 0;
                //while(i < txtSalario.TextLength)
                //for (i = 0; i < txtSalario.TextLength; i++)
                foreach (var caracter in txtSalario.Text)
                {
                    /*if (txtSalario.Text[i] != '0' && txtSalario.Text[i] != '1' && txtSalario.Text[i] != '2' &&
                       txtSalario.Text[i] != '3' && txtSalario.Text[i] != '4' && txtSalario.Text[i] != '5' &&
                       txtSalario.Text[i] != '6' && txtSalario.Text[i] != '7' && txtSalario.Text[i] != '8' &&
                       txtSalario.Text[i] != '9')*/
                    if (caracter != '0' && caracter != '1' && caracter != '2' &&
                       caracter != '3' && caracter != '4' && caracter != '5' &&
                       caracter != '6' && caracter != '7' && caracter != '8' &&
                       caracter != '9')
                    {
                        MessageBox.Show("El salario solo debe tener números",
                          this.Text,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                        return false;
                    }
                    //i++;
                    //i = i + 1;
                    //i += 1;
                }
            }

            return true;
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            var caracter = e.KeyChar;
            if (caracter != '0' && caracter != '1' && caracter != '2' &&
                caracter != '3' && caracter != '4' && caracter != '5' &&
                caracter != '6' && caracter != '7' && caracter != '8' &&
                caracter != '9')
            {
                e.Handled = true;
            }
        }
    }
}
