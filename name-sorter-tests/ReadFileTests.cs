using System;
using System.Collections.Generic;
using NameSorter;
using Xunit;

namespace NameSorter.Tests
{
    public class ReadFileTests
    {
        [Fact]
        public void ReadFile_ThrowsFileNotFoundException_WhenFileNotFound()
        {
            // Arrange
            var fileReader = new FileReader();

            // Act & Assert
            Assert.Throws<FileNotFoundException>(
                () => fileReader.ReadFile("file-not-found.txt").ToList());
        }

        [Fact]
        public void ReadFile_ReturnsExpectedResult_WhenFileExists()
        {
            // Arrange
            var fileReader = new FileReader();
            var expectedResult = new List<string>
            {
                "Janet Parsons",
                "Vaughn Lewis",
                "Adonis Julius Archer",
                "Shelby Nathan Yoder",
                "Marin Alvarez",
                "London Lindsey",
                "Beau Tristan Bentley",
                "Leo Gardner",
                "Hunter Uriah Mathew Clarke",
                "Mikayla Lopez",
                "Frankie Conner Ritter"
            };

            // Act
            var actualResult = fileReader.ReadFile("./unsorted-names-list.txt");

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
