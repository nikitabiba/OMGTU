for i in range(1, 13):
    f = open(fr"C:\Users\csr10\OneDrive\Рабочий стол\Work\Отгадай число\input_s1_{i:02}.txt")
    f2 = open(fr"C:\Users\csr10\OneDrive\Рабочий стол\Work\Отгадай число\output_s1_{i:02}.txt")
    n = int(f.readline())
    A = []
    for j in range(n+1):
        s = f.readline().split()
        A.append(s)
    A.reverse()
    kol_x = 0
    sum_chis = int(A[0][0])
    A.pop(0)
    for a in A:
        if a[0] == "+":
            if a[1] == "x":
                kol_x += 1
            else:
                sum_chis -= int(a[1])
        elif a[0] == "-":
            if a[1] == "x":
                kol_x -= 1
            else:
                sum_chis += int(a[1])
        elif a[0] == "*":
            sum_chis /= int(a[1])
            kol_x /= int(a[1])
    kol_x += 1
    answer = round(sum_chis / kol_x)
    right_ans = f2.readline()
    print(f"Test {i}: {answer} {right_ans}")