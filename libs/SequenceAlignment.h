#ifndef SEQUENCE_ALIGNMENT_H
#define SEQUENCE_ALIGNMENT_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int** createSequenceGrid(char*, char*);
int** initializeGrid(int**, int, int, char*, char*);
int calculateCell(int**, int, int, char, char);

#endif // SEQUENCE_ALIGNMENT_H