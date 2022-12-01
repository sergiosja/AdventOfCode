import scala.io.Source
import scala.annotation.tailrec

def main(args: Array[String]): Unit = 
    val input = readInput("input.txt")
    println(groupElfCalories(input).map(_.sum).max)
    println(groupElfCalories(input).map(_.sum).sortBy(-_).take(3).sum)

def readInput(filename: String): List[String] =
    Source.fromFile(filename).getLines.toList

def groupElfCalories(input: List[String]): List[List[Int]] =
    @tailrec
    def loop(input: List[String], tmp: List[Int], acc: List[List[Int]]): List[List[Int]] =
        input match
            case Nil => acc
            case head :: tail =>
                head match
                    case "" => loop(input.tail, List[Int](), tmp::acc)
                    case a => loop(input.tail, a.toInt::tmp, acc)
    loop(input, List[Int](), List[List[Int]]())
