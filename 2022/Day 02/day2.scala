import scala.io.Source
import scala.annotation.tailrec

def main(args: Array[String]): Unit =
    val input = readInput("input.txt")
    println(play(input, scoresToMap(List("B X", "C Y", "A Z", "A X", "B Y", "C Z", "C X", "A Y", "B Z"))))
    println(play(input, scoresToMap(List("B X", "C X", "A X", "A Y", "B Y", "C Y", "C Z", "A Z", "B Z"))))


def readInput(filename: String): List[String] =
    Source.fromFile(filename).getLines.toList


def scoresToMap(scores: List[String]): Map[String, Int] =
    scores.zipWithIndex.map{ case (a, b) => (a, b + 1) }.toMap


def play(input: List[String], scores: Map[String, Int]): Int =
    @tailrec
    def loop(input: List[String], acc: Int): Int =
        input match
            case Nil => acc
            case head :: tail => loop(tail, acc + scores(head))
    loop(input, 0)
