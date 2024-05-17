namespace TPN1EfCore.Windows
{
    public partial class Form1 : Form
    {
        private static IServiceProvider? _serviceProvider;
        public Form1(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
