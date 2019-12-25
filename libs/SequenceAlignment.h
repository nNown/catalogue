#ifndef SEQUENCE_ALIGNMENT_H
#define SEQUENCE_ALIGNMENT_H

    #ifdef SEQUENCE_ALIGNMENT_H
    #define EXPORT __declspec(dllexport)
    #else
    #define EXPORT __declspec(dllimport)
    #endif

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

EXPORT char* alignSequences(char*, char*);
char* initializeGrid(int**, int, int, char*, char*);
int calculateCell(int**, int, int, char, char);
char* traceBackSequence(int**, int, int, char*, char*);

#endif // SEQUENCE_ALIGNMENT_H