using CafedralReportingWPF.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Helpers
{
    class DbContextSingleton
    {
        private static Context _instance;

        private DbContextSingleton()
        { }

        public static Context GetContext()
        {
            if (_instance == null)
                _instance = new Context();
            return _instance;
        }
    }
}
