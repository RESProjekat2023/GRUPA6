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
            foreach(Item i in items)
            {
                temp.Add(i);
            }
            return temp;
        }

        public void AddItem(Item it)
        {
            items.Add(it);
        }

        public int NumberOfItems()
        {
            return items.Count;
        }

        public int DataSet
        {
            get => dataSet;
            set => dataSet = value;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }
        public List<Item> Items
        {
            get => items;
            set => items = value;
        }

        public bool AddToItems(Item it)
        {
            /* TO DO */
            return false;
        }
    }
}
