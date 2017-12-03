



def lastDigitsPandigital(n):
    occured = [True] + [False]*9
    for i in range(9):
        digit = n % 10
        if occured[digit]:
            return False
        occured[digit] = True
        n //= 10
    return True


def firstDigitsPandigital(n):
    while n >= 1000000000:
        n //= 10
    return lastDigitsPandigital(n)


def firstAndLastDigitsPandigital(nlast,n):
    if not lastDigitsPandigital(nlast):
        return False
    #print("Maybe")
    return firstDigitsPandigital(n)


i = 2
a, b = 1, 1
lastA, lastB = 1, 1

while not firstAndLastDigitsPandigital(lastB,b):
    a, b = b, a+b
    lastA, lastB = lastB, (lastA + lastB) % 1000000000
    i += 1

print(i)
