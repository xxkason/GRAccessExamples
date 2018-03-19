using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRAccessExamples
{
    class GRAccessException : Exception
    {
        public GRAccessException()
        {

        }

        public GRAccessException(string message) : base(message)
        {

        }
    }

    class InvalidConfiguration : GRAccessException
    {
        public InvalidConfiguration()
        {

        }
        public InvalidConfiguration(string message) : base(message)
        {

        }
    }

    class GalaxyFetchFailure : GRAccessException
    {
        public GalaxyFetchFailure()
        {

        }

        public GalaxyFetchFailure(string message) : base(message)
        {

        }
    }

    class GalaxyNotExist : GRAccessException
    {
        public GalaxyNotExist()
        {

        }
    }

    class LoginFailure : GRAccessException
    {

    }
}
