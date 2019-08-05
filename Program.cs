using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = "id";
            var regex = $@"(?<{key}>aa[\d]+)";
            var txt = @"aa12346578sdfafasdaa123fsdaa456werew";
            var value = Regex.Match(txt, regex).Groups[key].Value;
            var values = Regex.Matches(txt, regex).OfType<Match>()
                .Select(m => m.Groups[key].Value);

            using (var log = new EventLog())
            {
                log.Source = typeof(Program).FullName;
                log.WriteEntry(txt, EventLogEntryType.Error);
            }

            Console.WriteLine(string.Join(", ", values));
            Console.ReadLine();
        }
    }
}
