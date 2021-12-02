import java.io.File

fun main() {
    var depth = 0
    var pos = 0
    var aim = 0

    for (dir in readFile("input.txt")) {
        if (dir.first == "down") {
            depth += dir.second
        }

        if (dir.first == "up") {
            depth -= dir.second
        }

        if (dir.first == "forward") {
            pos += dir.second
            aim += depth * dir.second
        }
    }

    // Part 1
    println(pos * depth)

    // Part 2
    println(pos * aim)
}


fun readFile(fileName: String): MutableList<Pair<String, Int>> {
    val tmp = mutableListOf<Pair<String, Int>>()
    File(fileName).forEachLine { val (a, b) = it.split(" "); tmp.add(Pair(a, b.toInt())) }
    return tmp
}