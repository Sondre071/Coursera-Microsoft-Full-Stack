// Grade management console system

// This grade management system requires a few things. Ability to add students, add grades, calculate average grade, and fetch all grades. This requires awaiting user action input, and then checking which action the user chose. Upon executing the action, the user is prompted for whatever extra details the action requires, such as student ID, or student name.


class Program
{
    static void Main()
    {
        GradeManager gradeManager = new GradeManager();

        while (true)
        {
            Console.WriteLine("Choose an action:");

            Console.WriteLine("1: Add student");
            Console.WriteLine("2: Add grade");
            Console.WriteLine("3. Print student grades");
            Console.WriteLine("4. Print average student grade");
            Console.WriteLine("5. Exit program");
            
            int action = int.Parse(Console.ReadLine());

            switch (action)
            {
                case 1:
                    Console.WriteLine("Provide student name");
                    string newStudentName = Console.ReadLine();

                    Console.WriteLine("Provide student id");
                    int newStudentId = int.Parse(Console.ReadLine());

                    gradeManager.AddStudent(newStudentId, newStudentName);
                    break;

                case 2:
                    Console.WriteLine("Provide student id");
                    int studentId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Provide grade");
                    int newGrade = int.Parse(Console.ReadLine());

                    gradeManager.AddGrade(studentId, newGrade);
                    break;

                case 3:

                    Console.WriteLine("Provide student id");

                    int printStudentGradesId = int.Parse(Console.ReadLine());
                    
                    gradeManager.PrintGrades(printStudentGradesId);
                    break;

                case 4:
                    Console.WriteLine("Provide student id");
                    int avgStudentId = int.Parse(Console.ReadLine());
                    
                    gradeManager.PrintAverageGrade(avgStudentId);
                    break;
                
                case 5:
                    return;
                
                default:
                    Console.WriteLine("Invalid option, try again");
                    break;
            }
        }
    }
}


public class GradeManager
{
    private List<Student> students = new List<Student>();
    private List<Grade> grades = new List<Grade>();

    public void AddStudent(int id, string name)
    {
        students.Add(new Student(id, name));
    }

    public void AddGrade(int studentId, int grade)
    {
        grades.Add(new Grade(studentId, grade));
    }

    public void PrintAverageGrade(int studentId)
    {
        List<Grade> studentGrades = grades.FindAll(x => x.StudentId == studentId);

        int totalGradeValue = 0;

        for (int i = 0; i < studentGrades.Count; i++)
        {
            totalGradeValue += studentGrades[i].Score;
        }
        
        int averageGrade = totalGradeValue / studentGrades.Count;
        
        Console.WriteLine("Average grade: " + averageGrade);
    }

    public void PrintGrades(int studentId)
    {
        Console.WriteLine("Grades");
        
        List<Grade> studentGrades = grades.FindAll(x => x.StudentId == studentId);
        
        foreach (var grade in studentGrades)
        {
            Console.WriteLine($"Student ID: {grade.StudentId}, Grade: {grade.Score}");
        }
    }
}

public class Grade
{
    public int StudentId { get; set; }
    public int Score { get; set; }

    public Grade(int studentId, int score)
    {
        StudentId = studentId;
        Score = score;
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }
}