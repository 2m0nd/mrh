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
            Helper.AddToMetadataBuildNumber("AssemblyMetaInformation.cs", "2244");
        }
    }
}
