namespace StarwarsTheme.Domain.Characters
{
    public class Character
    {
        public CharacterId Id { get; }
        public CharacterInfo Info { get; private set; }
        public Character(CharacterId id, CharacterInfo info)
        {
            Id = id;
            Info = info;
        }
        public override bool Equals(object obj)
        {
            if(obj is Character)
            {
                return false;
            }

            return Id == ((Character)obj).Id;
        }
        public override int GetHashCode() =>
            Id.GetHashCode() + Info.GetHashCode();
    }
}
