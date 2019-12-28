#ifndef DOUBLE_LINKED_LIST_H
#define DOUBLE_LINKED_LIST_H

    #ifdef DOUBLE_LINKED_LIST_H
    #define EXPORT __declspec(dllexport)
    #else
    #define EXPORT __declspec(dllimport)
    #endif

#include <stdlib.h>

typedef struct node_t {
    void* data;
    struct node_t* next;
    struct node_t* prev;
} node;

typedef struct List {
    node* head;
    node* tail;
} DoubleLinkedList;

EXPORT DoubleLinkedList* CreateDoubleLinkedList();
EXPORT DoubleLinkedList* Slice(DoubleLinkedList*, int);

EXPORT void Push(DoubleLinkedList*, void*);
EXPORT void Pop(DoubleLinkedList*);

EXPORT void Unshift(DoubleLinkedList*, void*);
EXPORT void Shift(DoubleLinkedList*);

EXPORT void IndexUnshift(DoubleLinkedList*, int, void*);
EXPORT void IndexShift(DoubleLinkedList*, int);

EXPORT void Foreach(DoubleLinkedList*, void(*callback)(node*, int));

#endif // DOUBLE_LINKED_LIST_H