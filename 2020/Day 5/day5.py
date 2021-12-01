def binarysearch(left, right, middle, seq):
    for c in seq:
        if c == "F" or c == "L":
            right = middle
        elif c == "B" or c == "R":
            left = middle + 1

        middle = (left + right) // 2

    return middle


def main():
    f = open("input.txt", "r")
    s = set()

    for bp in f:
        s.add(binarysearch(0, 127, 127 // 2, bp[:7])
                * 8
                + binarysearch(0, 7, 7 // 2, bp[7:]))


    # Part 1
    print(max(s))

    # Part 2
    for i in range(min(s), max(s)):
        if i not in s:
            print(i)
            break

main()