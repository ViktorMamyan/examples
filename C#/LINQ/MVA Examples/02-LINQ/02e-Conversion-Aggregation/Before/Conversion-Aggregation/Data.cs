using System;
using System.Collections.Generic;

namespace Conversion_Aggregation
{
	static class Data
	{
		public static List<Customer> Customers
		{
			get
			{
				var customers = new List<Customer>
				{
					new Customer{ FirstName="Johnson",LastName="Smith",City="Menlo Park",Orders=89326 },
					new Customer{ FirstName="Marjorie",LastName="Jones",City="Oakland",Orders=45538 },
					new Customer{ FirstName="Cheryl",LastName="Carson",City="Berkeley",Orders=31758 },
					new Customer{ FirstName="Michael",LastName="O'Leary",City="San Jose",Orders=39727 },
					new Customer{ FirstName="Dean",LastName="Straight",City="Oakland",Orders=83821 },
					new Customer{ FirstName="Meander",LastName="Smith",City="Lawrence",Orders=60805 },
					new Customer{ FirstName="Abraham",LastName="Bennet",City="Berkeley",Orders=31607 },
					new Customer{ FirstName="Ann",LastName="Dull",City="Palo Alto",Orders=71446 },
					new Customer{ FirstName="Burt",LastName="Gringlesby",City="Covelo",Orders=82164 },
					new Customer{ FirstName="Charlene",LastName="Locksley",City="San Francisco",Orders=7577 },
					new Customer{ FirstName="Morningstar",LastName="Greene",City="Nashville",Orders=81015 },
					new Customer{ FirstName="Reginald",LastName="Blotchet-Halls",City="Corvallis",Orders=82779 },
					new Customer{ FirstName="Akiko",LastName="Yokomoto",City="Walnut Creek",Orders=69618 },
					new Customer{ FirstName="Innes",LastName="del Castillo",City="Ann Arbor",Orders=78921 },
					new Customer{ FirstName="Michel",LastName="DeFrance",City="Gary",Orders=19906 },
					new Customer{ FirstName="Dirk",LastName="Stringer",City="Oakland",Orders=65342 },
					new Customer{ FirstName="Stearns",LastName="MacFeather",City="Oakland",Orders=98659 },
					new Customer{ FirstName="Livia",LastName="Karsen",City="Oakland",Orders=10599 },
					new Customer{ FirstName="Sylvia",LastName="Panteley",City="Rockville",Orders=50465 },
					new Customer{ FirstName="Sheryl",LastName="Hunter",City="Palo Alto",Orders=96008 },
					new Customer{ FirstName="Heather",LastName="McBadden",City="Vacaville",Orders=17811 },
					new Customer{ FirstName="Anne",LastName="Ringer",City="Salt Lake City",Orders=84188 },
					new Customer{ FirstName="Albert",LastName="Ringer",City="Salt Lake City",Orders=29525 }
				};
				return customers;
			}
		}
	}

	class Customer
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string City { get; set; }
		public int Orders { get; set; }

		public override string ToString()
		{
			return string.Format("{0}, {1} {2} {3}",
				LastName, FirstName, City, Orders);
		}
	}
}
