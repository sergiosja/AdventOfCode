# Day 7
Todays puzzle was all about maths, and the two numbers you needed were the *median* and *mean* of the crabs' locations. Relatively straight forward, but it's not actually a perfect algorithm for finding the mean. For the example input I used Math.ceil, while for the *actual* input I used Math.floor. There is probably a better way.

## The solution
Very satisfied with today's solutions, higher order functions really do make life easier :slightly_smiling_face:

For part 1, get the sum of abs(location_of_crab - median) for every crab in the list, a quite straight forward and succinct O(n) solution.

For part 2, we discover that jet fuel burns in a different way. Instead of staying constant, it increases linearly! I have changed this one a couple of times, first I had a brute force solution, then I replaced it with the good old n(n+1)/2 formula, before I realised I could take advantage of Kotlin's wonderful range functions. I think the formula is quicker, but I prefer the current solution.
