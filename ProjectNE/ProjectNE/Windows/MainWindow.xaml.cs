using ProjectNE.SQL;
using System.Windows;

namespace ProjectNE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Visibility ShowTestPane = Visibility.Visible;

        public MainWindow()
        {
            InitializeComponent();

            TestPane.Visibility = ShowTestPane;
        }

        /// <summary>
        /// Test the SQL hookup, and debug into it to see how it works.
        /// </summary>
        private void SQLTest_Click(object sender, RoutedEventArgs e)
        {
            // Don't forget to have native debugging!
            FileDBManager db = new FileDBManager();
            db.CreateDBExample();
        }
    }
}
