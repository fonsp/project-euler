'''
If we have f'(x) = x^2 and f(0)=0
then f(x)=1/3 x^3 ~= (0^2 +) 1^2 + ... + n^2

f^{-1}(10^8) ~= 670

So a sequence of consecutive squares with a sum below 10^8 has at most
670 elements.
Thus, there are at most 670^2~=500,000 sequences. We can try them all.

Runtime: 1s

'''

# I find this sexy:
from itertools import accumulate, count, takewhile

def digits_of(n):
    while n != 0:
        yield n % 10
        n //= 10


def is_palindromic(n):
    digits = list(digits_of(n))
    return digits == digits[::-1]


def palindromic_sums_of_sequences_from(start, max_sum):
    # All sums of sequences below max_sum:
    candidates = takewhile(lambda x: x<max_sum, accumulate(i*i for i in count(start)))
    # We have to skip 1-element sequences:
    next(candidates)
    return filter(is_palindromic, candidates)


def calc(N):
    # For each starting index, the 'list' of valid sequence sums
    list_of_lists = (palindromic_sums_of_sequences_from(start,N) for start in range(1,int(N**.5/2)))
    # Explode list and remove duplicates
    unique_sols = set().union(*list_of_lists)
    return sum(unique_sols)


print(calc(1e8))
