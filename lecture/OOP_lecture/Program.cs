// Person blake = new Person();
// blake.FirstName = "blake";
// blake.LastName = "hunter";

// Person devin = new Person("devin", "spaulding");

// Person tom = new Person()
// {
//     FirstName = "tom",
//     LastName = "Harris"
// };

// Console.WriteLine(blake.FirstName);
// Console.WriteLine(devin.FirstName);
// Console.WriteLine(tom.FirstName);

Student blake = new Student("blake", "hunter", "javascript");
Student devin = new Student("devin", "spaulding", "c#");
Student tom = new Student("tom", "harris", "python");
Person max = new Person("max", "rauchman");

List<Student> csharpStudents = new List<Student>()
{
    blake,
    devin,
    tom
};

Lecture oopIntro = new Lecture("OOP Intro", new DateTime(2022, 9, 2), max, csharpStudents);


oopIntro.PrintAttendanceList();