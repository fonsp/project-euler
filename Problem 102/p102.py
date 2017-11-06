

class Vec:
    def __init__(self, x, y):
        self.x = x
        self.y = y
    def __add__(self, other):
        return Vec(self.x+other.x, self.y+other.y)
    def __sub__(self, other):
        return Vec(self.x-other.x, self.y-other.y)
    def cross(a, b):
        return a.x*b.y - a.y*b.x
    def __str__(self):
        return "(" + str(self.x) + "," + str(self.y)+ ")"

class Triangle:
    def __init__(self, a, b, c):
        self.a = a
        self.b = b
        self.c = c
    def __str__(self):
        return "{" + str(self.a) + ", " + str(self.b) + ", " + str(self.c) + "}"
    __repr__ = __str__

coordlist = [[int(x) for x in line.split(',')] for line in open('p102_triangles.txt').read().split()]

triangles = [Triangle(Vec(l[0], l[1]), Vec(l[2], l[3]), Vec(l[4], l[5])) for l in coordlist]

zero = Vec(0,0)

def contains_zero(t):
    a,b,c = t.a,t.b,t.c
    return ((Vec.cross(b - a, zero - a) < 0) == \
        (Vec.cross(c - a, zero - a) > 0)) and \
        ((Vec.cross(c - b, zero - b) < 0) == \
        (Vec.cross(a - b, zero - b) > 0)) and \
        ((Vec.cross(a - c, zero - c) < 0) == \
        (Vec.cross(b - c, zero - c) > 0))


print(sum(1 if contains_zero(x) else 0 for x in triangles))
