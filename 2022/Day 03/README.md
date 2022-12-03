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

Finding the sum was then trivial

```scala
input.foldLeft(0)((x, y) => x + setPri(findItem(part(y))))
```

To my surprise part 2 was less hassle than part 1, much thanks to Scala's grouping function. Now I just needed to find the badges

```scala
def findBadge(l: List[String]): Int =
    (l(0) intersect l(1) intersect l(2)).head
```

and fold

```scala
input.grouped(3).foldLeft(0)((x, y) => x + setPri(findBadge(y)))
```
