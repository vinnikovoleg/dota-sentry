using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotaSentry.Client.Business.DataAccess.Interfaces;
using DotaSentry.Client.Models;

namespace DotaSentry.Client.Business.DataAccess
{
    public class HeroesRepository : BaseRepository, IHeroesRepository
    {
        public HeroesRepository(JsonClient jsonClient)
            : base(jsonClient)
        {
        }

        public async Task<List<Hero>> GetHeroesAsync()
        {
            var url = $"{Host}/api/heroes/";
            return await JsonClient.GetAsync<List<Hero>>(url);
        }
    }
}
