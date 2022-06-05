using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Text.Json;
using System.IO;


namespace Dane
{
    public class Logger
    {
        private static List<Ball> balls;
        private Stopwatch stopwatch = new Stopwatch();

        public Logger(List<Ball> b)
        {
            balls = b;
            Thread t = new Thread(() =>
            {
                stopwatch.Start();
                while (true)
                {
                    if (stopwatch.ElapsedMilliseconds >= 10)
                    {
                       stopwatch.Restart();
                       using (StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + "\\logger.txt", true))
                       {
                           string stamp = ($"Log started {DateTime.Now:r}");
                           foreach (Ball ball in balls)
                           {
                               writer.WriteLine(stamp + JsonSerializer.Serialize(ball));
                           }
                       }

                    }
                }
            })
            {
                IsBackground = true
            };
            t.Start();
        }

        public void stop()
        {
            stopwatch.Reset();
            stopwatch.Stop();
        }
    }
}
