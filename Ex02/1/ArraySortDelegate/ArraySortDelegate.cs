using System;
using System.Diagnostics;

// TODO:
// Definieren Sie einen Delegate-Typ "Comparer"
// mit derselben Signatur wie die untenstehenden Funktionen 
// CompareFraction bzw CompareString
// delegate 
delegate int Comparer(object x, object y);

/// <summary>
/// Einfacher Referenztyp für das Rechnen mit Bruechen 
/// </summary>
class Fraction
{
    public int a, b;
    public Fraction(int a, int b) { this.a = a; this.b = b; }
    // Überladene Methode System.Object.ToString
    public override string ToString() { return a + "/" + b; }
}

class Program
{
    // Statische Methode zum Vergleichen zweier Brueche x und y
    // Resultat 0: x = y; Resultat -1: x < y; Resultat +1: x > y
    // Signatur muss mit Delegate "Comparer" übereinstimmen
    static int CompareFraction(object x, object y)
    {
        Fraction f1 = (Fraction)x;
        Fraction f2 = (Fraction)y;
        float fract1 = (float)f1.a / f1.b;
        float fract2 = (float)f2.a / f2.b;
        if (fract1 < fract2) return -1;
        else if (fract1 > fract2) return 1;
        else return 0;
    }

    // Statische Methode zum Vergleichen zweier strings x und y
    // Resultat 0: x = y; Resultat -1: x < y; Resultat +1: x > y
    // Signatur muss mit Delegate "Comparer" übereinstimmen
    static int CompareString(object x, object y)
    {
        return ((string)x).CompareTo(y);
    }

    // Generische Sort-Methode zum Sortieren von beliebigen Arrays a
    // compare ist eine Delegate-Instanz und enthaelt die Referenz (=Funktionszeiger)
    // auf eine Compare-Funktion fuer den aktuellen Elementtyp des Arrays
    static void Sort(object[] a, Comparer compare)
    {

        // TODO:
        // Überpruefen Sie folgende Vorbedingung
        // compare muss genau eine Methode referenzieren (kein Multicast)
        // Sie koennen dazu die Methode Debug.Assert verwenden (siehe Help)
        // Debug.Assert ...
        Debug.Assert(compare != null && compare.GetInvocationList().Length==1);

        // Selection sort
        for (int i = 0; i < a.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < a.Length; j++)
            {
                if (compare(a[j], a[min]) < 0) min = j;
            }
            if (min != i) { object x = a[i]; a[i] = a[min]; a[min] = x; }
        }
    }

    public static void Main()
    {
        Fraction[] a = { new Fraction(1, 2), new Fraction(3, 4), new Fraction(4, 8), new Fraction(8, 3) };
        string[] b = { "pears", "apples", "oranges", "bananas", "plums" };

        // TODO:
        // Sortieren Sie den Array a mit der Sort-Methode
        // Sort(...);
        Comparer comparer = new Comparer(CompareFraction);
        Sort(a, comparer);

        // Ausgabe des sortierten Arrays a
        foreach (Fraction f in a) Console.Write(f + " ");
        Console.WriteLine();

        // TODO:
        // Sortieren Sie den Array b mit der Sort-Methode
        // Sort(...);
        Comparer comparer2 = new Comparer(CompareString);
        Sort(b, comparer2);

        // Ausgabe des sortierten Arrays b
        foreach (string s in b) Console.Write(s + " ");
        Console.WriteLine();

        Console.WriteLine("Press Enter to Exit");
        Console.ReadLine();
    }
}

