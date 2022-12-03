import scala.io.Source

def main(args: Array[String]): Unit =
    val input = readInput("input.txt")
    println(input.foldLeft(0)((x, y) => x + setPri(findItem(part(y)))))
    println(input.grouped(3).foldLeft(0)((x, y) => x + setPri(findBadge(y))))

def readInput(filename: String): List[String] =
    Source.fromFile(filename).getLines.toList

def part(s: String): (String, String) =
    s.splitAt(s.length/2)

def findItem(xs: (String, String)): Int =
    (xs(0) intersect xs(1)).head

def findBadge(l: List[String]): Int =
    (l(0) intersect l(1) intersect l(2)).head

def setPri(x: Int): Int =
    if x >= 97 then x-96 else x-38
