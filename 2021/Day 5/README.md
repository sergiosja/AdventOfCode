# Day 5
Another matrix problem! Just like yesterday I took (presumably) the most brute-force approach. There are dozens of smarter, quicker and more readable ways of solving this one, but with more exams coming up shortly I decided to be quick and dirty.

## The solution
I built an n x n matrix, with n being the biggest number from the input file. Each tile is a 0. After that I simply added 1 to the appropriate tiles

For part 1 we only cared about the horizontal and vertical lines, so I simply updated the appropriate indexes. Time complexity should be O(n), since we in worst case only will go all the way up/down or front/back.

Part 2 was worse (as it tends to be), since we now also had to take diagonals into consideration. We have two types, the ones where both the x and y are increased (2,0 -> 6,4), and the ones where they intersect (8,0 -> 0,8). This means we have to maniuplate both x and y simultaneously, but when following the recipe it didn't cause me too much trouble. The time complexity should be the same, even though n has been slightly prolonged :slightly_smiling_face: