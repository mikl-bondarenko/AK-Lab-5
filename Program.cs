using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        Console.WriteLine("Введіть шлях до каталогу (наприклад, C:\\Users\\Username\\Documents):");
        string directoryPath = Console.ReadLine();

        // Перевіряємо, чи існує вказаний каталог
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Каталог не знайдено.");
            return;
        }

        Console.WriteLine("Введіть нову дату та час (у форматі yyyy-MM-dd HH:mm:ss):");
        string newDateString = Console.ReadLine();

        DateTime newDate;
        if (!DateTime.TryParse(newDateString, out newDate))
        {
            Console.WriteLine("Некоректний формат дати. Використовуйте формат yyyy-MM-dd HH:mm:ss");
            return;
        }

        try
        {
            // Отримуємо список файлів у каталозі
            string[] files = Directory.GetFiles(directoryPath);

            // Змінюємо дату та час створення для кожного файлу
            foreach (string file in files)
            {
                // Змінюємо дату створення на нову дату
                File.SetCreationTime(file, newDate);
                Console.WriteLine($"Змінено дату створення файлу {file}");
            }

            Console.WriteLine("Зміни виконано успішно.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}
