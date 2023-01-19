using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.LoadBalancer
{
	public class Description
	{

		private int dataSet;
		private int id;
		private List<Item> items;

		public Description()
		{
			items = new List<Item>(2);
			DataSet = -1;
		}
		public Description(int ID)
		{
			id = ID;
			items = new List<Item>(2);
			DataSet = -1;
		}
		~Description()
		{

		}


		public List<Item> GetItems()
		{
			List<Item> temp = new List<Item>();
			foreach (Item i in items)
			{
				temp.Add(i);
			}
			return temp;
		}

		public void AddItem(Item it)
		{
			items.Add(it);
			Console.WriteLine($"[LOAD BALANCER: Description ID:{id}|DATASET:{-1}||Item CODE:{it.Code}|Value:{it.Value} added to items]");
		}



		public int NumberOfItems()
		{
			return items.Count;
		}
		public int DataSet { get => dataSet; set => dataSet = value; }
		public int Id { get => id; set => id = value; }
		public List<Item> Items { get => items; set => items = value; }

		public bool AddToItems(Item it)
		{
			if (items.Count == 0)
			{
				items.Add(it);
				Console.WriteLine($"[LOAD BALANCER: Description ID:{id}|DATASET:{-1}||Item CODE:{it.Code}|Value:{it.Value} added to items]");
				return true;
			}
			else if (it.Code == 1 && items[0].Code == 2 && items.Count != 2)
			{
				items.Add(it);
				DataSet = 1;
				Console.WriteLine($"[LOAD BALANCER: Description ID:{id}|DATASET:{dataSet}||Item CODE:{it.Code}|Value:{it.Value} added to items]");
				return true;
			}
			else if (it.Code == 2 && items[0].Code == 1 && items.Count != 2)
			{
				items.Add(it);
				DataSet = 1;
				Console.WriteLine($"[LOAD BALANCER: Description ID:{id}|DATASET:{dataSet}||Item CODE:{it.Code}|Value:{it.Value} added to items]");
				return true;
			}
			else if (it.Code == 3 && items[0].Code == 4 && items.Count != 2)
			{
				items.Add(it);
				DataSet = 2;
				Console.WriteLine($"[LOAD BALANCER: Description ID:{id}|DATASET:{dataSet}||Item CODE:{it.Code}|Value:{it.Value} added to items]");
				return true;
			}
			else if (it.Code == 4 && items[0].Code == 3 && items.Count != 2)
			{
				items.Add(it);
				DataSet = 2;
				Console.WriteLine($"[LOAD BALANCER: Description ID:{id}|DATASET:{dataSet}||Item CODE:{it.Code}|Value:{it.Value} added to items]");
				return true;
			}
			else if (it.Code == 5 && items[0].Code == 6 && items.Count != 2)
			{
				items.Add(it);
				DataSet = 3;
				Console.WriteLine($"[LOAD BALANCER: Description ID:{id}|DATASET:{dataSet}||Item CODE:{it.Code}|Value:{it.Value} added to items]");
				return true;
			}
			else if (it.Code == 6 && items[0].Code == 5 && items.Count != 2)
			{
				items.Add(it);
				DataSet = 3;
				Console.WriteLine($"[LOAD BALANCER: Description ID:{id}|DATASET:{dataSet}||Item CODE:{it.Code}|Value:{it.Value} added to items]");
				return true;
			}
			else if (it.Code == 7 && items[0].Code == 8 && items.Count != 2)
			{
				items.Add(it);
				DataSet = 4;
				Console.WriteLine($"[LOAD BALANCER: Description ID:{id}|DATASET:{dataSet}||Item CODE:{it.Code}|Value:{it.Value} added to items]");
				return true;
			}
			else if (it.Code == 8 && items[0].Code == 7 && items.Count != 2)
			{
				items.Add(it);
				DataSet = 4;
				Console.WriteLine($"[LOAD BALANCER: Description ID:{id}|DATASET:{dataSet}||Item CODE:{it.Code}|Value:{it.Value} added to items]");
				return true;
			}
			else if (items.Count == 2)
			{
				Console.WriteLine($"[LOAD BALANCER: Description ID:{id}|DATASET:{dataSet} is full]");
				return false;
			}
			else
				return false;

		}
	}
}
