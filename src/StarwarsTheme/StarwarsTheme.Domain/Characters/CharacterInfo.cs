namespace StarwarsTheme.Domain.Characters
{
    public record CharacterInfo
    {
        public string Name { get; }
        public string EyeColor { get; }
        public CharacterInfo(string name, string eyeColor) => (Name, EyeColor) = (name, eyeColor);
    }
}
