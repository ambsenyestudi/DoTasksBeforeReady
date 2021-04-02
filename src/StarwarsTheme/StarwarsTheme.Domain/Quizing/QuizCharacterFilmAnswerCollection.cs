using StarwarsTheme.Domain.Filrms;
using System.Collections.Generic;
using System.Linq;

namespace StarwarsTheme.Domain.Quizing
{
    public class QuizCharacterFilmAnswerCollection
    {
        private List<QuizCharacterFilmAnswer> quizAnswerList;

        public QuizCharacterFilmAnswerCollection(
            IEnumerable<Film> filmCollection, 
            QuizId quizId)
        {
            this.quizAnswerList = filmCollection.Select(fm => new QuizCharacterFilmAnswer(quizId, fm.Info)).ToList();
        }

        public EpisodeIdCollection ToEpisodeIdCollection()
        {
            return new EpisodeIdCollection(quizAnswerList.Select(x => x.FilmInfo.EpisodeId));
        }
    }
}