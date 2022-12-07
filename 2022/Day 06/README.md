# Day 6

Today was fun cause I got to use Scala's sliding window function!

## Solution

Surprisingly straight-forward puzzle today, and perhaps my shortest solution thus far. To find each marker I just run this one with n=4 for part one and n=14 for part two

```scala
def findMarker(msg: String, n: Int): Int =
    msg.sliding(n, 1).indexWhere(x => x == x.distinct) + n
```
