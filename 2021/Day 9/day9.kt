import java.io.File

fun main() {
    val heightmap = readFile("input.txt")
    var risklevels = 0

    for (i in 0..heightmap.size-1) {
        for (j in 0..heightmap[i].size-1) {
            var counter = 0

            try {
                if (heightmap[i][j] < heightmap[i-1][j])
                    counter++
            } catch (e: IndexOutOfBoundsException) {
                counter++
            }

            try {
                if (heightmap[i][j] < heightmap[i+1][j])
                    counter++
            } catch (e: IndexOutOfBoundsException) {
                counter++
            }

            try {
                if (heightmap[i][j] < heightmap[i][j-1])
                    counter++
            } catch (e: IndexOutOfBoundsException) {
                counter++
            }

            try {
                if (heightmap[i][j] < heightmap[i][j+1])
                    counter++
            } catch (e: IndexOutOfBoundsException) {
                counter++
            }

            if (counter == 4)
                risklevels += heightmap[i][j] + 1
        }
    }

    println(risklevels)
}


// Helper function for reading from file
fun readFile(fileName: String): MutableList<List<Int>> {
    val tmp = mutableListOf<List<Int>>()
    File(fileName).forEachLine{ tmp.add(it.toCharArray().map{ Character.getNumericValue(it) })}
    return tmp
}