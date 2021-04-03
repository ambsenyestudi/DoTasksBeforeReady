using StarwarsTheme.Domain.Characters;

namespace StarwarsTheme.Domain.Quizing.CharacterEyeColors
{
    public class CharacterEyeColorQuiz
    {
        private const string HEADING_TEMPLATE = "What color are the eyes of {0}?";
        public QuizId Id { get; }
        public string Heading { get; set; }
        private CharacterEyeColorAnswer Answer { get; }

        internal CharacterEyeColorQuiz(QuizId id, Character character)
        {
            Id = id;
            Heading = string.Format(HEADING_TEMPLATE, character.Info.Name);
            Answer = new CharacterEyeColorAnswer(id, character);
        }
        public bool IsCorrectAnswer(CharacterEyeColorAnswer characterEyeColor)
        {
            if (characterEyeColor.Id != Answer.Id)
            {
                characterEyeColor = new CharacterEyeColorAnswer(Answer.Id, characterEyeColor.EyeColor);
            }
            return Answer == characterEyeColor;
        }
    }
}
