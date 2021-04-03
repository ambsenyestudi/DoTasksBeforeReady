using StarwarsTheme.Domain.Characters;

namespace StarwarsTheme.Domain.Quizing.CharacterEyeColors
{
    public record CharacterEyeColorAnswer
    {
        public QuizId Id { get; }
        public string EyeColor { get; }
        public CharacterEyeColorAnswer(QuizId id, Character character)
        {
            Id = id;
            EyeColor = character.Info.EyeColor;
        }
        public CharacterEyeColorAnswer(QuizId id, string eyeColor) =>  (Id, EyeColor) = (id, eyeColor);

    }
}