using System.Runtime.InteropServices;

namespace Controllers.DoubleLinkedList {
    public class DLLController {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct node {
            public void* data;
            public node* next;
            public node* prev;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct List {
            public node* head;
            public node* tail;
        }

        public unsafe delegate void Callback(node* el, int index);

        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern List* CreateDoubleLinkedList();
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void Push(List* list, void* data);
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void Pop(List* list);
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void Unshift(List* list, void* data);
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void Shift(List* list);
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void IndexUnshift(List* list, int index, void* data);
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void IndexShift(List* list, int index);
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void Foreach(List* list, Callback callback);
    }
}
