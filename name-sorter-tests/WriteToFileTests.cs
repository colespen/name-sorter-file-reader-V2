using System;
using System.Collections.Generic;
using System.IO;
using NameSorter;
using Xunit;

namespace NameSorter.Tests
{
    public class WriteToFileTests
    {
        [Fact]
        public void WriteToFile_CreatesFile_WhenFileDoesNotExist()
        {
            // Arrange
            var fileWriter = new FileWriter();
            var fileName = "./test-output.txt";
            var names = new List<string> { "John Doe", "Jane Doe", "Bob Smith" };

            // Act
            fileWriter.WriteToFile(fileName, names);

            // Assert
            Assert.True(File.Exists(fileName));

            // Clean up
            File.Delete(fileName);
        }

        [Fact]
        public void WriteToFile_WritesNamesToFile_WhenFileExists()
        {
            // Arrange
            var fileWriter = new FileWriter();
            var fileName = "./test-output.txt";
            var names = new List<string> { "John Doe", "Jane Doe", "Bob Smith" };
            var expectedContent = "John Doe\nJane Doe\nBob Smith\n";

            // Act
            fileWriter.WriteToFile(fileName, names);

            // Assert
            var actualContent = File.ReadAllText(fileName);
            Assert.Equal(expectedContent, actualContent);

            // Clean up
            File.Delete(fileName);
        }
    }
}
