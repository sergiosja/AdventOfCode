import java.io.File

fun main() {
    val path = mutableListOf<List<Char>>()
    rff("input.txt", path)

    part_one(path)
    part_two(path)
}


fun part_one(path: MutableList<List<Char>>) {
    var dist = 0
    var c = 0

    for (i in path) {
        if (i[dist] == '#') {
            c++
        }
        dist = (3 + dist) % i.size
    }
    
    println(c)
}


fun part_two(path: MutableList<List<Char>>) {
    val counters = mutableListOf<Long>(0, 0, 0, 0, 0)
    val dists = mutableListOf(0, 0, 0, 0, 0)
    val incs = mutableListOf(1, 3, 5, 7)

    for (i in 0..path.size-1) {
        for (j in 0..3) {
            if (path[i][dists[j]] == '#') {
                counters[j]++
            }
            dists[j] = (dists[j] + incs[j]) % path[i].size
        }
        if (i % 2 == 0) {
            if (path[i][dists[4]] == '#') {
                counters[4]++
            }
            dists[4] = (dists[4] + 1) % path[i].size
        }
    }

    println(counters.reduce { org, i -> org * i })
}


// Helper function for reading from file
fun rff(fileName: String, lof: MutableList<List<Char>>) =
    File(fileName).forEachLine { lof.add(it.toList()) }