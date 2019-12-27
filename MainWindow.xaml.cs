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
using System.Runtime.InteropServices;

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
                MessageBox.Show(Marshal.PtrToStringAnsi((IntPtr)initializedData.head->next->data.name)); 
            }           
        }
    
        private DLLController.List GetData() {
            unsafe {
                var List = DLLController.CreateDoubleLinkedList();
                var ParsedData = new DLLController.Data();
                
                System.Text.Encoding enc = System.Text.Encoding.ASCII;
                byte[] name = enc.GetBytes("Random name");

                int size = Marshal.SizeOf(name[0] * name.Length);

                IntPtr ptr = Marshal.AllocHGlobal(size);
                
                Marshal.Copy(name, 0, ptr, name.Length);

                ParsedData.name = (byte*) ptr.ToPointer();
                ParsedData.pathToImage = (byte*) ptr.ToPointer();
                
                DLLController.Push(List, ParsedData);
                return *List;
            }
        }
    }
}
