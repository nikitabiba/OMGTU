import copy

inf = float("inf")

graf = [[0, 7, inf, inf, 9, 2, inf, inf, inf, inf, inf, inf],
        [7, 0, 5, 4, 8, 2, inf, inf, inf, inf, inf, inf],
        [inf, 5, 0, 2, 9, inf, inf, inf, inf, inf, inf, inf],
        [inf, 4, 2, 0, 3, inf, 8, 3, inf, inf, inf, inf],
        [9, 8, 9, 3, 0, 3, 5, 1, 7, inf, inf, inf],
        [2, 2, inf, inf, 3, 0, inf, 6, 1, inf, inf, inf],
        [inf, inf, inf, 8, 5, inf, 0, 6, inf, 4, 4, inf],
        [inf, inf, inf, 3, 1, 6, 6, 0, 2, 7, 8, 5],
        [inf, inf, inf, inf, 7, 1, inf, 2, 0, inf, 6, 1],
        [inf, inf, inf, inf, inf, inf, 4, 7, inf, 0, 10, inf],
        [inf, inf, inf, inf, inf, inf, 4, 8, 6, 10, 0, 3],
        [inf, inf, inf, inf, inf, inf, inf, 5, 1, inf, 3, 0]]

A = copy.deepcopy(graf)

for i in range(len(graf)):
    for j in range(len(graf)):
        for k in range(len(graf)):
            if graf[j][k] > graf[j][i] + graf[i][k]:
                graf[j][k] = graf[j][i] + graf[i][k]
for i in graf:
    print(i)

a = int(input("Первая вершина: "))
b = int(input("Вторая вершина: "))

way = [b]
u = a - 1
v = b - 1

while a not in way:
    for i in range(len(graf)):
        if graf[i][v] != inf and graf[u][v] == graf[u][i] + A[i][v] and (i+1) not in way:
            way.append(i+1)
            v = i
way.reverse()
print(way)
