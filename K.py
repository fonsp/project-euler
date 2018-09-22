def findSummation(toReach, values):
	#print(values)
	firstValue = values[0]
	if len(values)==1:
		#print(toReach, ((toReach-1) // firstValue)+1)
		yield [max(0,((toReach-1) // firstValue)+1)]
		return
	for firstAmount in range(((toReach-1) // firstValue)+2):
		#print("x",toReach, values[1:])
		yield from ([firstAmount] + list(piemel) for piemel in findSummation(toReach - firstAmount*firstValue, values[1:]))



def dot(vec1,vec2):
	return sum(map(lambda x,y: x*y, vec1, vec2))

from sys import stdin

B = int(stdin.readline())
numCompanies = int(stdin.readline())


possiblePackages = set()

packSizesAdv = []
packSizesReal = []



for compI in range(numCompanies):
	line = (int(s) for s in stdin.readline()[:-1].split(" "))
	numPacks = next(line)
	packSizes = list(line)
	
	packSizesAdv.append(packSizes)
	if compI == 0:
		packSizesReal.append(packSizes)
	else:
		currentReal = []
		
		prevAdv = packSizesAdv[compI-1]
		prevReal = packSizesReal[compI-1]
		for packI in range(numPacks):
			possibleRecipes = findSummation(packSizes[packI], prevAdv)
			bestRecipes = []
			bestSum = float('inf')
			for recipe in possibleRecipes:
				advSum = dot(prevAdv, recipe)
				if advSum <= bestSum:
					if advSum != bestSum:
						bestRecipes = []
						bestSum = advSum
					bestRecipes.append(recipe)
			
			worstRealSum = min(dot(prevReal, r) for r in bestRecipes)
			currentReal.append(worstRealSum)
			if worstRealSum >= B:
				possiblePackages.add(packSizes[packI])
		packSizesReal.append(currentReal)


print("impossible" if len(possiblePackages)==0 else min(possiblePackages))
			






