from math import gcd

greatestA = 0
greatestB = 1

for b in range(1,1000001):
	if b == 7:
		continue
	a = (3*b)//7
	if gcd(a,b)==1 and a*greatestB > b*greatestA:
		greatestA = a
		greatestB = b

print(greatestA, '/', greatestB)
print("Answer:")
print(greatestA)
