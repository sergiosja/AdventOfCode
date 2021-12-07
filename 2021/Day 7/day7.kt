import java.io.File

fun main() {
    val crabs = readFile("input.txt")

    // Part 1
    val m = crabs[crabs.size/2]
    println(crabs.map{ Math.abs(it - m) }.sum())

    // Part 2
    val mv = Math.floor((crabs.sum()/crabs.size).toDouble())
    var mc = 0
    for (i in 0..crabs.size-1) {
        var c = 0
        var ec = 0
        while (crabs[i] < mv) {
            crabs[i]++
            ec++
            c += ec
        }
        while (crabs[i] > mv) {
            crabs[i]--
            ec++
            c += ec
        }
        mc += c
    }
    println(mc)
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