using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using StarwarsTheme.Domain;
using StarwarsTheme.Domain.Films;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace StarwarsTheme.Test.Quizing
{
    public static class QuizingConstans
    {
        #region NEW HOPE
        public static readonly Guid NEW_HOPE_ID = new Guid("6896cd62-d509-4ec5-aee4-f8b704832fa5");
        public const int NEW_HOPE_EPISODE_ID = 4;
        public const string NEW_HOPE_TITLE = "A new hope";
        public const string NEW_HOPE_DIRECTOR = "George Lucas";
        public static readonly ReleaseDate NEW_HOPE_RELEASEDATE = ReleaseDate.Parse("1977-05-25");
        public static readonly Film NEW_HOPE_FILM = new Film(
            new FilmId(NEW_HOPE_ID),
            new FilmInfo(NEW_HOPE_TITLE,
                NEW_HOPE_DIRECTOR,
                NEW_HOPE_EPISODE_ID,
                
                NEW_HOPE_RELEASEDATE
            ));
        #endregion NEW HOPE
        #region EMPIRE STRIKES BACK
        public static readonly Guid EMPIRE_STRIKES_BACK_ID = new Guid("93bb4a91-c442-4068-9aa6-20cc50db38b3");
        public const string EMPIRE_STRIKES_BACK_TITLE = "The empire strikes back";
        public const int EMPIRE_STRIKES_BACK_EPISODE_ID = 5;
        public const string EMPIRE_STRIKES_BACK_DIRECTOR = "Irvin Kershner";
        public static readonly ReleaseDate EMPIRE_STRIKES_BACK_RELEASEDATE = ReleaseDate.Parse("1980-05-17");
        public static readonly Film EMPIRE_STRIKES_BACK_FILM = new Film(
            new FilmId(EMPIRE_STRIKES_BACK_ID),
            new FilmInfo(EMPIRE_STRIKES_BACK_TITLE,
                EMPIRE_STRIKES_BACK_DIRECTOR,
                EMPIRE_STRIKES_BACK_EPISODE_ID,
                EMPIRE_STRIKES_BACK_RELEASEDATE
            ));
        #endregion EMPIRE STRIKES BACK
        #region RETURN OF THE JEDI
        public static readonly Guid RETURN_OF_THE_JEDI_ID = new Guid("ab8f53b1-3786-4cdc-a7a1-3530e6ffd8a5");
        public const string RETURN_OF_THE_JEDI_TITLE = "Empire strikes back";
        public const int RETURN_OF_THE_JEDI_EPISODE_ID = 6;
        public const string RETURN_OF_THE_JEDI_DIRECTOR = "Richard Marquand";
        public static readonly ReleaseDate RETURN_OF_THE_JEDI_RELEASEDATE = ReleaseDate.Parse("1983-05-25");
        public static readonly Film RETURN_OF_THE_JEDI_FILM = new Film(
            new FilmId(RETURN_OF_THE_JEDI_ID),
            new FilmInfo(RETURN_OF_THE_JEDI_TITLE,
                RETURN_OF_THE_JEDI_DIRECTOR,
                RETURN_OF_THE_JEDI_EPISODE_ID,
                RETURN_OF_THE_JEDI_RELEASEDATE
            ));
        #endregion RETURN OF THE JEDI


        public static IReadOnlyCollection<Film> OLD_SAGA_FILM_LIST = new List<Film>
        {
            NEW_HOPE_FILM,
            EMPIRE_STRIKES_BACK_FILM,
            RETURN_OF_THE_JEDI_FILM
        };


    }
}
