import scala.io.Source

def main(args: Array[String]): Unit =
    val input = readInput("input.txt")
    println(helpElves(input, 0, 2))
    println(helpElves(input, 0, 3))

def readInput(filename: String): List[String] =
    (for (line <- Source.fromFile(filename).getLines) yield line).toList

def helpElves(nums: List[String], fabric: Int, slack: Int): Int =
    nums match
        case Nil => fabric
        case head::tail =>
            val q = head.split("x").map(_.toInt).toList
            val part = if slack == 2 then surface(decompose(q)) else volume(smallest(q))
            helpElves(tail, fabric + extra(q, slack) + part, slack)

def extra(xs: List[Int], n: Int): Int =
    xs.sorted.take(n).product

// Part 1
def decompose(xs: List[Int]): (Int, Int, Int) =
    (xs.head, xs.tail.head, xs.tail.tail.head)

def surface(v: (Int, Int, Int)): Int =
    2 * v(0) * v(1) + 2 * v(1) * v(2) +  2 * v(2) * v(0)

// Part 2
def smallest(xs: List[Int]): List[Int] =
    xs.sorted.take(2)

def volume(xs: List[Int]): Int =
    2*xs.head + 2*xs.tail.head
