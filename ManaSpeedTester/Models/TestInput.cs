using System;
using System.Reflection;

namespace ManaSpeedTester.Models
{
    public class TestInput
    {
        public DateTime start { get; set; }
        public DateTime finish { get; set; }
        public MethodBase? method { get; set; }
        public dynamic[] data { get; set; }

        public TestInput()
        {

        }

        public TestInput(DateTime s, DateTime f, MethodBase? m, params dynamic[] d)
        {
            start = s;
            finish = f;
            method = m;
            data = d;
        }
    }
}
