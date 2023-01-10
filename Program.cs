using System;
using System.Collections;
using Home;
public class Program
{
    public static void Main(string[] args)
    {
        Operations obj = new Operations();
        Console.Write("Enter the number of Fans: ");
        int fan = obj.getIntInput();
        Console.Write("Enter the number of ACs: ");
        int ac = obj.getIntInput();
        Console.Write("Enter the number of Bulbs: ");
        int bulb = obj.getIntInput();
        int sum = fan + ac + bulb;
        List<Appliance> devices = new List<Appliance>();
        List<Switch> SwitchBoard = new List<Switch>();
        devices = obj.CreateDevices(fan,ac,bulb);
        SwitchBoard = obj.CreateSwitches(sum);
        string Oppstate;
        string name;
        int i = 1;
        while (true)
        {
            Console.WriteLine("MENU :");
            foreach(var a in devices)
            {
                string id = (a.applianceId).ToString();
                bool deviceState = obj.getStatebyId(SwitchBoard, a.applianceId);
                Console.WriteLine(id + ". " + a.name + " is \"" + obj.getStateString(deviceState) + "\"");
            }
            Console.WriteLine((sum+1).ToString() + ". " + "Exit");
            Console.Write("Select one option from the menu ");
            int op = obj.getIntInput();
            if (op <= sum)
            {
                name = obj.getNamebyId(devices,op);
                Oppstate = obj.getStateString(!obj.getStatebyId(SwitchBoard,op));
                Console.WriteLine("1. " + "Switch " + name + " " + Oppstate);
                Console.WriteLine("2. " + "Back");
                Console.Write("Select One option from Above: ");
                int option = obj.getIntInput();
                if (option == 1)
                {
                    obj.changeState(SwitchBoard,op);
                }
                else if (option == 2)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Please Enter valid Option");
                }

            }
            else if (op == (sum + 1))
            {
                Console.WriteLine("Exiting............");
                break;
            }
            else
            {
                Console.WriteLine("Please Enter valid Option");
            }
        }
    }
}