kin = uint32(0)
xin = uint32(0)
nin = uint32(0)

cache=ones(1,1,'uint32')

function y = getNP(kin, nin,cache)
  if kin==0 && nin == 0
    y = 1;
    return
  end
  if kin < 1 || kin > nin
    y = 0;
    return
  end
  if kin == 1 || kin == nin
    y = 1;
    return
  end
    y = cache(1,uint32(1+(kin-2)+(nin-2)*(nin-3)/2));    
end

function setNP(kin, nin, xin, cache)
  %1+(kin-2)+(nin-2)(nin-3)/2
  cache(1,uint32(1+(kin-2)+(nin-2)*(nin-3)/2)) = xin;
end

n = 3

sums = zeros(1,1)

for z=1:10000
  sum = 2;
  for k = 2:(n-1)
    p = getNP(uint32(k),uint32(n-k),cache)+getNP(uint32(k-1),uint32(n-1),cache);
    cache(1,uint32(1+(k-2)+(n-2)*(n-3)/2)) = p;
    sum = sum + p;
  end
  sums(1,n) = mod(sum,1000000);
  n = n+1
end