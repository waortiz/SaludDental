using Entidades;
using Negocio;
using Repositorio;
using System.ComponentModel;

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
            try
            {
                //TODO: 1. Recuperar los datos del formulario
                /*
                 En este paso asignamos los valores de los controles a 
                 variables locales
                 */
                Paciente paciente = new Paciente();

                var primerNombre = txtPrimerNombre.Text;
                dynamic segundoNombre = txtSegundoNombre.Text;
                string primerApellido = txtPrimerApellido.Text;
                String segundoApellido = txtSegundoApellido.Text;
                var tipoDocumento = cboTiposDocumento.SelectedItem as TipoDocumento;
                DateTime fechaNacimiento = dtpFechaNacimiento.Value;
                string telefono = txtTelefono.Text;
                string celular = txtCelular.Text;
                string direccion = txtDireccion.Text;
                var departamento = cboDepartamento.SelectedItem as string;
                var ciudad = cboCiudad.SelectedItem as Ciudad;
                var sexo = rdbFemenino.Checked ? 1 :
                           rdbMasculino.Checked ? 2 :
                           rdbNoBinario.Checked ? 3 : 1;
                var titular = chkTitular.Checked;
                var salario = 0M;

                //TODO: 2. Validar los datos del formulario
                if (ValidarDatos())
                {
                    //TODO: 3. Guardar los datos del formulario en un repositorio

                    //TODO: 4. Mostrar mensaje de confirmación/negación de la operación
                    salario = decimal.Parse(txtSalario.Text);

                    paciente.PrimerNombre = primerNombre;
                    paciente.SegundoNombre = segundoNombre;
                    paciente.PrimerApellido = primerApellido;
                    paciente.SegundoApellido = segundoApellido;
                    paciente.TipoDocumento = tipoDocumento;
                    paciente.NumeroDocumento = txtNumeroDocumento.Text;
                    paciente.FechaNacimiento = fechaNacimiento;
                    paciente.Sexo = new Sexo() { Id = sexo };
                    paciente.Direccion = direccion;
                    paciente.Ciudad = ciudad;
                    paciente.Celular = celular;
                    paciente.Titular = titular;
                    paciente.Telefono = telefono;


                    IRepositorioPaciente repositorioPaciente = new RepositorioPaciente();
                    INegocioPaciente negocioPaciente = new NegocioPaciente(repositorioPaciente);
                    if (paciente.Id == 0)
                        negocioPaciente.IngresarPaciente(paciente);
                    else
                        negocioPaciente.ActualizarPaciente(paciente);

                    var datos = @"Primer Nombre: " + primerNombre + "\n" + "Segundo Nombre: " + segundoNombre + "\n" + "Primer Apellido: " + primerApellido + "\n" + "Segundo Apellido: " + segundoApellido + "\n" + "Tipo Documento: " + tipoDocumento + "\n" + "Fecha Nacimiento: " + "\n" + fechaNacimiento.ToString("yyyy/MM/dd") + "Teléfono: " + telefono + "\n" + "Dirección: " + direccion + "\n" + "Departamento: " + departamento + "\n" + "Ciudad: " + ciudad + "\n" + "Sexo: " + sexo + "\n" + "Titular: " + titular + "\n" +
                                     "Salario: " + salario.ToString("###,##");
                    MessageBox.Show(datos, "Datos Paciente",
                        MessageBoxButtons.OK);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor sabes te queremos. Por ahora el sistema tiene dificultades. Volveremos pronto.  " +
                    "El error presentado es: " + ex.Message,
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
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
            var tipoDocumento = cboTiposDocumento.SelectedItem as TipoDocumento;
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
            if (tipoDocumento == null)
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
            if (!rdbFemenino.Checked && !rdbMasculino.Checked && !rdbNoBinario.Checked)
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
                caracter != '9' && (int)caracter != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper()[0];
        }

        private void txtCelular_Validating(object sender, CancelEventArgs e)
        {
            erpMensaje.SetError(txtCelular, null);
            if (txtCelular.Text.Length == 0 || txtCelular.Text[0] != '3')
            {
                erpMensaje.SetError(txtCelular, "El número de celular debe empezar por 3");
            }
        }

        private void DatosPaciente_Load(object sender, EventArgs e)
        {
            INegocioMaestro negocio = new NegocioMaestro();

            cboTiposDocumento.DataSource = negocio.ObtenerTiposDocumento();
            cboTiposDocumento.DisplayMember = "Nombre";

            cboDepartamento.DataSource = negocio.ObtenerDepartamentos();
            cboDepartamento.DisplayMember = "Nombre";

        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            INegocioMaestro negocio = new NegocioMaestro();
            var departamento = cboDepartamento.SelectedItem as Departamento;
            if (cboDepartamento.SelectedItem != null)
            {
                cboCiudad.DataSource = negocio.ObtenerCiudades(departamento.Id);
                cboCiudad.DisplayMember = "Nombre";
            }
            else
            {
                cboCiudad.DataSource = new List<Ciudad>();
                cboCiudad.DisplayMember = "Nombre";
            }
        }
    }
}
