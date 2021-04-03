using System;

namespace StarwarsTheme.Domain.Characters
{
    public class IncompleteCharacterInformationException:Exception
    {
        public IncompleteCharacterInformationException(string message):base(message) 
        {
        }
    }
}
