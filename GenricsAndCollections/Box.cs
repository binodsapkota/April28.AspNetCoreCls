using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenricsAndCollections
{
    public class Box
    {
        

		private object _data;

		public object Data
		{
			get { return _data; }
			set { _data = value; }
		}


	}

    public class GenericBox<T>
    {
        private T _data;
        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
