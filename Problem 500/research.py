from itertools import count

def divisorsOf(n):
    return [1,n] + [i for i in range(2,n) if n%i==0]

def firstWithNDivisors(n):
    return next(i for i in count(1) if len(divisorsOf(i)) >= n)

for i in count():
    n = 2**i
    x = firstWithNDivisors(n)
    print(n, x, divisorsOf(x))



'''
For every bit in xi, the chance of being 0 is (1/2)^i.
The chance of being 1 is 1 - (1/2)^i.
The chance of every bit being 1 is (1-(1/2)^i)^32.

To compute:

\sum_{i=0}^{\infty} i * (1-(1/2)^i)^32

'''
