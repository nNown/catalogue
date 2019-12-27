#ifndef DOUBLE_LINKED_LIST_H
#define DOUBLE_LINKED_LIST_H

    #ifdef DOUBLE_LINKED_LIST_H
    #define EXPORT __declspec(dllexport)
    #else
    #define EXPORT __declspec(dllimport)
    #endif

#include <stdlib.h>

typedef struct ListDataFormat {
    char* name;
    char* pathToImage;
} Data;

typedef struct node_t {
    Data data;
    struct node_t* next;
    struct node_t* prev;
} node;

typedef struct List {
    node* head;
    node* tail;
} DoubleLinkedList;

EXPORT DoubleLinkedList* CreateDoubleLinkedList();
EXPORT DoubleLinkedList* Slice(DoubleLinkedList*, int);

EXPORT int Push(DoubleLinkedList*, Data);
EXPORT int Pop(DoubleLinkedList*);

EXPORT int Unshift(DoubleLinkedList*, Data);
EXPORT int Shift(DoubleLinkedList*);

EXPORT int IndexUnshift(DoubleLinkedList*, int, Data);
EXPORT int IndexShift(DoubleLinkedList*, int);

EXPORT void Foreach(DoubleLinkedList*, void(*callback)(node*, int));

#endif // DOUBLE_LINKED_LIST_H