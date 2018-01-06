from scipy.optimize import minimize
import numpy as np

L = 100/np.sqrt(2)
P = (L - 50)/2


def dist(x1,y1,x2,y2):
    return np.sqrt((x1-x2)**2 + (y1-y2)**2)

def time(x):
    result = dist(0,0,x[0],P)/10
    result += dist(x[5],0,L,P)/10
    for i in range(5):
        result += dist(x[i],0,x[i+1],10)/(9-i)
    return result

x0 = [P+ (10/np.sqrt(2))*i for i in range(6)]
res = minimize(time, x0, tol=1e-20)
print("{0:.10f}".format(res.fun))
