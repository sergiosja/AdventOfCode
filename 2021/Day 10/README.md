# Day 9
I'm done with my final exam, and can finally allocate time to the more important things in life, like AOC :wink:

This problem reminds me a lot of the [Delimiter soup](https://open.kattis.com/problems/delimitersoup) problem on Kattis, and can well enough be solved with the same technique!

Also, I will most likely do the rest of AOC in Kotlin, to prepare for a TA job next semester.

# The solution
For part 1, create a hashmap over every bracket and a map over each bracket's value. Then append opening brackets to a stack, and if the current closing bracket matches the last opening bracket on the stack, simply pop from the stack. If not, add that bracket's value to a total sum, and the whole line to another list "tbr". Time complexity is O(n) as we're going through every bracket of the input file, but we never finish the corrupted lines!

For part 2 we follow the same train of thought, but we ignore the chuncks we added to tbr. When we get to the end of the chunk, we add our syntax error score to a list of sums and return the middle one.