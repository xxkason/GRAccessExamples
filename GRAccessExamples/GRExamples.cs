using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchestrA.GRAccess;

namespace GRAccessExamples
{
    class GRExamples
    {
        public string NodeName
        {
            get
            {
                return Environment.MachineName;
            }
        }

        public IGalaxy _galaxy;

        public void getGalaxy(string galaxyName, string username = "", string password = "")
        {
            if (string.IsNullOrEmpty(galaxyName))
            {
                throw new InvalidConfiguration("Galaxy name cannot be empty");
            }

            //GRAccess object
            GRAccessApp grAccess = new GRAccessAppClass();

            //Retrieve all galaxies from this machine
            IGalaxies gals = grAccess.QueryGalaxies(this.NodeName);

            //If there's no galaxies or we failed to query
            if ((gals == null) || (!grAccess.CommandResult.Successful))
            {
                throw new GalaxyFetchFailure("Unable to get galaxies, is this running on the GR node?");
            }

            _galaxy = gals[galaxyName];

            if (_galaxy == null)
            {
                throw new GalaxyNotExist();
            }

            _galaxy.Login(username, password);

            if (!_galaxy.CommandResult.Successful)
            {
                throw new LoginFailure();
            }
        }
    }
}
