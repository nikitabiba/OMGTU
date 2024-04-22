import copy

mas = [[float("inf")] * 9 for _ in range(13)]
for i in range(len(mas)):
    for j in range(len(mas[0])):
        if i == 0 or j == 0 or i == len(mas)-1 or j == len(mas[0])-1:
            mas[i][j] = -1

mas[3][3] = -1
mas[4][3] = -1
mas[5][3] = -1
mas[6][3] = -1
mas[9][2] = -1
mas[10][2] = -1
mas[11][2] = -1
mas[2][5] = -1
mas[3][5] = -1
mas[4][5] = -1
mas[8][5] = -1
mas[8][6] = -1
mas[8][7] = -1


start = list(map(int, input("Начальная позиция: ").split()))
end = list(map(int, input("Конечная позиция: ").split()))
mas[start[0]][start[1]] = 0

dist = 0
prev = copy.deepcopy(mas)
while mas[end[0]][end[1]] == float("inf"):
    for i in range(len(mas)):
        for j in range(len(mas[0])):
            if mas[i][j] == dist:
                for k in range(-1, 2):
                    for l in range(-1, 2):
                        if not (k == 0 and l == 0) and mas[i+k][j+l] != -1:
                            mas[i+k][j+l] = min(mas[i+k][j+l], dist + 1)
    if prev == mas:
        break
    dist += 1
    prev = copy.deepcopy(mas)

way = [(end[0], end[1])]
x = end[0]
y = end[1]
if mas[end[0]][end[1]] != float("inf"):
    for i in mas:
        print(i)
    while (start[0], start[1]) not in way:
        flag = False
        for k in range(-1, 2):
            for l in range(-1, 2):
                if not (k == 0 and l == 0) and mas[x + k][y + l] == mas[x][y] - 1:
                    way.append((x + k, y + l))
                    x += k
                    y += l
                    flag = True
                    break
            if flag:
                break
    way.reverse()
    print("Путь: ", end="")
    print(way)
else:
    print("Нет пути")