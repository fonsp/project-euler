from itertools import count
#from collections import set
import math

square = lambda n: n*n

squareCache = []
squareCacheSet = set()

def squareOf(n):
    while len(squareCache) < n:
        newSquare = square(len(squareCache)+1)
        squareCache.append(newSquare)
        squareCacheSet.add(newSquare)
    return squareCache[n-1]

def isSquare(n):
    while len(squareCache) == 0 or squareCache[-1] < n:
        derp = squareOf(len(squareCache)+1)
    return n in squareCacheSet

def isSquare2(n):
    return n == square(round(math.sqrt(n)))

def minimalSolution(D):
    print(D)
    if isSquare(D):
        return -1
    for x in count(1):
        Dy2 = squareOf(x)-1
        if Dy2 % D == 0:
            y2 = Dy2 // D
            if isSquare(y2):
                return x

def minimalSolution2(D,start,end):
    print(D)
    if isSquare(D):
        return -1
    for y in range(start,end):
        x2 = D*square(y)+1
        if isSquare(x2):
            return round(math.sqrt(x2))
    print("Derp")
    return -2

def minimalSolution3(D,start,end):
    print(D)
    if isSquare2(D):
        return -1
    for y in range(start,end):
        x2 = D*square(y)+1
        if isSquare2(x2):
            return round(math.sqrt(x2))
    print("Derp")
    return -2

def minimalSolution4(D,start,end):
    print(D)
    if isSquare2(D):
        return -1
    for y in range(start,end):
        y2 = square(y)
        n = y2 -1
        x2 = D+1 + D*n
        if isSquare2(x2):
            return round(math.sqrt(x2))
    print("Derp")
    return -2


for D in range(1,2):
    print(minimalSolution(D), minimalSolution3(D,1,100000000))

candidates = list(range(1,1000+1))

yStart = 1
yEnd = 100001

bestD = -1
bestX = 0

while len(candidates)>1:
    print(yStart)
    newCandidates = set()
    for candidate in candidates:
        x = minimalSolution4(candidate,yStart,yEnd)
        if x == -2:
            newCandidates.add(candidate)
        elif x > bestX:
            bestX = x
            bestD = candidate
    candidate = newCandidates
    yStart, yEnd = yEnd, yEnd + 100000
