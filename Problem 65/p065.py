from math import gcd

class Rational:
    def __init__(self, a, b):
        self.a = a
        self.b = b

    def __add__(self, other):
        return Rational(self.a*other.b + self.b*other.a, self.b*other.b)

    def __mul__(self, other):
        return Rational(self.a*other.a, self.b*other.b)

    def __truediv__(self, other):
        return Rational(self.a*other.b, self.b*other.a)

    def __str__(self):
        return str(self.a) + "/" + str(self.b)

    def reduce(self):
        g = gcd(self.a,self.b)
        self.a //= g
        self.b //= g

numiters = 100
r = Rational(0, 1)
one = Rational(1, 1)

for i in range(numiters-1,0,-1):
    x, y = divmod(i + 1, 3)
    k = 2*x if y == 0 else 1
    r = one / (Rational(k,1) + r)

r = one + one + r
r.reduce()
print(r)
print("Sum of digits:")
digits = []
numerator = r.a
while numerator > 0:
    x, y = divmod(numerator, 10)
    numerator = x
    digits.append(y)

print(sum(digits))

