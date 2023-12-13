using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EDI.DataAccess.Entities.Attributes;
using EDI.DataAccess.Entities.Interfaces;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Common.Attributes;
using Portal.Common.Entity.Abstracts;
using Portal.Common.Entity.Interfaces;

namespace EDI.DataAccess.Entities
{
	[AuditLog]
	public abstract class BaseEdiObject<TEntity> : BaseObject<TEntity, int> where TEntity: EntityObjectWithConfig<TEntity, int>
	{
        private static ILog ediConversionErrorLog = LogManager.GetLogger("Edi.Conversion.Error");

		public bool HasEdiConvertError { get; set; }
		public string EdiConvertErrorMessage { get; set; }
     
		public void AddEdiConvertError(string message)
		{
			HasEdiConvertError = true;
			if (EdiConvertErrorMessage == null)
				EdiConvertErrorMessage = message;
			else
				EdiConvertErrorMessage = "\n" + EdiConvertErrorMessage;

			try
			{
				throw new DataAccess.EdiConvertException(message);
			}
			catch (EdiConvertException ex)
			{
				ediConversionErrorLog.Error(message, ex);
			}
		}
        public override void Configure(EntityTypeBuilder<TEntity> b)
        {
            b.Property(x => x.Id).HasColumnType("int");
            b.Ignore(p => p.Deleted);
            //b.Property(p => p.SSMA_TimeStamp).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate().HasColumnType("rowversion");
        }

	}

    public abstract class BaseObject<TEntity, IdType> : EntityObjectWithConfig<TEntity, IdType> where TEntity : class, IEntityObject<IdType>
	{
		[Timestamp]
		[NotSave]
        public byte[] SSMA_TimeStamp { get; set; }

	}

}