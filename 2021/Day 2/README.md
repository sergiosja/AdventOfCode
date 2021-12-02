# Day 2

Very straight-forward puzzle today, didn't really know how to make it fancy (not that I tried very hard either). Both parts build on the main algorithm, which simply goes through the input tuples and does some form for arithmetic.

## The solution
For part one, simply increase `depth` when we go down and decrease when we go up, and increase `pos` when we go forward. In the end, print the product of our depth and position. O(n) time complexity since we need every line of input.

For part two, another variable `aim` is introduced. Luckily it doesn't cause any hassle, and we simply increase it by `depth` x `dist` every time we go forward. In the end, print the product of our aim and position. Linear time again, for the same reason as stated above.