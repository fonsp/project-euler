# PIEMELS IN JELMARS MOND

from sys import stdin

moleculeWeHave, amount = stdin.readline().split(' ')
amount = int(amount)
moleculeWeWant = stdin.readline()[:-1]

def isNumber(thing):
	charCode = ord(thing)
	return charCode <= 57 and charCode >= 48
	
def isLetter(thing):
	return not isNumber(thing)

def readAtoms(molecule, multiplier):
	atoms = {}
	letter = ''
	number = False 
	for char in molecule:
		if (isLetter(char)):
			letter = char
			number = False
			if (char not in atoms):
				atoms[letter] = 1
			else:
				atoms[letter] += 1
		else:
			if (not number):
				atoms[letter] -= 1
				number = char
			else:
				atoms[letter] -= int(number)
				number += char
			atoms[letter] += int(number)
			
	for key in atoms:
		atoms[key] = atoms[key] * multiplier
	return atoms

atomsAvailable = readAtoms(moleculeWeHave, amount)
atomsWeNeed = readAtoms(moleculeWeWant, 1)

nrs = []
nrFound = False
lowestNrFound = float('inf')
for key in atomsWeNeed:
	if (key not in atomsAvailable):
		nrFound = False
		break;
	else:
		nr = atomsAvailable[key] // atomsWeNeed[key]
		nrFound = True
		lowestNrFound = min(lowestNrFound, nr)
		
amountPossible = 0 if not nrFound else lowestNrFound
print(amountPossible)
