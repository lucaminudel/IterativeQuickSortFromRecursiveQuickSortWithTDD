using System.Collections.Generic;
using NUnit.Framework;


namespace QuickSort.Tests
{
	[TestFixture]
	public class IterativeQuickSortTest
	{
		[Test]
		public void Just_finish_with_basic_case_sort_problem()
		{
			var mockSortProblem = new MockSortProblem();
			mockSortProblem.SetExpectedCall_IsBasicCase(true);
			var target = new IterativeQuickSort();

			target.Sort(mockSortProblem);

			mockSortProblem.VerifyExpectations();			
		}

		[Test]
		public void With_non_basic_case_sort_problem_send_reduced_problems_to_the_solver()
		{
			var mockSortProblem1 = new MockSortProblem();
			var mockReducedSortProblem1_1 = new MockSortProblem();
			var mockReducedSortProblem1_2 = new MockSortProblem();
			var mockReducedSortProblem1_2_1 = new MockSortProblem();
			var mockReducedSortProblem1_2_2 = new MockSortProblem();

			mockSortProblem1.SetExpectedCall_IsBasicCase(false);
			IEnumerable<ISortProblem> reducedProblems0 = new[] { mockReducedSortProblem1_1, mockReducedSortProblem1_2 };
			mockSortProblem1.SetExpectedCall_GetReducedProblems(reducedProblems0);

			mockReducedSortProblem1_1.SetExpectedCall_IsBasicCase(true);

			mockReducedSortProblem1_2.SetExpectedCall_IsBasicCase(false);
			IEnumerable<ISortProblem> reducedProblems1_2 = new[] { mockReducedSortProblem1_2_1, mockReducedSortProblem1_2_2 };
			mockReducedSortProblem1_2.SetExpectedCall_GetReducedProblems(reducedProblems1_2);

			mockReducedSortProblem1_2_1.SetExpectedCall_IsBasicCase(true);
			mockReducedSortProblem1_2_2.SetExpectedCall_IsBasicCase(true);


			var target = new IterativeQuickSort();
			target.Sort(mockSortProblem1);


			mockSortProblem1.VerifyExpectations();
			mockReducedSortProblem1_1.VerifyExpectations();
			mockReducedSortProblem1_2.VerifyExpectations();
			mockReducedSortProblem1_2_1.VerifyExpectations();
			mockReducedSortProblem1_2_2.VerifyExpectations();
		}
	}
}
