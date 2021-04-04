using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StarwarsTheme.Domain.Characters
{
    public class CharacterCollection:IEnumerable<Character>
    {
        private Dictionary<string, Character> characterNameDictionary = new Dictionary<string, Character>();
        private Dictionary<CharacterId, Character> characterIdDictionary = new Dictionary<CharacterId, Character>();
        
        public CharacterCollection(IEnumerable<Character> characters)
        {
            processCollection(characters);
        }
        private void processCollection(IEnumerable<Character> characters)
        {
            var characterList = characters.ToList();
            for (int i = 0; i < characterList.Count; i++)
            {
                var name = characterList[i].Info.Name;
                var id = characterList[i].Id;

                characterNameDictionary.Add(name, characterList[i]);
                characterIdDictionary.Add(id, characterList[i]);
            }
        }
        public Character GetBy(string name) => characterNameDictionary[name];
        public Character GetBy(CharacterId id) => characterIdDictionary[id];
        public IEnumerable<Character> AsEnumerable() =>
            characterNameDictionary.Values;

        public IEnumerator<Character> GetEnumerator() => characterNameDictionary.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool ContainsId(string id) => characterNameDictionary.ContainsKey(id);
    }
}
