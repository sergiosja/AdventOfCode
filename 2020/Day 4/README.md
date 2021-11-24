# Day 4

Two days in a row with Kotlin, and though I love Kotlin, I wanted to switch it up. Since I never use Java anymore, why not opt for Java ;)

One thing I love about [Kattis](open.kattis.com) is that problems are introduced with (oftentimes) interesting descriptions, and so far I am loving AOC for the very same reason! Who doesn't fancy a bit of passport fraud every now and then?

## The solution
For part one, go through the input and add the keys to a HashSet. If you hit a line break, check if the set contains all necessary fields. If they do, increase the `valid` by 1. Reset the HashSet. I think this qualifies for O(n * k), with n being total lines, and k being key-value pairs per line.

For part two, I wrote the worst code I ever have, so many nested for-loops. I basically hard-coded the whole problem. The worst part? When I ran the code, I got the wrong answer.

Therefore I have decided to learn as little regEx as possible, go back and solve both with regEx.

Change in plans! Apparently Perl is an excellent choice for this sort of task, because regEx is literally built into the language. Therefore, I have decided I will solve this task in Perl. First, I must learn Perl.