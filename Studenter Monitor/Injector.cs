using System;
using System.Windows;
using Studenter.Data.Factories;
using Studenter.Logic;
using Studenter.Logic.Factories;

namespace Studenter.Monitor
{
    internal class Injector
    {
        private IDataReader dataReader = null;
        private IDataWriter dataWriter = null;
        private string sourcePath;

        internal void Run() {
            sourcePath = @"G:\Studium\Komponentenbasierte Softwareentwicklung\Studenter\resources\database.accdb";

            try {
                dataReader = DataReaderFactory.CreateInstance(sourcePath);
                dataReader.InitDb();

                dataWriter = DataWriterFactory.CreateInstance(sourcePath);
                dataWriter.InitDb();

                var queries = LogicQueriesFactory.CreateInstance(dataReader);
                var commands = LogicCommandsFactory.CreateInstance(dataWriter);

                var app = new Application();
                app.Run();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Studenter", MessageBoxButton.OK, MessageBoxImage.Error);
            } finally {
                if (dataReader != null) {
                    dataReader.CloseDb();
                }

                if (dataWriter != null) {
                    dataWriter.CloseDb();
                }
            }
        }
    }
}
