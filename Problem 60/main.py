from sympy import prime
from sympy.ntheory import isprime
from sympy.utilities.iterables import subsets


def main(lim):
    found = False
    result = 1e99
    subs = [list(s) for s in subsets(range(lim),4)]
    for s in subs:
        s.append(lim)
        ps = [prime(x+2) for x in s]
        #print(ps)
        if test(ps):
            found = True
            result = min(result, sum(ps))
        #input()
    if found:
        print(result)
    return found


def test(subs):
    #print(subs)
    pairs = [list(p) for p in subsets(subs, 2)]
    #print(pairs)
    for pair in pairs:
        x = pair[0]
        y = pair[1]
        #print(x,y)
        if (not isprime(append_numbers(x,y))) or (not isprime(append_numbers(y,x))):
            return False
    return True


def append_numbers(a,b):
    c = b
    while c > 0:
        c = c // 10
        a = a * 10
    return a + b

lim = 4
while not main(lim):
    lim += 1

print(test([3,7,109,673]))
