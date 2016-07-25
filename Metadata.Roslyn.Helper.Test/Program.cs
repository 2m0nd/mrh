using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metadata.Roslyn.Helper.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args?.Length != 2)
                throw new Exception("Need two arguments, 1 - metadata.cs path, 2-build number.");

            Helper.AddToMetadataBuildNumber(args[0], args[1]);
        }
    }
}
