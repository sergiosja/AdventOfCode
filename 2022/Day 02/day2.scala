import scala.io.Source
import scala.annotation.tailrec

def main(args: Array[String]): Unit =
    val input = readInput("input.txt")
    val strategy = scoresToMap(List("B X", "C Y", "A Z", "A X", "B Y", "C Z", "C X", "A Y", "B Z"))
    val realStrategy = scoresToMap(List("B X", "C X", "A X", "A Y", "B Y", "C Y", "C Z", "A Z", "B Z"))

    println(play(input, strategy))
    println(play(input, realStrategy))

def readInput(filename: String): List[String] =
    Source.fromFile(filename).getLines.toList

def scoresToMap(scores: List[String]): Map[String, Int] =
    scores.zipWithIndex.map{ case (a, b) => (a, b + 1) }.toMap

def play(input: List[String], strategy: Map[String, Int]): Int =
    input.foldLeft(0)((x, y) => x + strategy(y))