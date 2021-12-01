# Day 5

Did day 5 in Python because I'm lazy. Don't get me wrong, I'm very fond of Python, but it almost feels like a cheat code when you could theoretically solve them in, say, [ArnoldC](https://esolangs.org/wiki/ArnoldC) or [Malbolge](https://esolangs.org/wiki/Malbolge). Nevertheless I got the stars I needed :smile:

## The solution
The input description smelles like roses and binary search. Simple binary search on the plane aisle and seat. before printing the max.

Part 1 is O(n log n), because you have to binary search through all the boarding passes.

Part 2 is O(n), we just iterate from min to max and break when we find the missing number.