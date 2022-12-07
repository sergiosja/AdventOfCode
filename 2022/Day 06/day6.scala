import scala.io.Source
import scala.annotation.tailrec

def main(args: Array[String]): Unit =
    val input = readInput("input.txt")
    println(findMarker(input, 4))
    println(findMarker(input, 14))

def readInput(filename: String): String =
    Source.fromFile(filename).getLines.next

def findMarker(msg: String, n: Int): Int =
    msg.sliding(n, 1).indexWhere(x => x == x.distinct) + n
