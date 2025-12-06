

public class WorkHourCounter
{
    private static List<Worker> workers = new List<Worker>();
    private static List<int> AcceptedInputs = [1, 2, 3];
    public void Run()
    {
        while (true)
        {

            if (workers.Count() == 0)
            {
                Console.WriteLine("Syötä uusi ID-numero (5 numeroa)");
                int id = Convert.ToInt32(Console.ReadLine());

                if (id.ToString().Length != 5)
                {
                    Console.WriteLine("ID:n tulee olla viisinumeroinen!\n");
                    continue;
                }
                workers.Add(new Worker(id));
                Console.WriteLine("Käyttäjä lisätty onnistuneesti.\n");
                break;

            }
            else
            {
                Console.WriteLine("Syötä ID-numero");
                int existing_id = Convert.ToInt32(Console.ReadLine());

                foreach (Worker w in workers)
                {
                    if (w.Id != existing_id)
                    {
                        Console.WriteLine("ID:tä ei tunnistettu, yritä uudelleen");
                        continue;
                    }

                    else
                    {
                        Console.WriteLine("ID tunnistettu");
                        break;
                    }
                }
            }
        }
        while (true)
        {
            Console.WriteLine("1: Syötä tunteja\n2: Tulosta tunnit\n3: Kirjaudu ulos");
            int input = Convert.ToInt32(Console.ReadLine());

            //Tarkistetaan, että annettu luku on 1,2 tai 3
            if (!AcceptedInputs.Contains(input))
            {
                Console.WriteLine("Ei toimintoa, yritä uudelleen.");
                continue;
            }
            else if (input == 1)
            {
                workers[0].AddHours();
            }
            else if (input == 2)
            {
                Console.WriteLine(workers[0].ToString());
            }
            else if (input == 3)
            {
                Console.WriteLine("Kirjauduttu ulos");
                break;
            }
        }

    }
}
public class Worker
{
    public int Id { get; }
    public int Hours { get; private set; }

    public int WorkDays { get; private set; }

    public Worker(int id)
    {
        Id = id;
        Hours = 0;
        WorkDays = 0;
    }

    public void AddHours()
    {
        Console.WriteLine("Syötä tekemäsi tunnit, lopettaaksesi syötä 0");
        while (true)
        //while-loopin avulla työtuntien syöttö listaan, 0 keskeyttää.
        {
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 0)
            {
                break;
            }
            //Syötteen ollessa jokin kokonaisluku lisätään se tunteihin ja +1 työpäivä
            //per lisäys
            this.Hours += input;
            this.WorkDays += 1;
        }

    }

    public override string ToString()
    {
        if(this.Hours> 0)
        {
        return "ID-numero: " + Id + " Tunnit: " + Hours + " Ka: " + Hours/WorkDays;    
        }
        return "Ei tulostettavaa\n";
    }

}