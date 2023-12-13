using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeTermsOfDeliveryOrTransportFunctionCode : BaseCodeEntity<CodeTermsOfDeliveryOrTransportFunctionCode>
    {

        public override string CodeDefinitionText => @"  1     Price condition
              Specifies a condition related to the price which a
              seller must fulfil before the buyer will complete a
              purchase.

     2     Despatch condition
              Condition requested by the customer under which the
              supplier shall deliver: Extent of freight costs, means
              of transport.

|    3     Price and despatch condition
              Condition related to price and despatch that the seller
              must complete before the customer will agree payment.

     4     Collected by customer
              Indicates that the customer will pick up the goods at
              the supplier. He will take care of the means of
              transport.

     5     Transport condition
              Specifies the conditions under which the transport takes
              place under the responsibility of the carrier.

     6     Delivery condition
              Specifies the conditions under which the goods must be
              delivered to the consignee.";

        public override string StringCodeDefinitionText { get; }
    }
}
