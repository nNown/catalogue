#include "DoubleLinkedList.h"

void test3(node*, int);

int main() {
    // List working in O(n*n) 

    DoubleLinkedList* test = CreateDoubleLinkedList();
    Push(test, 10);
    Push(test, 20);
    Push(test, 30);
    Push(test, 40);
    Push(test, 50);
    Push(test, 60);
    Pop(test);
    IndexUnshift(test, 0, 1);
    IndexUnshift(test, 2, 1);
    IndexUnshift(test, 4, 1);
    Unshift(test, 1);
    Shift(test);
    DoubleLinkedList* test2 = Slice(test, 3);

    IndexShift(test, 0);

    PrintList(test);
    printf("\n");
    PrintList(test2);
    printf("\n\n");
    PrintInReverseOrder(test);
    printf("\n");
    PrintInReverseOrder(test2);
    printf("\n\n");
    Foreach(test, test3);
    PrintList(test);

    return 0;
}

void test3(node* el, int index) {
    el->value += 100;
}