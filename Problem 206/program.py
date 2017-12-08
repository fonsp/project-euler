from math import *
from itertools import *

# If x^2 ends with a '0', then x must end with '0'. Thus, I am ignoring the
# requirement for the last 0, and I will multiply the result by 10.

goodDigits = list(range(1,10))

def valid(x):
    for i in range(9):
        if (x % 10) != goodDigits[-1-i]:
            return False
        x = x // 100
    return True

# Since every digit is in the range 0..9, x must lie in the range:
print(next(10*x for x in range(floor(sqrt(10203040506070809)),1+ceil(sqrt(19293949596979899))) if valid(x*x)))
