using DubbeleKingen.Models;
using DubbeleKingen.Models.Receptibles;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DubbeleKingen.Services
{
    public class GameService
    {
        #region PROPERTIES

        private string goodUrl = "https://dubbelkingen-default-rtdb.europe-west1.firebasedatabase.app/games.json";
        private string baseUrl = "https://dubbelkingen-default-rtdb.europe-west1.firebasedatabase.app/";

        private HttpClient client;
        private readonly ChildQuery query;

        #endregion

        public GameService() 
        {
            client = new();

            string path = "games";
            query = new FirebaseClient(baseUrl).Child(path);
        }

        public async Task<GameRoot?> GetAllGames()
        {
            try
            {
                var sourceGenOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    TypeInfoResolver = GameContext.Default
                };

                var response = await client.GetAsync(goodUrl);

                GameRoot? players;
                if (response.IsSuccessStatusCode)
                {
                    var test = await response.Content.ReadAsStringAsync();
                    players = JsonSerializer.Deserialize<GameRoot>(test);
                    return players;
                }
            }
            catch (Exception ex)
                { await Shell.Current.DisplayAlert("Fout", ex.Message, "OK"); }
            return null;
            
        }

        public async Task SaveGame(Game current)
        {
            var gameList = await GetAllGames();

            GameRoot list = new() { games = new() };
            bool matched = false;

            // If exists already, replace.
            gameList?.games.ForEach(x =>
            {
                if (current.Id == x.Id)
                {
                    x = current;
                    matched = true;
                };
                list.games.Add(x);
            });

            if (!matched)
                list.games.Add(current);

            // Try pushing to DB
            try
            {
                await query.PutAsync(list);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Fout", ex.Message, "OK");
            }

        }
    }
}
