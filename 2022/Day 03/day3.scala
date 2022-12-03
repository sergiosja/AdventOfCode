import scala.io.Source

def main(args: Array[String]): Unit =
    val input = readInput("input.txt")
    println(input.map(x => setPri(findItem(part(x)))).sum)
    println(input.grouped(3).map(x => setPri(findBadge(x))).sum)

def readInput(filename: String): List[String] =
    Source.fromFile(filename).getLines.toList

def part(s: String): (String, String) =
    s.splitAt(s.length/2)

def findItem(xs: (String, String)): Int =
    (xs(0) intersect xs(1)).head

def findBadge(xs: List[String]): Int =
    (xs(0) intersect xs(1) intersect xs(2)).head

def setPri(x: Int): Int =
    if x >= 97 then x-96 else x-38
