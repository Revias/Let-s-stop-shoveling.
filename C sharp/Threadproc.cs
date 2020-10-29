using System;
using System.Threading;

class Site
{
    public string name;
    public Site(string aname) { name = aname; }
    
}


class Threadproc
{
    private static Site site = new Site("www.soen.co.kr");

    static void ThreadProc()
    {
        for (int i = 0; i < 100; i++)
        {
            lock (site)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("{0}에서 {1}% 다운로드 중", site.name, i);
                Thread.Sleep(1000);
            }
        }
    }
    static void DoSomthing()
    {
        string old = site.name;
        site.name = "www.loseapi";

        for (int i = 0; i < 100; i++)
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("{0}에서 {1}% 다운로드 중", site.name, i);
            Thread.Sleep(500);
        }
        site.name = old;
    }

    static void Main(string[] args)
    {
        Thread T = new Thread(new ThreadStart(ThreadProc));
        T.Start();
        Thread.Sleep(2000);
        lock (site)
        {
            DoSomthing();
        }
        /*
        for (;;)
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.A)
            {
                Console.Beep();
            }
            if (cki.Key == ConsoleKey.B)
            {
                break;
            }
        }
        Console.WriteLine("주 쓰레드 종료");
        */
    }
}