from math import *

def E(x, y):
    n = 0
    while y != 0:
        x, y = y, x % y
        n += 1
    return n

res = []

for N in range(1,400)[20:21]:
    values = [[E(x,y) for y in range(1,N+1)] for x in range(1,N+1)]
    res.append(max(max(row) for row in values))
    print('\n'.join([str(val) for val in values]))


print(res)
print([floor(sqrt(i)) for i in range(1,400)])
