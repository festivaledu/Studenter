using System;

namespace Studenter.Monitor
{
    class Program
    {
        [STAThread]
        static void Main(string[] args) {
            new Injector().Run();
        }
    }
}
