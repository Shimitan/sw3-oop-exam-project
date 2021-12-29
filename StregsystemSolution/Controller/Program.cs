using Core;
using UserInterface;

namespace Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            IStregsystem core = new Stregsystem();
            IStregsystemUI ui = new StregsystemCLI(core);
            StregsystemController controller = new StregsystemController(ui, core);
            
            ui.Start();
        }
    }
}