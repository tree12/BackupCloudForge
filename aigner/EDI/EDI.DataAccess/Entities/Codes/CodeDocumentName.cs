using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeDocumentName : BaseCodeEntity<CodeDocumentName>
    {
        public override string CodeDefinitionText => @"
        1 Certificate of analysis
        2 Certificate of conformity
        3 Certificate of quality
        4 Test report
        5 Product performance report
        6 Product specification report
        7 Process data report
        8 First sample test report
        9 Price/sales catalogue
       10 Party information
       12 Mill certificate
       13 Post receipt
       14 Weight certificate
       15 Weight list
       16 Certificate
       17 Combined certificate of value and origin
       18 Movement certificate A.TR.1
       19 Certificate of quantity
       20 Quality data  message
       21 Query
       22 Response to query
      105 Purchase order
      110 Manufacturing instructions
      120 Stores requisition
      130 Invoicing data sheet
      140 Packing instructions
      150 Internal transport order
      190 Statistical and other administrative internal documents
      201 Direct payment valuation request
      202 Direct payment valuation
      203 Provisional payment valuation
      204 Payment valuation
      205 Quantity valuation
      206 Quantity valuation request
      207 Contract bill of quantities - BOQ
      208 Unpriced tender BOQ
      209 Priced tender BOQ
      210 Enquiry
      211 Interim application for payment
      212 Agreement to pay
      215 Letter of intent
      220 Order
      221 Blanket order
      222 Spot order
      223 Lease order
      224 Rush order
      225 Repair order
      226 Call off order
      227 Consignment order
      228 Sample order
      229 Swap order
      230 Purchase order change request
      231 Purchase order response
      232 Hire order
      233 Spare parts order
      240 Delivery instructions
      241 Delivery schedule
      242 Delivery just-in-time
      245 Delivery release
      270 Delivery note
      271 Packing list
      310 Offer/quotation
      311 Request for quote
      315 Contract
      320 Acknowledgement of order
      325 Proforma invoice
      326 Partial invoice
      327 Operating instructions
      328 Name/product plate
      330 Request for delivery instructions
      335 Booking request
      340 Shipping instructions
      341 Shipper's letter of instructions (air)
      343 Cartage order (local transport)
      345 Ready for despatch advice
      350 Despatch order
      351 Despatch advice
      370 Advice of distribution of documents
      380 Commercial invoice
      381 Credit note
      382 Commission note
      383 Debit note
      384 Corrected invoice
      385 Consolidated invoice
      386 Prepayment invoice
      387 Hire invoice
      388 Tax invoice
      389 Self-billed invoice
      390 Delcredere invoice
      393 Factored invoice
      394 Lease invoice
      395 Consignment invoice
      396 Factored credit note
      409 Instructions for bank transfer
      412 Application for banker's draft
      425 Collection payment advice
      426 Documentary credit payment advice
      427 Documentary credit acceptance advice
      428 Documentary credit negotiation advice
      429 Application for banker's guarantee
      430 Banker's guarantee
      431 Documentary credit letter of indemnity
      435 Preadvice of a credit
      447 Collection order
      448 Documents presentation form
      450 Payment order
      451 Extended payment order
      452 Multiple payment order
      454 Credit advice
      455 Extended credit advice
      456 Debit advice
      457 Reversal of debit
      458 Reversal of credit
      460 Documentary credit application
      465 Documentary credit
      466 Documentary credit notification
      467 Documentary credit transfer advice
      468 Documentary credit amendment notification
      469 Documentary credit amendment
      481 Remittance advice
      485 Banker's draft
      490 Bill of exchange
      491 Promissory note
      492 Financial statement of account
      493 Statement of account message
      520 Insurance certificate
      530 Insurance policy
      550 Insurance declaration sheet (bordereau)
      575 Insurer's invoice
      580 Cover note
      610 Forwarding instructions
      621 Forwarder's advice to import agent
      622 Forwarder's advice to exporter
      623 Forwarder's invoice
      624 Forwarder's certificate of receipt
      630 Shipping note
      631 Forwarder's warehouse receipt
      632 Goods receipt
      633 Port charges documents
      635 Warehouse warrant
      640 Delivery order
      650 Handling order
      655 Gate pass
      700 Waybill
      701 Universal (multipurpose) transport document
      702 Goods receipt, carriage
      703 House waybill
      704 Master bill of lading
      705 Bill of lading
      706 Bill of lading original
      707 Bill of lading copy
      708 Empty container bill
      709 Tanker bill of lading
      710 Sea waybill
      711 Inland waterway bill of lading
      712 Non-negotiable maritime transport document (generic)
      713 Mate's receipt
      714 House bill of lading
      715 Letter of indemnity for non-surrender of bill of lading
      716 Forwarder's bill of lading
      720 Rail consignment note (generic term)
      722 Road list-SMGS
      723 Escort official recognition
      724 Recharging document
      730 Road consignment note
      740 Air waybill
      741 Master air waybill
      743 Substitute air waybill
      744 Crew's effects declaration
      745 Passenger list
      746 Delivery notice (rail transport)
      750 Despatch note (post parcels)
      760 Multimodal/combined transport document (generic)
      761 Through bill of lading
      763 Forwarder's certificate of transport
      764 Combined transport document (generic)
      765 Multimodal transport document (generic)
      766 Combined transport bill of lading/multimodal bill of lading
      770 Booking confirmation
      775 Calling forward notice
      780 Freight invoice
      781 Arrival notice (goods)
      782 Notice of circumstances preventing delivery (goods)
      783 Notice of circumstances preventing transport (goods)
      784 Delivery notice (goods)
      785 Cargo manifest
      786 Freight manifest
      787 Bordereau
      788 Container manifest (unit packing list)
      789 Charges note
      790 Advice of collection
      791 Safety of ship certificate
      792 Safety of radio certificate
      793 Safety of equipment certificate
      794 Civil liability for oil certificate
      795 Loadline document
      796 Derat document
      797 Maritime declaration of health
      798 Certificate of registry
      799 Ship's stores declaration
      810 Export licence, application for
      811 Export licence
      812 Exchange control declaration, export
      820 Despatch note model T
      821 Despatch note model T1
      822 Despatch note model T2
      823 Control document T5
      824 Re-sending consignment note
      825 Despatch note model T2L
      830 Goods declaration for exportation
      833 Cargo declaration (departure)
      840 Application for goods control certificate
      841 Goods control certificate
      850 Application for phytosanitary certificate
      851 Phytosanitary certificate
      852 Sanitary certificate
      853 Veterinary certificate
      855 Application for inspection certificate
      856 Inspection certificate
      860 Certificate of origin, application for
      861 Certificate of origin
      862 Declaration of origin
      863 Regional appellation certificate
      864 Preference certificate of origin
      865 Certificate of origin form GSP
      870 Consular invoice
      890 Dangerous goods declaration
      895 Statistical document, export
      896 INTRASTAT declaration
      901 Delivery verification certificate
      910 Import licence, application for
      911 Import licence
      913 Customs declaration without commercial detail
      914 Customs declaration with commercial and item detail
      915 Customs declaration without item detail
      916 Related document
      917 Receipt (Customs)
      925 Application for exchange allocation
      926 Foreign exchange permit
      927 Exchange control declaration (import)
      929 Goods declaration for importation
      930 Goods declaration for home use
      931 Customs immediate release declaration
      932 Customs delivery note
      933 Cargo declaration (arrival)
      934 Value declaration
      935 Customs invoice
      936 Customs declaration (post parcels)
      937 Tax declaration (value added tax)
      938 Tax declaration (general)
      940 Tax demand
      941 Embargo permit
      950 Goods declaration for Customs transit
      951 TIF form
      952 TIR carnet
      953 EC carnet
      954 EUR 1 certificate of origin
      955 ATA carnet
      960 Single administrative document
      961 General response (Customs)
      962 Document response (Customs)
      963 Error response (Customs)
      964 Package response (Customs)
      965 Tax calculation/confirmation response (Customs)
      966 Quota prior allocation certificate
      990 End use authorization
      991 Government contract
      995 Statistical document, import
      996 Application for documentary credit
      998 Previous Customs document/message
";

        public override string StringCodeDefinitionText { get; }
    }
}
