# Day 7
Todays puzzle was a simple if you know basic maths, and the two numbers you needed were the *median* and *mean* of the crabs' locations. Relatively straight forward, but it's not actually a perfect algorithm for finding the mean. For the example input I used Math.ceil, while for the *actual* input I used Math.floor. There is probably a better way.

## The solution
Very satisfied with todays solutions, higher order functions really do make life easier :slightly_smiling_face:

For part 1, get the sum of abs(location_of_crab - median) for every crab in the list, a quite straight forward and succinct O(n) solution.

For part 2, we discover that jet fuel burns in a different way. Instead of staying constant, it increases linearly! Therefore we can use the math formula n(n+1)/2, where n is good old abs(loc - mean), to find out exactly how much they spend to get from a to b.