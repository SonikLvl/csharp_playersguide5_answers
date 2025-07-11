//349 The Repeating Stream
Console.Title = "The Repeating Stream";

RecentNumbers recentNumbers = new RecentNumbers();
Random random = new Random();
Thread thread = new Thread(RandomNum);

thread.Start();
while (true) { 
    if (Console.ReadKey().Key == ConsoleKey.Enter)
    {
        if (recentNumbers.AreSame()) Console.Write("The are the same! ");
        else Console.Write("Nah ");
        Console.WriteLine(recentNumbers.FirstNum + " " + recentNumbers.SecondNum);
    
    }
}

void RandomNum()
{
    while (true) {
        Thread.Sleep(1000); //1 s

        int num = random.Next(10);
        Console.WriteLine(num);
        recentNumbers.Update(num);
    }
}
class RecentNumbers
{
    private readonly object _numberLock = new object();
    public int FirstNum { get; set; }
    public int SecondNum { get; set; }
    public void Update(int firstNum)
    {
        lock (_numberLock)
        {
        
        SecondNum = FirstNum;
        FirstNum = firstNum;
        }
    }
    public bool AreSame() => FirstNum == SecondNum;
}