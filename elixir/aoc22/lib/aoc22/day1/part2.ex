defmodule Aoc22.Day1.Part2 do
  def run(sender) do
    receive do
      {:calculate, input} ->
        result = calculate(input, [], 0) |> Enum.sort(&(&1 > &2)) |> Enum.take(3) |> Enum.sum
        send(sender, {:part2, result})

      _ ->
        IO.puts("Unknown message received")
    end
  end

  defp calculate([], sums, _) do
    sums
  end

  defp calculate(input, sums, agg) do
    case input do
      ["" | tail] -> calculate(tail, [agg | sums], 0)
      [head | tail] -> calculate(tail, sums, agg + String.to_integer(head))
    end
  end
end
