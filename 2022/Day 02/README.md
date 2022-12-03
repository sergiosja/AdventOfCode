# Day 2

...

## Solution

After messing about with multiple maps, a friend of mine made me aware of the games pattern. Converted a list on the form ["elf's move player's move"] with this

```scala
def scoresToMap(scores: List[String]): Map[String, Int] =
    scores.zipWithIndex.map{ case (a, b) => (a, b + 1) }.toMap
```

Wanted to run fold/reduce/scan on the input list, but the strings got converted to the Matchable data type, so I just made a new function doing exactly what I wanted fold/reduce/scan to do

```scala
def play(input: List[String], scores: Map[String, Int]): Int =
    @tailrec
    def loop(input: List[String], acc: Int): Int =
        input match
            case Nil => acc
            case head :: tail => loop(tail, acc + scores(head))
    loop(input, 0)
```

Finally I could run

```scala
play(input, scoresToMap(List("B X", "C Y", "A Z", "A X", "B Y", "C Z", "C X", "A Y", "B Z")))
```

on part 1, and

```scala
play(input, scoresToMap(List("B X", "C X", "A X", "A Y", "B Y", "C Y", "C Z", "A Z", "B Z")))
```

on part 2 :grin:
