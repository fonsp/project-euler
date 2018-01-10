from math import sqrt, ceil
from itertools import takewhile

def isPrime(n):
    if n < 2:
        return False
    if n < 4:
        return True
    if (n & 1) == 0:
        return False
    if n % 3 == 0:
        return False
    sqrtN = ceil(sqrt(n))
    i = 5
    additionalAdder = 0
    while i <= sqrtN:
        if n %i == 0:
            return False
        i += 2 + additionalAdder
        additionalAdder = 2 - additionalAdder
    return True


def Malt(p,q,N):
    best = 0
    ppowi = p
    while True:
        j = 1
        ppowiqpowj = ppowi*q
        while ppowiqpowj <= N:
            j += 1
            ppowiqpowj *= q
        if j == 1:
            return best // q
        best = max(best, ppowiqpowj)
        ppowi *= p
    return best // q


def M(p,q,N):
    best = 0
    i = 1
    ppowi = p
    j = 1
    ppowiqpowj = p*q
    if ppowiqpowj > N:
        return 0
    new = ppowiqpowj * q
    while new <= N:
        j += 1
        ppowiqpowj = new
        new = ppowiqpowj*q
    while j > 0:
        #print(i, j, ppowiqpowj)
        best = max(best,ppowiqpowj)
        i += 1
        ppowiqpowj *= p
        while ppowiqpowj > N:
            j -= 1
            ppowiqpowj //= q
    return best

def S(Nmax):
    result = 0
    primesBelowNmax = [i for i in range(Nmax//2) if isPrime(i)]
    for i,p in enumerate(primesBelowNmax):
        maxQ = Nmax // p
        for q in takewhile(lambda x: x <= maxQ, primesBelowNmax[i+1:]):
            result += M(p,q,Nmax)
    return result


print(M(2,3,100))
print(M(3,5,100))
print(M(2,73,100))
print(S(10000000))
