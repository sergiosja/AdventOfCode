# Day 3

Fun task, not particularly satisfied with my solution, many DRY violations that could probably be easily avoided. At least I haven't declared any variables outside of my main function yet!

## Solution

From my experience, most problems containing duplication detection scream out for sets. Here, I stored coordinates as (Int, Int) in sets, and got what I wanted

The central algorithm is

```scala
def visitHouses(dir: String, houses: Set[(Int, Int)], x: Int, y: Int): Set[(Int, Int)] =
    dir.head match
        case ' ' => houses
        case '<' => visitHouses(dir.tail, houses + ((x-1, y)), x-1, y)
        case '>' => visitHouses(dir.tail, houses + ((x+1, y)), x+1, y)
        case '^' => visitHouses(dir.tail, houses + ((x, y+1)), x, y+1)
        case 'v' => visitHouses(dir.tail, houses + ((x, y-1)), x, y-1)
```

Straight forward pattern matching. If we've traversed the string, we return the set of coordinates. If else, we move (by adjusting x or y) and add the coordinates to our set. Part two is similar, but now the string contains commands for Santa _and_ RoboSanta! To get their respective directions I used

```scala
def interleave(dirs: String): (String, String) =
    @annotation.tailrec
    def loop(dirs: String, xs: String, ys: String): (String, String) =
        if dirs.head == ' ' then (xs + ' ', ys + ' ')
        else dirs.tail.length % 2 match
            case 0 => loop(dirs.tail, xs + dirs.head, ys)
            case _ => loop(dirs.tail, xs, ys + dirs.head)
    loop(dirs, "", "")
```

Then I just ran visitHouses on the two resulting directions and took the union of them.
