#ifndef DOUBLE_LINKED_LIST_H
#define DOUBLE_LINKED_LIST_H

    #ifdef DOUBLE_LINKED_LIST_H
    #define EXPORT __declspec(dllexport)
    #else
    #define EXPORT __declspec(dllimport)
    #endif

#include <stdlib.h>

typedef struct node_t {
    int value;
    struct node_t* next;
    struct node_t* prev;
} node;

typedef struct List {
    node* head;
    node* tail;
} DoubleLinkedList;

EXPORT DoubleLinkedList* CreateDoubleLinkedList();
EXPORT DoubleLinkedList* Slice(DoubleLinkedList*, int);

EXPORT int Push(DoubleLinkedList*, int);
EXPORT int Pop(DoubleLinkedList*);

EXPORT int Unshift(DoubleLinkedList*, int);
EXPORT int Shift(DoubleLinkedList*);

EXPORT int IndexUnshift(DoubleLinkedList*, int, int);
EXPORT int IndexShift(DoubleLinkedList*, int);

EXPORT void Foreach(DoubleLinkedList*, void(*callback)(node*, int));

#endif // DOUBLE_LINKED_LIST_H