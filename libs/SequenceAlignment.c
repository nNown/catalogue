#include "SequenceAlignment.h"

int** createSequenceGrid(char* mainSequence, char* comparedSequence) {
    int mainSequenceLength = strlen(mainSequence) + 1;
    int comparedSequenceLength = strlen(comparedSequence) + 1;
    int max = mainSequenceLength > comparedSequenceLength ? mainSequenceLength : comparedSequenceLength;
    int min = mainSequenceLength < comparedSequenceLength ? mainSequenceLength : comparedSequenceLength;

    int** grid = malloc(min * sizeof(int*));
    if(grid == NULL) {
        fprintf(stderr, "Out of memory\n");
        return NULL;
    }

    int i, j;
    for(i = 0; i < min; i++) {
        grid[i] = malloc(max * sizeof(int));

        if(grid[i] == NULL) {
            fprintf(stderr, "Out of memory\n");
            return NULL;
        }
    }
    
    return initializeGrid(grid, max, min, mainSequence, comparedSequence);
}

int** initializeGrid(int** grid, int cols, int rows, char* horizontalSequnce, char* verticalSequence) {
    grid[0][0] = 0;
    
    int i, j;

    for(i = 1; i < rows; i++) {
        grid[i][0] = grid[i - 1][0] - 1;
    }

    for(i = 1; i < cols; i++) {
        grid[0][i] = grid[0][i - 1] - 1;
    }

    for(i = 0; i < rows; i++) {
        for(j = 0; j < cols; j++) {
            if(i != 0 && j != 0) {
                grid[i][j] = calculateCell(grid, i, j, horizontalSequnce[j - 1], verticalSequence[i - 1]);
            }
            printf("%d ", grid[i][j]);
        }
        printf("\n");
    }

    return grid;
}

int calculateCell(int** grid, int row, int col, char mainChar, char comparedChar) {
    int max = -1;

    printf("%c %c\n", mainChar, comparedChar);

    return max;
}