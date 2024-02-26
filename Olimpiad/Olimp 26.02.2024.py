for h in range(1, 11):
    dic = dict()
    mas = []
    with open(f"C:\\Users\\csr10\\OneDrive\\Рабочий стол\\Work\\Зельеварение\\input{h}.txt", encoding="UTF-8") as f1, open(f"C:\\Users\\csr10\\OneDrive\\Рабочий стол\\Work\\Зельеварение\\output{h}.txt", encoding="UTF-8") as f2:
        ans = f2.readline()
        for i in range(100):
            a = f1.readline()
            a = a.replace("\n", "")
            mas.append(a)
    for i in range(100):
        if mas[i] == "":
            mas = mas[:i]
            break
    for i in range(len(mas)):
        if "DUST" in mas[i]:
            mas[i] = mas[i].replace("DUST", "DT") + " TD"
        elif "FIRE" in mas[i]:
            mas[i] = mas[i].replace("FIRE", "FR") + " RF"
        elif "WATER" in mas[i]:
            mas[i] = mas[i].replace("WATER", "WT") + " TW"
        elif "MIX" in mas[i]:
            mas[i] = mas[i].replace("MIX", "MX") + " XM"
        dic[i+1] = mas[i].split()
    for key, value in dic.items():
        for i in range(len(value)):
            if value[i][0] in "0123456789":
                dic[key][i] = "".join(dic[int(value[i])])
    print(f"Test {h}:")
    print("".join(dic[len(mas)]))
    print(ans)

