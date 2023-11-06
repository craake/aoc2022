lines = File.readlines(File.join(File.dirname(__FILE__), 'input.txt')).map(&:to_i)
calories = []
current = 0

lines.each do |l|
  current += l; next if l != 0

  calories << current
  current = 0
end

calories.sort! { |a, b| a <=> b }

pt1_result = calories.last
pt2_result = calories.last(3).sum

puts 'Day 1'
puts '-----'
puts "Pt. 1 result #{pt1_result}"
puts "Pt. 2 result #{pt2_result}"
