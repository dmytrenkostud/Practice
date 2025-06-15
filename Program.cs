
using Practice;
using System.Text.Json;


class Program
{
    
    static void Main()
    {
        BidirectionalList bidirectionalList = new BidirectionalList();
        
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Add item");
        Console.WriteLine("2. Remove item");
        Console.WriteLine("3. Print list");
        Console.WriteLine("4. Search");
        Console.WriteLine("5. Serialize");
        Console.WriteLine("6. Deserialize");
        Console.WriteLine("7. Sort");
        Console.WriteLine("0. Exit");

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    try
                    {
                        Console.WriteLine("Sport (Tennis, Football, Basketball, Hockey): ");
                        SportType sport = Enum.Parse<SportType>(Console.ReadLine());

                        Console.WriteLine("Weight: ");
                        float weight = float.Parse(Console.ReadLine());

                        Console.WriteLine("Professional Grade(True or False): ");
                        bool proGrade = bool.Parse(Console.ReadLine());

                        SportsEquipment newSE = new SportsEquipment(sport, weight, proGrade);
                        bidirectionalList.InsertMiddle(newSE);

                        Console.WriteLine("Item added.\n");
                        bidirectionalList.PrintList();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid value entered!"); 
                    
                    }
                    break;
                
                case "2":
                    try
                    {
                        Console.WriteLine("Element index: ");
                        int index = int.Parse(Console.ReadLine());
                        bidirectionalList.RemoveAt(index);
                        Console.WriteLine("Item removed.");
                        bidirectionalList.PrintList();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;
                case "3":
                    bidirectionalList.PrintList();
                    break;
                case "4":
                    List<SportsEquipment> list = bidirectionalList.Search();
                    Console.WriteLine("Found items: ");
                    if (list.Count != 0)
                    {
                        foreach (var element in list)
                        {
                            Console.WriteLine(element.String());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No items found.");
                    }
                    break;
                case "5":
                    if (bidirectionalList.count != 0)
                    {
                        string json = JsonSerializer.Serialize(bidirectionalList.ToList(), new JsonSerializerOptions
                        {
                            WriteIndented = true
                        });
                    
                        File.WriteAllText("output.json", json);
                        Console.WriteLine("Serialization Done!");
                    }
                    else
                    {
                        Console.WriteLine("No items found.");
                    }
                    break;
                
                case "6":
                    try
                    {
                        string json_file = File.ReadAllText("input.json");

                        List<SportsEquipment>? items = JsonSerializer.Deserialize<List<SportsEquipment>>(json_file);

                        if (items != null)
                        {
                            foreach (var element in items)
                            {
                                bidirectionalList.InsertMiddle(element);
                            }

                            Console.WriteLine("Deserialization Done!");
                        }
                        else
                        {
                            Console.WriteLine("Deserialization returned null!");
                        }

                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine("File not found!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                   
                    break;
                case "7":
                    if (bidirectionalList.count != 0)
                    {
                        bidirectionalList.BubbleSortByWeight();
                        bidirectionalList.PrintList();
                    }
                    else
                    {
                        Console.WriteLine("No items found.");
                    }
                    break;
                    
                case "0":
                    exit = true;
                    break;
            }  
        }

    }
}