from itertools import count

'''
summed = [False]*100000001
numberSummed = 0
sum = 0
'''

def lowestMWithDivisorNpowP(n,p):
    if p<=0:
        return 0
    index = 0
    blockLength = 1
    blockCount = 1
    while p >= blockCount:
        numberOfContainedBlocks = p // blockCount
        #print(p, blockCount, numberOfContainedBlocks)
        if numberOfContainedBlocks >= n:
            blockLength *= n
            blockCount = n*blockCount + 1
        if numberOfContainedBlocks == n:
            numberOfContainedBlocks = 1
        if numberOfContainedBlocks <= n:
            #print(1,blockCount)
            return n*numberOfContainedBlocks * blockLength + lowestMWithDivisorNpowP(n,p-numberOfContainedBlocks*blockCount)

def s(n):
    maxM = 0
    divisor = 2
    p = 0
    while n > 1:
        if n % divisor == 0:
            p += 1
            n //= divisor
        else:
            if p>0:
                maxM = max(maxM, lowestMWithDivisorNpowP(divisor, p))
                p = 0
            divisor += 1
    maxM = max(maxM, lowestMWithDivisorNpowP(divisor, p))
    return maxM

#S = lambda n: sum(s(i) for i in range(2,n+1))
def S(n):
    result = 0
    for i in range(2,n+1):
        if i%10000 == 0:
            print(i/1000000)
        result += s(i)
    return result

print(S(100000000))
