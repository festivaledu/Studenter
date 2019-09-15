using Studenter.Logic;
using Studenter.Presentation.Services;
using Studenter.Presentation.ViewModels;
using Studenter.Presentation.Views;

namespace Studenter.Presentation.Factories
{
    public static class DialogFactory
    {
        public static IDialog CreateInstance(ILogicQueries logicQueries, ILogicCommands logicCommands) {
            var createService = new CreateStudentService(logicCommands);
            var searchService = new SearchStudentService(logicQueries);

            var mainVM = new MainViewModel(searchService);

            var createStudentVM = new CreateStudentViewModel(mainVM, createService, searchService);
            var searchResultsVM = new SearchResultsViewModel(mainVM, createService, searchService);
            var searchStudentVM = new SearchStudentViewModel(mainVM, searchService);

            var aboutView = new AboutView();
            var createStudentView = new CreateStudentView(createStudentVM);
            var searchResultsView = new SearchResultsView(searchResultsVM);
            var searchStudentView = new SearchStudentView(searchStudentVM);

            var mainView = new MainView(mainVM, aboutView, createStudentView, searchResultsView, searchStudentView);

            return mainView;
        }
    }
}
