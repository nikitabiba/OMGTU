for j in range(1, 15):
    minfir = 0
    minpr = 873498173724.0
    num = '0'
    if len(str(j)) == 1:
        num += str(j)
    else:
        num = str(j)
    with open(f'C:\\Users\\csr10\\OneDrive\\Рабочий стол\\Work\\Постройка дома\\input_s1_{num}.txt', encoding='utf-8') as f1, open(f'C:\\Users\\csr10\\OneDrive\\Рабочий стол\\Work\\Постройка дома\\output_s1_{num}.txt', encoding='utf-8') as f2:
        answer = f2.readline()
        strk = [int(i) for i in f1.readline().split()]
        x = strk[0]
        y = strk[1]
        l = strk[2]
        c1 = strk[3]
        c2 = strk[4]
        c3 = strk[5]
        c4 = strk[6]
        c5 = strk[7]
        c6 = strk[8]
        kol = 2 * (x + y)
        mx = max(x, y)
        kolcopy = kol
        lcopy = l
        prices = []
        sum1 = kol * (c4 + c5) + l * (c2 + c6)
        if l <= mx:
            kol -= l
            sum2 = l * c1 + kol * (c4 + c5)
        else:
            kol -= mx
            l -= mx
            sum2 = mx * c1 + kol * (c4 + c5) + l * (c2 + c6)
        kol = kolcopy
        l = lcopy
        if l <= kol:
            kol -= l
            sum3 = l * (c2 + c3) + kol * (c4 + c5)
        else:
            l -= kol
            sum3 = kol * (c2 + c3) + l * (c2 + c6)
        kol = kolcopy
        l = lcopy
        if l <= mx and l <= kol:
            kol -= l
            sum4 = l * c1 + kol * (c4 + c5)
        elif l > mx and l <= kol:
            kol -= l
            l -= mx
            sum4 = mx * c1 + l * (c2 + c3) + kol * (c4 + c5)
        elif x > y and kol < l:
            l -= kol
            kol -= x
            sum4 = x * c1 + kol * (c2 + c3) + l * (c2 + c6)
        elif x <= y and kol < l:
            l -= kol
            kol -= y
            sum4 = y * c1 + kol * (c2 + c3) + l * (c2 + c6)
        prices.append(sum1)
        prices.append(sum2)
        prices.append(sum3)
        prices.append(sum4)
        itog = min(prices)
    if str(itog) == answer:
        print(itog, '=', answer, ' -  passed')
    else:
        print(itog, '=', answer, ' -  fail')
