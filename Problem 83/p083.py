from math import inf

matrix = [[int(x) for x in line.split(',')] for line in open('p083_matrix.txt').read().split()]
#print(matrix)

def getC(node):
    return matrix[node[0]][node[1]]

size = len(matrix)
start = (0,0)
goal = (size-1, size-1)

def neighbours(node):
    result = []
    if node[0] > 0:
        result.append((node[0]-1,node[1]))
    if node[0] < size - 1:
        result.append((node[0]+1,node[1]))
    if node[1] > 0:
        result.append((node[0],node[1]-1))
    if node[1] < size - 1:
        result.append((node[0],node[1]+1))
    return result

explored = set()
toExplore = set([start])
shortestDist = {start: matrix[0][0]}


while len(toExplore) > 0:
    currentNode = min(toExplore, key=shortestDist.get)
    toExplore.remove(currentNode)
    currentCost = shortestDist[currentNode]
    if currentNode == goal:
        print(currentCost)
        break
    for neighbour in neighbours(currentNode):
        newCost = currentCost + getC(neighbour)
        if newCost < shortestDist.get(neighbour, inf):
            shortestDist[neighbour] = newCost
            toExplore.add(neighbour)
