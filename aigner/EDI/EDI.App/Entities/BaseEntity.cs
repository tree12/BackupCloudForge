using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.App.Entities
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime ModifiedDate { get; set; }

		public String CreateUser { get; set; }
		public String ModifiedUser { get; set; }
	}
}
