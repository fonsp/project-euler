# No real explanation for what happens here, I calculated the number of
# increasing and decreasing numbers below 10^n directly (which is too slow at
# n=100), and these sequences turned out to be quite simple.

# Runtime: 0.1s

import itertools

def numIncreasingBelowTenPow(n):
    if n==1:
        return [[i] for i in range(1,10)], 10
    return [],numIncreasingBelowTenPow(n-1)[1]*(9+n)//n ## determined experimentally idk why
    # This used to be the direct computation
    shorterSeqs, N = numIncreasingBelowTenPow(n-1)
    newSeqs = itertools.chain(*([[i]+seq for i in range(1,seq[0]+1)] for seq in shorterSeqs))
    newSeqs = list(newSeqs)
    return newSeqs, N+len(newSeqs)

def numDecreasingBelowTenPow(n):
    if n==1:
        return [[i] for i in range(0,10)], 10
    shorterSeqs, N = numDecreasingBelowTenPow(n-1)
    # Also determined experimentally: the difference sequence of this function
    # is exactly the sequence of the previous function.
    return [],N+ numIncreasingBelowTenPow(n)[1] - 1
    # This used to be the direct computation
    newSeqs = itertools.chain(*([[i]+seq for i in range(seq[0],10)] for seq in shorterSeqs))
    newSeqs = list(newSeqs)
    return newSeqs, N + len(newSeqs) - 1 # -1 to acount for 00000

def numConstantBelowTenPow(n):
    if n==1:
        return 10 # 0, 1, ..., 9
    return 9 + numConstantBelowTenPow(n-1) # 111..1, ..., 9..9


def calcTenPow(n):
    _,inc = numIncreasingBelowTenPow(n)
    _,dec = numDecreasingBelowTenPow(n)
    con = numConstantBelowTenPow(n)
    return inc + dec - con - 1 # not sure why -1 is needed

print(calcTenPow(100))


# Num increasing:
# 10,55,220,715,2002,5005,11440,24310,48620,92378,167960,293930,497420,817190,1307504,2042975,3124550,4686825,6906900

# Num decreasing:
# 10,64,283,997,2998,8002,19441,43750,92369,184746,352705,646634,1144053,1961242,3268745
