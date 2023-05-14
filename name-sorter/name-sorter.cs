using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSorter
{
    public interface IReadFile
    {
        IEnumerable<string> ReadFile(string file);
    }

    public interface ISortNames
    {
        IEnumerable<string> SortByLastName(IEnumerable<string> names);
    }

    public interface IWriteFile
    {
        void WriteToFile(string fileName, IEnumerable<string> names);
    }

    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("\nPlease enter filename argument to run program.\n");
                Console.WriteLine("Correct usage: name-sorter ./name-of-file.txt\n");
                return;
            }
            var path = args[1];
            var fileReader = new FileReader();
            var nameSorter = new NameSorter();
            var fileWriter = new FileWriter();
            var sortedNames = nameSorter.SortByLastName(fileReader.ReadFile(path));
            PrintSortedNames(sortedNames);
            fileWriter.WriteToFile("./sorted-names-list.txt", sortedNames);
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void PrintSortedNames(IEnumerable<string> sortedNames)
        {
            Console.WriteLine("Names sorted by last name:\n");
            foreach (var name in sortedNames)
            {
                Console.WriteLine(name);
            }
        }
    }

    public class FileReader : IReadFile
    {
        public IEnumerable<string> ReadFile(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException("File not found.", file);
            }
            using var reader = File.OpenText(file);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }

    public class NameSorter : ISortNames
    {
        public IEnumerable<string> SortByLastName(IEnumerable<string> names)
        {
            return names.OrderBy(name => name.Split(' ').Last());
        }
    }

    public class FileWriter : IWriteFile
    {
        public void WriteToFile(string fileName, IEnumerable<string> names)
        {
            using var writer = File.CreateText(fileName);
            foreach (var name in names)
            {
                writer.WriteLine(name);
            }
            Console.WriteLine("\nNames written to file => sorted-names-list.txt\n");
        }
    }
}
