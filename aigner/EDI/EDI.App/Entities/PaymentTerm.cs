using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
    public class PaymentTerm
    {
        /// <summary>
        /// 0330 PAT Payment terms basis
        /// 4279 Payment terms type qualifier M an..3
        ///
        /// 22 Discount
        /// </summary>
        public string TypeQualifier { get; set; }
        /// <summary>
        /// C112 Terms/time information C - 2475 Payment time reference, coded M an..3
        ///
        /// 5 Date of invoice
        /// </summary>
        public string TimeReferenceCode { get; set; }
        /// <summary>
        /// C112 Terms/time information C - 2009 Time relation, coded C an..3
        ///
        /// 3 After reference
        /// </summary>
        public string TimeRelationCode { get; set; }
        /// <summary>
        /// C112 Terms/time information C - 2151 Type of period, coded C an..3
        ///
        /// D Day
        /// </summary>
        public string TypeOfPeriod { get; set; }
        /// <summary>
        /// C112 Terms/time information C - 2152 Number of periods C n..3
        ///
        /// Number of periods (e.g. days) of the type indicated in data element 2151
        /// </summary>
        public string NumberOfPeriod { get; set; }
        /// <summary>
        /// 0350 18 PCD C 1 2 Percentage details
        /// C501 Percentage details M - 5245 Percentage qualifier M an..3
        ///
        /// Discount
        /// </summary>
        public string PercentageQualifier { get; set; }
        /// <summary>
        /// 0350 18 PCD C 1 2 Percentage details
        /// C501 Percentage details M - 5482 Percentage C n..10
        ///
        /// </summary>
        public string Percentage { get; set; }

        public void init(Loop_PAT_ORDERS patOrders)
        {
            TypeQualifier = patOrders.PAT.Paymenttermstypequalifier_01;
            TimeReferenceCode = patOrders.PAT.TERMSTIMEINFORMATION_03.Paymenttimereferencecoded_01;
            TimeRelationCode = patOrders.PAT.TERMSTIMEINFORMATION_03.Timerelationcoded_02;
            TypeOfPeriod = patOrders.PAT.TERMSTIMEINFORMATION_03.Typeofperiodcoded_03;
            NumberOfPeriod = patOrders.PAT.TERMSTIMEINFORMATION_03.Numberofperiods_04;

        }
        public void init(Loop_PAT_INVOIC patInvoices)
        {
            TypeQualifier = patInvoices.PAT.Paymenttermstypequalifier_01;
            TimeReferenceCode = patInvoices.PAT.TERMSTIMEINFORMATION_03.Paymenttimereferencecoded_01;
            TimeRelationCode = patInvoices.PAT.TERMSTIMEINFORMATION_03.Timerelationcoded_02;
            TypeOfPeriod = patInvoices.PAT.TERMSTIMEINFORMATION_03.Typeofperiodcoded_03;
            NumberOfPeriod = patInvoices.PAT.TERMSTIMEINFORMATION_03.Numberofperiods_04;
            PercentageQualifier = patInvoices.PCD.PERCENTAGEDETAILS_01.Percentagequalifier_01;
            Percentage = patInvoices.PCD.PERCENTAGEDETAILS_01.Percentage_02;

        }
        public void init(Loop_PAT_ORDCHG patOrders)
        {
            TypeQualifier = patOrders.PAT.Paymenttermstypequalifier_01;
            TimeReferenceCode = patOrders.PAT.TERMSTIMEINFORMATION_03.Paymenttimereferencecoded_01;
            TimeRelationCode = patOrders.PAT.TERMSTIMEINFORMATION_03.Timerelationcoded_02;
            TypeOfPeriod = patOrders.PAT.TERMSTIMEINFORMATION_03.Typeofperiodcoded_03;
            NumberOfPeriod = patOrders.PAT.TERMSTIMEINFORMATION_03.Numberofperiods_04;

        }
        public void init(Loop_PAT_ORDRSP patOrdrsps)
        {
            TypeQualifier = patOrdrsps.PAT.Paymenttermstypequalifier_01;
            TimeReferenceCode = patOrdrsps.PAT.TERMSTIMEINFORMATION_03.Paymenttimereferencecoded_01;
            TimeRelationCode = patOrdrsps.PAT.TERMSTIMEINFORMATION_03.Timerelationcoded_02;
            TypeOfPeriod = patOrdrsps.PAT.TERMSTIMEINFORMATION_03.Typeofperiodcoded_03;
            NumberOfPeriod = patOrdrsps.PAT.TERMSTIMEINFORMATION_03.Numberofperiods_04;

        }
    }
}
