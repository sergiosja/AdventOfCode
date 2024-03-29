import java.io.File

fun main() {
    val crabs = readFile("input.txt")

    // Part 1
    val m = crabs[crabs.size/2]
    println(crabs.map{ Math.abs(it - m) }.sum())

    // Part 2
    val mv = Math.floor((crabs.sum()/crabs.size).toDouble())
    println(crabs.map{ (0..Math.abs(it - mv).toInt()).sum() }.sum())
}


// Helper function for reading from file
fun readFile(fileName: String): MutableList<Int>
    = File(fileName)
        .bufferedReader()
        .use { it
        .readText()
        .split(",")
        .map(String::toInt)
        .sorted()
        .toMutableList() }