using System;
using Xunit;

public class SearchControllerTests
{
	[Fact]
	public async Task Search_ShouldReturnResults()
	{
		var controller = new SearchController(_context);

		var result = await controller.Search_ShouldReturnResults("steve");

		Assert.NotNull(result);
	}
}
