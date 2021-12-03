import java.io.File
val input = readFile("input.txt")

fun main() {
    println(partOne())
    println(partTwo("oxygen", 0, input.toMutableSet(), mutableSetOf<String>(), mutableSetOf<String>())
          * partTwo("co2", 0, input.toMutableSet(), mutableSetOf<String>(), mutableSetOf<String>()))
}


fun partOne(): Int {
    val nums = IntArray(input[0].length)
    var gamma = ""
    var epsilon = ""

    for (i in input)
        for (d in 0..i.length-1)
            nums[d] += if (i[d] == '1') 1 else -1

    for (i in nums)
        gamma += if (i > 0) "1" else "0"

    for (i in gamma)
        epsilon += if (i == '0') "1" else "0"

    return gamma.toInt(2) * epsilon.toInt(2)
}


fun partTwo(lsr: String, counter: Int, main: MutableSet<String>, a: MutableSet<String>, b: MutableSet<String>): Int {
    for (seq in main)
        if (seq[counter] == '1')
            a.add(seq)
        else
            b.add(seq)

    var newmain: MutableSet<String>?
    if (lsr == "oxygen")
        newmain = if (a.size >= b.size) a else b
    else
        newmain = if (a.size < b.size) a else b

    if (newmain.size == 1)
        return newmain.toMutableList().removeAt(0).toInt(2)

    return partTwo(lsr, counter+1, newmain, mutableSetOf<String>(), mutableSetOf<String>())
}


fun readFile(fileName: String): List<String>
    = File(fileName).useLines { it.toList() }