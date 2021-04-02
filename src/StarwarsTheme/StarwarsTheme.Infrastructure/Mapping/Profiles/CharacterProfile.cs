﻿using AutoMapper;
using StarwarsTheme.Application.Characters;
using StarwarsTheme.Domain.Characters;
using StarwarsTheme.Infrastructure.Characters.Models;

namespace StarwarsTheme.Infrastructure.Mapping.Profiles
{
    public class CharacterProfile:Profile
    {
        public CharacterProfile()
        {
            CreateMap<CharacterInfo, CharacterDTO>();
            CreateMap<StarwarsCharacter, CharacterInfo>();
        }
        
    }
}
