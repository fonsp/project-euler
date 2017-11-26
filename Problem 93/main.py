
from fractions import Fraction as Frac
from itertools import combinations, chain, count

# All integer partitions of n, with each part value <= N, and M (possibly with
# value 0) parts
def getintpartlim(N, M, n):
	if n < 0:
		return
	if n==0:
		yield [0]*M
		return
	if M==1:
		if n <= N:
			yield [n]
		return
	if N==1:
		if n <= M:
			yield [0]*(M-n) + [1]*n
		return
	yield from getintpartlim(N-1,M,n)
	for remainder in getintpartlim(N,M-1,n-N):
		yield remainder + [N]


commutativeOps = [
    lambda a, b: a+b,
    lambda a, b: a*b,
]
nonCommutativeOps = [
    lambda a, b: a-b,
]

allOps = commutativeOps + nonCommutativeOps
for op in nonCommutativeOps:
    allOps.append(lambda a, b: op(b, a))


# Since Fraction has no 'NaN' value:
def safeDivision(a,b):
    if b.numerator == 0:
        return (False, 0)
    return (True, a/b)

crazyOps = [safeDivision,
    lambda a, b: safeDivision(b, a)
]


# Recursive function that applies every operator to each pair of its terms
def getTargets(terms):
    if len(terms) == 1:
        if terms[0].denominator == 1 and terms[0].numerator > 0:
            yield terms[0].numerator
    else:
        for pair in combinations(range(len(terms)), 2):
            others = [x for i,x in enumerate(terms) if i not in pair]
            a = terms[pair[0]]
            b = terms[pair[1]]
            for op in allOps:
                yield from getTargets([op(a,b)] + others)
            for op in crazyOps:
                allowed, res = op(a, b)
                if allowed:
                    yield from getTargets([res] + others)

def countQ(quadruplet):
    targets = set(getTargets([Frac(x) for x in quadruplet]))
    # Highest n so that 1..n are in the set
    return next(n for n in count() if n+1 not in targets)

bestQuad = []
best = 0

# Create a quad by adding [1,2,3,4] to each increasing integer partition with
# its sum smaller than or equal to (6+7+8+9) - (1+2+3+4)
for digitSum in range(21):
    for basis in getintpartlim(5,4,digitSum):
        quad = [x + i + 1 for i,x in enumerate(basis)]
        current = countQ(quad)
        if current > best:
            best = current
            bestQuad = quad

print(''.join([str(d) for d in bestQuad]))
