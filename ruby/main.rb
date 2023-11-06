Dir::children('.').each do |child|
  if child.start_with?('day') && File.directory?(child)
    path = "./#{child}/program.rb"
    require path if File.exist?(path)
  end
end

