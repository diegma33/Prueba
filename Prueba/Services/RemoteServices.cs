using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Xaml.Controls;

namespace Prueba.Services
{
    static class RemoteServices
    {
        public static List<Team> getTeams()
        {
            //List<Team> teamList2=testWebServices().Result;
            List<Team> teamList = new List<Team>();
            teamList.Add(new Team() { imgPath = "/Assets/almeria.jpg", name = "Almeria" });
            teamList.Add(new Team() { imgPath = "/Assets/atMadrid.png", name = "AtMadrid" });
            teamList.Add(new Team() { imgPath = "/Assets/barca.png", name = "Barca" });
            teamList.Add(new Team() { imgPath = "/Assets/espanyol.png", name = "Espanyol" });
            teamList.Add(new Team() { imgPath = "/Assets/levante.jpg", name = "Levante" });
            teamList.Add(new Team() { imgPath = "/Assets/realMadrid.jpg", name = "Real Madrid" });

            return teamList;
        }

        public static async void testWebServices(Object o)
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
                // Details in ex.Message and ex.HResult.       
            }

            JsonArray root = JsonArray.Parse(result);
            for(uint i= 0; i < root.Count; i++)
            {
                JsonObject h = root.GetObjectAt(i);
                try
                {
                    teamList.Add(new Team() { imgPath = h["image"].GetString(), name = h["name"].GetString() });
                }
                catch
                {
                    continue;       
                }

            }
            var settingsVal = root.GetObjectAt(0);
            httpClient.Dispose();
            (o as GridView).ItemsSource = teamList;
        }
    }
}
