using System;
using System.Windows;
using System.Runtime.InteropServices;
using Controllers.DoubleLinkedList;
using Models.AnimalModel;

namespace ProjektPP2 {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public static unsafe DLLController.List* data;
        public static unsafe DLLController.node* currentNode;
        public static MainWindow ParentWindowRef;
        private unsafe void AppStartup(object sender, StartupEventArgs args) {
            data = GetData();
        }

        private unsafe DLLController.List* GetData() {
            var List = DLLController.CreateDoubleLinkedList();
            var ParsedData = new AnimalData().GetJsonData("./data/animals.json");
            for(int i = 0; i < ParsedData.Count; i++) {
                IntPtr ParsedObjectPtr = Marshal.AllocHGlobal(Marshal.SizeOf(ParsedData[i]));
                Marshal.StructureToPtr(ParsedData[i], ParsedObjectPtr, false);

                DLLController.Push(List, ParsedObjectPtr.ToPointer());
            }
            return List;
        }
    }
}
