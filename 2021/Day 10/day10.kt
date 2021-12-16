import java.io.File
val input = readFile("input.txt")

fun main() {
    val tbr = mutableListOf<String>()

    println(partOne(tbr))
    println(partTwo(tbr))
}


fun partOne(tbr: MutableList<String>): Int {
    val b = listOf('{', '[', '(', '<', '}', ']', ')', '>')
    val vals = mapOf(')' to 3, ']' to 57, '}' to 1197, '>' to 25137)
    var counter = 0

    for (chunk in input) {
        val stack = mutableListOf<Char>()

        outer@ for (c in 0..chunk.length-1) {
            for (i in 0..3) {
                if (chunk[c] == b[i]) {
                    stack.add(chunk[c]); continue
                }
            
                if (chunk[c] == b[i+4]) {
                    if (stack[stack.size-1] != b[i]) {
                        counter += vals[chunk[c]]!!
                        tbr.add(chunk)
                        break@outer
                    }
                    stack.removeAt(stack.size-1)
                }
            }
        }
    }

    return counter
}


fun partTwo(tbr: MutableList<String>): Long {
    val b = listOf('{', '[', '(', '<', '}', ']', ')', '>')
    val vals = mapOf('(' to 1, '[' to 2, '{' to 3, '<' to 4)
    val sums = mutableListOf<Long>()

    for (chunk in input) {
        if (chunk in tbr)
            continue

        val stack = mutableListOf<Char>()
        var counter: Long = 0

        for (c in 0..chunk.length-1) {
            for (i in 0..3) {
                if (chunk[c] == b[i]) {
                    stack.add(chunk[c]); continue
                }
                
                if (chunk[c] == b[i+4]) {
                    stack.removeAt(stack.size-1);
                }
            }
        }
        
        for (i in stack.reversed())
            counter = counter * 5 + vals[i]!!

        sums.add(counter)
    }

    return sums.sorted()[sums.size/2]
}


// Helper function for reading from file
fun readFile(fileName: String): MutableList<String> {
    val tmp = mutableListOf<String>()
    File(fileName).forEachLine{ tmp.add(it) }
    return tmp
}