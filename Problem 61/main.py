'''
Idea:

For each permutation of the six types, create an adjacency matrix A for
the directed graph where nodes are 4 digits numbers, and nodes x and y
are connected x->y iff type(y) = (type(x) + 1) mod 6 and the first two
digits of y equal the last two of x.

Find a complete cycle by searching for a trivial unit vector e such that
e * A^6 = e. These are exactly the indices of any non-zero terms of the
diagonal of A^6.
'''

import sys
import numpy as np
from itertools import permutations, takewhile, chain
from collections import namedtuple

numberGenerators = [
    lambda n: n*(n+1)//2,
    lambda n: n**2,
    lambda n: n*(3*n-1)//2,
    lambda n: n*(2*n-1),
    lambda n: n*(5*n-3)//2,
    lambda n: n*(3*n-2)
]

N = len(numberGenerators)

numbersPerType = []

for f in numberGenerators:
    start = next(n for n in range(1000) if f(n) > 999)
    numbersPerType.append(list(takewhile(lambda x: x < 10000, (f(n) for n in range(start, 10000)))))

allNumbers = list(chain(*numbersPerType))

def isOfType(index):
    t = 0
    while index >= 0:
        index -= len(numbersPerType[t])
        t += 1
    return t - 1

totalCount = sum(len(l) for l in numbersPerType)

# Check whether y follows x
follows = lambda y, x: y//100 == x % 100

for typeOrderEnding in list(permutations(range(1,N))):
    Arows = []
    typeOrder = [0] + list(typeOrderEnding)
    for i,x in enumerate(allNumbers):
        # Type of the current node
        currentType = isOfType(i)
        # ... its position in the current ordering
        currentTypeI = next(typeI for typeI in range(N) if typeOrder[typeI]==currentType)
        nextType = typeOrder[(currentTypeI + 1) % N]
        # Create a row with zeros and ones for each node
        # 1 iff the column node's type follows the row's node's type and
        # the first and last digits match.
        # Precomputing the 'follows' matrix does not increase performance.
        Arows.append([1 if isOfType(j)==nextType and follows(y,x) else 0 for j,y in enumerate(allNumbers)])
    # Create the adjacency matrix and compute all N-cycles
    A = np.array(Arows)
    AN = np.linalg.matrix_power(A, N)
    # If an N-cycle exists, A^N will have exactly N zeros along its diagonal,
    # representing the N nodes in the cycle
    row = np.diag(AN)
    if np.any(row):
        #print([z for i,z in enumerate(allNumbers) if row[i] != 0])
        print(sum(z for i,z in enumerate(allNumbers) if row[i] != 0))
        sys.exit()
