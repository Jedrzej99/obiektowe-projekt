using System;
using System.Collections.Generic;
using System.Linq;

class Pizza
{
    public string Nazwa { get; set; }
    public List<string> Składniki { get; set; }
    public double Cena { get; set; }

    public Pizza(string nazwa, List<string> składniki, double cena)
    {
        Nazwa = nazwa;
        Składniki = składniki;
        Cena = cena;
    }
}

class Zamówienie
{
    public List<Pizza> Pizze { get; set; }
    public List<string> Dodatki { get; set; }
    public double Cena { get; set; }

    public Zamówienie(List<Pizza> pizze, List<string> dodatki, double cena)
    {
        Pizze = pizze;
        Dodatki = dodatki;
        Cena = cena;
    }
}

class SymulatorPizzy
{
    static List<Pizza> Pizze = new List<Pizza>()
    {
        new Pizza("Margherita", new List<string>() { "sos pomidorowy", "ser mozzarella" }, 30),
        new Pizza("Pepperoni", new List<string>() { "sos pomidorowy", "ser mozzarella", "pepperoni" }, 35),
        new Pizza("Funghi", new List<string>() { "sos pomidorowy", "ser mozzarella", "pieczarki" }, 40),
        new Pizza("Capriciosa", new List<string>() { "sos pomidorowy", "ser mozzarella", "pieczarki", "kapary", "oliwki" }, 45),
        new Pizza("Quattro Formaggi", new List<string>() { "sos pomidorowy", "ser mozzarella", "gorgonzola", "camembert", "parmezan" }, 50),
        new Pizza("Vegetariana", new List<string>() { "sos pomidorowy", "ser mozzarella", "papryka", "cebula", "pomidor" }, 45),
        new Pizza("Calzone", new List<string>() { "sos pomidorowy", "ser mozzarella", "szynka", "pieczarki", "cebula" }, 40)
    };
    static List<string> Dodatki = new List<string>()
    {
        "sos czosnkowy", "sos BBQ", "keczup", "piwo", "cola", "tymbark", "mirinda", "7up", "grzaniec"
    };

    static Random rand = new Random();

    public static Zamówienie LosoweZamówienie()
    {
        List<Pizza> pizze = new List<Pizza>();
        double cena = 0;

        int liczbaPizz = rand.Next(1, 4);
        for (int i = 0; i < liczbaPizz; i++)
        {
            Pizza pizza = Pizze[rand.Next(Pizze.Count)];
            pizze.Add(pizza);
            cena += pizza.Cena;
        }

        List<string> dodatki = new List<string>();
        int liczbaDodatków = rand.Next(1, 4);
        for (int i = 0; i < liczbaDodatków; i++)
        {
            string dodatek = Dodatki[rand.Next(Dodatki.Count)];
            dodatki.Add(dodatek);
            cena += (dodatek.Contains("sos")) ? 3 : 7;
        }

        return new Zamówienie(pizze, dodatki, cena);
    }

    static void Main(string[] args)
    {
        Zamówienie zamówienie = LosoweZamówienie();
        Console.WriteLine("Zamówienie:");
        foreach (Pizza pizza in zamówienie.Pizze)
        {
            Console.WriteLine("- " + pizza.Nazwa + " (" + string.Join(", ", pizza.Składniki) + ") - " + pizza.Cena + " zł");
        }
        Console.WriteLine("Dodatki: " + string.Join(", ", zamówienie.Dodatki));
        Console.WriteLine("Suma: " + zamówienie.Cena + " zł");
    }
}

