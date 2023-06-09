using Microsoft.EntityFrameworkCore;
using BrainerHubDemoModel.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BrainerHubDemoModel.SpDbContext.StoreProcedureResult;

namespace BrainerHubDemoModel.SpDbContext
{
    /// <summary>
    /// POCSpContext
    ///</summary>
    public partial class POCSpContext : DbContext
    {
        /// <summary>
        /// POCSpContext
        ///</summary>
        public POCSpContext()
        {
        }
        /// <summary>
        /// Create
        ///</summary>

        public static POCSpContext Create(string connid)
        {
            if (!string.IsNullOrEmpty(connid))
            {
                //  var connStr = ConnectionStrings[connid];
                var optionsBuilder = new DbContextOptionsBuilder<POCSpContext>();
                optionsBuilder.UseSqlServer(connid);
                return new POCSpContext(optionsBuilder.Options);
            }
            else
            {
                throw new ArgumentNullException("ConnectionId");
            }
        }
        /// <summary>
        /// POCSpContext
        ///</summary>
        public POCSpContext(DbContextOptions<POCSpContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// ExecutreStoreProcedureResult virtual
        ///</summary>
        public virtual DbSet<ExecutreStoreProcedureResult> ExecutreStoreProcedureResult { get; set; }

        /// <summary>
        /// ExecutreStoreProcedureResultWithSID virtual
        ///</summary>
        public virtual DbSet<ExecutreStoreProcedureResultWithSID> ExecutreStoreProcedureResultWithSID { get; set; }

        /// <summary>
        /// ExecuteStoreProcedureResultWithId virtual
        ///</summary>
        public virtual DbSet<ExecuteStoreProcedureResultWithId> ExecuteStoreProcedureResultWithId { get; set; }

        /// <summary>
        /// ExecutreStoreProcedureResultList virtual
        ///</summary>
        public virtual DbSet<ExecutreStoreProcedureResultList> ExecutreStoreProcedureResultList { get; set; }

        /// <summary>
        /// ExecutreStoreProcedureResultWithEntitySID virtual
        ///</summary>
        public virtual DbSet<ExecutreStoreProcedureResultWithEntitySID> ExecutreStoreProcedureResultWithEntitySID { get; set; }


        /// <summary>
        /// OnConfiguring
        ///</summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }
        }
        /// <summary>
        /// GetOptions
        ///</summary>
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        /// <summary>
        /// OnModelCreating
        ///</summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region SP           
            modelBuilder.Entity<ExecutreStoreProcedureResult>().HasNoKey().Property(e => e.ErrorMessage).HasConversion<System.String>();
            modelBuilder.Entity<ExecutreStoreProcedureResultWithSID>().HasNoKey().Property(e => e.ErrorMessage).HasConversion<System.String>();
            modelBuilder.Entity<ExecutreStoreProcedureResultWithSID>().HasNoKey().Property(e => e.SID).HasConversion<System.String>();
            modelBuilder.Entity<ExecuteStoreProcedureResultWithId>().HasNoKey().Property(e => e.ErrorMessage).HasConversion<string>();
            modelBuilder.Entity<ExecuteStoreProcedureResultWithId>().HasNoKey().Property(e => e.Id).HasConversion<int>();
            modelBuilder.Entity<ExecutreStoreProcedureResultList>().HasNoKey().Property(e => e.ErrorMessage).HasConversion<System.String>();
            modelBuilder.Entity<ExecutreStoreProcedureResultWithEntitySID>().HasNoKey().Property(e => e.ErrorMessage).HasConversion<System.String>();

            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        /// <summary>
        /// OnModelCreatingPartial
        /// </summary>
        /// <param name="modelBuilder"></param>
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

