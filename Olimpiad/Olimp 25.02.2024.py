from sys import setrecursionlimit
import threading

def main():
    for k in range(1, 17):
        global lst
        sotrudniki = {}
        sotrudniki2 = {}
        with open(f"C:\\Users\\csr10\\OneDrive\\Рабочий стол\\Work\\Компании\\input_s1_{k:02}.txt") as f, open(f"C:\\Users\\csr10\\OneDrive\\Рабочий стол\\Work\\Компании\\output_s1_{k:02}.txt") as f2:
            s1 = f.readline().split()
            if s1[0] not in sotrudniki2.keys():
                if len(s1) == 1:
                    sotrudniki2[s1[0]] = "Unknown Name"
                else:
                    sotrudniki2[s1[0]] = " ".join(s1[1:])
            else:
                if sotrudniki2[s1[0]] == "Unknown Name" and len(s1) != 1:
                    sotrudniki2[s1[0]] = " ".join(s1[1:])
            s11 = s1[0]

            s2 = f.readline().split()
            if s2[0] not in sotrudniki2.keys():
                if len(s2) == 1:
                    sotrudniki2[s2[0]] = "Unknown Name"
                else:
                    sotrudniki2[s2[0]] = " ".join(s2[1:])
            else:
                if sotrudniki2[s2[0]] == "Unknown Name" and len(s2) != 1:
                    sotrudniki2[s2[0]] = " ".join(s2[1:])
            s22 = s2[0]

            sotrudniki[s11] = [s22]

            while True:
                s1 = f.readline().split()
                s11 = s1[0]
                if s11 == "END":
                    break
                if s1[0] not in sotrudniki2.keys():
                    if len(s1) == 1:
                        sotrudniki2[s1[0]] = "Unknown Name"
                    else:
                        sotrudniki2[s1[0]] = " ".join(s1[1:])
                else:
                    if sotrudniki2[s1[0]] == "Unknown Name" and len(s1) != 1:
                        sotrudniki2[s1[0]] = " ".join(s1[1:])

                s2 = f.readline().split()
                if s2[0] not in sotrudniki2.keys():
                    if len(s2) == 1:
                        sotrudniki2[s2[0]] = "Unknown Name"
                    else:
                        sotrudniki2[s2[0]] = " ".join(s2[1:])
                else:
                    if sotrudniki2[s2[0]] == "Unknown Name" and len(s2) != 1:
                        sotrudniki2[s2[0]] = " ".join(s2[1:])
                s22 = s2[0]
                if s11 not in sotrudniki.keys():
                    sotrudniki[s11] = [s22]
                else:
                    sotrudniki[s11].append(s22)
            name = f.readline()
            if any(x not in "0123456789" for x in name):
                for i, j in sotrudniki2.items():
                    if j == name:
                        name = i

            lst = set()
            def find(name):
                if name not in sotrudniki.keys():
                    lst.add(name)
                    return
                for i in sotrudniki[name]:
                    lst.add(i)
                    find(i)


            find(name)

            lst1 = sorted(list(lst))
            if name in lst1:
                lst1.remove(name)
            lst1 = list(map(lambda x: x + " " + sotrudniki2[x], lst1))
            if len(lst1) == 0:
                lst1.append('NO')

            flag = True
            test = f2.readlines()
            for l in range(len(test)):
                test[l] = test[l].replace("\n", "")
            for i in range(len(test)):
                if lst1[i] != test[i]:
                    flag = False
                    break
            print(f"Test{k}: {flag}")


setrecursionlimit(20000)
threading.stack_size(2 ** 26)
thread = threading.Thread(target=main)
thread.start()
