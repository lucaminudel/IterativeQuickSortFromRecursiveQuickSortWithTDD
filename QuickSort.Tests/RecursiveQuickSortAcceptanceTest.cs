using NUnit.Framework;

namespace QuickSort.Tests
{
	[TestFixture]
	public class RecursiveQuickSortAcceptanceTest : QuickSortAcceptanceTest<RecursiveQuickSort>
	{
	}

	[TestFixture]
	public class IterativeQuicksortAcceptanceTest : QuickSortAcceptanceTest<IterativeQuickSort>
	{
	}

}
