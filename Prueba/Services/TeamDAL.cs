using Prueba.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Services
{
    static class TeamDAL
    {
        private static SQLiteAsyncConnection conn = new SQLiteAsyncConnection("teams");

        public static async void createDatabase()
        {
            await conn.CreateTableAsync<Team>();
        }

        public static async void insertTeam(Team team)
        {
            await conn.InsertAsync(team);
        }

        public static async void getTeam(String name)
        {
            var query = conn.Table<Team>().Where(x => x.name == name);
            var result = await query.ToListAsync();
            foreach (var item in result)
            {
                Debug.WriteLine(string.Format("{0}: {1} {2}", item.id, item.name, item.imgPath));
            }
        }

        public static async Task<List<Team>> getAllTeam()
        {
            var query = conn.Table<Team>();
            List<Team> resultTeams = await query.ToListAsync();
            foreach (var item in resultTeams)
            {
                Debug.WriteLine(string.Format("{0}: {1} {2}", item.id, item.name, item.imgPath));
            }
            return resultTeams;
        }
    }
}
