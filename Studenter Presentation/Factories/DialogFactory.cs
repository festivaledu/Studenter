using Studenter.Logic;
using Studenter.Presentation.Views;

namespace Studenter.Presentation.Factories
{
    public static class DialogFactory
    {
        public static IDialog CreateInstance(ILogicQueries logicQueries, ILogicCommands logicCommands) {
            var aboutView = new AboutView();

            var mainView = new MainView(aboutView);

            return mainView;
        }
    }
}
