rebra = ["12", "16",  "23", "24", "34", "45", "78", "89", "79", "bc"]
vershini = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "b", "c", "d"]
def smezh(x, y, rebra):
    for rebro in rebra:
        if ((x + y) in rebro) or ((y + x) in rebro):
            return True
def smezh_ver(x, rebra):
    lst = []
    for i in rebra:
        if x == i[0]:
            lst.append(i[1])
        elif x == i[1]:
            lst.append(i[0])
    return lst

mas = []
maskomp = []
def poisk(ver, rebra, vershini):
    global mas
    if len(smezh_ver(ver, rebra)) == 0:
        mas.append(ver)
        return
    for i in vershini:
        if smezh(ver, i, rebra) and i not in mas:
            mas.append(i)
            poisk(i, rebra, vershini)

for x in vershini:
    poisk(x, rebra, vershini)
    komponenta = sorted(list(set(mas)))
    if komponenta not in maskomp:
        maskomp.append(komponenta)
    mas = []


print(maskomp)

