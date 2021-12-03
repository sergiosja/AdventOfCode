import java.io.File
val input = readFile("input.txt")

fun main() {
    println(partOne())
    println(partTwo("oxygen") * partTwo("co2"))
}


fun partOne(): Int {
    val nums = IntArray(input[0].length)
    var gamma = ""
    var epsilon = ""

    for (i in input)
        for (d in 0..i.length-1)
            nums[d] += if (i[d] == '1') 1 else -1

    for (i in nums) gamma += if (i > 0) "1" else "0"
    for (i in gamma) epsilon += if (i == '0') "1" else "0"

    return gamma.toInt(2) * epsilon.toInt(2)
}


fun partTwo(lsr: String): Int {
    var main = input.toMutableSet()
    var a = mutableSetOf<String>()
    var b = mutableSetOf<String>()
    var counter = 0

    while (true) {
        if (counter > 0) {
            if (lsr == "oxygen")
                main = if (a.size >= b.size) a else b
            else
                main = if (a.size < b.size) a else b

            if (main.size == 1)
                for (i in main)
                    return i.toInt(2)
        }

        a = mutableSetOf<String>()
        b = mutableSetOf<String>()

        for (seq in main)
            if (seq[counter] == '1')
                a.add(seq)
            else
                b.add(seq)
        
        counter += 1
    }
}


fun readFile(fileName: String): List<String>
    = File(fileName).useLines { it.toList() }