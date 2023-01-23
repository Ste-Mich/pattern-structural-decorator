using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            // espresso with an extra shot, soy milk and two sugars
            // 30            +  20        + 35         + 5 + 5      = 95
            ICoffee coffee = new Espresso();
            coffee = new ExtraShotWrapper(coffee);
            coffee = new ExtraSoymilkWrapper(coffee);
            coffee = new ExtraSugarWrapper(coffee);
            coffee = new ExtraSugarWrapper(coffee);
            coffee = new ExtraSugarWrapper(new ExtraSugarWrapper(new ExtraSoymilkWrapper(new ExtraShotWrapper(new Espresso()))));
            coffee.PrintDescription();
            Console.WriteLine("Your coffee costs: "+ coffee.GetPrice());
        }
    }

    public interface ICoffee
    {
        public void PrintDescription();
        public int GetPrice();
    }

    public class Espresso : ICoffee
    {
        public int BasePrice { get; set; } = 30;
        public void PrintDescription()
        {
            Console.WriteLine("Espresso - one shot, small coffee.");
        }
        public int GetPrice()
        {
            return BasePrice;
        }
    }

    public class Cappucino : ICoffee
    {
        public int BasePrice { get; set; } = 65;
        public void PrintDescription()
        {
            Console.WriteLine("Espresso - one shot and milk, medium coffee.");
        }
        public int GetPrice()
        {
            return BasePrice;
        }
    }

    public class Late : ICoffee
    {
        public int BasePrice { get; set; } = 70;
        public void PrintDescription()
        {
            Console.WriteLine("Espresso - one shot and a lot of milk, big coffee.");
        }
        public int GetPrice()
        {
            return BasePrice;
        }
    }

    public class ExtraShotWrapper : ICoffee
    {
        public ICoffee Wrapee { get; set; }

        public ExtraShotWrapper(ICoffee wrapee)
        {
            Wrapee = wrapee;
        }

        public int GetPrice()
        {
            return Wrapee.GetPrice() + 20;
        }

        public void PrintDescription()
        {
            Wrapee.PrintDescription();
            Console.WriteLine("- And an extra shot.");
        }
    }

    public class ExtraMilkWrapper : ICoffee
    {
        public ICoffee Wrapee { get; set; }

        public ExtraMilkWrapper(ICoffee wrapee)
        {
            Wrapee = wrapee;
        }

        public int GetPrice()
        {
            return Wrapee.GetPrice() + 15;
        }

        public void PrintDescription()
        {
            Wrapee.PrintDescription();
            Console.WriteLine("- And extra milk.");
        }
    }

    public class ExtraSoymilkWrapper : ICoffee
    {
        public ICoffee Wrapee { get; set; }

        public ExtraSoymilkWrapper(ICoffee wrapee)
        {
            Wrapee = wrapee;
        }

        public int GetPrice()
        {
            return Wrapee.GetPrice() + 35;
        }

        public void PrintDescription()
        {
            Wrapee.PrintDescription();
            Console.WriteLine("- And extra soymilk.");
        }
    }

    public class ExtraSugarWrapper : ICoffee
    {
        public ICoffee Wrapee { get; set; }

        public ExtraSugarWrapper(ICoffee wrapee)
        {
            Wrapee = wrapee;
        }

        public int GetPrice()
        {
            return Wrapee.GetPrice() + 5;
        }

        public void PrintDescription()
        {
            Wrapee.PrintDescription();
            Console.WriteLine("- And extra sugar.");
        }
    }
}
