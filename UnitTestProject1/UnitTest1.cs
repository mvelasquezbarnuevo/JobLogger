using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestConsoleLog()
        {
            ILogDestination consoleWriterInjector = new ConsoleTest();
            ILogDestination fileWriterInjector = new FileTest();
            ILogDestination dataBaseWriterInjector = new DataBaseTest();

            var jobLogger = new JobLogger2(true, false, false);

            //aplicar ID x set
            jobLogger.LoggerConsole = consoleWriterInjector;
            jobLogger.LoggerFile = fileWriterInjector;
            jobLogger.LoggerDataBase = dataBaseWriterInjector;

            jobLogger.LogAsMessage("test");
            jobLogger.LogAsWarning("test");
            jobLogger.LogAsError("test");


            Assert.AreEqual(((DataBaseTest)dataBaseWriterInjector).GetResults().Count, 0);
            Assert.AreEqual(((FileTest)fileWriterInjector).GetResults().Count, 0);
            Assert.AreEqual(((ConsoleTest)consoleWriterInjector).GetResults().Count, 3);
        }

        [TestMethod]
        public void TestFileLog()
        {
            ILogDestination consoleWriterInjector = new ConsoleTest();
            ILogDestination fileWriterInjector = new FileTest();
            ILogDestination dataBaseWriterInjector = new DataBaseTest();

            var jobLogger = new JobLogger2(false, true, false);

            //aplicar ID x set
            jobLogger.LoggerConsole = consoleWriterInjector;
            jobLogger.LoggerFile = fileWriterInjector;
            jobLogger.LoggerDataBase = dataBaseWriterInjector;

            jobLogger.LogAsMessage("test");
            jobLogger.LogAsWarning("test");
            jobLogger.LogAsError("test");


            Assert.AreEqual(((DataBaseTest)dataBaseWriterInjector).GetResults().Count, 0);
            Assert.AreEqual(((FileTest)fileWriterInjector).GetResults().Count, 3);
            Assert.AreEqual(((ConsoleTest)consoleWriterInjector).GetResults().Count, 0);
        }

        [TestMethod]
        public void TestDataBaseLog()
        {
            ILogDestination consoleWriterInjector = new ConsoleTest();
            ILogDestination fileWriterInjector = new FileTest();
            ILogDestination dataBaseWriterInjector = new DataBaseTest();

            var jobLogger = new JobLogger2(false, false, true);

            //aplicar ID x set
            jobLogger.LoggerConsole = consoleWriterInjector;
            jobLogger.LoggerFile = fileWriterInjector;
            jobLogger.LoggerDataBase = dataBaseWriterInjector;

            jobLogger.LogAsMessage("test");
            jobLogger.LogAsWarning("test");
            jobLogger.LogAsError("test");


            Assert.AreEqual(((DataBaseTest)dataBaseWriterInjector).GetResults().Count, 3);
            Assert.AreEqual(((FileTest)fileWriterInjector).GetResults().Count, 0);
            Assert.AreEqual(((ConsoleTest)consoleWriterInjector).GetResults().Count, 0);
        }

    }
}
