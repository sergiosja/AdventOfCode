# Day 3

I must admit, it's sad to ditch Scheme this early. I am totally inexperienced when it comes to bit manipulation, so I apologise in advance for (what feels like anyway) such a brute-force solution. Perhaps I will go back and try to work some magic later!

## The solution
For part 1, I created an `IntArray` with length of the bits, before adding/subtracting values based on each bit sequence's current digit. Afterwards, if the array index is positive, we add 1 to the gamma bit seq, and 1 if else. Then we simply invert the values for our epsilon bit seq, before returning their decimal product. The solution is `O(n * s)`, with `n` being the amount of bit sequences, and `s` being the length of each bit sequece.

Part 2 is a bit trickier. Our approach is similar, but we instead keep sets of bit sequences where the respective digits are 0 and 1, and eliminate the smallest set after each "round". We are ultimately left with a single value, which is then either our "Oxygen scrubber rating" or "CO2 scrubber rating", and the result is again the decimal product of these. The solution is technically O(n * s) for the same reason as stated above, but it turns out to be more of a `O(n * log n)`, as we seem to eliminate ca. half of the input set in each round!
