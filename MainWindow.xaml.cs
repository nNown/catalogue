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
        DLLController.List initializedData;
        public MainWindow()
        {   
            initializedData = GetData();
            InitializeComponent();
        }

        private void Test(object sender, RoutedEventArgs args) {
            unsafe {
                MessageBox.Show("" + initializedData.head->next->value); 
            }           
        }

        private DLLController.List GetData() {
            unsafe {
                var Data = DLLController.CreateDoubleLinkedList();
                DLLController.Push(Data, 100);

                return *Data;
            }
        }
    }
}
