# INTERNET EXPLORERS
# YOOOOOOO
# GEIL

from sys import stdin

Tg, Ty, Tr = [int(s) for s in stdin.readline().split(" ")]
n = int(stdin.readline())

TS = Tg+Ty+Tr
Tgy = Tg + Ty
Tgyr = TS

Tmin = 0
Tmax = TS-1 # -1 of niet?

gMin = TS
gMax = 0
yMin = TS
yMax = 0
rMin = TS
rMax = 0


for i in range(n):
	lineSplit = stdin.readline().split(" ")
	t, c = int(lineSplit[0]), lineSplit[1]
	t -= TS * (t // TS)
	if c[0]=='g':
		gMin = min(gMin, t)
		gMax = max(gMax, t)
	elif c[0]=='y':
		yMin = min(yMin, t)
		yMax = max(yMax, t)
	elif c[0]=='r':
		rMin = min(rMin, t)
		rMax = max(rMax, t)

gRange = gMax - gMin
yRange = yMax - yMin
rRange = rMax - rMin

print(gMin,gMax)
print(yMin,yMax)
print(rMin,rMax)
print()

if gRange >= 0:
	Tmin = max(Tmin, gMax-Tg-1)
	Tmax = min(Tmax, gMin)
if yRange >= 0:
	Tmin = max(Tmin, yMax-Tgy-1)
	Tmax = min(Tmax, yMin)
if rRange >= 0:
	Tmin = max(Tmin, rMax-Tgyr-1)
	Tmax = min(Tmax, rMin)



lineSplit = stdin.readline().split(" ")
tq, cq = int(lineSplit[0]), lineSplit[1]
tq = tq % TS
#LUL

# ondergrens, bovengrens voor T:
print(Tmin,Tmax)



Twidth = Tmax - Tmin + 1


Tthis = 0


if cq[0] == 'g':
	Tthis = Tg
elif cq[0] == 'y':
	Tthis = Ty
	tq -= Tg
elif cq[0] == 'r':
	Tthis = Tr
	tq -= Tgy

tq = tq % TS

yesWidth = Twidth - max(0,tq - Tthis) - max(0,Twidth - tq)
yesWidth = max(0,yesWidth)

#print(yesWidth, Twidth)






"""

yes, no = [], []
for offset in range(Tmin, Tmax+1, 1):
	bounds = []
	if (cq[0] == 'g'):
		bounds = range(0 + offset, Tg + offset)
	elif (cq[0] == 'y'):
		bounds = range(Tg + offset, Tg + Ty + offset)
	elif (cq[0] == 'r'):
		bounds = range(Tg + Ty + offset, Tg + Ty + Tr + offset)
	bounds = [i % TS for i in bounds]
	print(list(bounds))
	print(tq)
	if (tq in bounds):
		yes.append(1)
	else:
		no.append(1)
print('p', len(yes)/(len(yes) + len(no)))




"""
