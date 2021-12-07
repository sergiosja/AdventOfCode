# Day 7
Todays puzzle was a simple if you know basic maths, and the two numbers you needed were the *median* and *mean* of the crabs' locations. Relatively straight forward, but it's not actually a perfect algorithm for finding the mean. For the example input I used Math.ceil, while for the *actual* input I used Math.floor. There is probably a better way.

## The solution
Very satisfied with part 1, used higher order functions to get the answer from a cheeky oneliner in O(n) time.

Part 2 on the other hand, much less satisfied with. Will hopefully go back and fix it up when I learn the magic trick. I used 3(!) counters, a global 'mc', in addition to 'c' and 'ec' which are updated in every iteration. Until a crab's location is equal to the mean, we updace ec by 1 and c by ec. When they match, update mc by c. Do this for every crab and voilà, you have your answer :slightly_smiling_face: