using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DubbeleKingen.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        [JsonConstructor]
        public Player(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Player(int id)
        {
            Id = id;
            Name = $"Player {id}";
        }
    }
    [JsonSerializable(typeof(List<Player>))]
    internal sealed partial class PlayerContext : JsonSerializerContext
    {

    }
}
