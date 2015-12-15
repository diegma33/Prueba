using Prueba.Models;
using Prueba.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Prueba.ViewModels
{
    public class TeamViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Team> _teamsWebServices;
        public ObservableCollection<Team> TeamsWebServices
        {
            get
            {
                return _teamsWebServices;
            }
            set
            {
                _teamsWebServices = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("TeamsWebServices"));
            }
        }

        private ObservableCollection<Team> _teamsBD;
        public ObservableCollection<Team> TeamsBD
        {
            get
            {
                return _teamsBD;
            }
            set { _teamsBD = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("TeamsBD"));
            }
        }

        public TeamViewModel()
        {
        }

        public void cleanBD()
        {
            TeamDAL.cleanDatabase();
            int count = TeamsBD.Count;
            for (int it = 0; it < count; it++)
            {
                TeamsBD.RemoveAt(0);
            }
        }

        public void saveAll()
        {
            foreach (Team t in TeamsWebServices)
            {
                if (!TeamsBD.Contains(t))
                {
                    TeamsBD.Add(t);
                    TeamDAL.insertTeam(t);
                }

            }
        }

        public void saveTeam(Team t)
        {
            if (!TeamsBD.Contains(t))
            {
                TeamsBD.Add(t);
                TeamDAL.insertTeam(t);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
