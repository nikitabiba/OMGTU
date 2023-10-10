with open(f'C:\\Users\\csr10\\OneDrive\\Рабочий стол\\Work\\Tests1.txt', encoding='utf-8') as f:
    strk = [i.strip() for i in f.readlines()]
    for i in range(0, 15, 2):
        k = 0
        for n in range(1, int(strk[i]) + 1):
            for z in range(1, 21):
                if int(((2**z)*n)/((2**z)-1)) == ((2**z)*n)/((2**z)-1):
                    k += 1
        print(k, '-', strk[i+1], end=' ')
        if str(k) == strk[i+1]:
            print('passed')
        else:
            print('fail')