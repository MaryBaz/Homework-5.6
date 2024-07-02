namespace Homework_5._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EnterUser();
            ShowData();
        }
        static (string Name, string LastName, int Age, int NumPet, int NumFavColor, bool HavePet, string[] PetName, string[] favColor) Anketa;
        static (string Name, string LastName, int Age, int NumPet, int NumFavColor, bool HavePet, string[] PetName, string[] favColor) EnterUser()
        {
            Console.Write("Введите имя: ");
            Anketa.Name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            Anketa.LastName = Console.ReadLine();

            string age;
            int intage;
            do
            {
                Console.Write("Введите возраст цифрами: ");
                age = Console.ReadLine();

            } while (Checknum(age, out intage));

            Anketa.Age = intage;

            Console.Write("Есть ли у вас питомцы? (Да/Нет): ");
            var PetResult = Console.ReadLine();

            while (PetResult != "Да" && PetResult != "Нет")
            {
                Console.WriteLine("Некорректный ответ, пожалуйста, ответьте Да или Нет");
                PetResult = Console.ReadLine();
            }
            if (PetResult == "Да")
            {
                Anketa.HavePet = true;
                string pet;
                int intpet;
                do
                {
                    Console.WriteLine("Введите количество питомцев цифрами: ");
                    pet = Console.ReadLine();

                } while (Checknum(pet, out intpet));

                Anketa.NumPet = intpet;

                string[] PetName = new string[intpet];
                Console.WriteLine("Введите имя/имена питомца(цев): ");
                for (int i = 0; i < intpet; i++)
                {
                    PetName[i] = Console.ReadLine();
                }

                Anketa.PetName = PetName;
            }

            else
            {
                Anketa.NumPet = 0;
            }

            string colors;
            int intcolors;
            do
            {
                Console.Write("Напишите количество ваших любимых цветов цифрами: ");
                colors = Console.ReadLine();
            } while (Checknum(colors, out intcolors));

            Anketa.NumFavColor = intcolors;

            string[] favColor = new string[intcolors];
            Console.WriteLine("Введите Ваш(и) любимый(е) цвет(а): ");
            for (int i = 0; i < intcolors; i++)
            {
                favColor[i] = Console.ReadLine();
            }

            Anketa.favColor = favColor;

            return Anketa;
        }

        static bool Checknum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {

                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            {
                Console.WriteLine("Некорректное значение, введите значение цифрами");
                corrnumber = 0;
                return true;
            }
        }
        static (string Name, string LastName, int Age, int NumPet, int NumFavColor, bool HavePet, string[] PetName, string[] favColor) ShowData()
        {
            Console.WriteLine("Привет! Я получил от пользователя нижеуказанные данные");
            Console.WriteLine($"Имя: {Anketa.Name}");
            Console.WriteLine($"Фамилия: {Anketa.LastName}");
            Console.WriteLine($"Возраст: {Anketa.Age}"); if (Anketa.HavePet)
            {
                Console.WriteLine($"Количество питомцев: {Anketa.NumPet}");
                Console.WriteLine("Клички питомцев:");
                foreach (string pet in Anketa.PetName)
                {
                    Console.WriteLine(pet);
                }
            }
            else
            {
                Console.WriteLine("У пользователя нет питомцев");
            }
            Console.WriteLine($"Количество любимых цветов: {Anketa.NumFavColor}");
            Console.WriteLine("Любимые цвета:");
            foreach (string col in Anketa.favColor)
            {
                Console.WriteLine(col);
            }

            return Anketa;
        }
    }
}
