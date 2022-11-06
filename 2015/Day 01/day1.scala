import scala.io.Source

def main(args: Array[String]): Unit =
    val input = readInput("input.txt")
    println(findFloor(s"${input} ", 0))
    println(enterBasement(s"${input} ", 0, 0))

def readInput(filename: String): String =
    Source.fromFile(filename).getLines.next

def findFloor(dir: String, floor: Int): Int =
    dir.head match
        case ' ' => floor
        case '(' => findFloor(dir.tail, floor+1)
        case ')' => findFloor(dir.tail, floor-1)

def enterBasement(dir: String, count: Int, pos: Int): Int =
    if count < 0 then pos
    else dir.head match
        case '(' => enterBasement(dir.tail, count+1, pos+1)
        case ')' => enterBasement(dir.tail, count-1, pos+1)
