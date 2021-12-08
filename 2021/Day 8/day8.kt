import java.io.File
val input = readFile("input.txt")

fun main() {
    println(partOne())
    println(partTwo())
}

fun partOne(): Int {
    var counter = 0
    for (i in input)
        for (j in i[1].split(" "))
            if (j.length == 2 || j.length == 3 || j.length == 4 || j.length == 7)
                counter += 1
    return counter
}

fun partTwo(): Int {
    var counter = 0
    for (i in input) {
        val (groups, digits) = findDigits(i)

        // Use 1 to get 3            
        for (j in groups.get(5)!!) {
            if (j.makeSet().containsAll(digits[1].makeSet())) {
                groups.get(5)!!.remove(j)
                digits[3] = j
                break
            }
        }

        // Use 3 to get 9
        for (j in groups.get(6)!!) {
            if (j.makeSet().containsAll(digits[3].makeSet())) {
                groups.get(6)!!.remove(j)
                digits[9] = j
                break
            }
        }

        // Use 1 to get 0 and 6
        for (j in groups.get(6)!!) {
            if (j.makeSet().containsAll(digits[1].makeSet()))
                digits[0] = j
            else
                digits[6] = j
        }

        // Use 6 to get 5 and 2
        for (j in groups.get(5)!!) {
            if (digits[6].makeSet().containsAll(j.makeSet()))
                digits[5] = j
            else
                digits[2] = j
        }

        var tba = ""
        for (j in i[1].split(" ")) {
            for (d in 0..9) {
                if (j.makeSet().equals(digits[d].makeSet())) {
                    tba += d.toString()
                    break
                }
            }
        }
        counter += tba.toInt()
    }

    return counter
}


fun findDigits(input: List<String>): Pair<MutableMap<Int, MutableList<String>>, Array<String>> {
    val groups = mutableMapOf(5 to mutableListOf<String>(), 6 to mutableListOf<String>())
    val digits = Array<String>(10){""}

    for (i in input[0].split(" ")) {
        when (i.length) {
            5 -> groups.get(5)!!.add(i)
            6 -> groups.get(6)!!.add(i)
            2 -> digits[1] = i
            3 -> digits[7] = i
            4 -> digits[4] = i
            7 -> digits[8] = i
        }
    }

    return Pair(groups, digits)
}


// Helper functions
fun String.makeSet(): Set<String> =
    this.split("").subList(1, this.length+1).toSet()

fun readFile(fileName: String): List<List<String>> {
    val tmp = mutableListOf<List<String>>()
    File(fileName).forEachLine { tmp.add(it.split(" | ")) }
    return tmp.toList()
}