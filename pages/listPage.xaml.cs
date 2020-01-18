using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using Controllers.DoubleLinkedList;
using Models.AnimalModel;

namespace ProjektPP2 {
    public partial class listPage : Page {
        unsafe DLLController.node* currentNode;

        public listPage() {
            App.ParentWindowRef.ParentFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            AnimalModel currentModel;
                
            unsafe { 
                currentNode = App.data->head->next;
                currentModel = GetModel(currentNode);
            }

            this.DataContext = currentModel;

            InitializeComponent();
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
                DLLController.Shift(App.data);
            // Delete last node in the list
            } else if(currentNode->next->data == null && currentNode->prev->data != null) {
                this.DataContext = GetModel(currentNode->prev);

                Marshal.FreeHGlobal((IntPtr) currentNode->data);
                currentNode = currentNode->prev;
                DLLController.Pop(App.data);
            // Delete node between first and last node
            } else if(currentNode->next->data != null && currentNode->prev->data != null) {
                int index = 0;
                DLLController.node* temp = App.data->head->next;
                while(temp->data != currentNode->data) {
                    temp = temp->next;
                    index++;
                }

                this.DataContext = GetModel(currentNode->next);
                
                Marshal.FreeHGlobal((IntPtr) currentNode->data);
                currentNode = currentNode->next;
                DLLController.IndexShift(App.data, index);
            }
        }

        private void ChangeToAddView(object sender, RoutedEventArgs args) {
            App.ParentWindowRef.ParentFrame.Navigate(new addPage());
        }
    }
}