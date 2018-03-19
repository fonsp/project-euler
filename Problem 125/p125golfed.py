import itertools as t
d=lambda n:[n%10]+d(n//10)if n>0 else[]
calc=lambda N:sum(set().union(*(filter(lambda n:d(n)==d(n)[::-1],list(t.takewhile(lambda x:x<N,t.accumulate(i*i for i in t.count(z))))[1:])for z in range(1,N))))
print(calc(1000))
