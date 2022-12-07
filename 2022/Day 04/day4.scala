import scala.io.Source

def main(args: Array[String]): Unit =
    val input = readInput("input.txt")
    println(fullOverlap(input))
    println(overlap(input))

def readInput(filename: String): List[Array[Int]] =
    Source.fromFile(filename).getLines.map(_.split("[,-]")).map(_.map(_.toInt)).toList

def sift(xs: Array[Int]): Boolean =
    xs(0) <= xs(2) && xs(1) >= xs(3) || xs(1) <= xs(3) && xs(0) >= xs(2)

def fullOverlap(xs: List[Array[Int]]): Int =
    xs.filter(sift).size

def overlap(xs: List[Array[Int]]): Int =
    xs.filter(x => (x(0) max x(2)) <= (x(1) min x(3))).size
