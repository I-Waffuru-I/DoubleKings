using DubbeleKingen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DubbeleKingen.Models.Receptibles;

namespace DubbeleKingen.Services
{
    public interface IGameService
    {
        Task<GameRoot?> GetAllGames();

        Task SaveGame(Game current);
    }
}
