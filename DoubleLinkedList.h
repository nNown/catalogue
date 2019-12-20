#ifndef DOUBLE_LINKED_LIST_H
#define DOUBLE_LINKED_LIST_H

#include <stdlib.h>
#include <stdio.h>

typedef struct node_t {
    int value;
    struct node_t* next;
    struct node_t* prev;
} node;

typedef struct List {
    node* head;
    node* tail;
} DoubleLinkedList;

DoubleLinkedList* CreateDoubleLinkedList();
DoubleLinkedList* Slice(DoubleLinkedList*, int);

int Push(DoubleLinkedList*, int);
int Pop(DoubleLinkedList*);

int Unshift(DoubleLinkedList*, int);
int Shift(DoubleLinkedList*);

int IndexUnshift(DoubleLinkedList*, int, int);
int IndexShift(DoubleLinkedList*, int);

void PrintList(DoubleLinkedList*);
void PrintInReverseOrder(DoubleLinkedList*);

void Foreach(DoubleLinkedList*, void(*callback)(node*, int));

#endif // DOUBLE_LINKED_LIST_H