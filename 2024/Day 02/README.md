# Day 2

~~Day 2 and I'm already defeated~~ We back baby!

## Solution

The sliding window approach works perfectly for the first part: We create a sliding window of pairs, and feed them to our `isSafe` function which determines whether or not the "report" is safe. If it is, we map the list to 1, if not, we map it to 0. We do this for each report, before printing the sum.

For the second part, we create permutations of each list, and feed them to our `isSafe` function one by one. The function returns a list of 0s and 1s, but a list of one or more 1s means we have a tolerable system (thanks [Petter](https://github.com/petternett))! Thus, if any of these permutations are tolerable, we map the report to 1 like before, and if they are all 0, we map the report to 0. In the end, we sum each report like we did in part 1.