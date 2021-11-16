using System;

namespace HalloWelt
{
    class Program
    {
        static double totalPrice = 0;
        static double totalTaxes = 0;

        static object[,] table = {
            {"Pflegespülung Plus", 3, 7.95} ,     /*  Erste Reihe */
            {"Conditioner Tropical", 1, 5.95} ,   /*  Zweite Reihe */
            {"Antischuppen Special", 5, 9.99} ,    /*  Dritte Reihe */
            {"Antischuppen Special", 5, 9.99} ,    /*  Dritte Reihe */
            {"Antischuppen Special", 5, 9.99} ,    /*  Dritte Reihe */
            {"Antischuppen Special", 5, 9.99} ,    /*  Dritte Reihe */
            {"Antischuppen Special", 5, 9.99} ,    /*  Dritte Reihe */
            {"Antischuppen Special", 5, 9.99} ,    /*  Dritte Reihe */
            {"Antischuppen Special", 5, 9.99} ,    /*  Dritte Reihe */
            {"Antischuppen Special", 5, 9.99} ,    /*  Dritte Reihe */
            {"Antischuppen Special", 5, 9.99}     /*  Dritte Reihe */
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            coverLetter();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Produkt\t\t\t\tMenge\t\tUst. 19%\tPreis\t\tGesamt");


            for(int i = 0; i < table.GetLength(0); i++)
            {
                printRow(i);
            }





            printShippingCosts();

            // Print total sum
            Console.WriteLine("");
            Console.WriteLine("Gesamtsumme \t\t Ust.: " + Math.Round(totalTaxes, 2) + "€\t\t" + totalPrice + "€");
        }

        static void printRow(int rowNumber)
        {
            showPrice((string)table[rowNumber, 0], (int)table[rowNumber, 1], (double)table[rowNumber, 2]);
        }


        static void printShippingCosts()
        {
            if (totalPrice > 25)
            {
                Console.WriteLine("Versandkosten \t\t\t\t\t\t\t\t\t" + 0 + "€");
            }
            else if (totalPrice > 15)
            {
                Console.WriteLine("Versandkosten \t\t\t\t\t" + Math.Round(2.95 * 0.19, 2) + "€\t\t\t\t" + 2.95 + "€");
                totalTaxes = totalTaxes + 2.95 * 0.19;
                totalPrice = totalPrice + 2.95;
            }
            else
            {
                Console.WriteLine("Versandkosten \t\t\t\t\t" + Math.Round(5.95 * 0.19, 2) + "€\t\t\t\t" + 5.95 + "€");
                totalTaxes = totalTaxes + 5.95 * 0.19;
                totalPrice = totalPrice + 5.95;
            }
        }

        static void coverLetter()
        {
            string name = "Frau Mustermann";
            string date = "05.09.2021";
            Console.WriteLine("Hallo " + name + @",
Hiermit übersende ich ihnen die Rechnung für meine Leistungen am " + date + @". 
Vielen Dank, dass Sie unsere Dienste genutzt haben.

Mit freundlichen Grüßen
Junus Ergin");
        }


        static void showPrice(string productName, int amount, double price)
        {
            double total = amount * price;
            totalPrice = totalPrice + total;
            
            
            double taxes = total * 0.19;
            totalTaxes = totalTaxes + taxes;


            Console.WriteLine(productName + "\t\t" + amount + "\t\t" + Math.Round(taxes, 2) + "€\t\t" + Math.Round(price, 2)+ "€\t\t" + total + "€");
        }

    }
}
