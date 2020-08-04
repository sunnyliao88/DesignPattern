using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class FactoryDP
    {
        public static void Demo()
        {
            MethodCreditCardFactoryDemo();
            ConstructorCreditCardFactoryDemo();
            GenericCreditCardFactoryDemo();
        }

        static void MethodCreditCardFactoryDemo()
        {
            ICreditCard creditCard = MethodCreditCardFactory.GetCreditCard("BMO");
            ShowCreditCard(creditCard);
            creditCard = MethodCreditCardFactory.GetCreditCard("TD");
            ShowCreditCard(creditCard);
            creditCard = MethodCreditCardFactory.GetCreditCard("CIBC");
            ShowCreditCard(creditCard);
        }
        static void ConstructorCreditCardFactoryDemo()
        {
            ICreditCard creditCard = new ConstructorCreditCardFactory("BMO").CreditCard;
            ShowCreditCard(creditCard);
            creditCard = new ConstructorCreditCardFactory("TD").CreditCard;
            ShowCreditCard(creditCard);
            creditCard = new ConstructorCreditCardFactory("CIBC").CreditCard;
            ShowCreditCard(creditCard);
        }
        static void GenericCreditCardFactoryDemo()
        {
            ICreditCard creditCard = new GenericCreditCardFactory<BMOCreditCard>().CreditCard;
            ShowCreditCard(creditCard);
            creditCard = new GenericCreditCardFactory<TDCreditCard>().CreditCard;
            ShowCreditCard(creditCard);
            creditCard = new GenericCreditCardFactory<CIBCCreditCard>().CreditCard;
            ShowCreditCard(creditCard);
        }


        static void ShowCreditCard(ICreditCard c)
        {
            Console.WriteLine($"CardType: {c.GetCardType()}; Limit: {c.GetCreditLimit()}; AnnualCharge: {c.GetAnnualCharge()}% ");
        }


    }

    interface ICreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        double GetAnnualCharge();
    }
    class BMOCreditCard : ICreditCard
    {
        public double GetAnnualCharge()
        {
            return 2.0;
        }

        public string GetCardType()
        {
            return "BMO";
        }

        public int GetCreditLimit()
        {
            return 5000;
        }
    }
    class TDCreditCard : ICreditCard
    {
        public double GetAnnualCharge()
        {
            return 1.8;
        }

        public string GetCardType()
        {
            return "TD";
        }

        public int GetCreditLimit()
        {
            return 6000;
        }
    }
    class CIBCCreditCard : ICreditCard
    {
        public double GetAnnualCharge()
        {
            return 2.5;
        }

        public string GetCardType()
        {
            return "CIBC";
        }

        public int GetCreditLimit()
        {
            return 8000;
        }
    }
    class MethodCreditCardFactory
    {
        public static ICreditCard GetCreditCard(string name)
        {
            switch (name)
            {
                case "BMO":
                    return new BMOCreditCard();
                case "TD":
                    return new TDCreditCard();
                case "CIBC":
                    return new CIBCCreditCard();
                default:
                    throw new Exception("Invalid card type");
            }
        }

    }
    class ConstructorCreditCardFactory
    {
        public ICreditCard CreditCard { get; }
        public ConstructorCreditCardFactory(string name)
        {
            switch (name)
            {
                case "BMO":
                    CreditCard = new BMOCreditCard();
                    break;
                case "TD":
                    CreditCard = new TDCreditCard();
                    break;
                case "CIBC":
                    CreditCard = new CIBCCreditCard();
                    break;
                default:
                    throw new Exception("Invalid card type");
            }
        }


    }
    class GenericCreditCardFactory<T> where T : ICreditCard, new()
    {
        public ICreditCard CreditCard { get; }
        public GenericCreditCardFactory()
        {
            CreditCard = new T();
        }
    }

}
