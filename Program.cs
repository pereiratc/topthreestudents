
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Define the student record.
record Student(string Name, int Score);

// Store the students entered by the user.
List<Student> students = new();

Console.WriteLine("=== TOP 3 STUDENT REPORT ===");

// Ask how many students will be entered.
int count;

while (true)
{
    Console.Write("How many students (10-15)? ");

    if (int.TryParse(Console.ReadLine(), out count)
        && count >= 10 && count <= 15)
        break;

    Console.WriteLine("Please enter a number between 10 and 15.");
}

// Collect student information.
for (int i = 1; i <= count; i++)
{
    Console.WriteLine($"\nStudent {i}");

    string name;

    do
    {
        Console.Write("Name: ");
        name = Console.ReadLine()?.Trim() ?? "";
    }
    while (string.IsNullOrWhiteSpace(name));

    int score;

    while (true)
    {
        Console.Write("Score (0-100): ");

        if (int.TryParse(Console.ReadLine(), out score)
            && score >= 0 && score <= 100)
            break;

        Console.WriteLine("Invalid score. Enter 0 to 100.");
    }

    students.Add(new Student(name, score));
}

// Filter, sort, select top 3, and format the report.
List<string> topStudents = students
    .Where(s => s.Score >= 75)
    .OrderByDescending(s => s.Score)
    .Take(3)
    .Select(s => $"{s.Name} — {s.Score}")
    .ToList();

// Save the report to a text file.
string filePath = "report.txt";
File.WriteAllLines(filePath, topStudents);

// Read the file and display the saved report.
Console.WriteLine("\n=== TOP STUDENTS (SCORE >= 75) ===");

string[] reportLines = File.ReadAllLines(filePath);

if (reportLines.Length == 0)
{
    Console.WriteLine("No students qualified.");
}
else
{
    foreach (string line in reportLines)
    {
        Console.WriteLine(line);
    }
}

Console.WriteLine($"\nReport saved to: {Path.GetFullPath(filePath)}");
