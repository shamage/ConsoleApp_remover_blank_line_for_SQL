// This is Blank Line Remower Console App in C#.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = Path.GetFullPath("path/to/your/input.sql");
        string outputFilePath = Path.GetFullPath("path/to/your/output.sql");

        RemoveConsecutiveBlankLines(inputFilePath, outputFilePath);
    }

    static void RemoveConsecutiveBlankLines(string inputFile, string outputFile)
    {
        if (!File.Exists(inputFile))
        {
            Console.WriteLine($"Input file not found: {inputFile}");
            return;
        }

        try
        {
            using (StreamReader reader = new StreamReader(inputFile))
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                string line;
                bool previousLineBlank = false;

                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (!previousLineBlank)
                        {
                            writer.WriteLine(line);
                            previousLineBlank = true;
                        }
                    }
                    else
                    {
                        writer.WriteLine(line);
                        previousLineBlank = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log the error
            Console.WriteLine($"An error occurred: {ex.Message}");
            // Optionally, log to a file or monitoring system
        }
    }
}

