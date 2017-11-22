from itertools import combinations
from multiprocessing import Pool

def getintpartlim(N, M, n):
	if n < 0:
		return
	if n==0:
		#yield [0]*M
		return
	if M==1:
		if n <= N:
			yield [n]
		return
	if N==1:
		if n <= M:
			yield [0]*(M-n) + [1]*n
		return
	yield from getintpartlim(N-1,M,n)
	for remainder in getintpartlim(N,M-1,n-N):
		yield remainder + [N]


def items_unique(x):
    return len(x) == len(set(x))

def is_special_sum_set(A):
    # TODO: Could be faster
    '''
    if not items_unique(A):
        print(A)
        print('a')
        return False
    '''
    n = len(A)

    for k in range(n):
        if not items_unique([sum(subset) for subset in combinations(A, k)]):
            #print('b')
            return False
    for k in range(1,(n+1)//2):
        if sum(A[0:k+1]) <= sum(A[-k:]):
            #print('a')
            return False
    return True

suboptimal = [20 + x for x in [0, 11, 18, 19, 20, 22, 25]]
print(is_special_sum_set(suboptimal))
print(sum(suboptimal))

minsum = sum(range(1,7+1))
maxsum = sum(suboptimal)

print(list(getintpartlim(10,3,10)))

zeroto6 = list(range(7))

def check2(candidate):

    if is_special_sum_set(candidate):
        print(candidate)

def check(setsum, start):
    currentSum = 7*start + 21
    adder = [start + x for x in zeroto6]
    return [[adder[i]+bonus[i] for i in range(7)] for bonus in getintpartlim(setsum - currentSum, 7, setsum - currentSum)]

poolA = Pool(16)
poolB = Pool(16)
for setsum in range(170, maxsum + 1,2):
    print("Checking ", setsum)
    start = 6
    arglistA = []
    while setsum >= 7*start + 21:
        '''
        currentSum = 7*start + 21
        adder = [start + x for x in zeroto6]
        for bonus in getintpartlim(setsum - currentSum, 7, setsum - currentSum):
            candidate = [adder[i]+bonus[i] for i in range(7)]
            if is_special_sum_set(candidate):
                print(candidate)
                break;
        '''
        arglistA.append((setsum, start))

        start += 1
    arglistB = []
    if len(arglistA) > 0:
        for c in poolA.starmap(check, arglistA):
            arglistB = arglistB + c
    poolB.imap_unordered(check2, arglistB)
#asdf
'''
0+1+2+3+4+5+6 = 21
start, start+1, ..., end

2*start + 1 > end
so
end = start + 6
2*start > start + 5
so:
start > 5

sum >= 7*start + 21



'''
