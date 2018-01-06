from fractions import Fraction

def isPrime(n):
    return [1] == [i for i in range(1,n) if n % i == 0]

primelist = [1 if isPrime(i) else -1 for i in range(501)]
frog = [1,1,1,1,-1,-1,1,1,1,-1,1,1,-1,1,-1]
getProb = lambda a,b: Fraction(1,2) + Fraction(a*b,6)

accumulator = [0] + [Fraction(1,500)]*500

for i in range(0,15):
    newaccumulator = [0]*501
    for n in range(1,501):
        current = getProb(frog[i],primelist[n])
        if i ==0:
            newaccumulator[n] = current * accumulator[n]
        elif n == 1:
            newaccumulator[n] = current * Fraction(1,2) * accumulator[2]
        elif n == 500:
            newaccumulator[n] = current * Fraction(1,2) * accumulator[499]
        elif n == 2:
            newaccumulator[n] = current * (accumulator[1] + Fraction(1,2) * accumulator[3])
        elif n == 499:
            newaccumulator[n] = current * (accumulator[500] + Fraction(1,2) * accumulator[498])
        else:
            newaccumulator[n] = current * Fraction(1,2) * (accumulator[n-1] + accumulator[n+1])
    accumulator = newaccumulator

print(sum(accumulator))
