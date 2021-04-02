namespace StarwarsTheme.Domain.Quizing
{
    public class QuizCharacterFilmAnswerCollection
    {
        public EpisodeIdCollection ToEpisodeIdCollection()
        {
            return new EpisodeIdCollection(new int[] { 4, 5, 6 });
        }
    }
}