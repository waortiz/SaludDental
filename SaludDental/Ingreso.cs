namespace SaludDental
{
    public partial class Ingreso : Form
    {
        private const string USUARIO = "wortiz";
        private const string CLAVE = "123";

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

            if (txtUsuario.Text == USUARIO && txtClave.Text == CLAVE)
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

        }
    }
}