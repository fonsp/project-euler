from itertools import count


# test 1/(n+1) through 1/(2*n)

# 1/x + 1/y = 1/n
# So: 1/y = (x - n) / (xn)
# (x-n) must be a divisor of xn

distinct = lambda n: sum(1 if (x*n) % (x-n) == 0 else 0 for x in range(n+1, n*2 + 1))

print(next(n for n in count() if distinct(n) > 1000))
