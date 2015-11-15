using System;
using System.Collections.Generic;
using System.Text;

namespace CVE_ExperimentEngine
{
    class Notification
    {
        public static void writeMessage(String message)
        {
            Console.Out.WriteLine(message);
        }

        public static void writeError(String message)
        {
            Console.Error.Write(message);
        }
    }
}
