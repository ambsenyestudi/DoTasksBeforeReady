using System.Linq;

namespace StarwarsTheme.Domain.Characters
{
    public record CharacterInfo
    {
        public static CharacterInfo Empty = new CharacterInfo(string.Empty, string.Empty);

        public string Name { get; }
        public string EyeColor { get; }

        public CharacterInfo(string name, string eyeColor) 
        {
            EnsureInfo(name, eyeColor);
            (Name, EyeColor) = (name, eyeColor);
        }

        public static bool TryCreate(string name, string eyeColor, out CharacterInfo characterInfo)
        {
            if(!IsValidInfo(name, eyeColor))
            {
                characterInfo = Empty;
                return false;
            }
            characterInfo = new CharacterInfo(name, eyeColor);
            return true;
        }

        private static void EnsureInfo(string name, string eyeColor)
        {
            if(!IsValidInfo(name, eyeColor))
            {
                throw new IncompleteCharacterInformationException("");
            }
        }

        private static bool IsValidInfo(params string[] infoList) =>
            infoList.All(inf => !string.IsNullOrWhiteSpace(inf));
    }
}
