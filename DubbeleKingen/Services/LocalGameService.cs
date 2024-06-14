using DubbeleKingen.Models;
using DubbeleKingen.Models.Receptibles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Xml;

namespace DubbeleKingen.Services
{
    public class LocalGameService : IGameService
    {

         public LocalGameService()  
         {
            filePath = FileSystem.AppDataDirectory;
         }

        #region PROPERTIES

        StreamWriter writer;
        XmlWriter xmlWriter;
        
        string filePath;
        #endregion

        public Task<GameRoot?> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public Task SaveGame(Game current)
        {
            writer = new StreamWriter(filePath=);

            
            

            throw new NotImplementedException();
        }
    }
}
