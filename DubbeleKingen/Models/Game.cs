using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DubbeleKingen.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int PlayerCount { get; set; }

        public Player[] Players { get; set; } = null!;
        // Dictionary <playerName,score>
        public Dictionary<string,int> Plus { get; set; } = null!;
        public Dictionary<string,int> Min { get; set; } = null!;

        public Game() {}
        [JsonConstructor]
        public Game(int id,string name, int playerCount, Player[] players, Dictionary<string,int> plus, Dictionary<string,int> min)
        {
            Id = id;
            Name = name;
            PlayerCount = playerCount;
            Players = players;
            Plus = plus;
            Min = min;
        }

    }
    [JsonSerializable(typeof(List<Game>))]
    internal sealed partial class GameContext : JsonSerializerContext
    {

    }
}
