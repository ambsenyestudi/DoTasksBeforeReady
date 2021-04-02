using System;

namespace StarwarsTheme.Domain
{
    public class EmptyCollectionException:Exception
    {
        public EmptyCollectionException(string message):base(message)
        {

        }
    }
}
