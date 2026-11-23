# topthreestudents

Goal: Given a List<Student> (Name, Score), write a text report of the top 3
students with score >= 75, sorted high to low.
• Skills: Where, OrderByDescending, Take(3), Select, ToList, File.WriteAllLines
Steps:
• Define a Student record with Name and Score
• Build a sample List<Student> with 10-15 students of varied scores
• Use a LINQ chain to filter (>= 75), sort descending, and take the top 3
• Project each into a string like 'John — 92' with Select
• File.WriteAllLines to report.txt and open the file to verify
TRY IT YOURSELF : LAB 01
22Pick another domain. Build a data set, add some filtering and then print
to a file. Read the file back to display what got written