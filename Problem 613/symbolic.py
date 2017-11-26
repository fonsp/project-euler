# The triangle is placed as:
'''
y
|
|
40
|\
| \
|  \
|   \
|    \
0----30------- x

and named:

C


A  B
'''

from sympy import *
from mpmath import *

# To get an answer accurate to 10 digits after the decimal point:
mp.dps = 10

# For any point (x,y), the angle CAB
angle = lambda x,y: pi/2 + atan((x/(40-y)+y/(30-x))/(1-x*y/(40-y)/(30-x)))

# To get the probability, simply integrate angle(x,y)/2pi over the triangle,
# and divide by the total area.
triangleArea = 30*40/2

# Integration is done in two steps.
row = lambda y: quad(lambda x: angle(x,y)/2/pi/triangleArea, [0, 30*(1-y/40)])
triangle = quad(lambda y: row(y), [0, 40])

print(triangle)

# Well that was easy..
