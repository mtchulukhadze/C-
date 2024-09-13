

using System;
using System.Threading;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstname;
    string lastname;
    double balance;

    public cardHolder(string cardNum, int pin, string firstname, string lastname, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstname = firstname;
        this.lastname = lastname;
        this.balance = balance;
    }

    public string getCardNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstname()
    {
        return firstname;
    }

    public string getLastname()
    {
        return lastname;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(string NewcardNum)
    {
        cardNum = NewcardNum;
    }

    public void setPin(int Newpin)
    {
        pin = Newpin;
    }

    public void setFirstName(string NewfirstName)
    {
        firstname = NewfirstName;
    }

    public void setLastName(string NewlastName)
    {
        lastname = NewlastName;
    }

    public void setBalance(double Newbalance)
    {
        balance = Newbalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("please choose one of the following options...");
            Console.WriteLine("1. peposit");
            Console.WriteLine("2. withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money whould like to deposit");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine($"your new balance is: {currentUser.getBalance()}");
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("how much money you want to withdraw");
            double withrdaw = double.Parse(Console.ReadLine());
            // check if balance is enough
            if(currentUser.getBalance() < withrdaw)
            {
                Console.WriteLine("not enough money");
            }
            else
            {
                double newBalance = currentUser.getBalance() - withrdaw;
                currentUser.setBalance(newBalance);
                Console.WriteLine("withdraw accepted");
                Console.WriteLine($"current balance is: {newBalance}");
            }

        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine($"current Balance: {currentUser.getBalance()}");
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("123456", 1234, "Mikheil", "tchulukhadze", 23.5));

        Console.WriteLine("welcome to ATM");
        Console.WriteLine("Enter your cardNumber");

        string debidcardnum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debidcardnum = Console.ReadLine();
                // check it this data exists in database

                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debidcardnum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("card not recognise, please try again");
                }
            }
            catch
            {
                Console.WriteLine("card not recognise, please try again");
            }
        }

        for (int i=0; i <= 10; i++)
        {
            Console.Write("* ");
            Thread.Sleep(250);
        }
        Console.WriteLine();

        Console.WriteLine("enter your pin");

        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // check it pin is correct

                currentUser = cardHolders.FirstOrDefault(a => a.pin == userPin);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("pin is not correct");
                }
            }
            catch
            {
                Console.WriteLine("pin is not correct");
            }
        }

        for (int i = 0; i <= 10; i++)
        {
            Console.Write("* ");
            Thread.Sleep(250);
        }
        Console.WriteLine();

       

        Console.WriteLine($"Hello {currentUser.getFirstname()}");

        int option = 0;

        do
        {
            printOptions();

            string input = Console.ReadLine();

            if(int.Parse(input) == 1)
            {

                deposit(currentUser);
            }
            else if(double.Parse(input) == 2)
            {
                withdraw(currentUser);
            }
            else
            {
                break;
            }
        }
        while (option != 4);
    }

}
