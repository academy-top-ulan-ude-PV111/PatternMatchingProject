namespace PatternMatchingProject
{
    class Person
    {
        public string? Name { get; set; }

        public string? City { set; get; }

        public virtual void Print()
        {
            Console.WriteLine($"Person name: {Name}");
        }
    }

    class User : Person
    {
        //public string Login { set; get; }
        public bool IsAdmin { set; get; }
        public override void Print()
        {
            Console.WriteLine($"User name: {Name} - [Admn {IsAdmin}]");
        }
    }
    internal class Program
    {
        static void HelloPerson(Person person)
        {
            //if (person is Person { City: "Москва" })
            //    Console.WriteLine($"Привет {person.Name} столичный житель");
            //else
            //    Console.WriteLine($"Привет {person.Name} провинциал");

            //if (person is User { City: "Москва", IsAdmin: true })
            //    Console.WriteLine($"Привет {person.Name} столичный админ");
            //else
            //    Console.WriteLine($"Привет {person.Name} провинциал или не админ");

            string s = person switch
            {
                User { City: "Москва", IsAdmin: true } => $"Привет {person.Name} столичный админ",
                User { City: "Москва", IsAdmin: false, Name: var name } => $"Привет {name} столичный юзер",
                { Name: var name } => $"Привет {name} провинциал или не юзер вовсе"
            };
            Console.WriteLine(s);

        }

        //static public int? Calc(int a, int b, int code)
        //{
        //    //switch(code)
        //    //{
        //    //    case 1: return a + b;
        //    //    case 2: return a - b;
        //    //    case 3: return a * b;
        //    //    default: return null;
        //    //}

        //    //int? result = code switch
        //    //{
        //    //    1 => a + b,
        //    //    2 => a - b,
        //    //    3 => a * b,
        //    //    _ => null
        //    //};
        //    //return result;

        //    //return code switch
        //    //{
        //    //    1 => a + b,
        //    //    2 => a - b,
        //    //    3 => a * b,
        //    //    _ => null
        //    //};
        //}
        static void Main(string[] args)
        {
            // NEW SWITCH
            //Calc(10, 20, 3);

            int l = 200;
            string s = l switch
            {
                < 10 => "меньше дециметра",
                < 50 => "меньше полуметра",
                < 100 => "меньше метра",
                _ => "больше метра"
            };
            Console.WriteLine("длина " + s);

            int money = 70500;
            s = money switch
            {
                > 0 and <= 50000 => "без комиссии",
                > 50000 and <= 100000 => "комиссия 10%",
                > 100000 and <= 1000000 => "комиссия 20%",
                _ => "непонятная сумма"
            };
            Console.WriteLine("сумма " + money.ToString() + " " + s);

            // СООТВЕТСТВИЕ ТИПУ

            //Person? person = new User() { Name = "Bob", IsAdmin = false };

            ////person = new Person() { Name = "Joe" };
            ////person = null;
            ////Console.WriteLine(person is User);
            ////Console.WriteLine(person is Person);

            //switch (person)
            //{
            //    case User user when user.IsAdmin:
            //        Console.WriteLine("Admin");
            //        break;
            //    case null:
            //        Console.WriteLine("NULL");
            //        break;
            //    default:
            //        Console.WriteLine("Not User or User not admin");
            //        break;
            //}

            ////string str = "user";
            ////Console.WriteLine(str is "User");

            ////Object? obj = null;

            ////if(obj is not null)
            ////{

            ////}

            // СООТВЕТСТВИЕ СВОЙСТВ
            Person joe = new() { Name = "Joe", City = "Москва" };
            Person bob = new() { Name = "Bob", City = "Воронеж" };

            HelloPerson(joe);
            HelloPerson(bob);

            Person tom = new User() { Name = "Tom", City = "Москва", IsAdmin = true };
            HelloPerson(tom);

        }
    }
}