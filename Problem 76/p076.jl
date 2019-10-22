function ∑(a)
	s = 0
	for x in a
		s += x
	end
	return s
end

count_sums(🐟, 🐢=1) = ∑((count_sums(🐟-i, i) for i in 🐢:(🐟 ÷ 2))) + ((🐟 >= 🐢) ? 1 : 0)

println(count_sums(100)-1)
