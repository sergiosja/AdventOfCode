# Day 1

As of right now, I lack 2 things:
1. Knowledge of reading from files in Prolog
2. Time to figure it out

I created a tiny Python script to assist me in turning the strings into facts. What I wanted was one file with facts only, and one file with the solutions. Instead I put everything in the same file. May God have mercy on me.

## The actual solution
There are multiple ways of solving this one, the naive double for-loop O(n^2), the clever set/hashmap O(n) etc. When I first saw this one I had just learned the basics of Prolog, and I immediately thought to myself, "why don't I just let SWI deal with it?" So that is exactly what I did.

You wouldn't see the difference between my solution for Part 1 and Part 2 in the dark, and that is what I love about Prolog :grin: