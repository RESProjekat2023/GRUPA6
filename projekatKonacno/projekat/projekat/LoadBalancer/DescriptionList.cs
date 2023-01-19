using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.LoadBalancer
{
	public class DescriptionList
	{

		public List<Description> descriptions;

		public DescriptionList()
		{
			descriptions = new List<Description>();
		}

		~DescriptionList()
		{

		}


		public bool CheckIsIdFree(int id)
		{
			foreach (Description d in descriptions)
			{
				if (d.Id == id)
					return false;
			}
			return true;
		}



		public List<int> TakenIDs()
		{
			List<int> taken = new List<int>();
			foreach (Description d in descriptions)
			{
				taken.Add(d.Id);
			}
			return taken;
		}


		public int Funkcija(int code) 
		{
			foreach (Description d in descriptions)
			{

				if (d.DataSet == -1) 
				{
					foreach (Item it in d.GetItems())
					{
						if (it.Code == 1 & code == 2)
						{
							d.DataSet = 1;
							return d.Id;
						}
						if (it.Code == 2 & code == 1)
						{
							d.DataSet = 1;
							return d.Id;
						}
						if (it.Code == 3 & code == 4)
						{
							d.DataSet = 2;
							return d.Id;
						}
						if (it.Code == 4 & code == 3)
						{
							d.DataSet = 2;
							return d.Id;
						}
						if (it.Code == 5 & code == 6)
						{
							d.DataSet = 3;
							return d.Id;
						}
						if (it.Code == 6 & code == 5)
						{
							d.DataSet = 3;
							return d.Id;
						}
						if (it.Code == 7 & code == 8)
						{
							d.DataSet = 4;
							return d.Id;
						}
						if (it.Code == 8 & code == 7)
						{
							d.DataSet = 4;
							return d.Id;
						}
					}
				}
			}
			return -1;
		}


		public Description NadjiPoDataSetu()
		{
			foreach (Description d in descriptions)
			{
				if (d.DataSet != -1)
				{
					return d;
				}
			}
			return null;
		}


		public void AddToList(Description d)
		{
			descriptions.Add(d);
		}

	}
}
