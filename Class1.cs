using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    public class Appliance
    {
        public int applianceId;
        public string name;
        public Appliance(string name,int id)
        {
            this.name = name;
            this.applianceId = id;
        }
    }
    public class Fan : Appliance{
        public Fan(string name,int n) : base(name,n){ }
    }
    public class AC : Appliance {
        public AC(string name,int n) : base(name,n) { }
    }
    public class Bulb : Appliance {
        public Bulb(string name,int n) : base(name,n) { }
    }
    public class Switch
    {
        public int switchId;
        public bool state;
        public Switch(int id)
        {
            this.switchId = id;
            this.state = false;
        }

    }
    public class Operations
    {
        public int getIntInput()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        public List<Appliance> CreateDevices(int fan, int ac, int bulb)
        {
            List<Appliance> Device = new List<Appliance>();
            int id = 1;
            for (int i = 1; i <= fan; i++)
            {
                Device.Add(new Fan("Fan" + " " + (i.ToString()),id));
                id = id + 1;
            }
            for (int i = 1; i <= ac; i++)
            {
                Device.Add(new AC("AC" + " " + (i.ToString()),id));
                id = id + 1;
            }
            for (int i = 1; i <= bulb; i++)
            {
                Device.Add(new Bulb("Bulb" + " " + (i.ToString()),id));
                id = id + 1;
            }
            return Device;
        }
        public List<Switch> CreateSwitches(int sum)
        {
            List<Switch> switches = new List<Switch>();
            for(int i = 1; i <= sum; i++)
            {
                switches.Add(new Switch(i));
            }
            return switches;
        }
        public bool getStatebyId(List<Switch> s,int id)
        {
            foreach (Switch sw in s)
            {
                if(sw.switchId == id)
                {
                    return (sw.state);
                }
            }
            return false;
        }
        public string getStateString(bool s) {
            return s ? "On" : "Off";
        }
        public string getNamebyId(List<Appliance> device,int id) {
            foreach(Appliance a in device)
            {
                if (a.applianceId == id)
                {
                    return a.name;
                }
            }
            return "Not found";
        }
        public void changeState(List<Switch> s,int id)
        {
            foreach (Switch sw in s)
            {
                if (sw.switchId == id)
                {
                    sw.state = !sw.state;
                }
            }
        }
    }
}
