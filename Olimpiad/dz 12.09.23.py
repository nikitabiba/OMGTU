st = input('Введите "1", если хотите использовать цикл\nВведите "2" если хотите использовать формулу\n')
mas = [1, 2, 3, 20]   # массив со значениями количества грядок для проверки
if st == '1':
    for i in mas:
        s = 0   # путь
        for i in range(1, i + 1):
            s += 24 + 20 * i   # увеличение пути на каждом колодце с учётом длины, ширины грядки и расстояния между колодцем и первой грядкой
        print('Количество грядок:', str(i) + '; Путь:', s)
else:
    for i in mas:
        s = 24 * i + (i**2 + i) * 10   # путь по формуле с учётом длины, ширины грядки и расстояния между колодцем и первой грядкой
        print('Количество грядок:', str(i) + '; Путь:', s)