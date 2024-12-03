# Day 3

Thankfully the regex task came early this year 😌

## Solution

For part 1, we match the entire input by the pattern specified by the shopkeeper. Then we extract the integer pairs, multiply them, and sum the products to give us our answer.

For part 2, we split on `do()` and `don't()`, and now only match the instructions followed by a `do()` (and the one we start out with). Then we follow the same approach as we did for part 1, and voilà :)