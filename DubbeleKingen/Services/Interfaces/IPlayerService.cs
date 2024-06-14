using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DubbeleKingen.Models;
using DubbeleKingen.Models.Receptibles;

namespace DubbeleKingen.Services
{
    public interface IPlayerService
    {
        Task<PlayerRoot?> GetPlayers();

        Task<List<Player>?> GetPlaceholderPlayers(int i);

        Task<bool> MakeNewPlayer(string input);
    }
}
