using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface IEdiPayment
    {
        /// <summary>
        /// 0330 PAT Payment terms basis
        /// 4279 Payment terms type qualifier M an..3
        ///
        /// 22 Discount
        /// </summary>
        public string PaymentTerm1_TypeQualifier { get; set; }

        /// <summary>
        /// 0330 PAT Payment terms basis - C110 Payment terms C
        /// 4277 Terms of payment identification M an..17
        ///
        /// 22 Discount
        /// </summary>
        public string PaymentTerm1_TermsOfPaymentIdentification { get; set; }
        /// <summary>
        /// 0330 PAT Payment terms basis - C110 Payment terms C
        /// 1131 Code list qualifier C an..3 N 
        ///
        /// Not used
        /// </summary>
        public string PaymentTerm1_CodeListQualifier { get; set; }
        /// <summary>
        /// 0330 PAT Payment terms basis - C110 Payment terms C
        /// 4276 Terms of payment C an..35 M an..35 
        ///
        /// This freetext needs to be filled.
        /// </summary>
        public string PaymentTerm1_TermsOfPayment { get; set; }
        /// <summary>
        /// C112 Terms/time information C - 2475 Payment time reference, coded M an..3
        ///
        /// 5 Date of invoice
        /// </summary>
        public string PaymentTerm1_TimeReferenceCode { get; set; }

        /// <summary>
        /// C112 Terms/time information C - 2009 Time relation, coded C an..3
        ///
        /// 3 After reference
        /// </summary>
        public string PaymentTerm1_TimeRelationCode { get; set; }

        /// <summary>
        /// C112 Terms/time information C - 2151 Type of period, coded C an..3
        ///
        /// D Day
        /// </summary>
        public string PaymentTerm1_TypeOfPeriod { get; set; }

        /// <summary>
        /// C112 Terms/time information C - 2152 Number of periods C n..3
        ///
        /// Number of periods (e.g. days) of the type indicated in data element 2151
        /// </summary>
        public int? PaymentTerm1_NumberOfPeriod { get; set; }

        /// <summary>
        /// 0350 18 PCD C 1 2 Percentage details
        /// C501 Percentage details M - 5245 Percentage qualifier M an..3
        ///
        /// Discount
        /// </summary>
        public string PaymentTerm1_PercentageQualifier { get; set; }

        /// <summary>
        /// 0350 18 PCD C 1 2 Percentage details
        /// C501 Percentage details M - 5482 Percentage C n..10
        ///
        /// </summary>
        public decimal? PaymentTerm1_Percentage { get; set; }

        /// <summary>
        /// Payment Term 2
        /// </summary>
        /// <summary>
        /// 0330 PAT Payment terms basis
        /// 4279 Payment terms type qualifier M an..3
        ///
        /// 22 Discount
        /// </summary>
        public string PaymentTerm2_TypeQualifier { get; set; }
        /// <summary>
        /// 0330 PAT Payment terms basis - C110 Payment terms C
        /// 4277 Terms of payment identification M an..17
        ///
        /// 22 Discount
        /// </summary>
        public string PaymentTerm2_TermsOfPaymentIdentification { get; set; }
        /// <summary>
        /// 0330 PAT Payment terms basis - C110 Payment terms C
        /// 1131 Code list qualifier C an..3 N 
        ///
        /// Not used
        /// </summary>
        public string PaymentTerm2_CodeListQualifier { get; set; }
        /// <summary>
        /// 0330 PAT Payment terms basis - C110 Payment terms C
        /// 4276 Terms of payment C an..35 M an..35 
        ///
        /// This freetext needs to be filled.
        /// </summary>
        public string PaymentTerm2_TermsOfPayment { get; set; }
        /// <summary>
        /// C112 Terms/time information C - 2475 Payment time reference, coded M an..3
        ///
        /// 5 Date of invoice
        /// </summary>
        public string PaymentTerm2_TimeReferenceCode { get; set; }

        /// <summary>
        /// C112 Terms/time information C - 2009 Time relation, coded C an..3
        ///
        /// 3 After reference
        /// </summary>
        public string PaymentTerm2_TimeRelationCode { get; set; }

        /// <summary>
        /// C112 Terms/time information C - 2151 Type of period, coded C an..3
        ///
        /// D Day
        /// </summary>
        public string PaymentTerm2_TypeOfPeriod { get; set; }

        /// <summary>
        /// C112 Terms/time information C - 2152 Number of periods C n..3
        ///
        /// Number of periods (e.g. days) of the type indicated in data element 2151
        /// </summary>
        public int? PaymentTerm2_NumberOfPeriod { get; set; }

        /// <summary>
        /// 0350 18 PCD C 1 2 Percentage details
        /// C501 Percentage details M - 5245 Percentage qualifier M an..3
        ///
        /// Discount
        /// </summary>
        public string PaymentTerm2_PercentageQualifier { get; set; }

        /// <summary>
        /// 0350 18 PCD C 1 2 Percentage details
        /// C501 Percentage details M - 5482 Percentage C n..10
        ///
        /// </summary>
        public decimal? PaymentTerm2_Percentage { get; set; }

        /// <summary>
        /// Payment Term 2
        /// </summary>
        /// <summary>
        /// 0330 PAT Payment terms basis
        /// 4279 Payment terms type qualifier M an..3
        ///
        /// 22 Discount
        /// </summary>
        public string PaymentTerm3_TypeQualifier { get; set; }
        /// <summary>
        /// 0330 PAT Payment terms basis - C110 Payment terms C
        /// 4277 Terms of payment identification M an..17
        ///
        /// 22 Discount
        /// </summary>
        public string PaymentTerm3_TermsOfPaymentIdentification { get; set; }
        /// <summary>
        /// 0330 PAT Payment terms basis - C110 Payment terms C
        /// 1131 Code list qualifier C an..3 N 
        ///
        /// Not used
        /// </summary>
        public string PaymentTerm3_CodeListQualifier { get; set; }
        /// <summary>
        /// 0330 PAT Payment terms basis - C110 Payment terms C
        /// 4276 Terms of payment C an..35 M an..35 
        ///
        /// This freetext needs to be filled.
        /// </summary>
        public string PaymentTerm3_TermsOfPayment { get; set; }

        /// <summary>
        /// C112 Terms/time information C - 2475 Payment time reference, coded M an..3
        ///
        /// 5 Date of invoice
        /// </summary>
        public string PaymentTerm3_TimeReferenceCode { get; set; }

        /// <summary>
        /// C112 Terms/time information C - 2009 Time relation, coded C an..3
        ///
        /// 3 After reference
        /// </summary>
        public string PaymentTerm3_TimeRelationCode { get; set; }

        /// <summary>
        /// C112 Terms/time information C - 2151 Type of period, coded C an..3
        ///
        /// D Day
        /// </summary>
        public string PaymentTerm3_TypeOfPeriod { get; set; }

        /// <summary>
        /// C112 Terms/time information C - 2152 Number of periods C n..3
        ///
        /// Number of periods (e.g. days) of the type indicated in data element 2151
        /// </summary>
        public int? PaymentTerm3_NumberOfPeriod { get; set; }

        /// <summary>
        /// 0350 18 PCD C 1 2 Percentage details
        /// C501 Percentage details M - 5245 Percentage qualifier M an..3
        ///
        /// Discount
        /// </summary>
        public string PaymentTerm3_PercentageQualifier { get; set; }

        /// <summary>
        /// 0350 18 PCD C 1 2 Percentage details
        /// C501 Percentage details M - 5482 Percentage C n..10
        ///
        /// </summary>
        public decimal? PaymentTerm3_Percentage { get; set; }



        public PAT generatePayment1();

        public PCD generatePercentage1();
        public PAT generatePayment2();

        public PCD generatePercentage2();
        public PAT generatePayment3();

        public PCD generatePercentage3();

    
    }
}
