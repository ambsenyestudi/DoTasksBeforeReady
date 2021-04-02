using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsTheme.Domain
{
    public class EmptyCollectionException:Exception
    {
        public EmptyCollectionException(string message):base(message)
        {

        }
    }
}
