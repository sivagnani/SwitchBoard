using System;

/*public class Appliance
{
    public string state;
    public string name;
    Appliance(string n)
    {
        state = "off";
        name= n;
    }

}*/
public class Program
{
    static Dictionary<string,string> appliances = new Dictionary<string, string>();
    static string[] arr;
    public static void Main(string[] args)
    {
        Console.Write("Enter the number of Fans: ");
        int fan = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the number of ACs: ");
        int ac = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the number of Bulbs: ");
        int bulb = Convert.ToInt32(Console.ReadLine());
        int sum = fan + ac + bulb;
        arr = new string[sum];
        Create("Fan",fan);
        Create("AC",ac);
        Create("Bulb",bulb);
        int i = 0;
        foreach(KeyValuePair<string,string> kv in appliances)
        {
            arr[i] = kv.Key;
            i++;
        }
        Menu();
    }
    public static void Menu()
    {
        Console.WriteLine("MENU :");
        for(int i = 0; i < arr.Length;i++)
        {
            Console.WriteLine((i+1).ToString()+". "+arr[i]+" is \"" + appliances[arr[i]]+"\"");
        }
        Console.WriteLine((arr.Length+1).ToString() + ". " +"Exit");
        Console.Write("Select one option from the menu ");
        int op = Convert.ToInt32(Console.ReadLine());
        if(op <= arr.Length)
        {
            Edit(op);
        }
        else if (op == (arr.Length + 1))
        {
            Console.WriteLine("Exiting............");
        }
        else
        {
            Console.WriteLine("Please Enter valid Option");
        }        
    }
    public static void Edit(int op)
    {
        string state = (appliances[arr[op - 1]] == "Off" ? "On" : "Off");
        Console.WriteLine("1. " + "Switch " + arr[op - 1] +" "+ state);
        Console.WriteLine("2. " + "Back");
        Console.Write("Select One option from Above: ");
        int option = Convert.ToInt32(Console.ReadLine());
        if(option == 1) 
        {
            appliances[arr[op - 1]] = state;
            Menu();
        }
        else if(option == 2)
        {
            Menu();
        }
        else
        {
            Console.WriteLine("Please Enter valid Option");
        }
    }
    public static void Create(string device, int count)
    {
        for(int i=1; i<=count; i++)
        {
            string dev = device+" "+(i.ToString());
            appliances.Add(dev, "Off");
        }
    }
}