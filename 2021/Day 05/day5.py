from collections import defaultdict

def findoverlap(matrix):
    return sum([len(list(filter(lambda x: x > 1, row))) for row in matrix])

def main():
    vents = defaultdict(list)
    maxlen = 0

    with open("input.txt", "r") as input:
        for i in input:
            a, b, c, d = map(int, i[:-1].replace(' -> ',',').split(','))
            if max(a, b, c, d) > maxlen:
                maxlen = max(a, b, c, d)

            # Horizontal lines
            if a == c:
                vents["xH"].append((a, (min(b, d), max(b, d))))
            
            elif b == d:
                vents["yH"].append((b, (min(a, c), max(a, c))))

            # Diagonal lines
            elif a+b == c+d:
                mt = (a, b, abs(a-c)) if a < c else (c, d, abs(a-c))
                vents["dS"].append(mt)

            elif a-c == b-d:
                inc = c-a if a < c else a-c
                mt = (a, b, inc) if a < c else (c, d, inc)
                vents["dI"].append(mt)

    matrix = [[0 for _ in range(maxlen+1)] for _ in range(maxlen+1)]

    # Part 1
    for i in vents["xH"]:
        for j in range(i[1][0], i[1][1]+1):
            matrix[j][i[0]] += 1

    for i in vents["yH"]:
        for j in range(i[1][0], i[1][1]+1):
            matrix[i[0]][j] += 1

    print(findoverlap(matrix))

    # Part 2
    for i in vents["dS"]:
        for j in range(i[2]+1):
            matrix[i[1]-j][i[0]+j] += 1

    for i in vents["dI"]:
        for j in range(i[2]+1):
            matrix[i[1]+j][i[0]+j] += 1

    print(findoverlap(matrix))


if __name__ == "__main__":
    main()