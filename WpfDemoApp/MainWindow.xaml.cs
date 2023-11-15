using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FakePublisher fakePublisher;

        public MainWindow()
        {
            InitializeComponent();

            fakePublisher = new FakePublisher();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyDialogMemoryLeak myDialog = new MyDialogMemoryLeak();
            myDialog.Owner = this; // Set the owner to enable proper dialog behavior
            myDialog.SubscribeFakePublisher(fakePublisher);
            myDialog.ShowDialog();
        }
    }
}
