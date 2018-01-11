from fractions import Fraction

'''
Probabilty of the sum of n sided-sided dice being k.
'''
def f(n,k,sides):
    if k < n or k > n*sides:
        return 0
    if n == 1:
        return 1/sides
    return sum(f(n-1,k-j,sides)*f(1,j,sides) for j in range(sides+1))

'''
Precompute f(6,colin,6)
'''
colinlist = [f(6,colin,6) for colin in range(9*4+1)]

'''
For each possible throw by peter, compute the probabilty of that throw, and multiply by the chance of winning
'''
print("{0:.7f}".format(sum(f(9,peter,4)*sum(colinlist[colin] for colin in range(6,peter)) for peter in range(9,9*4+1))))
