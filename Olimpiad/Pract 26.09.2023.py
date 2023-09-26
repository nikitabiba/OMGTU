from decimal import Decimal
def S(x, y, z):
    return 2*(x*y + x*z + y*z)
def V(x, y, z):
    return x*y*z / 1000
for j in range(1, 11):
    minfir = 0
    minpr = 873498173724.0
    with open(f'C:\\Users\\csr10\\OneDrive\\Рабочий стол\\Work\\Упаковки молока\\input{j}.txt', encoding='utf-8') as f1, open(f'C:\\Users\\csr10\\OneDrive\\Рабочий стол\\Work\\Упаковки молока\\output{j}.txt', encoding='utf-8') as f2:
        answer = f2.readline()
        for i in range(1, int(f1.readline())+1):
            st = f1.readline().split()
            x1, y1, z1 = int(st[0]), int(st[1]), int(st[2])
            x2, y2, z2 = int(st[3]), int(st[4]), int(st[5])
            c1, c2 = float(st[6]), float(st[7])
            s1, s2 = S(x1, y1, z1), S(x2, y2, z2)
            v1, v2 = V(x1, y1, z1), V(x2, y2, z2)
            p = ((s1*c2 - c1*s2) / (v2*s1 - v1*s2))
            if p < minpr:
                minfir = i
                minpr = p
    minpr = Decimal(str(minpr))
    minpr = minpr.quantize(Decimal("1.00"))
    if str(minfir)+' '+str(minpr) == answer:
        print(minfir, minpr, '=', answer, ' -  passed')
    else:
        print(minfir, minpr, '=', answer, ' -  fail')