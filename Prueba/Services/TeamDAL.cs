using Prueba.Models;
using SQLite;
using System.Collections.Generic;
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

        public static async Task<List<Team>> getAllTeam()
        {
            var query = conn.Table<Team>();
            List<Team> resultTeams = await query.ToListAsync();
            return resultTeams;
        }

        public static async void cleanDatabase()
        {
            await conn.DropTableAsync<Team>();
            createDatabase();
        }
    }
}
