using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace InterviewProblemSet
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestsOnConsole();
        }

        private static void RunTestsOnConsole()
        {
            var sb = new StringBuilder();

            var solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\..\\"));
            var xunitPath = solutionPath + @"packages\xunit.runner.console.2.1.0\tools\xunit.console.exe";
            var xunitArgs = solutionPath + @"InterviewProblemSet\bin\Debug\InterviewProblemSet.exe -verbose";

            var psi = new ProcessStartInfo(xunitPath, xunitArgs);
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;

            Process p = new Process();

            // redirect the output
            // hookup the eventhandlers to capture the data that is received
            p.OutputDataReceived += (sender, stringArgs) => sb.AppendLine(stringArgs.Data);
            p.ErrorDataReceived += (sender, stringArgs) => sb.AppendLine(stringArgs.Data);

            // direct start
            p.StartInfo = psi;

            p.Start();
            // start our event pumps
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();

            // until we are done
            p.WaitForExit();

            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }
    }
}
