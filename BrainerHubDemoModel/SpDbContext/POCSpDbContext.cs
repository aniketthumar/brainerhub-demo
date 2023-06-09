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
    /// POCSpDbContext
    /// </summary>
    public partial class POCSpDbContext : DbContext
    {
        /// <summary>
        /// POCSpDbContext
        ///</summary>
        public POCSpDbContext()
        {
        }
        /// <summary>
        /// Create
        ///</summary>

        public static POCSpDbContext Create(string connid)
        {
            if (!string.IsNullOrEmpty(connid))
            {
                //  var connStr = ConnectionStrings[connid];
                var optionsBuilder = new DbContextOptionsBuilder<POCSpDbContext>();
                optionsBuilder.UseSqlServer(connid);
                return new POCSpDbContext(optionsBuilder.Options);
            }
            else
            {
                throw new ArgumentNullException("ConnectionId");
            }
        }
        /// <summary>
        /// POCSpDbContext
        ///</summary>
        public POCSpDbContext(DbContextOptions<POCSpDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// ExecutreStoreProcedureStudentList
        /// </summary>
        public virtual DbSet<StudentListResponse> ExecutreStoreProcedureStudentList { get; set; }


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
           
            modelBuilder.Entity<StudentListResponse>().HasNoKey();


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
