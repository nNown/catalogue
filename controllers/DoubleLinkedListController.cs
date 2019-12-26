using System;
using System.Runtime.InteropServices;

namespace DoubleLinkedListController {
    public class DLLController {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct node {
            public int value;
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
        public unsafe static extern int Push(List* list, int val);
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int Pop(List* list);
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int Unshift(List* list, int val);
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int Shift(List* list);
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int IndexUnshift(List* list, int index, int val);
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int IndexShift(List* list, int index);
        [DllImport(@"./libs/DoubleLinkedList.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void Foreach(List* list, Callback callback);
    }
}
