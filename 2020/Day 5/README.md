# Day 5

Did day 5 in Python because I'm lazy. Don't get me wrong, I'm very fond of Python, but it almost feels like a cheat code when you could theoretically solve them in, say, [ArnoldC](https://esolangs.org/wiki/ArnoldC) or [Malbolge](https://esolangs.org/wiki/Malbolge) instead. Nevertheless I got the stars I needed :smile:

## The solution
The input description smells like roses and binary search. Simple binary search on the plane aisle and seat.

Part 1 is O(n). Even though binary search is O(log n), we have to look through the entire set of boarding passes to find the max. Could probably be optimised by simply passing the current max as an argument with each search, and updating if the new number exceeds it (Comparing and assignment are both primitive operations, so part 1 would be improved to O(log n)).

Part 2 is O(n), since we already have the boarding passes in a set, we can put all the numbers in the range from smallest to largest in a new set, and return the difference. The last part is O(1), but since we have to fill up the array first, we end up with linear time complexity.
