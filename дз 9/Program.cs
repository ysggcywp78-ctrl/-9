using System;

// Книга — простая штука. struct = при копировании создаётся полная копия.
struct Book
{
    public string Title;
    public string Author;

    public Book(string t, string a)
    {
        Title = t;
        Author = a;
    }

    // Чтобы красиво печаталось в консоль
    public override string ToString()
    {
        return $"{Title} от {Author}";
    }
}

// Студент — сложная штука. class = при копировании копируется только "адрес".
class Student
{
    public string Name;
    public Book MyBook;

    // Это и есть тот самый общий счётчик (статический). Один на всех студентов.
    private static int totalCount = 0;

    // Свойство, чтобы снаружи можно было только прочитать число, но не поменять его.
    public static int Total => totalCount;

    public Student(string name, string bookTitle, string bookAuthor)
    {
        Name = name;
        MyBook = new Book(bookTitle, bookAuthor);

        totalCount++;
    }

    public override string ToString()
    {
        return $"{Name} любит книгу: {MyBook}";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Старт ===");
        Console.WriteLine($"Студентов сейчас: {Student.Total}\n"); 

        Student s1 = new Student("Анна", "Мастер и Маргарита", "Булгаков");
        Console.WriteLine(s1);
        Console.WriteLine($"Стало студентов: {Student.Total}\n"); 
        Student s2 = new Student("Игорь", "Преступление и наказание", "Достоевский");
        Console.WriteLine(s2);
        Console.WriteLine($"Стало студентов: {Student.Total}\n"); 

        Console.WriteLine("Делаем копию студента: Student s1Copy = s1;");
        Student s1Copy = s1; 
        Console.WriteLine($"Количество студентов НЕ изменилось: {Student.Total}"); 

        s1Copy.Name = "Аня (новое имя)";
        s1Copy.MyBook = new Book("Война и мир", "Толстой");

        Console.WriteLine("\nСмотрим на s1 и s1Copy:");
        Console.WriteLine($"s1:      {s1}");    
        Console.WriteLine($"s1Copy:  {s1Copy}");


        Console.WriteLine("\n--- Теперь копируем Книгу (struct) ---");
        Book b1 = s2.MyBook;   
        Book b2 = b1;      
        b2.Title = "Идиот";    

        Console.WriteLine($"b1 (оригинал): {b1}"); 
        Console.WriteLine($"b2 (копия):   {b2}"); 

        Console.WriteLine("\nГотово! Разница видна: у студента копия = ссылка, у книги копия = новый объект.");
    }
}