'''
Brute force:

      /|\
   a /c| \ a
    /__|__\
       b


a = b \pm 1


area = b * c
(b/2)^2 + c^2 = a^2
so
2c = sqrt(4a^2 - b^2)
                      = sqrt(f(b)) or sqrt(g(b))
   for                     a=b+1        a=b-1
respectively.

Runtime: 8mins on my lappy

'''

from math import sqrt
square = lambda x: x*x

def isperf(x):
    if x < 0:
        return False
    return square(int(sqrt(x))) == x


def addition_of(b,twocsquaredfunc,perimiterfunc):
    twocsquared = twocsquaredfunc(b)
    if isperf(twocsquared):
        twoc = int(sqrt(twocsquared))
        if (b * twoc) % 2 == 0:
            perimiter = perimiterfunc(b)
            if 0 <= perimiter <= 1000000000:
                return perimiter
    return 0


f = lambda b: 3*b*b + 8*b + 4
g = lambda b: 3*b*b - 8*b + 4

fper = lambda b: b + 2*(b+1)
gper = lambda b: b + 2*(b-1)

# The rectangles 1-1-0 and 1-1-2 don't count. => -6
print(-2 + -4 + sum(addition_of(b, f, fper) + addition_of(b, g, gper) for b in range(333333333)))
