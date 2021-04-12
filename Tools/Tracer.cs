using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AssignmentASCLib.Tools
{
    public class Tracer
    {
        private static TraceSource ts = new TraceSource("Game Library");
        private static Tracer tracer = null;
        private static object _lock = new object();
        private Tracer()
        {
            ts.Switch = new SourceSwitch("Info", "All");
            TraceInfo(0, DateTime.Now.ToString());
            
        }

        public static Tracer GetTracer
        {
            get
            {
                lock (_lock)
                {
                    if (tracer == null)
                    {
                        tracer = new Tracer();
                    }
                    return tracer;
                }
            }
        }

        public void TraceInfo(int id, String message)
        {
            ts.Listeners.Add(new TextWriterTraceListener(new StreamWriter(@".\Tracer.txt", true)));
            ts.TraceEvent(TraceEventType.Information, id, message);
            ts.Close();
        }
    }
}
