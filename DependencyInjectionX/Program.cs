using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionX
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger;

            string loggerType = "Text";

            switch (loggerType)
            {
                case "database":
                    logger = new DataBaseLogger(loggerType);
                    break;
                 default:
                    logger = new TextLogger("Text Lonnger");
                    break;


            }

            LogMangaer logMangaer = new LogMangaer(logger);
            try
            {
                throw new DivideByZeroException();
            }
            catch (Exception e)
            {
                logMangaer.Log(e.Message);
                Console.ReadKey();
            }

        }
    }
   
    interface ILogger
    {
        void Log(String message);

        


    }

    class LogMangaer
    {
        private ILogger _logger;
        // Constructur Injection
        public LogMangaer(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(String message)
        {
            _logger.Log(message);
        }


    }

    class TextLogger: ILogger
    {
        private string v;

        public TextLogger(string v)
        {
            this.v = v;
        }

        public void Log(String message)
        {
            Console.WriteLine("Log to a text file");
        }
    }

    

    class DataBaseLogger : ILogger
    {
        private string loggerType;

        public DataBaseLogger(string loggerType)
        {
            this.loggerType = loggerType;
        }

        public void Log(String message)
        {
            Console.WriteLine("Log to database");
        }
    }
}
