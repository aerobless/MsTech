﻿using System;

namespace Something
{
	public class Various
	{
		public Various ()
		{
		}

		public void Run ()
		{
			//Why? I just wanted to use goto once in my live!
			gotoExample ();


		}

		static void gotoExample ()
		{
			int i = 0;
			gotoMarker:
			if (i == 0) {
				i = 1;
				Console.Out.WriteLine ("before goto");
				goto gotoMarker;
			} else {
				Console.Out.WriteLine ("after goto");
			}
		}
	}
}

