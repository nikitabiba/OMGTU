inf = float("inf")
graf = [[inf, 7, inf, inf, 9, 2, inf, inf, inf, inf, inf, inf],
        [7, inf, 5, 4, 8, 2, inf, inf, inf, inf, inf, inf],
        [inf, 5, inf, 2, 9, inf, inf, inf, inf, inf, inf, inf],
        [inf, 4, 2, inf, 3, inf, 8, 3, inf, inf, inf, inf],
        [9, 8, 9, 3, inf, 3, 5, 1, 7, inf, inf, inf],
        [2, 2, inf, inf, 3, inf, inf, 6, 1, inf, inf, inf],
        [inf, inf, inf, 8, 5, inf, inf, 6, inf, 4, 4, inf],
        [inf, inf, inf, 3, 1, 6, 6, inf, 2, 7, 8, 5],
        [inf, inf, inf, inf, 7, 1, inf, 2, inf, inf, 6, 1],
        [inf, inf, inf, inf, inf, inf, 4, 7, inf, inf, 10, inf],
        [inf, inf, inf, inf, inf, inf, 4, 8, 6, 10, inf, 3],
        [inf, inf, inf, inf, inf, inf, inf, 5, 1, inf, 3, inf]]


start = int(input("Начальная вершина: "))
l = [inf] * len(graf)
l2 = []
l[start-1] = 0
for i in range(len(graf)-1):
    for j in range(len(graf)):
        for k in range(len(graf)):
            if l[j] > graf[k][j] + l[k]:
                l[j] = graf[k][j] + l[k]

flag = True
for j in range(len(graf)):
    for k in range(len(graf)):
        if l[j] > graf[k][j] + l[k]:
            flag = False
            print("Имеется отрицательный цикл")

if flag:
    print(l)

if flag:
    for finish in range(len(graf)):
        way = [finish+1]
        v = finish
        while start not in way:
            for i in range(len(graf)):
                if graf[i][v] != inf and l[v] == graf[i][v] + l[i]:
                    way.append(i + 1)
                    v = i
        way.reverse()
        print(f"Путь до вершины {finish+1}: {way}")