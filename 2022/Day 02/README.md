# Day 2

Quite happy with the final result and that I'm still able to do these in Scala

## The solution

After messing about with multiple maps, a friend of mine made me aware of the game's pattern. Converted a list on the form ["elf's move player's move"] with this

```scala
def scoresToMap(scores: List[String]): Map[String, Int] =
    scores.zipWithIndex.map{ case (a, b) => (a, b + 1) }.toMap
```

Spent ages trying to accumulate a sum with fold, before ultimately writing my own version. After another round of google I found out foldLeft was what I needed!

```scala
def play(input: List[String], strategy: Map[String, Int]): Int =
    input.foldLeft(0)((x, y) => x + strategy(y))
```
