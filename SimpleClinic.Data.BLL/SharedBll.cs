using SimpleClinic.Data.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Bll
{
    public class SharedBll
    {
        public static AppDbContext Db = new AppDbContext();
    }
}
