using System;
using System.Collections.Generic;
using System.Diagnostics;

// Definieren Sie einen Delegate-Typ Comparer
// mit derselben Signatur wie die untenstehenden Funktionen 
// CompareFraction bzw CompareString
//
delegate int Comparer<T>(T x, T y);

/// <summary>
/// einfacher Referenztyp für das Rechnen mit Bruechen 
/// </summary>
class Fraction 
{
	public int a, b;
	public Fraction(int a, int b) { this.a = a; this.b = b; }
	//ueberladene Methode System.Object.ToString
	public override string ToString() { return a + "/" + b; }
}

class Test 
{ 
	//statische Methode zum Vergleichen zweier Brueche x und y
	// Resultat 0: x = y; Resultat -1: x < y; Resultat +1: x > y
	//Signatur muss mit Delegate Comparer übereinstimmen
	static int CompareFraction(Fraction x, Fraction y) 
	{
		Fraction f1 = x;
		Fraction f2 = y;
		float fract1 = (float)f1.a / f1.b;
		float fract2 = (float)f2.a / f2.b;
		if (fract1 < fract2) return -1;
		else if (fract1 > fract2) return 1;
		else return 0;
	}
  
	//statische Methode zum Vergleichen zweier strings x und y
	// Resultat 0: x = y; Resultat -1: x < y; Resultat +1: x > y
	//Signatur muss mit Delegate Comparer übereinstimmen
	static int CompareString(String x, String y) 
	{
		return x.CompareTo(y);
	}

	//Generische Sort-Methode zum Sortieren von beliebigen Arrays a
	//compare ist eine Delegate-Instanz und enthaelt die Referenz (=Funktionszeiger)
	//auf eine Compare-Funktion fuer den aktuellen Elementtyp des Arrays
	static void Sort<T>(T[] a, Comparer<T> compare) 
	{

//		Ueberpruefen Sie folgende Vorbedingung
//	    compare muss genau eine Methode referenzieren (kein Multicast)
//		Sie koennen dazu die Methode Debug.Assert verwenden (siehe Help)

		Debug.Assert (compare != null && compare.GetInvocationList().Length == 1, "genau eine Vergleichsfunktion");

		// selection sort
		for (int i = 0; i < a.Length-1; i++) 
		{
			int min = i;
			for (int j = i+1; j < a.Length; j++) 
			{
				if (compare(a[j], a[min]) < 0) min = j;
			}
			if (min != i) { T x = a[i]; a[i] = a[min]; a[min] = x; }
		}
	}
  
	public static void Main() 
	{
		Fraction[] a = { new Fraction(1,2), new Fraction(3,4), new Fraction(4,8), new Fraction(8,3)};
		string[] b = {"pears", "apples", "oranges", "bananas", "plums"};

//		Sortieren Sie den Array a mit der Sort-Methode
		Sort(a, new Comparer<Fraction>(CompareFraction));

		//Ausgabe des sortierten Arrays a
		foreach (Fraction f in a) Console.Write(f + " ");
		Console.WriteLine();

//		Sortieren Sie den Array b mit der Sort-Methode
		Sort(b, new Comparer<String>(CompareString));

		//Ausgabe des sortierten Arrays b
		foreach (string s in b) Console.Write(s + " ");
		Console.WriteLine();

        //Exercise 2.2
        List<Fraction> fracList = new List<Fraction>(a);
        fracList.Sort(CompareFraction);
        fracList.ForEach(Console.WriteLine);

        //Convert the Fraction List to a String List
        List<String> someList = fracList.ConvertAll(i => i.ToString());
        Console.Out.WriteLine(someList);

		//End
		Console.WriteLine("Press Enter to Exit");
		Console.ReadLine();
	}
}

