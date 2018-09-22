from sys import stdin
from fractions import Fraction


# line format:

# ((startx, starty), (endx, endy))


def lineDirection(line):
	if line[0][0] > line[1][0]:
		return 'u'
	dy = line[1][1] - line[0][1]
	if dy > 0:
		return 'r'
	elif dy < 0:
		return 'l'
	else:
		return 'h'

def willIntersectLine(x, line):
	return x >= line[0][0] and x <= line[1][0]

def calcIntersectionHeight(x, line):
	return Fraction(line[0][1],1) + Fraction(x - line[0][0], line[1][0]-line[0][0])*Fraction(line[1][1]-line[0][1],1)



def willPushShip(x,y,lines,ignoreIndex):
	if y >= 0:
		return False
	lowestIntersectionHeight = float('inf')
	lowestLine = "piemel"
	lowestLineIndex = -1
	lowestLineFound = False
	
	
	for lineIndex,l in enumerate(lines):
		if willIntersectLine(x,l) and lineIndex not in ignoreIndex:
			height = calcIntersectionHeight(x,l)
			if height < lowestIntersectionHeight:
				lowestIntersectionHeight = height
				lowestLine = l
				lowestLineIndex = lineIndex
				lowestLineFound = True
	if not lowestLineFound:
		return False
	
	if lowestIntersectionHeight >= 0:
		return 0
	lineDir = lineDirection(lowestLine)
	if lineDir == 'h':
		return True
	if lineDir == 'l':
		cand = lines[lowestLineIndex-1]
		
		if cand[0][0] < cand[1][0]:
			if cand[0][1] <= cand[1][1]:
				# stuk
				return True
			else:
				#volgen
				return willPushShip(cand[1][0],cand[1][1],lines, [lowestLineIndex])
		else:
			if cand[0][1] >= cand[1][1]:
				#rec
				return willPushShip(cand[1][0],cand[1][1],lines, [lowestLineIndex, (lowestLineIndex-1) % len(lines)])
			else:
				if Fraction(lowestLine[1][0]-lowestLine[0][0],lowestLine[1][1]-lowestLine[0][1]) > Fraction(cand[1][0]-cand[0][0],cand[1][1]-cand[0][1]):
					#stuk
					return True
				else:
					return willPushShip(cand[1][0],cand[1][1],lines, [lowestLineIndex, (lowestLineIndex-1) % len(lines)])
	if lineDir == 'r':
		cand = lines[lowestLineIndex+1]
		
		if cand[0][0] < cand[1][0]:
			if cand[0][1] >= cand[1][1]:
				# stuk
				return True
			else:
				#volgen
				return willPushShip(cand[0][0],cand[0][1],lines, [lowestLineIndex])
		else:
			if cand[0][1] <= cand[1][1]:
				#rec
				return willPushShip(cand[1][0],cand[1][1],lines, [lowestLineIndex, (lowestLineIndex+1) % len(lines)])
			else:
				if Fraction(lowestLine[1][0]-lowestLine[0][0],lowestLine[1][1]-lowestLine[0][1]) < Fraction(cand[1][0]-cand[0][0],cand[1][1]-cand[0][1]):
					#stuk
					return True
				else:
					return willPushShip(cand[1][0],cand[1][1],lines, [lowestLineIndex, (lowestLineIndex+1) % len(lines)])
					
	return False
	



"""
line = ((1,1),(3,3))

for x in [0, 1, 2, 3, 4]:
	print(willIntersectLine(x,line))
	print(calcIntersectionHeight(x,line))

"""


n,b = [int(s) for s in stdin.readline().split(" ")]

vertices = []
lines = []


xbounds = [100000,-100000]

for i in range(n):
	newCoord = tuple(int(s) for s in stdin.readline().split(" "))
	vertices.append(newCoord)
	xbounds[0] = min(newCoord[0],xbounds[0])
	xbounds[1] = max(newCoord[1],xbounds[1])
	
for i in range(n):
	lines.append((vertices[i-1],vertices[i]))

balls = (int(s) for s in stdin.readline().split(" "))
balls = filter(lambda x: xbounds[0] <= x <= xbounds[1], balls)

#balls = filter(lambda x: not willPushShip(x, -100001, lines, []), balls)

print(sum(1 for kutje in balls if willPushShip(kutje, -100001, lines, [])))
