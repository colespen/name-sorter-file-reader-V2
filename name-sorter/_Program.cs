//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace NameSorter;

//public class Program
//{
//    static string? path;
//    static IEnumerable<string>? sortednames;
//    static IEnumerable<string>? lines;

//    // Main(string[] args)
//    public static void Main()
//    {
//        //if (args.Length < 1)
//        //{
//        //    Console.WriteLine("Usage: name-sorter <filename>");
//        //    return;
//        //}

//        //path = args[0];
//        path = "./unsorted-names-list.txt";
//        lines = ReadFrom(path);
//        sortednames = SortByLastName();
//        PrintSortedNames();
//        WriteSortedNames();
//        System.Threading.Thread.Sleep(1000);
//        Console.WriteLine("Press any key to exit");
//        Console.ReadKey();
//    }

//    static IEnumerable<string> ReadFrom(string file)
//    {
//        if (!File.Exists(file))
//        {
//            throw new FileNotFoundException("File not found.", file);
//        }
//        //Console.WriteLine("ReadFrom()\n");
//        string? line;
//        using var reader = File.OpenText(file);
//        while ((line = reader.ReadLine()) != null)
//        {
//            yield return line;
//        }
//        // below is equivalent to above while loop
//        //return reader.ReadToEnd().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
//    }

//    static IEnumerable<string> SortByLastName()
//    {
//        if (lines == null)
//        {
//            throw new ArgumentNullException(nameof(lines));
//        }
//        return lines.OrderBy(name => name.Split(' ').Last());
//    }

//    static void PrintSortedNames()
//    {
//        if (sortednames == null)
//        {
//            throw new ArgumentNullException(nameof(sortednames));
//        }
//        //Console.WriteLine("PrintSortedNames()\n");
//        Console.WriteLine("Names sorted by last name:\n");
//        foreach (var name in sortednames)
//        {
//            Console.WriteLine(name);
//        }
//    }

//    static void WriteSortedNames()
//    {
//        if (sortednames == null)
//        {
//            throw new ArgumentNullException(nameof(sortednames));
//        }
//        using var writer = File.CreateText("./sorted-names-list.txt");
//        foreach (var name in sortednames)
//        {
//            writer.WriteLine(name);
//        }
//        Console.WriteLine("\nNames written to file => sorted-names-list.txt\n");
//        return;
//    }

//}
