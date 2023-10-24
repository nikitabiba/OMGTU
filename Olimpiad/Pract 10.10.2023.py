n = int(input())
count = 0
count += n
for i in range(2, 10**1000):
    if 2**i - 1 > n:
        break
    count += int(n / (2**i - 1))
print(count)