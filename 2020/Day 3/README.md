# Day 3

Coding wise, not the most challenging puzzle I have solved. Still I was stuck for a whole day, felt like I had tried everything, before I *actually* read the problem description. The pattern will repeat itself! I knew it was too good to be true. Funny enough it made my code simpler, as I could safely discard the try-catch I was using :grin:

Didn't see any reason to ditch Kotlin yet, so stuck with it for these straight-forward solutions. The code is again not very pretty, but I still cannot see too many flaws either.

## The solution
For part 1, go through the list diagnally by increasing the position by 3 and mod the length of the area. If the current char in the list is a '#', increase the counter. Simple, O(n)

For part 2, do the exact same thing, but check all the routes by putting their increase-by-amount in a list, as well as their values. When done, use reduce to multiply them together. *Techincally* O(n\*j)
