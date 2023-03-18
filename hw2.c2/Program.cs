using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClockspace
{
    public delegate void TickHandler(object sender, TickEventArgs e);
    public delegate void AlarmHandler(object sender, AlarmEventArgs e);
    public class TickEventArgs{ }  
    public class AlarmEventArgs{ }
    public class AlarmClock
    {
        public event TickHandler OnTick;
        public event AlarmHandler AlarmTriggers;
        public void Tick1()
        {
            Console.WriteLine("Alarm Clock Starts! ");
            Console.WriteLine("It is ticking....");
            TickEventArgs args = new TickEventArgs();
            OnTick(this, args);
        }
        public void Alarm1() 
        {
            AlarmEventArgs args = new AlarmEventArgs();
            AlarmTriggers(this, args);
        }
    }
    public class Form
    {
        public AlarmClock clock1= new AlarmClock();
        public Form() 
        {
            clock1.OnTick += new TickHandler(alarm_OnTick);
            clock1.AlarmTriggers += new AlarmHandler(alarm_Alarm);
        }
        void alarm_OnTick(object sender, TickEventArgs e)
        {
            Console.Write("Time now is: ");
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(1000);
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ticking ends up.");
        }
        void alarm_Alarm(object sender, AlarmEventArgs e)
        {
            Thread.Sleep(4500);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.Write("  <Alarm Clock Rings! ! !>  \n");
            Console.Write("And numbers turn blue.... ");
        }
    }
    class Mainclass
    {
        static void Main(string[] args)
        {
            Form f = new Form();
            Parallel.Invoke(
                ()=>f.clock1.Tick1(),
                ()=>f.clock1.Alarm1()
            );
        }
    }
}