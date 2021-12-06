# Day 1
Ran out of ways to procrastinate so did the first every AOC puzzle! Decided to go for Scheme cause part 1 was *screaming* our for higher order functions :slightly_smiling_face: Struggled to parse the input to a list, since Scheme are so strict on parenthesees. Made a quick and dirty Python script to do that job for me.

## The solution
For part 1, just collect all the opening parenthesees and closing parenthesees into seperate lists and print the difference of their sizes. Practically a one-liner. Time complexity will be O(2n) = O(n), since we have to go through the entire input list twice.

For part 2 I wrote a procedure that gives rise to an iterative process, and therefore managed to solve it in *actual* O(n). Go through the list char for char and update the values 'up' and 'down'. When down surpasses up, their sum is printed.