using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitApp.Services
{
    internal class PrintingServices
    {
        public void Print()
        {
            DateTime startTime = DateTime.UtcNow;
            TimeSpan future = TimeSpan.FromSeconds(8);
            while(DateTime.UtcNow-startTime < future) {
                Debug.WriteLine("Delay :"+DateTime.Now.ToString("hh:mm:ss"));
            }
            Debug.WriteLine("Delay Over");
        }

        public Task PrintAsync1() {
            return Task.Run(Print);
        }

        public Task<string> PrintAsync2() 
        {
            return Task.Run(() =>
            {
                Print();
                Random random = new Random();
                return "Success ->" + random.Next(1,10);
            });
        }
    }
}
