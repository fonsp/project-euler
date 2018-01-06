

'''
For every bit in xi, the chance of being 0 is (1/2)^i.
The chance of being 1 is 1 - (1/2)^i.
The chance of every bit being 1 is (1-(1/2)^i)^32.

The probability of N being the *first* correct value is:
P(N first correct) = P(N correct) * P(N-1 incorrect)

To compute:

\sum_{i=1}^{\infty} i * {(1-(1/2)^i)^32 * (1-(1-(1/2)^(i-1))^32)}
=
\sum_{i=1}^{\infty} i * {(1-(1/2)^i)^32 - (1-(1/2)^(i-1))^32}



'''
from itertools import count

cumulator = 0
oneovertwopowi = .5

lastThing = 0

for i in count(1):
    newThing = (1-oneovertwopowi)**32
    #cumulator += i * (newThing * (1-lastThing))
    cumulator += i * ((1-(1/2)**i)**32 * (1-(1-(1/2)**(i-1))**32))
    lastThing = newThing
    oneovertwopowi /= 2
    if i%100 == 0:
        print(cumulator)
