def H(n):
    counter = 0
    d = 1
    counter += Hstraight(n)
    for depth in range(1,n):
        for dist in range(1,n):
            manhattan = (depth + dist)
            #print(1,manhattan)
            counter += Hstraight((n//manhattan))
    return counter


def Hstraight(n):
    if n < 3:
        return 0
    counter = (n-2)*(n-1)//2
    d = 2
    while n // d >= 3:
        counter += (n//d-2)*(n//d-1)//2
        d+=1
    return counter


print(H(3))
print(H(6))
print(H(20))
