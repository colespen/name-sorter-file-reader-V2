using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NameSorter.Tests
{
    public class NameSorterTests
    {
        [Fact]
        public void SortByLastName_ShouldSortNamesByLastName()
        {
            // Arrange
            var nameSorter = new NameSorter();
            var unsortedNames = new List<string>
            {
                "Wenona Smith Elliot",
                "Jane Doe",
                "Emily Wilson Scott",
                "Bob Johnson"
            };
            var expectedSortedNames = new List<string>
            {
                "Jane Doe",
                "Wenona Smith Elliot",
                "Bob Johnson",
                "Emily Wilson Scott"
            };

            // Act
            var sortedNames = nameSorter.SortByLastName(unsortedNames);

            // Assert
            Assert.Equal(expectedSortedNames, sortedNames.ToList());
        }
    }
}
