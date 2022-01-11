import java.io.File
val cavern = readFile("input.txt")
var p1 = 0

fun main() {
    println(rec(0, 0))
}

fun rec(acc: Int, steps: Int): Pair<Int, Int> {
    // Part 1
    if (steps == 100) p1 = acc

    // Part 2
    run p2@ { cavern.forEach{ o -> if (o.sum() != 0) return@p2 }.also { return Pair(p1, steps) }}


    // 1st iteration -> Increase energy level of each octopus with 1
    for (i in cavern) {
        for (j in 0..i.size-1) {
            i[j]++
        }
    }

    // 2nd iteration -> Increase energy level of all neighbours if octopus flashes
    while (true) {
        if (!cavern.flash()) {
            break
        }
    }

    // 3rd iteration -> Set all flashed octopi to 0
    var counter: Int = 0
    for (i in cavern) {
        for (j in 0..i.size-1) {
            if (i[j] < 0) {
                i[j] = 0
                counter++
            }
        }
    }

    return rec(acc+counter, steps+1)
}


// Helper extension function
fun MutableList<IntArray>.flash(): Boolean {
    var done = false
    for (i in 0..this.size-1) {
        for (j in 0..this[i].size-1) {
            if (this[i][j] > 9) {
                try { this[i-1][j-1]++ } catch (e: IndexOutOfBoundsException) {}
                try { this[i-1][j+1]++ } catch (e: IndexOutOfBoundsException) {}
                try { this[i-1][j]++ } catch (e: IndexOutOfBoundsException) {}
                try { this[i][j-1]++ } catch (e: IndexOutOfBoundsException) {}
                try { this[i][j+1]++ } catch (e: IndexOutOfBoundsException) {}
                try { this[i+1][j+1]++ } catch (e: IndexOutOfBoundsException) {}
                try { this[i+1][j-1]++ } catch (e: IndexOutOfBoundsException) {}
                try { this[i+1][j]++ } catch (e: IndexOutOfBoundsException) {}
                this[i][j] = -100
                done = true
            }
        }
    }
    return done
}

// Helper function for reading from file
fun readFile(fileName: String): MutableList<IntArray> {
    val tmp = mutableListOf<IntArray>()
    File(fileName).forEachLine{ tmp.add(it.toCharArray().map{ Character.getNumericValue(it) }.toIntArray())}
    return tmp
}