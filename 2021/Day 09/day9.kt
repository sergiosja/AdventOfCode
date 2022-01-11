import java.io.File
val input = readFile("input.txt")

fun main() {
    println(part1(input))
    println(part2(input))
}


fun part1(heightmap: MutableList<MutableList<Int>>): Int {
    var risklevels = 0

    for (i in 0..heightmap.size-1) {
        for (j in 0..heightmap[i].size-1) {
            if (heightmap.compareNb(i, j, i-1, j) + heightmap.compareNb(i, j, i+1, j) +
                heightmap.compareNb(i, j, i, j-1) + heightmap.compareNb(i, j, i, j+1) == 4) {
                risklevels += heightmap[i][j] + 1
            }
        }
    }

    return risklevels
}


fun part2(heightmap: MutableList<MutableList<Int>>): Int {
    var raisins = mutableListOf<Int>()

    for (i in 0..heightmap.size-1) {
        for (j in 0..heightmap[i].size-1) {
            if (heightmap.compareNb(i, j, i-1, j) + heightmap.compareNb(i, j, i+1, j) +
                heightmap.compareNb(i, j, i, j-1) + heightmap.compareNb(i, j, i, j+1) == 4) {
                raisins.add(dfs(heightmap, i, j))
            }
        }
    }

    return raisins.sortedByDescending{ it }.take(3).fold(1){ sum, acc -> sum * acc }
}


fun dfs(arr: MutableList<MutableList<Int>>, x: Int, y: Int): Int {
    val q = mutableListOf<Pair<Int, Int>>(x to y)
    var counter = 0

    while (q.isNotEmpty()) {
        val (a, b) = q.removeAt(q.size-1)

        if (arr.valid(a, b) && arr[a][b] < 9) {
            counter += 1
            arr[a][b] = 9

            q.add(Pair(a, b+1))
            q.add(Pair(a, b-1))
            q.add(Pair(a+1, b))
            q.add(Pair(a-1, b))
        }
    }

    return counter
}

// Helper extension functions
fun MutableList<MutableList<Int>>.compareNb(x: Int, y: Int, x2: Int, y2: Int): Int {
    try {
        if (this[x][y] < this[x2][y2])
            return 1
    } catch (e: IndexOutOfBoundsException) {
        return 1
    }

    return 0
}

fun MutableList<MutableList<Int>>.valid(x: Int, y: Int): Boolean {
    try {
        this[x][y]
    } catch (e: IndexOutOfBoundsException) {
        return false
    }
    return true
}

// Helper function for reading from file
fun readFile(fileName: String): MutableList<MutableList<Int>> {
    val tmp = mutableListOf<MutableList<Int>>()
    File(fileName).forEachLine{ tmp.add(it.toCharArray().map{ Character.getNumericValue(it) }.toMutableList())}
    return tmp
}
