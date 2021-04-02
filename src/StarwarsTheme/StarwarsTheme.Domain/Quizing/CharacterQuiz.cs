using StarwarsTheme.Domain.Characters;

namespace StarwarsTheme.Domain.Quizing
{
    public class CharacterQuiz
    {
        public QuizId Id { get; set; }
        public CharacterInfo Info { get; set; }
        public int EpsiodeId { get; set; }
    }
}
