class Board:
    def __init__(self, board):
        self.board = list(filter(lambda x: x != '', board))

    def checkWinner(self):
        for i in range(5):
            if self.getRow(i).count('M') == 5 or \
               self.getColumn(i).count('M') == 5:
                return True
        return False

    def getRow(self, n):
        return [self.board[i] for i in range(n*5, n*5+5)]

    def getColumn(self, n):
        return [self.board[i] for i in range(len(self.board)) if i % 5 == n]

    def getSum(self):
        return sum(map(int, filter(lambda x: x != 'M', self.board)))


def readInput(file):
    with open(file, 'r') as input:

        # The winning numbers
        numbers = input.readline()[:-1].split(',')
        input.readline()

        # All boards
        boards = list()
        curr = list()
        for i in input:
            if i[0] == '\n':
                boards.append(Board(curr))
                curr = list()
                continue
            
            for n in i[:-1].split(' '):
                curr.append(n)

    return numbers, boards


def main():
    numbers, boards = readInput("input.txt")
    winners = list()

    for n in numbers:
        for b in boards:
            if n in b.board:
                b.board = ['M' if x == n else x for x in b.board]

            # Part 1
            if not winners and b.checkWinner():
                print(b.getSum() * int(n))
                winners.append(b)

            # Part 2
            if b.checkWinner() and b not in winners:
                winners.append(b)

                if len(boards) == len(winners):
                    print(b.getSum() * int(n))
                    return


if __name__ == "__main__":
    main()