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
using System.Runtime.InteropServices;
using Controllers.DoubleLinkedList;
using Models.AnimalModel;

namespace ProjektPP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        unsafe DLLController.List* initializedData;
        public MainWindow()
        {   
            unsafe { initializedData = GetData(); }

            InitializeComponent();
        }

        private unsafe void Test(object sender, RoutedEventArgs args) {
            MessageBox.Show(Marshal.PtrToStringAnsi((IntPtr)initializedData->head->next->data.name));
        }

        private unsafe DLLController.List* GetData() {
            var List = DLLController.CreateDoubleLinkedList();
            var ParsedData = new DLLController.Data();
                
            var ModelData = new AnimalData().GetJsonData("./data/animals.json");
            for(int i = 0; i < ModelData.Count; i++) {
                ParsedData.name = ConvertStringToBytePointer(ModelData[i].name);
                ParsedData.pathToImage = ConvertStringToBytePointer(ModelData[i].pathToImage);
                DLLController.Push(List, ParsedData);
            }

            return List;
        }

        private unsafe byte* ConvertStringToBytePointer(string s) {
            byte[] stringAsByteArr = Encoding.ASCII.GetBytes(s);

            int size = Marshal.SizeOf(stringAsByteArr[0] * stringAsByteArr.Length);

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(stringAsByteArr, 0, ptr, stringAsByteArr.Length);

            return (byte*) ptr.ToPointer();
        }
    }
}
