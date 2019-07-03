using Studenter.Logic;
using Studenter.Presentation.Views;

namespace Studenter.Presentation.Factories
{
    public static class DialogFactory
    {
        public static IDialog CreateInstance(ILogicQueries logicQueries, ILogicCommands logicCommands) {
            var mainView = new MainView();

            return mainView;
        }
    }
}
