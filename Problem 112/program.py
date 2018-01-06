from itertools import count

def isBouncy(n):
    isIncreasing = True
    isDecreasing = True
    last = n % 10
    n //= 10
    while n>0:
        new = n % 10
        if isIncreasing and new > last:
            isIncreasing = False
        if isDecreasing and new < last:
            isDecreasing = False
        last = new
        n //= 10
    return not (isIncreasing or isDecreasing)

def firstAtRatio(ratio):
    counter = 0
    for i in count(1):
        if isBouncy(i):
            counter += 1
        if (100*counter)//i >= ratio:
            return i

print(firstAtRatio(99))
