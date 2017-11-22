from sympy.ntheory import isprime

def appendNumbers(a,b):
    c = b
    while c > 0:
        c = c // 10
        a = a * 10
    return a + b

def goodPair(a,b):
    if not isprime(appendNumbers(a,b)):
        return False
    return isprime(appendNumbers(b,a))


def getCompleteN(nodes, edges, N):
    if N == 1:
        if len(nodes) != 0:
            return True, nodes[0:1]
        return False, []
    for i in range(len(nodes)):
        candidateSet = [node for node in edges[nodes[i]] if node in nodes]
        holds, subset = getCompleteN(candidateSet, edges, N-1)
        if holds:
            return True, [nodes[i]] + subset
    return False, []


N = 5
primesSoFar = [2]
edgeDic = {2: []}
lim = 3
upperLim = float('inf')

bestSum = float('inf')
bestSet = []

print("Solutions:")

while lim < upperLim:
    if isprime(lim):
        neighbours = []
        for prime in primesSoFar:
            if goodPair(lim, prime):
                neighbours.append(prime)
        holds, subset = getCompleteN(neighbours, edgeDic, N-1)
        if holds:
            subset.append(lim)
            print(sum(subset), subset)
            if sum(subset) < bestSum:
                bestSum = sum(subset)
                bestSet = subset
                # Since a complete 4-graph has sum at least 792:
                upperLim = bestSum - 792

        for goodprime in neighbours:
            edgeDic[goodprime].append(lim)
        edgeDic[lim] = neighbours
        #edgeDic[lim] = []
        primesSoFar.append(lim)
    lim += 2
    #print(lim, edgeDic)

print()
print("Best solution:")
print(bestSet)
print(bestSum)
