# Day 5

Not very proud of this one. Cheated on the input, could probably have read the first part to a matrix and transposed it etc. but ended up hardcoding the crates into a Map instead.

## Solution

Put the crates into a map before reading the instruction part of the input

```scala
val boxes = Map(1->"WMLF", 2->"BZVMF", 3->"HVRSLQ", 4->"FSVQPMTJ", 5->"LSW", 6->"FVPMRJW", 7->"JQCPNRF", 8->"VHPSZWRB", 9->"BMJCGHZW")
```

Then just loop over the instructions, updating the dict accordingly. The updateDict function is disgusting so won't post it here

```scala
def moveBoxes(input: List[List[Int]], xs: Map[Int, String], r: Boolean): Map[Int, String] =
    @tailrec
    def loop(input: List[List[Int]], xs: Map[Int, String]): Map[Int, String] =
        input match
            case Nil => xs
            case cmd :: tail => loop(tail, updateDict(xs, cmd, r))
    loop(input, xs)
```

To find the top crate I sort the map, take the last char from each stack and return the final string

```scala
def topCrates(xs: Map[Int, String]): String =
    xs.toSeq.sortBy(_(0)).map(_(1).last).mkString
```
