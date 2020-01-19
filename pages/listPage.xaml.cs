using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using Controllers.DoubleLinkedList;
using Models.AnimalModel;

namespace ProjektPP2 {
    public partial class listPage : Page {
        public listPage() {
            App.ParentWindowRef.ParentFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            AnimalModel currentModel;
                
            unsafe { 
                App.currentNode = App.data->head->next;
                currentModel = GetModel(App.currentNode);
            }

            this.DataContext = currentModel;

            InitializeComponent();
        }

        private unsafe AnimalModel GetModel(DLLController.node* node) {
            return Marshal.PtrToStructure<AnimalModel>((IntPtr) node->data);
        }

        private unsafe void NextNode(object sender, RoutedEventArgs args) {
            if(App.currentNode->next->data != null) {
                App.currentNode = App.currentNode->next;
                this.DataContext = GetModel(App.currentNode);
            }
        }

        private unsafe void PrevNode(object sender, RoutedEventArgs args) {
            if(App.currentNode->prev->data != null) {
                App.currentNode = App.currentNode->prev;
                this.DataContext = GetModel(App.currentNode);
            }
        }

        private unsafe void DeleteNode(object sender, RoutedEventArgs args) {
            // Delete first node in the list
            if(App.currentNode->prev->data == null && App.currentNode->next->data != null) {
                this.DataContext = GetModel(App.currentNode->next);

                Marshal.FreeHGlobal((IntPtr) App.currentNode->data);
                App.currentNode = App.currentNode->next;
                DLLController.Shift(App.data);
            // Delete last node in the list
            } else if(App.currentNode->next->data == null && App.currentNode->prev->data != null) {
                this.DataContext = GetModel(App.currentNode->prev);

                Marshal.FreeHGlobal((IntPtr) App.currentNode->data);
                App.currentNode = App.currentNode->prev;
                DLLController.Pop(App.data);
            // Delete node between first and last node
            } else if(App.currentNode->next->data != null && App.currentNode->prev->data != null) {
                int index = 0;
                DLLController.node* temp = App.data->head->next;
                while(temp->data != App.currentNode->data) {
                    temp = temp->next;
                    index++;
                }

                this.DataContext = GetModel(App.currentNode->next);
                
                Marshal.FreeHGlobal((IntPtr) App.currentNode->data);
                App.currentNode = App.currentNode->next;
                DLLController.IndexShift(App.data, index);
            }
        }

        private void ChangeToAddView(object sender, RoutedEventArgs args) {
            App.ParentWindowRef.ParentFrame.Navigate(new addPage());
        }
    }
}