using Portal.Common.Entity.Abstracts;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Common.Attributes;

namespace EDI.DataAccess.Entities
{
    public class RequestLog : EntityObjectWithConfig<RequestLog, int>
	{
		[MaxLength(36)]
		public string Identity { get; set; }
		[MaxLength(45)]
		public string IpAddress { get; set; }
		public string Request { get; set; }
        public string OutDirection { get; set; }

        public override void Configure(EntityTypeBuilder<RequestLog> b)
        {
			b.Property(x => x.Id).HasColumnType("int");
            b.Ignore(p => p.Deleted);
		}
    }
}
