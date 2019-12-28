#include "DoubleLinkedList.h"

EXPORT DoubleLinkedList* CreateDoubleLinkedList() {
    node* head = malloc(sizeof(node));
    node* tail = malloc(sizeof(node));

    head->data = NULL;
    head->next = tail;
    head->prev = NULL;

    tail->data = NULL;
    tail->next = NULL;
    tail->prev = head;

    DoubleLinkedList* List = malloc(sizeof(DoubleLinkedList));
    List->head = head;
    List->tail = tail;

    return List;
}

EXPORT DoubleLinkedList* Slice(DoubleLinkedList* List, int index) {
    node* currentOfFirst = List->head->next;
    int i;
    for(i = 0; i < index - 1; i++) {
        if(currentOfFirst->next->next == NULL && i < index) {
            return List;
        }
        currentOfFirst = currentOfFirst->next;
    }

    node* currentOfSliced = currentOfFirst->next;

    currentOfFirst->next = List->tail;
    List->tail->prev = currentOfFirst;

    DoubleLinkedList* SlicedList = CreateDoubleLinkedList();
    SlicedList->head->next = currentOfSliced;
    currentOfSliced->prev = SlicedList->head;

    while(currentOfSliced->next->next != NULL) {
        currentOfSliced = currentOfSliced->next;
    }

    currentOfSliced->next = SlicedList->tail;
    SlicedList->tail->prev = currentOfSliced;

    return SlicedList;
}

EXPORT void Push(DoubleLinkedList* List, void* data) {
    node* temp = malloc(sizeof(node));
    temp->data = data;
    temp->next = List->tail;
    temp->prev = List->tail->prev;

    List->tail->prev->next = temp;
    List->tail->prev = temp;

    return;
}

EXPORT void Pop(DoubleLinkedList* List) {
    if(List->head->next->next == NULL) {
        List->head->next = NULL;
        List->tail->prev = NULL;
        free(List);
        return;
    }

    node* temp = List->tail->prev->prev;
    
    free(List->tail->prev);

    temp->next = List->tail;
    List->tail->prev = temp;

    return;
}

EXPORT void Unshift(DoubleLinkedList* List, void* data) {
    node* temp = malloc(sizeof(node));
    temp->data = data;
    temp->next = List->head->next;
    temp->prev = List->head;

    List->head->next->prev = temp;
    List->head->next = temp;

    return;
}

EXPORT void Shift(DoubleLinkedList* List) {
    if(List->head->next->next == NULL) {
        List->head->next = NULL;
        List->tail->prev = NULL;
        free(List);
        return;
    }

    node* temp = List->head->next->next;
    
    free(List->head->next);

    List->head->next = temp;
    temp->prev = List->head;

    return;
}

EXPORT void IndexUnshift(DoubleLinkedList* List, int index, void* data) {
    node* current = List->head;
    int i;

    for(i = 0; i < index; i++) {
        if(current->next == NULL && i < index) {
            return;
        }
        current = current->next;
    }

    node* temp = malloc(sizeof(node));

    temp->data = data;
    temp->next = current->next;
    temp->prev = current;

    current->next->prev = temp;
    current->next = temp;

    return;
}

EXPORT void IndexShift(DoubleLinkedList* List, int index) {
    node* current = List->head->next;
    int i; 
    for(i = 0; i < index; i++) {
        if(current->next->next == NULL && i < index) {
            return;
        }
        current = current->next;
    }

    current->prev->next = current->next;
    current->next->prev = current->prev;
    free(current);

    return;
}

EXPORT void Foreach(DoubleLinkedList* List, void(*callback)(node*, int)) {
    node* current = List->head->next;
    int i;
    for(i = 0; current->next != NULL; i++) {
        callback(current, i);
        current = current->next;
    }
}