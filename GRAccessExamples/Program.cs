using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchestrA.GRAccess;

namespace GRAccessExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            GRExamples grExample = new GRExamples();

            grExample.getGalaxy("toolkittest");
        }
    }
}
