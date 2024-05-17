using CARS.MainApp;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your username");
            string uname=Console.ReadLine();
            Console.WriteLine("Please enter your password");
            int pw=int.Parse(Console.ReadLine());
            int t = 2;
            while (t>0)
            {
                if(pw== 12345)
                {
                    MainModule mainModule = new MainModule();
                    mainModule.run();
                }
                else
                {
                    Console.WriteLine($"Wrong password, please enter the correct password again. You have {t} attempts left");
                    
                    pw= int.Parse(Console.ReadLine());
                    t = t - 1;
                    if (t == 0)
                    {
                        Console.WriteLine("You have entered wrong password for three times in a row. Login failed. Exiting...");
                    }
                }
                
            }
            
        }
    }
}
