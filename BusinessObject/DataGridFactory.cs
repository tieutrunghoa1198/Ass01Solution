using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessObject
{
    public interface IDataGridFactory
    {
        ObservableCollection<object> CreateCollection();
    }

    public class CollectionFactory
    {
        public IDataGridFactory MyList { get; private set; }

        public CollectionFactory(string type)
        {
            switch (type)
            {
                case "product":
                    MyList = new ProductObject();
                    break;
                case "member":
                    MyList = new MemberObject();
                    break;
                case "order":
                    MyList = new OrderObject();
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
