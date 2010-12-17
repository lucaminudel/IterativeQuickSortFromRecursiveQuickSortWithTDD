using System.Collections.Generic;

namespace QuickSort
{
	public class IterativeQuickSort: ISort
	{
		public void Sort(int[] arrayToBeSorted)
		{
			ISortProblem sortProblem = new SplitByMedianItem(arrayToBeSorted);
			Sort(sortProblem);
		}

		public void Sort(ISortProblem sortProblem)
		{
			var sortingSubproblems = new Stack<ISortProblem>();
			sortingSubproblems.Push(sortProblem);

			while (sortingSubproblems.Count > 0)
			{
				var subProblem = sortingSubproblems.Pop();

				if (subProblem.IsBasicCase)
				{
					continue;
				}

				foreach (var sortingSubproblem in subProblem.GetReducedProblems())
				{
					sortingSubproblems.Push(sortingSubproblem);
				}
			}
		}

	}
}
