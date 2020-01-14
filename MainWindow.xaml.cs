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

namespace ProjektPP2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        unsafe DLLController.List* initializedData;
        unsafe DLLController.node* currentNode;
        public MainWindow() { 
            AnimalModel currentModel;
            
            unsafe { 
                initializedData = GetData();
                currentNode = initializedData->head->next;
                currentModel = GetModel(currentNode);
            }

            this.DataContext = currentModel;

            InitializeComponent();
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

        private unsafe AnimalModel GetModel(DLLController.node* node) {
            return Marshal.PtrToStructure<AnimalModel>((IntPtr) node->data);
        }

        private unsafe void NextNode(object sender, RoutedEventArgs args) {
            if(currentNode->next->data != null) {
                currentNode = currentNode->next;
                this.DataContext = GetModel(currentNode);
            }
        }

        private unsafe void PrevNode(object sender, RoutedEventArgs args) {
            if(currentNode->prev->data != null) {
                currentNode = currentNode->prev;
                this.DataContext = GetModel(currentNode);
            }
        }

        private unsafe void DeleteNode(object sender, RoutedEventArgs args) {
            // Delete first node in the list
            if(currentNode->prev->data == null && currentNode->next->data != null) {
                this.DataContext = GetModel(currentNode->next);

                Marshal.FreeHGlobal((IntPtr) currentNode->data);
                currentNode = currentNode->next;
                DLLController.Shift(initializedData);
            // Delete last node in the list
            } else if(currentNode->next->data == null && currentNode->prev->data != null) {
                this.DataContext = GetModel(currentNode->prev);

                Marshal.FreeHGlobal((IntPtr) currentNode->data);
                currentNode = currentNode->prev;
                DLLController.Pop(initializedData);
            // Delete node between first and last node
            } else if(currentNode->next->data != null && currentNode->prev->data != null) {
                int index = 0;
                DLLController.node* temp = initializedData->head->next;
                while(temp->data != currentNode->data) {
                    temp = temp->next;
                    index++;
                }

                this.DataContext = GetModel(currentNode->next);
                
                Marshal.FreeHGlobal((IntPtr) currentNode->data);
                currentNode = currentNode->next;
                DLLController.IndexShift(initializedData, index);
            }
        }

        private void ChangeToAddView(object sender, RoutedEventArgs args) {}
    }
}
