import sys

def main():
    file = open(sys.argv[1], "r")
    tbw = open(sys.argv[2], "w")

    for line in file:
        tbw.write(f"aoc({line[:-1]}).\n")

if __name__ == "__main__":
    main()