using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WPFQuestionnaire.Models;
using System.Configuration;
using System.Data.Entity.ModelConfiguration;

namespace WPFQuestionnaire.DBContext
{
    class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ResultQuestionnaire> ResultQuestionnaires { get; set; }
        public DbSet<Question> Questions { get; set; }

        public Context() : base(ConfigurationManager.ConnectionStrings["MyDbConnect"].ToString()) { }
    }
}
