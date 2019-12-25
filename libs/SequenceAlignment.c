#include "SequenceAlignment.h"

EXPORT char* alignSequences(char* mainSequence, char* comparedSequence) {
    int mainSequenceLength = strlen(mainSequence) + 1;
    int comparedSequenceLength = strlen(comparedSequence) + 1;

    int** grid = malloc(comparedSequenceLength * sizeof(int*));
    if(grid == NULL) {
        fprintf(stderr, "Out of memory\n");
        return NULL;
    }

    int i, j;
    for(i = 0; i < comparedSequenceLength; i++) {
        grid[i] = malloc(mainSequenceLength * sizeof(int));

        if(grid[i] == NULL) {
            fprintf(stderr, "Out of memory\n");
            return NULL;
        }
    }
    
    return initializeGrid(grid, mainSequenceLength, comparedSequenceLength, mainSequence, comparedSequence);
}

char* initializeGrid(int** grid, int cols, int rows, char* horizontalSequnce, char* verticalSequence) {
    grid[0][0] = 0;
    
    int i, j;

    for(i = 1; i < rows; i++) {
        grid[i][0] = grid[i - 1][0] - 1;
    }

    for(i = 1; i < cols; i++) {
        grid[0][i] = grid[0][i - 1] - 1;
    }

    for(i = 1; i < rows; i++) {
        for(j = 1; j < cols; j++) {
            grid[i][j] = calculateCell(grid, i, j, horizontalSequnce[j - 1], verticalSequence[i - 1]);
        }
    }

    return traceBackSequence(grid, cols, rows, horizontalSequnce, verticalSequence);
}

int calculateCell(int** grid, int row, int col, char mainChar, char comparedChar) {
    int max = -1;
    int verticalResult = grid[row - 1][col];
    int horizontalResult = grid[row][col - 1];
    int diagonalResult = grid[row - 1][col - 1];

    if(mainChar != comparedChar) {
        verticalResult--;
        horizontalResult--;
        diagonalResult--;
    } else if(mainChar == comparedChar) {
        verticalResult++;
        horizontalResult++;
        diagonalResult++;
    }

    if(verticalResult > horizontalResult) {
        max = verticalResult;
    } else {
        max = horizontalResult;
    }

    if(max < diagonalResult) {
        max = diagonalResult;
    }

    return max;
}

char* traceBackSequence(int** grid, int cols, int rows, char* horizontalSequnce, char* verticalSequence) {
    int i, j, verticalResult, horizontalResult, diagonalResult, currentPosition;
    int maxLength = cols > rows ? cols - 1 : rows - 1;
    char* alignedSequence = malloc(maxLength * sizeof(char));
    alignedSequence[maxLength--] = '\0';

    i = rows - 1;
    j = cols - 1;

    while(i >= 0 && j >= 0) {
        if(i != 0) verticalResult = grid[i - 1][j];
        else verticalResult = -verticalResult - horizontalResult - diagonalResult - 10; 
        if(j != 0) horizontalResult = grid[i][j - 1];
        else horizontalResult = -horizontalResult - verticalResult - diagonalResult - 10;
        if (i != 0 && j != 0 ) diagonalResult = grid[i - 1][j - 1];
        else diagonalResult = -diagonalResult - verticalResult - horizontalResult - 10;
        currentPosition = grid[i][j];

        if(diagonalResult >= verticalResult && diagonalResult >= horizontalResult) {
            alignedSequence[maxLength] = verticalSequence[i - 1];
            i--;
            j--; 
        } else if(verticalResult >= diagonalResult && verticalResult >= horizontalResult) {
            alignedSequence[maxLength] = '-';
            i--;
        } else if(horizontalResult >= diagonalResult && horizontalResult >= verticalResult) {
            alignedSequence[maxLength] = '-';
            j--; 
        }
        maxLength--;
    }

    return alignedSequence;
}
