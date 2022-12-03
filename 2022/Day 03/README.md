# Day 3

## Solution

Created some helper functions for parting the strings, finding the common item and setting priority

```scala
def part(s: String): (String, String) =
    s.splitAt(s.length/2)

def findItem(xs: (String, String)): Int =
    (xs(0) intersect xs(1)).head

def setPri(x: Int): Int =
    if x >= 97 then x-96 else x-38
```

To find the sum I then mapped each string to their common item's priority, and retrieved their sum

```scala
input
  .map(x => setPri(findItem(part(x))))
  .sum
```

To my surprise part 2 was less hassle than part 1, much thanks to Scala's grouping function. Now I just needed to find the badges

```scala
def findBadge(xs: List[String]): Int =
    (xs(0) intersect xs(1) intersect xs(2)).head
```

and repeat

```scala
input
  .grouped(3)
  .map(x => setPri(findBadge(x)))
  .sum
```
