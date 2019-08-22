using System;
using System.Windows;
using Studenter.Data.Factories;
using Studenter.Logic;
using Studenter.Logic.Factories;
using Studenter.Presentation.Factories;

namespace Studenter.Monitor
{
    internal class Injector
    {
        private IDataReader dataReader;
        private IDataWriter dataWriter;
        private string sourcePath;

        internal void Run() {
            sourcePath = @"C:\Users\Fabian\Documents\Visual Studio 2017\Projects\Studenter\resources\database.accdb";

            try {
                dataReader = DataReaderFactory.CreateInstance(sourcePath);
                dataReader.InitDb();

                dataWriter = DataWriterFactory.CreateInstance(sourcePath);
                dataWriter.InitDb();

                var queries = LogicQueriesFactory.CreateInstance(dataReader);
                var commands = LogicCommandsFactory.CreateInstance(dataWriter);

                var dialog = DialogFactory.CreateInstance(queries, commands);

                var app = new Application();
                app.Run(dialog as Window);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Studenter", MessageBoxButton.OK, MessageBoxImage.Error);
            } finally {
                dataReader?.CloseDb();
                dataWriter?.CloseDb();
            }
        }
    }
}
