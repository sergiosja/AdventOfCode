# Day 11
Very cool task, but unfortunately my solution couldn't match it. For some reason I was really demotivated after my exams and AOC started feeling like a chore (probably because it was my tool of choice for procrastination during them). Will hopefully finish the calender before AOC 22, hehe

## The solution
The function `rec` revolves around both parts, since part two was so tiny. For part one, simulate the 3 rules from the problem description (with the help of a dirty try-catch shortcut). When we reach 100 steps, store the value in a global variable p1. When every octopus flashes, return an ordered pair of p1 and the current step.