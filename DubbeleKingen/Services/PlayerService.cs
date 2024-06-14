using DubbeleKingen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using System.Text.Json;
using System.Net.Http;
using DubbeleKingen.Models.Receptibles;

namespace DubbeleKingen.Services
{
    public class PlayerService
    {
        string baseUrl = "https://dubbelkingen-default-rtdb.europe-west1.firebasedatabase.app/";
        string goodlink = "https://dubbelkingen-default-rtdb.europe-west1.firebasedatabase.app/testplayers.json";

        private readonly ChildQuery query;
        HttpClient client;


        public PlayerService()
        {
            client = new();

            string path = "testplayers";
            query = new FirebaseClient(baseUrl).Child(path);
        }

        /// <summary>
        /// Gets all players from database.
        /// </summary>
        /// <returns></returns>
        public async Task<PlayerRoot?> GetPlayers()
        {
            try
            {
                var sourceGenOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    TypeInfoResolver = PlayerContext.Default
                };

                var response = await client.GetAsync(goodlink);

                PlayerRoot? players;
                if (response.IsSuccessStatusCode)
                {
                    var test = await response.Content.ReadAsStringAsync();
                     players = JsonSerializer.Deserialize<PlayerRoot>(test);
                    return players;
                }
            }
            catch(Exception ex)
            { await Shell.Current.DisplayAlert("Fout", ex.Message, "OK"); }
            return null;
        }

        /// <summary>
        /// Makes i amount of empty players.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public async Task<List<Player>?> GetPlaceholderPlayers(int i)
        {
            List<Player> players = new();
            for (int j = 0; j < i; j++)
            {
                players.Add(new(j+1));
            }
            return players;
        }

        public async Task<bool> MakeNewPlayer(string input)
        { 
            var root = await GetPlayers();

            if (root == null || string.IsNullOrEmpty(input))
                return false;

            // Does player exist?
            foreach (Player p in root.players)
            {
                if (p.Name == input)
                {
                    await Shell.Current.DisplayAlert("Fout", "De speler bestaat al", "OK");
                    return false;
                }
            };
            root.players.Add(new(root.players.Count, input));

            // Try pushing to DB
            try
            {
                await query.PutAsync(root);
                return true;
            }
            catch (Exception ex)
            { 
                await Shell.Current.DisplayAlert("Fout", ex.Message, "OK"); 
                return false; 
            }

        }
    }
}
    