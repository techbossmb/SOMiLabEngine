using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CVE_ExperimentEngine
{
    class LabVIEWTool
    {
        private class PInvoke
        {
            [DllImport("SOMLib.dll", EntryPoint = "SBTDaq", CallingConvention = CallingConvention.Cdecl)]
            public static extern double SBTDaq(double selector, double load);
        }
        public double callDll(double selector, double load)
        {
            
            double ret = PInvoke.SBTDaq(selector, load);
            return ret;
        }
    }
}
