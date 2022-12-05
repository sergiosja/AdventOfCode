# Day 4

Huge exam tomorrow so thankfully today's puzzle didn't require 100% of the brain

## Solution

Tried some fancy range stuff first but landed on what is probably the most brute way of doing it: if you can fit section one into section two or the other way around, we have a full overlap! Filtered the list by the mentioned requirement and retrieved the final size

```scala
def sift(xs: Array[Int]): Boolean =
    xs(0) <= xs(2) && xs(1) >= xs(3) || xs(1) <= xs(3) && xs(0) >= xs(2)

def fullOverlap(xs: List[Array[Int]]): Int =
    xs.filter(x => sift(x)).size
```

Yet again part 2 was less hassle, now we just need to see if the biggest value of the set with the smallest values is larger than the smallest value of the set with the largest values

```scala
def overlap(xs: List[Array[Int]]): Int =
    xs.filter(x => (x(0) max x(2)) <= (x(1) min x(3))).size
```
