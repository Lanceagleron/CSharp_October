// public class MyClass : InheritFromParentName is how you do inheritance in c#

public class Student : Person
{
    public string FavoriteLanguage {get; set;}

    public Student(string firstName, string lastName, string favoriteLanguage) : base(firstName, lastName)
    {
        FavoriteLanguage = favoriteLanguage;
    }

}