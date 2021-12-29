using Core;
using UserInterface;

namespace Controller
{
    public class StregsystemController
    {
        private IStregsystem _stregsystemCore;
        private IStregsystemUI _stregsystemUI;
        public StregsystemCommandParser CommandParser;

        public StregsystemController(IStregsystemUI ui, IStregsystem stregsystemCore)
        {
            _stregsystemCore = stregsystemCore;
            _stregsystemUI = ui;
            CommandParser = new StregsystemCommandParser(ui, stregsystemCore);

            ui.CommandEntered += CheckCommand;
        }

        public void CheckCommand(string command)
        {
            if (command == "")
            {
                _stregsystemUI.DisplayGeneralError("Enter a valid command");
            }
            else if (command.StartsWith(":"))
            {
                CommandParser.AdminCommandParse(command);
            }
            else
            {
                CommandParser.CommandParse(command);
            }
        }
    }
}