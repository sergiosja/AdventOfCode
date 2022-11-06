import scala.io.Source

def main(args: Array[String]): Unit =
    val input = readInput("input.txt")
    println(visitHouses(input, Set((0, 0)), 0, 0).size)

    val (a, b) = interleave(input)
    val as = visitHouses(a, Set((0, 0)), 0, 0)
    val bs = visitHouses(b, Set((0, 0)), 0, 0)
    println((as ++ bs).size)

def readInput(filename: String): String =
    Source.fromFile(filename).getLines.next

def visitHouses(dir: String, houses: Set[(Int, Int)], x: Int, y: Int): Set[(Int, Int)] =
    dir.head match
        case ' ' => houses
        case '<' => visitHouses(dir.tail, houses + ((x-1, y)), x-1, y)
        case '>' => visitHouses(dir.tail, houses + ((x+1, y)), x+1, y)
        case '^' => visitHouses(dir.tail, houses + ((x, y+1)), x, y+1)
        case 'v' => visitHouses(dir.tail, houses + ((x, y-1)), x, y-1)

def interleave(dirs: String): (String, String) =
    @annotation.tailrec
    def loop(dirs: String, xs: String, ys: String): (String, String) =
        if dirs.head == ' ' then (xs + ' ', ys + ' ')
        else dirs.tail.length % 2 match
            case 0 => loop(dirs.tail, xs + dirs.head, ys)
            case _ => loop(dirs.tail, xs, ys + dirs.head)
    loop(dirs, "", "")
