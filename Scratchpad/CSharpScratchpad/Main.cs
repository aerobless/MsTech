﻿using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Something
{
	class MainClass
	{
		static void Main (string[] args)
		{
			/*
			Parameters parameters = new Parameters ();
			parameters.Run ();

			Various various = new Various ();
			various.Run ();

			Classes classes = new Classes ();
			classes.Run ();

			Inheritance inheritance = new Inheritance ();
			inheritance.Run ();

			AbstractInheritance abstractInheritance = new AbstractInheritance ();
			abstractInheritance.Run ();
		
			AnonDelegateWithLambda anonDelegateWithLambda = new AnonDelegateWithLambda ();
			anonDelegateWithLambda.Run ();*/

			//EventTest test = new EventTest ();
		
			//string res = 'a'.ToString ();
			//Console.WriteLine (res);

			var kunden = new Kunde[] {
				new Kunde () { KId = 1, Name = "Muster" },
				new Kunde () { KId = 2, Name = "Schneider" }
			};

			var bestellungen = new List<Bestellung> ();
			Bestellung best = new Bestellung () { BId = 100, Datum = "11-Jan-09", KId = 1 };
			best.AddItem (new BestellItem () {
				IId = 1,
				Produkt = "Schraube",
				Anzahl = 100,
				Preis = 12.5F
			});
			best.AddItem (new BestellItem () {
				IId = 2,
				Produkt = "Mutter",
				Anzahl = 100,
				Preis = 2.5F
			});
			bestellungen.Add (best);
			best = new Bestellung () { BId = 101, Datum = "12-Jan-09", KId = 1 };
			best.AddItem (new BestellItem () { IId = 1, Produkt = "Unterlagscheibe", Anzahl = 100, Preis = 1.5F });
			bestellungen.Add (best);
			best = new Bestellung () { BId = 103, Datum = "12-Jan-09", KId = 2 };
			best.AddItem (new BestellItem () { IId = 1, Produkt = "Nagel", Anzahl = 500, Preis = 8.5F });
			best.AddItem (new BestellItem () {
				IId = 2,
				Produkt = "Haken",
				Anzahl = 400,
				Preis = 4.1F
			});
			bestellungen.Add (best);
			best = new Bestellung () { BId = 104, Datum = "13-Jan-09", KId = 2 };
			best.AddItem (new BestellItem () { IId = 1, Produkt = "Hammer", Anzahl = 5, Preis = 25.5F });
			bestellungen.Add (best);
			best = new Bestellung () { BId = 105, Datum = "14-Jan-09", KId = 2 };
			best.AddItem (new BestellItem () { IId = 1, Produkt = "Zange", Anzahl = 5, Preis = 55.5F });
			best.AddItem (new BestellItem () {
				IId = 2,
				Produkt = "Schraubenzieher",
				Anzahl = 10,
				Preis = 35.4F
			});
			bestellungen.Add (best);
		
			var q = from b in bestellungen
			        from p in b.Items
			        select new
			{
				p.Produkt,
				PreisSumme = p.Anzahl * p.Preis
			};

			//Console.WriteLine ("\nAufgabe b)\n");
			foreach (var foo in q) {
				//Console.WriteLine (foo);
			}

			string[] fullNames = { "Fritz Jakob Müller", "Gabi Keller" };

			IEnumerable<string> query = fullNames
				.SelectMany (fName => fName.Split ().Select (name => new { name, fName }))
				.OrderBy (x => x.fName)
				.ThenBy (x => x.name)
				.Select (x => x.name + " came from " + x.fName);

			IEnumerable<string> query2 = 
				from fullName in fullNames
				from name in fullName.Split ()
				orderby fullName, name
				select name + " came from " + fullName;

			foreach (var foo in query2) {
				Console.WriteLine (foo);
			}

		}
	}

	public class Kunde
	{
		public int KId { get; set; }

		public string Name { get; set; }
	}


	public class Bestellung
	{
		private List<BestellItem> items = new List<BestellItem> ();

		public int BId { get; set; }

		public string Datum { get; set; }

		public List<BestellItem> Items { get { return items; } }

		public int KId { get; set; }

		public void AddItem (BestellItem item)
		{
			Items.Add (item);
		}
	}

	public class BestellItem
	{
		public int Anzahl { get; set; }

		public int BId { get; set; }

		public int IId { get; set; }

		public double Preis { get; set; }

		public string Produkt { get; set; }
	}
		
}
