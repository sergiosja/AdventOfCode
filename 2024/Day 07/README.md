# Day 7

Brute force lifestyle. I'm not in a hurry!

## Solution

The input is parsed into a tuple `(target, [n1, .. n`<sub>`n`</sub>`])`. Then I just tried every possible combination of `*` and `+`, returning true if we hit the jackpot, and false as soon as we go too big (or if we stop short).

For part 2 I just added `(int64 (string acc + string x))` to the recursive call :-)