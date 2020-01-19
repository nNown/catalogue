using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using Controllers.DoubleLinkedList;
using Models.AnimalModel;

namespace ProjektPP2 {
    public partial class addPage : Page {
        private string pathToImg;
        public addPage() {
            App.ParentWindowRef.ParentFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            InitializeComponent();
        }

        private void cancelAddingNode(object sender, RoutedEventArgs args) {
            App.ParentWindowRef.ParentFrame.Navigate(new listPage());
        }

        private unsafe void addNode(object sender, RoutedEventArgs args) {
            AnimalModel data = new AnimalModel();

            Random _random = new Random();
            data.ID = _random.Next();

            data.name = Name.Text;
            data.latinName = LatinName.Text;
            data.family = Family.Text;
            data.conservationStatus = Status.Text;
            data.caughtBy = CaughtBy.Text;
            data.place = Place.Text;
            data.date = Date.Text;

            data.pathToImage = pathToImg;

            IntPtr ParsedData = Marshal.AllocHGlobal(Marshal.SizeOf(data));
            Marshal.StructureToPtr(data, ParsedData, false);

            DLLController.Push(App.data, ParsedData.ToPointer());
            App.ParentWindowRef.ParentFrame.Navigate(new listPage());
        }

        private void uploadImage(object sender, RoutedEventArgs args) {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

            fileDialog.DefaultExt = ".png";
            fileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            bool? result = fileDialog.ShowDialog();

            if(result == true) {
                pathToImg = fileDialog.FileName;
            }
        }
    }
}