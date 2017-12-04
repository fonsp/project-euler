def customMin(A, key):
    best

inputlines = open("p107_network.txt").read().split()

inf = float('inf')

weightmat = [[inf if c=='-' else int(c) for c in line.split(',')] for line in inputlines]
N = len(weightmat)

oldWeight = sum(sum(0 if x == inf else x for x in row) for row in weightmat)//2
print(oldWeight)


newWeight = 0
inTree = set([0])
queue = set(range(1,N))

while len(queue) > 0:
    toAdd = min(queue, key=lambda n: min(weightmat[n][i] for i in inTree))
    newWeight += min(weightmat[toAdd][i] for i in inTree)
    queue.remove(toAdd)
    inTree.add(toAdd)

print(newWeight)
print(oldWeight - newWeight)
