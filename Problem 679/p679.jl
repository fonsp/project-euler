
const S = ["A","E","F","R"]
const keywords = ["FREE", "FARE", "AREA", "REEF"]

# %%

function is_valid(state::String)::Bool
	counts::Array{Bool} = [false, false, false, false]
	indexers::Array{Int} = [1, 1, 1, 1]
	for c in state
		if c == 'x'
			indexers[:] = [1, 1, 1, 1]
		else
			for (i, kw) in enumerate(keywords)
				reset = false
				if c == kw[indexers[i]]
					indexers[i] += 1
				else
					indexers[i] = 1
					reset = true
				end
				if indexers[i] == 5
					if counts[i]
						return false
					end
					counts[i] = true
					indexers[i] = 1
					reset = true
				end
				if reset && c == kw[1]
					indexers[i] = 2
				end
			end
		end
	end
	return all(counts)
end

function how_many_fillings(state::String)::Int64
	if !is_valid(state)
		return 0
	end
	ind::Int = -1
	for (i, c) in enumerate(state)
		if c == 'x'
			ind = i
		end
	end
	if ind == -1
		return 1
	end

	total::Int64 = 0
	for cstring in S
		new_state::String = state[1:ind-1] * cstring * state[ind+1:end]
		total += how_many_fillings(new_state)
	end
	return total
end


function keyword_fits(state::String, keyword::String, position::Int64)::Bool
	for (i, c) in enumerate(keyword)
		current = state[position + i - 1]
		if !(current == 'x' || current == c)
			return false
		end
	end
	return true
end


function keyword_contained(state::String, keyword::String)::Bool
	ind = 1
	for c in state
		if (c == 'x' || c != keyword[ind])
			ind = 1
		else
			ind += 1
		end
		if ind == 5
			return true
		end
	end
	return false
end


function how_many_at_least(state::String, remaining_keywords::Array{Int64}, keyword_offset::Int64)::Int64
	if sum(remaining_keywords) == 0
		println(state)

		return 4^sum(c == 'x' for c in state)
	end
	total = 0
	for ki in 1:4
		if remaining_keywords[ki] == 0
			continue
		end
		keyword = keywords[ki]
		for start in (keyword_offset):(n-3)
			if keyword_fits(state, keyword, start)
				new_state = state[1:start-1] * keyword * state[start+4:end]
				# println(new_state)
				remaining_keywords[ki] -= 1
				total += how_many_at_least(new_state, remaining_keywords, start+1)
				remaining_keywords[ki] += 1
			end
		end
	end
	return total
end

function combinations(n::Int, k::Int)
	return (t for t in Iterators.product(repeat([(0,1)],n)...) if sum(t)==k)
end

function how_many_exact(state::String, num_keyword::Array{Int64})::Int64
	total = 0
	for k in 0:4
		sign = k % 2 == 0 ? 1 : -1

		for addition in combinations(4, k)
			println()
			println(num_keyword .+ addition)
			hm = how_many_at_least(state, num_keyword .+ addition, 1)
			total += sign * hm
			println(hm)
		end
	end
	return total
end

function how_many_brute(state::String, remaining_keywords::Array{Bool}, keyword_offset::Int64=1)::Int64
	if !any(remaining_keywords)
		return how_many_fillings(state)
	end
	total = 0
	for ki in 1:4
		if !remaining_keywords[ki]
			continue
		end
		keyword = keywords[ki]
		for start in (keyword_offset):(n-3)
			if keyword_fits(state, keyword, start)
				new_state = state[1:start-1] * keyword * state[start+4:end]
				# println(new_state)
				remaining_keywords[ki] = false
				total += how_many(new_state, remaining_keywords, start+1)
				remaining_keywords[ki] = true
			end
		end
	end
	return total
end

n = 12

function calc(n)
	state::String = repeat('x',n)
	rk::Array{Bool} = [true,true,true,true]
	return how_many(state, rk, 1)
end

# @time println(calc(n))


#how_many_at_least(repeat('x',n), [0,1,2,0])

println(how_many_exact(repeat('x',n), [1,1,1,1]))
println(how_many_brute(repeat('x',n), [true,true,true,true]))
