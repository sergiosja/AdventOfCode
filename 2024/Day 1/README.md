# Day 1

At long last 😌

## Solution

After wanting to try F# for the longest time, I've finally downloaded dotnet! The input is split, mapped to integers and unzipped to create a list of two lists like [[a; b; c;]; [x; y; z]].

For part 1, I've sorted the lists, zipped them back together, calculated each tuple's absolute value and summed the list.

For part 2, for each x in the first list I've filtered the second list by x and multiplied x by the length of the resulting list. In the end I've summed these values. In another life I'd cache the result :)