using Negocio;
using Repositorio;

namespace SaludDental
{
    public partial class Ingreso : Form
    {
        public Ingreso()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            erpMensaje.SetError(txtUsuario, null);
            erpMensaje.SetError(txtClave, null);
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                erpMensaje.SetError(txtUsuario, "Por favor ingresa el nombre de usuario");
                return;
            }
            if (string.IsNullOrEmpty(txtClave.Text))
            {
                erpMensaje.SetError(txtClave, "Por favor ingresa la contraseña");
                return;
            }

            INegocioUsuario negocio= new NegocioUsuario(new RepositorioSeguridad());
            if (negocio.ValidarUsuario(txtUsuario.Text , txtClave.Text))
            {
                var principal = new MDIPrincipal();
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Las credenciales de ingreso no son válidas. por favor verifique.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ingreso_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}