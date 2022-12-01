# Day 1

It's finally here!

## Solution

Straight forward puzzle, but struggled to find a oneliner to parse the input. Eventually ate the humble pie and made a function to "put" each elf's calories into separate lists. After that it was relatively simple

For part 1, get the sum of each elf's calories and retrieve the largest amount

```scala
groupElfCalories(input).map(_.sum).max
```

For part 2, get the sum of each elf's calories, sort by desc, and retrieve the sum of the top three

```scala
groupElfCalories(input).map(_.sum).sortBy(-_).take(3).sum
```
