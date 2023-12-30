def g():
    for i in range(1, 21):
        f = open(f"C:\\Работы\\Алгоритмизация и программирование\\Паук и муха\\input_s1_{i:02}.txt")
        a, b, c = map(int, f.readline().split())
        sx, sy, sz = map(int, f.readline().split())
        fx, fy, fz = map(int, f.readline().split())

        def rast(x1, y1, x2, y2):
            return ((x1 - x2) ** 2 + (y1 - y2) ** 2) ** 0.5
        ans = 0
        if (sx == fx == 0 or sy == fy == 0 or fz == sz == 0 or sx == fx == a or sy == fy == b or fz == sz == c):
            if sy == fy == 0 or sy == fy == b:
                ans = rast(sx, sz, fx, fz)
            elif sx == fx == 0 or sx == fx == a:
                ans = rast(sy, sz, fy, fz)
            elif sz == fz == 0 or sz == fz == c:
                ans = rast(sx, sy, fx, fy)
        elif (abs(sx - fx) == a or abs(sy - fy) == b or abs(sz - fz) == c):
            mas1 = []
            mas1.append(rast(-sy, sz, a + fy, fz))
            mas1.append(rast(sy, sz, a + 2 * b - fy, fz))
            mas1.append(rast(-sz, sy, a + fz, fy))
            mas1.append(rast(sz, sy, a + 2 * c - fz, fy))
            if abs(sz - fz) == c:
                a, c = c, a
                sx, sz = sz, sx
                fx, fz = fz, fx
            mas1.append(rast(-sy, sz, a + fy, fz))
            mas1.append(rast(sy, sz, a + 2 * b - fy, fz))
            mas1.append(rast(-sz, sy, a + fz, fy))
            mas1.append(rast(sz, sy, a + 2 * c - fz, fy))
            c, a = a, c
            sz, sx = sx, sz
            fz, fx = fx, fz
            if abs(sy - fy) == b:
                a, b = b, a
                sx, sy = sy, sx
                fx, fy = fy, fx
            mas1.append(rast(-sy, sz, a + fy, fz))
            mas1.append(rast(sy, sz, a + 2 * b - fy, fz))
            mas1.append(rast(-sz, sy, a + fz, fy))
            mas1.append(rast(sz, sy, a + 2 * c - fz, fy))
            ans = min(mas1)
        else:
            if (sx == 0 and fz == c) or (sx == c and fz == 0):
                if sx == c and fz == 0:
                    fx, fy, fz, sx, sy, sz = sx, sy, sz, fx, fy, fz
                ans = rast(sz, sy, c + fx, fy)
            elif (sx == 0 and fy == b) or (sy == b and fx == 0):
                if sy == b and fx == 0:
                    fx, fy, fz, sx, sy, sz = sx, sy, sz, fx, fy, fz
                ans = rast(-sy, sz, -b-fx, fz)
            elif (sx == 0 and fz == 0) or (fx == 0 and sz == 0):
                if fx == 0 and sz == 0:
                    fx, fy, fz, sx, sy, sz = sx, sy, sz, fx, fy, fz
                ans = rast(-sz, sy, fx, fy)
            elif (sx == 0 and fy == 0) or (fx == 0 and sy == 0):
                if fx == 0 and sy == 0:
                    fx, fy, fz, sx, sy, sz = sx, sy, sz, fx, fy, fz
                ans = rast(-sy, sz, fx, fz)

            elif (sz == 0 and fy == 0) or (fz == 0 and sy == 0):
                if fz == 0 and sy == 0:
                    fx, fy, fz, sx, sy, sz = sx, sy, sz, fx, fy, fz
                ans = rast(sx, sy, fx, -fz)
            elif (sz == 0 and fx == a) or (sx == a and fz == 0):
                if sx == a and fz == 0:
                    fx, fy, fz, sx, sy, sz = sx, sy, sz, fx, fy, fz
                ans = rast(sx, sy, a+fz, fy)
            elif (sz == 0 and fy == b) or (fz == 0 and sy == b):
                if fz == 0 and sy == b:
                    fx, fy, fz, sx, sy, sz = sx, sy, sz, fx, fy, fz
                ans = rast(sx, sy, fx, b+fz)

            elif (sy == 0 and fz == c) or (fy == 0 and sz == c):
                if fy == 0 and sz == c:
                    fx, fy, fz, sx, sy, sz = sx, sy, sz, fx, fy, fz
                ans = rast(sx, sz, fx, c + fy)
            elif (sy == 0 and fx == a) or (fy == 0 and sx == a):
                if fy == 0 and sx == a:
                    fx, fy, fz, sx, sy, sz = sx, sy, sz, fx, fy, fz
                ans = rast(sx, sz, a+fy, fz)

            elif (sz == c and fy == b) or (fz == c and sy == b):
                if fz == c and sy == b:
                    fx, fy, fz, sx, sy, sz = sx, sy, sz, fx, fy, fz
                ans = rast(sx, c+sy, fx, fz)
            elif (sz == c and fx == a) or (fz == c and sx == a):
                if fz == c and sx == a:
                    fx, fy, fz, sx, sy, sz = sx, sy, sz, fx, fy, fz
                ans = rast(sx, sy, a+c-fz, fy)

            elif (sy == b and fx == a) or (fy == b and sx == a):
                if fy == b and sx == a:
                    fx, fy, fz, sx, sy, sz = sx, sy, sz, fx, fy, fz
                ans = rast(sx, sz, a+b-fy, fz)

        f = open(f"C:\\Работы\\Алгоритмизация и программирование\\Паук и муха\\output_s1_{i:02}.txt")
        print(f"Test {i}")
        print(f"Наш ответ:        {round(ans, 3)}")
        print(f"Правильный ответ: {f.readline()}")
        print("-------------------------------------------")
g()
