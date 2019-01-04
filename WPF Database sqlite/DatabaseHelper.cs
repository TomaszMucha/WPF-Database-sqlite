using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    class DatabaseHelper
    {
        public static SQLiteConnection conn = new SQLiteConnection("Data Source=sqlite3.db;Version=3;New=False;Compress=True;");
    }
}
