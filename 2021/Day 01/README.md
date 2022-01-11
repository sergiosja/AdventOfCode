# Day 1

AOC is finally here! I also had my functional programming exam today, so I have dedicated todays puzzle to R5RS Scheme. Nothing fancy, but I like it a lot.

## The solution
For part one, recursively add 1 to the total output for every cadr that is greater than car. Time and space complexity are both O(n), since the procedure gives rise to a recursive process as well.

For part two, I created a helper procedure that returns a new list containing the new values from the sliding windows, before applying the procedure from part one on it. Since O(2n) is still O(n), we have maintained linear time complexity :smile:
