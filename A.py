from sys import stdin

h,w = [int(s) for s in stdin.readline().split(" ")]

weightsum = 0
nBlocks = 0


for y in range(h):
    line = stdin.readline()[:-1]
    
    additions = (i for i,c in enumerate(line) if c!='.')
    #print(additions)
    if y==h-1:
        additions = list(additions)
        leftbound = min(additions)
        rightbound = max(additions)
    for b in additions:
        weightsum += b
        nBlocks += 1

if weightsum*2 < (leftbound*2-1) * nBlocks:
    print("left")
elif weightsum*2 > (rightbound*2+1) * nBlocks:
    print("right")
else:
    print("balanced")