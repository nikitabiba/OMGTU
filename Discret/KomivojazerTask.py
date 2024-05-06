import copy

inf = float("inf")

A = [[inf, 41, 17, 23, 32],
     [13, inf, 45, 12, 37],
     [80, 45, inf, 50, 64],
     [23, 12, 50, inf, 67],
     [32, 37, 64, 67, inf]]
graf = copy.deepcopy(A)

def summa_const(A):
    summa = 0
    for i in range(len(A)):
        if not all(A[i][k] == float("inf") for k in range(len(A))):
            mn = A[i][0]
            for j in range(len(A)):
                mn = min(A[i][j], mn)
            summa += mn
            for k in range(len(A)):
                A[i][k] -= mn

    for i in range(len(A)):
        if not all(A[p][i] == float("inf") for p in range(len(A))):
            mn = A[0][i]
            for j in range(len(A)):
                mn = min(A[j][i], mn)
            summa += mn
            for k in range(len(A)):
                A[k][i] -= mn
    return A, summa


def prived_mat(A, rebro, cycle_rebros=None):
    for i in range(len(A)):
        A[rebro[0]][i] = float("inf")
    for j in range(len(A)):
        A[j][rebro[1]] = float("inf")
    if cycle_rebros is not None:
        for reb in cycle_rebros:
            A[reb[0]][reb[1]] = float("inf")
    return A


def deg_zero(A):
    mx_deg_zero = -1000
    rebro = (-1, -1)
    for i in range(len(A)):
        for j in range(len(A)):
            if A[i][j] == 0:
                mn_stroka = 10000
                mn_stolbec = 10000
                for k in range(len(A)):
                    if k == j:
                        continue
                    mn_stroka = min(mn_stroka, A[i][k])

                for l in range(len(A)):
                    if l == i:
                        continue
                    mn_stolbec = min(mn_stolbec, A[l][j])
                if mn_stroka + mn_stolbec > mx_deg_zero:
                    mx_deg_zero = mn_stroka + mn_stolbec
                    rebro = (i, j)
    return rebro



def has_cycle(edges):
    graph = {}
    for v1, v2 in edges:
        if v1 in graph:
            graph[v1].append(v2)
        else:
            graph[v1] = [v2]
    visited = set()

    def visit(vertex, path):
        visited.add(vertex)
        path.add(vertex)

        for neighbour in graph.get(vertex, ()):
            if neighbour in path or visit(neighbour, path):
                return True

        path.remove(vertex)
        return False

    return any(visit(v, set()) for v in graph if v not in visited)

answer = []
ocenka = []
res = summa_const(A)
ocenka.append(res[1])
A = res[0]

for _ in range(len(A)-2):
    rebro = deg_zero(A)
    answer.append(rebro)

    cycle_reb = []
    for i in range(len(A)):
        for j in range(len(A)):
            if has_cycle(answer + [(i, j)]):
                cycle_reb.append((i, j))
    if len(cycle_reb) == 0:
        cycle_reb = None

    A = prived_mat(A, rebro, cycle_reb)
    res1 = summa_const(A)
    ocenka.append(ocenka[-1] + res1[1])
    A = res1[0]

for i in range(len(A)):
    for j in range(len(A)):
        if A[i][j] == 0:
            answer.append((i, j))

way = [answer[0]]
sum_way = sum(graf[i[0]][i[1]] for i in answer)
print(f"Длина пути: {sum_way}")
while len(way) != len(answer):
    for i in answer:
        if i[0] == way[-1][1]:
            way.append(i)
print(f"Рёбра: {answer}")
print(f"Цикл из этих рёбер: {way}")
print(f"Оценки: {ocenka}")