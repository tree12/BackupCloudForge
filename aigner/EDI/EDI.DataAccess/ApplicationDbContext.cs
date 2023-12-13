using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Common.Entity.Base;
using Portal.Common.Entity.Interfaces;

namespace EDI.DataAccess
{
    public class ApplicationDbContext : DbContextBase
    {
        public DbSet<EdiInvoice> EdiInvoice { get; set; }
        public DbSet<EdiOrder> EdiOrder { get; set; }
        public DbSet<EdiOrderConfirmation> EdiOrderConfirmation { get; set; }
        public DbSet<EdiScheduleAgreement> EdiScheduleAgreement { get; set; }
        public DbSet<EdiDeliveryNote> EdiDeliveryNote { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor, IServiceProvider serviceProvider) : base(options, httpContextAccessor, serviceProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyDataAccessIEntityObject();
        }
    }
}