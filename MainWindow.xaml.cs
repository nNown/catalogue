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
using DoubleLinkedListController;

namespace ProjektPP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {   
            unsafe {
                var List = DLLController.CreateDoubleLinkedList();
                DLLController.Push(List, 100);
                test2 = List->head->next->value;
            }
            InitializeComponent();
        }

        int test2;
        private void Test(object sender, RoutedEventArgs args) {
            MessageBox.Show("" + test2);            
        }
    }
}
