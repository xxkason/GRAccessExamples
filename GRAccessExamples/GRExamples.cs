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
        private string _nodeName = Environment.MachineName;
        private bool _loggedIn = false;

        public IGalaxy _galaxy;

        public bool GetGalaxy(string galaxyName, string username = "", string password = "")
        {
            if (_loggedIn == true)
            {
                throw new 
            }
            if (string.IsNullOrEmpty(galaxyName))
            {
                throw new InvalidConfiguration("Galaxy name cannot be empty");
            }

            //GRAccess object
            GRAccessApp grAccess = new GRAccessAppClass();

            //Retrieve all galaxies from this machine
            IGalaxies gals = grAccess.QueryGalaxies(_nodeName);

            //If there's no galaxies or we failed to query
            if ((gals == null) || (!grAccess.CommandResult.Successful))
            {
                throw new GalaxyFetchFailure("Unable to get galaxies, is this running on the GR node?");
            }

            //Try and select our desired galaxy
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

            //We're all happy, we've got a galaxy and logged into it, let the user know
            _loggedIn = true;
            return true;
        }

        public void LogoutGalaxy()
        {
            if (_loggedIn)
            {
                _galaxy.Logout();
                _loggedIn = false;
            }
        }

        public bool CheckOut(string objectName, bool isTemplate)
        {
            return false;
        }

        public bool AddLimitAlarm(string objectName, string attributeName)
        {
            return false;
        }
    }
}
