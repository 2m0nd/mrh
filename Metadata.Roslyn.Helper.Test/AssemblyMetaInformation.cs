using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.ProjectName.Meta
{
    public static class AssemblyMetaInformation
    {
        //public const string RcPostfix = " " + "RC3";
		public const string BuildNumber = "0";
        public const string RcPostfix = "";

        public const string AssemblyVersion = "0.2.2." + BuildNumber;
        public const string AssemblyFileVersion = AssemblyVersion + RcPostfix;
        public const string ProductName = "Title";
    }
}
