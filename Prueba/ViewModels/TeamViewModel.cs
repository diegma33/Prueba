using Prueba.Common;
using Prueba.Models;
using Prueba.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.ViewModels
{
    public class TeamViewModel
    {
        private List<Team> _teams;
        public List<Team> Teams
        {
            get
            {
                return _teams;
            }
            set { _teams = value; }
        }

    }
}
