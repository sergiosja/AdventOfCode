import java.io.BufferedReader
import java.io.File

fun main() {
    val fish = LongArray(9)
    for (i in readFile("input.txt"))
        fish[i]++

    // Part 1
    println(lanternfish(fish.copyOf(), 79))

    // Part 2
    println(lanternfish(fish.copyOf(), 255))
}

fun lanternfish(fish: LongArray, n: Int): Long {
    for (i in 0..n) {
        val spec = fish[0]
        for (j in 1..8)
            fish[j-1] = fish[j]
        fish[6] += spec
        fish[8] = spec
    }
    return fish.sum()
}

// Helper function for reading from file
fun readFile(fileName: String): MutableList<Int>
    = File(fileName)
        .bufferedReader()
        .use { it
        .readText()
        .split(",")
        .map(String::toInt)
        .toMutableList() }