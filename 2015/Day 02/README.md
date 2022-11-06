# Day 2

Been learning Scala for a couple of days through [this gem of a book](https://www.manning.com/books/functional-programming-in-scala) and figured I might as well attepmt some puzzles simultaneously. As Kattis don't allow Scala (yet) I figured AOC would be my best bet. Might as well get some practice before AOC22 kicks off :smiley:

# The solution

I don't know enough Scala (neither am I particularly comfortable with fold/reduce and that magic) to solve this in a one-liner, but I'm looking at the bright side: The more Scala I'm writing the better, really.

For part one, I calculated the surface of the presents with

```scala
def surface(v: (Int, Int, Int)): Int =
    2 * v(0) * v(1) + 2 * v(1) * v(2) +  2 * v(2) * v(0)
```

and the extra paper with

```scala
def extra(xs: List[Int], n: Int): Int =
    xs.sorted.take(n).product
```

Part two turned out similar enough to part one, so I made this function which does the hard work

```scala
def helpElves(nums: List[String], fabric: Int, slack: Int): Int =
    nums match
        case Nil => fabric
        case head::tail =>
            val q = head.split("x").map(_.toInt).toList
            val part = if slack == 2 then surface(decompose(q)) else volume(smallest(q))
            helpElves(tail, fabric + extra(q, slack) + part, slack)
```

If the list is empty, we return our accumulated value. Else, we split the string, convert the strings to ints, and either get the surface or the volume from the ints, depending on which part we're doing. Nothing fancy, but it gets the job done!

To calculate the volume for part two I did this

```scala
def volume(xs: List[Int]): Int =
    2*xs.head + 2*xs.tail.head
```

The problem description was very straight forward and I followed it quite strictly to be honest.
