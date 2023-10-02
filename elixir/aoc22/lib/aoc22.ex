defmodule Aoc22 do
  alias Aoc22.Day1

  @moduledoc """
  Documentation for `Aoc22`.
  """

  def run do
    input_path = Path.join(:code.priv_dir(:aoc22), "input/day1")

    input =
      case File.read(input_path) do
        {:ok, content} -> content
        {:error, _} -> raise("Couldn't read input file")
      end

    lines = String.split(input, "\n")

    me = self()
    pid1 = spawn(Day1.Part1, :run, [me])
    pid2 = spawn(Day1.Part2, :run, [me])

    send(pid1, {:calculate, lines})
    send(pid2, {:calculate, lines})

    receive do
      {:part1, value} ->
        IO.puts("Received a message from part1: #{value}")

      {:part2, value} ->
        IO.puts("Received a message from part2: #{value}")
    after
      1_000 -> IO.puts("Nothing received for 1 second...")
    end

    rec()
  end

  defp rec do
    receive do
      {:part1, value} ->
        IO.puts("Received a message from part1: #{value}")

      {:part2, value} ->
        IO.puts("Received a message from part2: #{value}")
    after
      1_000 -> IO.puts("Nothing received for 1 second...")
    end

    rec()
  end
end
