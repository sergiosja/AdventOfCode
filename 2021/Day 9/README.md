# Day 9
Aaand we're back to matrixes. The first thing that came to my mind was recursively checking for smaller neighbours, but here you would naturally end up with duplicates. The second thing that came to my mind was to check if the *current* int was smaller than all its neighbours. I got tired of all the out-of-bounds checking and decided to go for try-catches to get my stars, but I was so amused by the final solution that I decided to keep it :smiley:

# The solution
For part one, every int has a counter, and if the int is smaller than a neighbour, the counter is increased by 1. The counter is also increased if it doesn't have a neighbour (applies to the top, leftmost, bottom and rightmost ints). O(n)

Have not attempted part two yet.