using System.Windows;
//dotnet run

namespace ProjektPP2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        
        public MainWindow() { 
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs args) {
            App.ParentWindowRef = this;
            this.ParentFrame.Navigate(new listPage());
        }
    }
}
