using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeSpecialServicedescriptionCode : BaseCodeEntity<CodeSpecialServicedescriptionCode>
    {

        public override string CodeDefinitionText { get; }

        public override string StringCodeDefinitionText => @"     AA    Advertising allowance

     AAA   Telecommunication charges

     AAB   Returned goods charges

     AAC   Modification costs

     AAD   Job-order production

     AAE   Outlays

     AAF   Off-premises surcharge

     AAG   Gold surcharge

     AAH   Processing surcharge

     AAI   Attestation fee

     AAJ   Copper surcharge

     AAK   Energy surcharge

     AAL   Deduction for missing parts

     AAM   Rubber surcharge

     AAN   Brass surcharge

     AAO   Material surcharge/deduction

     AAP   Lead surcharge

     AAQ   Price index surcharge

     AAR   Platinum surcharge

     AAS   Acceptance cost

     AAT   Rush delivery

     AAU   Selenium surcharge

     AAV   Special construction charge

     AAW   Deduction for delayed return

     AAX   Wolfram surcharge

     AAY   Airport fee

     AAZ   Concession fee

     ABA   Compulsory storage fee

     ABB   Defuel

     ABC   Into plane fee

     ABD   Overtime

     ABE   Reservicing charge

     ABF   Tooling cost

     ABG   Tooling charge

     ABH   Throughput allowance

     ABI   Superfund fee

     ABJ   Airport system fee

     ABK   Miscellaneous

     ABL   Packaging surcharge

     ABM   Scrap surcharge

     ABN   Dunnage charge

     ABO   Air freight transportation

     ABP   Carriage charge

     ABQ   Tonnage rebate

     ABR   Containerisation

     ABS   Carton packing

     ABT   Hessian wrapped

     ABU   Polyethylene wrap packing

     ABV   Miscellaneous customs charge

     ABW   Customs duty charge

     ABX   Miscellaneous special tooling charge

     ABY   Tooling amortisation

     ABZ   Miscellaneous rebate or discount

     ACA   Allowance

     ACB   Future discount off retail

     ACC   Miscellaneous setting costs (tooling)

     ACD   Minimum amount costs for quantity based surcharges

     ACE   Below schedule quantity after quantity-based surcharge

     ACF   Miscellaneous treatment

     ACG   Enamelling treatment

     ACH   Heat treatment

     ACI   Plating treatment

     ACJ   Painting

     ACK   Polishing

     ACL   Priming

     ACM   Preservation treatment

     ACN   Miscellaneous other surcharges

     ACO   Alloy surcharge

     ACP   Coke surcharge

     ACQ   Royalty surcharge

     ACR   Wheel handling charge

     ACS   Fitting surcharge

     ACT   Non-standard surcharge

     ACU   Standard surcharge

     ACV   Wheel surcharge

     ACW   Washer surcharge

     ACX   Ocean freight charge

     ACY   Container deposit charge

     ACZ   Damaged merchandise

     ADA   Bopsheet charge

     ADB   Drum deposit

     ADC   Consolidation

     ADD   Inland transportation

     ADE   Bill of lading charge

     ADF   Excise tax-destination

     ADG   Customs bond charge

     ADH   Per pound charge

     ADI   Royalties

     ADJ   Airbag charge

     ADK   Transfer charge

     ADL   Slipsheet charge

     ADM   Binding services

     ADN   Repair or replacement of broken returnable package

     ADO   Efficient logistics

     ADP   Merchandising

     ADQ   Product mix

     ADR   Other services

     ADS   Full pallet ordering

     ADT   Pick-up

     ADU   Handling by the 1st level sub-contractor

     ADV   Handling by the 2nd level sub-contractor

     ADW   Chronic illness service

     ADX   Handling by the contractor

     ADY   New product introduction

     ADZ   Direct delivery

     AEA   Diversion

     AEB   Disconnect

     AEC   Distribution

     AED   Handling of hazardous cargo

     AEE   Yearly turnover service

     AEF   Rents and leases

     AEG   System usage

     AEH   Location differential

     AEI   Aircraft refueling

     AEJ   Fuel shipped into storage

     AEK   Cash on delivery service

     AEL   Small order processing service

     AEM   Clerical or administrative services

     AEN   Guarantee service

     AEO   Collection and recycling service

     AEP   Copyright fee collection services

     AEQ   Charge for exceeding agreed ordered quantity


     AER   Automotive core charge


     AES   Veterinary inspection service


     AET   Pensioner service


     AEU   Medicine free pass holder


     AEV   Environmental protection service

     AEW   Environmental clean-up service


     AEX   National cheque processing service outside account area


     AEY   National payment service outside account area


     AEZ   National payment service within account area


     AG    Silver surcharge


     AJ    Adjustments


     AL    Aluminium surcharge


     AM    Additional material


     AU    Authentication charge


     CA    Cataloguing services


     CAA   Cancellation charge


     CAB   Cartage


     CAC   Cash discount


     CAD   Certification fee


     CAE   Certificate of conformance


     CAF   Certificate of origin


     CAG   Competitive allowance


     CAH   Competitive auto allowance


     CAI   Cutting charge


     CAJ   Consular costs


     CAK   Customer collection rebate


     CAL   Payroll payment service


     CAM   Cash transportation service


     CAN   Home banking service


     CAO   Bilateral agreement service


     CAP   Insurance brokerage service


     CAQ   Cheque generation service


     CAR   Preferential merchandising location


     CAS   Crane service


     CAT   Special colour service


     CB    Commission


     CD    Car loading


     CG    Cleaning charge


     CK    COD charge


     CL    Contract allowance


     CO    Cents off


     CP    Competitive price


     CS    Cigarette stamping


     CT    Count and recount


     CW    Container allowance


     DA    Defective allowance


     DAA   Deficit freight


     DAB   Layout/design


     DAD   Driver assigned unloading


     DAE   Distributor discount/allowance


     DI    Discount


     DL    Delivery


     DM    Demurrage


     EAA   Early buy allowance


     EAB   Early payment allowance


     EG    Engraving


     EP    Expediting premium


     ER    Exchange rate guarantee charge


     EX    Export shipping charge


     FA    Freight allowance


     FAA   Fabrication charge


     FAB   Freight equalization


     FAC   Freight surcharge
.

     FC    Freight charge


     FG    Free goods


     FH    Filling/handling charge


     FI    Finance charge


     FN    Special finish charge


     FR    Flat rate


     GAA   Grinding


     HAA   Hose charge


     HD    Handling


     HH    Hoisting and hauling


     IA    Invoice adjustment


     IAA   Installation


     IAB   Installation and warranty


     ID    Inside delivery charge


     IF    Inspection fee


     IN    Insurance


     IR    Installation and training


     IS    Invoice services


     KO    Koshering


     L1    Shipper load, carrier count


     LA    Labelling


     LAA   Labour charge


     LAB   Labour (repair and return orders)


     LAC   License fee


     LF    Legalisation fee

     LS    Local sales tax


     MA    Material allowance (special materials)


     MAA   Mileage or travel


     MAB   Mileage fee (for repair and return)


     MAC   Minimum order/minimum billing charge


     MAD   Monthly rental


     MAE   Mounting


     MC    Material surcharge (special materials)


     MI    Mail invoice


     ML    Mail invoice to each location


     NAA   Non-returnable containers


     OA    Outside cable connectors


     OAA   Overtime loading


     PA    Pack invoice with shipment


     PAA   Phosphatizing (steel treatment)


     PAB   Postage charge


     PAC   Premium charge


     PAD   Promotional allowance


     PAE   Promotional discount


     PC    Packing


     PD    Palladium surcharge


     PI    Pick-up allowance


     PL    Palletizing


     PN    Pallet charge


     PO    Per order charge


     QAA   Quantity surcharge


     QD    Quantity discount


     RAA Rebate


     RAB Repack charge


     RAC Repair


     RAD Returnable container


     RAE Resellers discount


     RAF Restocking charge


     RAG Roll rebate


     RAH Road/rail tanker rebate


     RE Re-delivery charge


     RF Refurbishing charge


     RH Rail wagon hire


     RO Roe allowance/charge


     RP Repair charge


     RV Freight charge/costs of loading

     SA Salvage


     SAA Shipping and handling


     SAB Special allowance


     SAC Special credit

     SAD Special packaging


     SAE Stamping


     SAF Supplemental items

     SAG Surcharge (dollar value)


     SAH Surcharge (percentage)


     SAI Shipper load, consignee unload


     SAJ Small packages charge


     SC Surcharge


     SD Shrinkage allowance


     SF Special rebate


     SG Shrink-wrap charge


     SH Special handling service


     SM Special finish
              

     ST Stamp duties
              Self explanatory.

     SU Set-up
              

     SZ Steel surcharge
              

     TAA Telephone charge
              

     TAB Tank rental
              

     TAC Testing charge
              

     TAD Testing allowance
              

     TAE Truckload discount
              

     TD Trade discount
              

     TS State tax


     TT Transportation - third party billing
              

     TV Transportation - vendor provided
              

     TX Tax


     TZ Temporary allowance
              

     UM Unsaleable merchandise allowance
              

     V1 Drop yard
              

     V2 Drop dock
              

     VAA Vendor freight
              

     VAB Volume discount


     VL Vehicle load allowance
              

     WH Warehousing

     XAA Combine all same day shipment
              

     YY Split pickup
              

     ZZZ Mutually defined
";
    }
}
