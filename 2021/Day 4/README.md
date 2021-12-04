# Day 4
Todays puzzle reminds me a lot of an oblig I did this semester, where I had to solve an 8-puzzle with the A* algorithm. I used OO to facilitate working on the board, and I figured I would do the same here. Slightly unhappy with the inconsistency between higher order functions and list comprehension, but other than that, I'm at ease with the overall solution :slightly_smiling_face:

## The solution
Each board is really just an array of strings, and revolves around the checkWinner-function, which checks whether an entire row or column has been marked. For every number in the bingo-list, we mark every board that contains the current number, by replacing it with an 'M'.

For part 1, we print the product of the *first* winner's unmarked tiles and the current number. I assume the time complexity must be O(n * b), since we scan every board for each bingo-number.

For part 2, we print the product of the *last* winner's unmarked tiles and the current number. The time complexity will be the same, but this is the actual worst case scenario!
