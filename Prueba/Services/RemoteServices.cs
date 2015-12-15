using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Prueba.Services
{
    static class RemoteServices
    {
        public static async Task<List<Team>> getTeamWebServices()
        {
            List<Team> teamList = new List<Team>();
            Uri uri = new Uri("http://app.konacloud.io/api/team/players/teams");
            HttpClient httpClient = new HttpClient();
            String result="";
            try
            {
                result = await httpClient.GetStringAsync(uri);
            }
            catch
            {
                return null;    
            }

            JsonArray root = JsonArray.Parse(result);
            for(uint it= 0; it < root.Count; it++)
            {
                JsonObject item = root.GetObjectAt(it);
                try
                {
                    teamList.Add(new Team() { imgPath = item["image"].GetString(), name = item["name"].GetString() });
                }
                catch
                {
                    continue;       
                }

            }
            var settingsVal = root.GetObjectAt(0);
            httpClient.Dispose();
            return teamList;
        }
    }
}
