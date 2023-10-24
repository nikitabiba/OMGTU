d1, m1, y1 = map(int, input().split('.'))
d2, m2, y2 = map(int, input().split('.'))
p = int(input())
dic = {1: 31, 2: 28, 3: 31, 4: 30, 5: 31, 6: 30, 7: 31, 8: 31, 9: 30, 10: 31, 11: 30, 12: 31}
days = 0
if y1 != y2:
    if y1 % 4 == 0:
        dic[2] = 29
    days += dic[m1] - d1 + 1
    for i in range(m1 + 1, 13):
        days += dic[i]
    for i in range(y1 + 1, y2):
        if i % 4 == 0:
            days += 366
        else:
            days += 365
    if y2 % 4 == 0:
        dic[2] = 29
    else:
        dic[2] = 28
    for i in range(1, m2):
        days += dic[i]
    days += d2
elif m1 == m2:
    days += d2 - d1 + 1
else:
    if y1 % 4 == 0:
        dic[2] = 29
    days += dic[m1] - d1 + 1
    for i in range(m1 + 1, m2):
        days += dic[i]
    days += d2
summ = ((2 * p + days - 1) / 2) * days
print(int(summ))