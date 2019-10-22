

triangle_number(n::Int64) = n * (n + 1) ÷ 2

offset = Int('A') - 1
word_to_number(s) = mapreduce(c -> Int(c) - offset, +, s)


which_triangle = []
△n = 1

function is_triangle(n)
	while n > length(which_triangle)
		◭ = triangle_number(△n)
		global which_triangle = [which_triangle; repeat([false], ◭ - length(which_triangle) - 1); [true]]
		global △n += 1
	end
	return which_triangle[n]
end


pe_input = readline("p042_words.txt")
words = (w[2:end-1] for w in split(pe_input, ','))

println(sum(map(is_triangle ∘ word_to_number, words)))
