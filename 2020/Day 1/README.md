# Day 1

As of right now, I lack 2 things:
1. Knowledge of reading from files in Prolog
2. Time to figure it out

I created a tiny Python script to assist me in turning the strings into facts. I created a seperate `input.pl` file, where each instance in input.txt is a fact instead of a string (e.g. 2010 -> aoc(2010)).

## The actual solution
There are multiple ways of solving this one, the naive double for-loop O(n^2), the clever set/hashmap O(n) etc. When I first saw this one I had just learned the basics of Prolog, and I immediately thought to myself, "why don't I just let SWI deal with it?" So that is exactly what I did.

You wouldn't see the difference between my solution for Part 1 and Part 2 in the dark, and that is what I like about Prolog :grin: