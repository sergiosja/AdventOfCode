import scala.io.Source
import scala.annotation.tailrec

def main(args: Array[String]): Unit =
    val input = readInput("input.txt")
    val boxes = Map(1->"WMLF", 2->"BZVMF", 3->"HVRSLQ", 4->"FSVQPMTJ", 5->"LSW", 6->"FVPMRJW", 7->"JQCPNRF", 8->"VHPSZWRB", 9->"BMJCGHZW")
    println(topCrates(moveBoxes(input, boxes, true)))
    println(topCrates(moveBoxes(input, boxes, false)))

def readInput(filename: String): List[List[Int]] =
    Source.fromFile(filename).getLines.map(_.split("move | from | to ").tail.map(_.toInt).toList).toList

def moveBoxes(input: List[List[Int]], xs: Map[Int, String], r: Boolean): Map[Int, String] =
    @tailrec
    def loop(input: List[List[Int]], xs: Map[Int, String]): Map[Int, String] =
        input match
            case Nil => xs
            case cmd :: tail => loop(tail, updateDict(xs, cmd, r))
    loop(input, xs)

def updateDict(xs: Map[Int, String], cmd: List[Int], r: Boolean): Map[Int, String] =
    if r then xs.updated(cmd(2), xs(cmd(2)) ++ xs(cmd(1)).takeRight(cmd(0)).reverse)
                .updated(cmd(1), xs(cmd(1)).dropRight(cmd(0)))
    else xs.updated(cmd(2), xs(cmd(2)) ++ xs(cmd(1)).takeRight(cmd(0)))
           .updated(cmd(1), xs(cmd(1)).dropRight(cmd(0)))

def topCrates(xs: Map[Int, String]): String =
    xs.toSeq.sortBy(_(0)).map(_(1).last).mkString