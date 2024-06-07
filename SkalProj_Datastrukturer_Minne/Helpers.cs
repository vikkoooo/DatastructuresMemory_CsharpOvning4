using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
	internal static class Helpers
	{
		/// <summary>
		/// Reverses the given text using a stack.
		/// </summary>
		/// <param name="text">The text to reverse.</param>
		/// <returns>A new string with the characters in reverse order.</returns>
		public static string ReverseText(string text)
		{
			Stack<char> characters = new Stack<char>(text.Length); // Create stack correct size

			// Add each character to the stack
			foreach (char c in text)
			{
				characters.Push(c);
			}

			// Build string to return
			StringBuilder result = new StringBuilder();

			// Pop each char off the stack
			foreach (char c in characters)
			{
				result.Append(c);
			}

			return result.ToString();
		}

		/// <summary>
		/// Checks if the parentheses in the given text are balanced.
		/// </summary>
		/// <param name="text">The text containing parentheses to check.</param>
		/// <returns>True if the parentheses are balanced, false otherwise.</returns>
		public static bool CheckParanthesis(string text)
		{
			// Define the pairs, key = opening and value = closing
			Dictionary<char, char> pairs = new Dictionary<char, char>
			{
				{ '(', ')' },
				{ '{', '}' },
				{ '[', ']' },
				{ '<', '>' }
			};

			// Create datastructure
			Stack<char> openers = new Stack<char>(); // stack to keep track of latest opener

			// Fill datastructures with openers
			foreach (char c in text)
			{
				// Check openers
				if (pairs.ContainsKey(c))
				{
					openers.Push(c); // push opener to stack

				} // Check closers
				else if (pairs.ContainsValue(c))
				{
					// If opening stack is empty we have already failed, do early exit
					if (openers.Count == 0)
					{
						return false;
					}
					// Algoritm is: if stack does not contain the corresponding opener on top of the stack we have failed
					// Steps:
					// 1. Peek stack with opening bracket and we get closing bracket corresponder
					// 2. If this is equal to our current char we are evaluating we have a good match - so we can remove it from stack and continue
					if (pairs[openers.Peek()] == c)
					{
						var tmp = pairs[openers.Pop()]; // Just pop and throw away
					}
					// We end up here when they did not match - this means we have failed
					else
					{
						return false;
					}
				}
			}

			// If all was successful we should now have an empty stack
			if (openers.Count == 0)
			{
				return true;
			}
			return false; // If we end up here for some reason we have failed
		}

		/// <summary>
		/// Computes the nth even number using recursion.
		/// </summary>
		/// <param name="n">The position of the even number to compute.</param>
		/// <returns>The nth even number.</returns>
		public static int RecursiveEven(int n)
		{
			// Base case 
			if (n == 1)
			{
				return 0;
			}
			// Recursive case
			else
			{
				return (RecursiveEven(n - 1) + 2);
			}

		}

		/// <summary>
		/// Computes the nth Fibonacci number using recursion.
		/// </summary>
		/// <param name="n">The position of the Fibonacci number to compute.</param>
		/// <returns>The nth Fibonacci number.</returns>
		public static int FibonacciRecursive(int n)
		{
			// Base case
			if (n <= 1) // Actually "n == 0 || n == 1" to make it clearer. Both start points return n.
			{
				return n;
			}
			// Recursive case f(n) = f(n-1) + f(n-2), f(n) function is same as return statement
			else
			{
				return (FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2));
			}
		}

		/// <summary>
		/// Computes the nth even number using iteration.
		/// </summary>
		/// <param name="n">The position of the even number to compute.</param>
		/// <returns>The nth even number.</returns>
		public static int IterativeEven(int n)
		{
			int result = 0;

			for (int i = 0; i < n - 1; i++)
			{
				result += 2;
			}
			return result;
		}

		/// <summary>
		/// Computes the nth Fibonacci number using iteration.
		/// </summary>
		/// <param name="n">The position of the Fibonacci number to compute.</param>
		/// <returns>The nth Fibonacci number.</returns>
		public static int FibonacciIterative(int n)
		{
			int current = 1; // Fib current
			int prev = current - 1; // Fib one behind
			int tmp = 0; // Temp storage 

			// Base case, same here - it actually represents both "n == 0 || n == 1" since they are the starting points
			if (n <= 1)
			{
				current = n;
			}
			else
			{
				for (int i = 2; i <= n; i++) // Start at n = 2 since base case covers 0 and 1 by default
				{
					tmp = current; // Will become one behind
					current = current + prev; // Add fib current with fib one behind to get new current
					prev = tmp; // Fib one behind will be whatever fib current was before the move
				}
			}
			return current;
		}
	}
}
