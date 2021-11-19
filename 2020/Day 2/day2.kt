import java.io.File

fun main() {
    val passwords = mutableListOf<List<String>>()
    rff("input.txt", passwords)
    part_one(passwords)
    part_two(passwords)
}


fun part_one(passwords: MutableList<List<String>>) {
    var sum = 0
    passwords.forEach { p ->
        if (p[3].filter { it == p[2][0] }.count() in p[0].toInt()..p[1].toInt()) sum++
    }.also{ println(sum) }
}


fun part_two(passwords: MutableList<List<String>>) {
    var sum = 0
    passwords.forEach { p ->
        val first = p[3][p[0].toInt()-1] == p[2][0]
        val last = p[3][p[1].toInt()-1] == p[2][0]
        
        if (first xor last) sum++
    }.also{ println(sum) }
}


// Helper function for reading from file
fun rff(fileName: String, lof: MutableList<List<String>>) =
    File(fileName).forEachLine { lof.add(it.split("-", ": ", " ")) }
