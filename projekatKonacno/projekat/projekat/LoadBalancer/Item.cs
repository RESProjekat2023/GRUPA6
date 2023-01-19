using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.LoadBalancer
{
	public class Item
	{

		private int _code;
		private int _value;

		public Item()
		{

		}

		~Item()
		{

		}

		public int Code
		{
			get
			{
				return _code;
			}
			set
			{
				_code = value;
			}
		}

		public int Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

	}
}
