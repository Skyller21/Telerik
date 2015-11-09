## Data Structures, Algorithms and Complexity Homework

1. What is the expected running time of the following C# code?
  - Explain why using Markdown.
  - Assume the array's size is `n`.

  ```cs

	  long Compute(int[] arr)
	  {
	      long count = 0;
	      for (int i=0; i<arr.Length; i++)
	      {
	          int start = 0, end = arr.Length-1;
	          while (start < end)
	              if (arr[start] < arr[end])
	                  { start++; count++; }
	              else 
	                  end--;
	      }
	      return count;
	  }

  ```

**Answer:** The expected running time of the code in the worst case is O(n^2). The best case is O(n).
			The outer loop will be executed n times.
			The inner loop will be executed n times.

---

2. What is the expected running time of the following C# code?
  - Explain why using Markdown.
  - Assume the input matrix has size of `n * m`.

  ```cs

	  long CalcCount(int[,] matrix)
	  {
	      long count = 0;
	      for (int row=0; row<matrix.GetLength(0); row++)
	          if (matrix[row, 0] % 2 == 0)
	              for (int col=0; col<matrix.GetLength(1); col++)
	                  if (matrix[row,col] > 0)
	                      count++;
	      return count;
	  }

  ```

**Answer:** The expected running time of the code in the worst case is O(n*m) which is O(n^2) if you assume that n and m are of the same magnitude. The best case is O(n).
			The outer loop will be executed n times.
			The inner loop will be executed m times.

---

3. (*) What is the expected running time of the following C# code?
  - Explain why using Markdown.
  - Assume the input matrix has size of `n * m`.

  ```cs
  long CalcSum(int[,] matrix, int row)

	  {
	      long sum = 0;
	      for (int col = 0; col < matrix.GetLength(0); col++) 
	          sum += matrix[row, col];
	      if (row + 1 < matrix.GetLength(1)) 
	          sum += CalcSum(matrix, row + 1);
	      return sum;
	  }
	  
	  Console.WriteLine(CalcSum(matrix, 0));

  ```

**Answer:** The expected running time of the code in the worst case O(n*m). In the best case you can pass row equal to the largest one or matrix with 1 row or 1 column and than the complexity will be O(n).
			
