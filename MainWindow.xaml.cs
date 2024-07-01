using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using employee_management_app.viewModels;
namespace employee_management_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new EmployeeViewModel();
            this.DataContext = viewModel;
        }
    }
}