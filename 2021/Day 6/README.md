# Day 6
*Finally* no more matrixes, at least for the time being. Todays puzzle was fun, and could probably be solved in multiple ways. The naive approach is to actually simulate the lanternfish reproduction, but this would take ages for part 2, so I attempted a little dynamic programming (if you can call it that) :smiley:

## The solution
Both parts are based on the main algorithm. Since we know that the cycle consists of max 8+1 days, we can map the number of fishes to its respective index. It's similarly to just simulating, but instead of going through a huge array, we simply move values from index i to i-1. We save i<sub>0</sub> and add it to i<sub>6</sub> and i<sub>8</sub>. Time complexity will be O(d), with d being days.
