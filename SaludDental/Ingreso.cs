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