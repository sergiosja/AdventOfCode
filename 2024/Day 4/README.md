# Day 4

Matrixes are back!

## Solution

For part 1, go over each char, and if we hit an `X`, we start searching in each possible direction. We bring a list of the remaining characters, and when visited, we skip them from the list. If we end up with an empty list, we know we've found the word! In the end we sum each index (one index can lead to multiple instances of `XMAS`) and then we have our answer.

For part 2 we do almost the same, but instead we look for `A`s. If we encounter one, we simply check if we can form an X of `MAS`', we map that index to a `1`, or else a `0`. Like previously, the sum of each index is our final answer!