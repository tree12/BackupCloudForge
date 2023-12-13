using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess.Entities.Interfaces;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities
{
    public class EdiDeliveryNote : EdiMasterMessage<EdiDeliveryNote>, ICarrier, IFreightForwarder, IDeliveryLocation, IEdiDeliveryCondition
    {
        public EdiDeliveryNote()
        {
        }
        /// <summary>
        /// 0030 6 DTM M 1 1 Date/time/period
        /// 
        /// </summary>
        public DateTime? DeliveryDate { get; set; }
        /// <summary>
        /// 0030 7 DTM M 1 1 Date/time/period
        /// 
        /// </summary>
        public DateTime? ArrivalDate { get; set; }
        /// <summary>
        /// 0030 8 DTM M 1 1 Date/time/period
        /// 
        /// </summary>
        public DateTime? DespatchDate { get; set; }


        /// <summary>
        /// 0070 SG1 D 1 1 RFF
        /// 0080 9 RFF M 1 1 Reference
        /// 1153 Reference qualifier M an..3 AAJ Transport order number
        ///
        /// </summary>
        public string TransportReferenceQualifier { get; set; }

        /// <summary>
        /// 0070 SG1 O 1 1 RFF
        /// 0080 9 RFF M 1 1 Reference
        /// 1154 Reference number C an..35
        ///
        /// Reference Number
        /// </summary>
        public string TransportReferenceNumber { get; set; }

        /// <summary>
        /// 0070 SG1 D 1 1 RFF
        /// 0080 9 RFF M 1 1 Reference
        /// 1153 Reference qualifier M an..3 CRN Conveyance reference number
        ///
        /// </summary>
        public string ConveyanceReferenceQualifier { get; set; }

        /// <summary>
        /// 0070 SG1 D 1 1 RFF
        /// 0080 9 RFF M 1 1 Reference
        /// 1154 Reference number C an..35
        ///
        /// Reference Number
        /// </summary>
        public string ConveyanceReferenceNumber { get; set; }

        #region Carrier

        public string Carrier_PartyQualifier { get; set; }
        public string Carrier_PartyId { get; set; }
        public string Carrier_ResponsibleAgency { get; set; }
        public string Carrier_CompanyName { get; set; }
        public string Carrier_Street { get; set; }
        public string Carrier_CityName { get; set; }
        public string Carrier_Postcode { get; set; }
        public string Carrier_CountryCode { get; set; }

        #endregion

        #region Freight Forwarder
        public string FreightForwarder_PartyQualifier { get; set; }
        public string FreightForwarder_PartyId { get; set; }
        public string FreightForwarder_ResponsibleAgency { get; set; }
        public string FreightForwarder_CompanyName { get; set; }
        public string FreightForwarder_Street { get; set; }
        public string FreightForwarder_CityName { get; set; }
        public string FreightForwarder_Postcode { get; set; }
        public string FreightForwarder_CountryCode { get; set; }

        #endregion

        #region Delivery Location

        public string Delivery_PlaceLocationQualifier { get; set; }
        public string Delivery_PlaceLocationIdentification { get; set; }

        #region TOD-LOC
        public string TermsOfDeliveryFunctionCode { get; set; }
        public string TermsOfDeliveryIncoterms { get; set; }
        public string TermsOfDeliveryPlaceLocationQualifier { get; set; }
        public string TermsOfDeliveryPlaceLocationIdentification { get; set; }

        #endregion

        #endregion

        #region TDT-transport
        /// <summary>
        /// 0230 SG6 C 10 1 TDT
        /// 0240 18 TDT M 1 1 Details of transport
        /// 8051 Transport stage qualifier M an..3 M an..3 12 At departure
        /// </summary>
        public string TransportStageQualifier { get; set; }
        /// <summary>
        /// 0230 SG6 C 10 1 TDT
        /// 0240 18 TDT M 1 1 Details of transport
        /// C220 Mode of transport - 8067 Mode of transport, coded C an..3 M an..3
        /// </summary>
        public string ModeOfTransportCoded { get; set; }
        /// <summary>
        /// 0230 SG6 C 10 1 TDT
        /// 0240 18 TDT M 1 1 Details of transport
        /// C228 Transport means C -8179 Type of means of transport identification
        /// </summary>
        public string TypeOfMeansTransportCoded { get; set; }

        #endregion

        #region CPS-Outer

        /// <summary>
        /// 0370 SG10 C 9999 1 CPS-SG11
        /// 0380 19 CPS M 1 1 Consignment packing sequence
        /// 7164 Hierarchical id. number M an..12 M an..12 
        /// </summary>
        public string HierarchicalIdNumber { get; set; }
        /// <summary>
        /// 0370 SG10 C 9999 1 CPS-SG11
        /// 0380 19 CPS M 1 1 Consignment packing sequence
        /// 7075 Packaging level, coded C an..3 M an..3
        /// </summary>
        public string PackagingLevelCoded { get; set; }

        #endregion

        #region PAC
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0410 20 PAC M 1 2 Package
        /// 7224 Number of packages C n..8 M n..8
        /// </summary>
        public string NumberOfPackages { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0410 20 PAC M 1 2 Package
        /// C531 Packaging details C - 7233 Packaging related information, coded C an..3 M an..3 35 Type of package
        /// </summary>
        public string PackagingRelatedInformationCoded { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0410 20 PAC M 1 2 Package
        /// C531 Packaging details C - 7073 Packaging terms and conditions, coded C an..3 M an..3
        /// </summary>
        public string PackagingTermsConditionsCoded { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0410 20 PAC M 1 2 Package
        /// C202 Package type C C - 7065 Type of packages identification C an..17 M an..17
        /// </summary>
        public string TypeOfPackagesIdentification { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0410 20 PAC M 1 2 Package
        /// C202 Package type C C - 3055 Code list responsible agency,coded C an..3 M an..3
        /// </summary>
        public string PACCodeListResponsibleAgencyCoded { get; set; }
        #endregion

        #region MEA -Gross
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// 6311 Measurement application qualifier M an..3 M an..3
        /// </summary>
        public string GrossMeasurementApplicationQualifier { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C502 Measurement details C M - 6313 Measurement dimension, coded C an..3 M an..3
        /// </summary>
        public string GrossMeasurementDimensionCoded { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C174 Value/range C M - 6411 Measure unit qualifier M an..3 M an..3 KGM Kilogram *
        /// </summary>
        public string GrossMeasureUnitQualifier { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C174 Value/range C M - 6314 Measurement value C n..18 M n..18 Gross weight
        /// </summary>
        public string GrossMeasurementValue { get; set; }

        #endregion

        #region MEA -Net
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// 6311 Measurement application qualifier M an..3 M an..3
        /// </summary>
        public string NetMeasurementApplicationQualifier { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C502 Measurement details C M - 6313 Measurement dimension, coded C an..3 M an..3
        /// </summary>
        public string NetMeasurementDimensionCoded { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C174 Value/range C M - 6411 Measure unit qualifier M an..3 M an..3 KGM Kilogram *
        /// </summary>
        public string NetMeasureUnitQualifier { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C174 Value/range C M - 6314 Measurement value C n..18 M n..18 Net weight
        /// </summary>
        public string NetMeasurementValue { get; set; }

        #endregion

        #region MEA -Volume
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// 6311 Measurement application qualifier M an..3 M an..3
        /// </summary>
        public string VolumeMeasurementApplicationQualifier { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C502 Measurement details C M - 6313 Measurement dimension, coded C an..3 M an..3
        /// </summary>
        public string VolumeMeasurementDimensionCoded { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C174 Value/range C M - 6411 Measure unit qualifier M an..3 M an..3 MTQ Cubic metre *
        /// </summary>
        public string VolumeMeasureUnitQualifier { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C174 Value/range C M - 6314 Measurement value C n..18 M n..18 Volume
        /// </summary>
        public string VolumeMeasurementValue { get; set; }

        #endregion

        #region Quantity-Maximum
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6063 Quantity qualifier M an..3
        ///
        /// 21 Ordered quantity
        /// </summary>
        public string MaximumQuantityQualifier { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6060 Quantity M n..15
        ///
        /// </summary>
        public decimal? MaximumQuantity { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6411 Measure unit qualifier C an..3
        ///
        /// Code specifying the unit of measurement, use UN/ECE
        /// Recommendation 20, Common code.
        ///     PCE Piece
        ///     MTR Metre*
        ///     KGM Kilogram*
        /// </summary>
        public string MaximumQTYMeasureUnitQualifier { get; set; }
        #endregion

        #region Quantity- Number of packages
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6063 Quantity qualifier M an..3
        ///
        /// 21 Ordered quantity
        /// </summary>
        public string PackageQuantityQualifier { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6060 Quantity M n..15
        ///
        /// </summary>
        public decimal? PackageQuantity { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6411 Measure unit qualifier C an..3
        ///
        /// Code specifying the unit of measurement, use UN/ECE
        /// Recommendation 20, Common code.
        ///     PCE Piece
        ///     MTR Metre*
        ///     KGM Kilogram*
        /// </summary>
        public string PackageQTYMeasureUnitQualifier { get; set; }
        #endregion

        #region PCI- Package identification
        /// <summary>
        /// 0470 SG13 C 1000 3 PCI-SG14
        ///
        /// 0480 26 PCI M 1 3 Package identification -4233 Marking instructions, coded C an..3 M an..3 17 Seller's instructions
        /// </summary>
        public string MarkingInstructionsCoded { get; set; }
        /// <summary>
        /// 0470 SG13 C 1000 3 PCI-SG14
        /// 0480 26 PCI M 1 3 Package identification - 7511 Type of marking, coded M an..3 M an..3
        /// </summary>
        public string TypeOfMarkingCoded { get; set; }
        /// <summary>
        /// 0470 SG13 C 1000 3 PCI-SG14
        /// 0480 26 PCI M 1 3 Package identification - 3055 Code list responsible agency, coded C an..3 M an..3
        /// </summary>
        public string PCICodeListResponsibleAgencyCoded { get; set; }
        #endregion

        #region GIN -ML Marking/label number
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0530 27 GIN M 1 4 Goods identity number -7405 Identity number qualifier M an..3 M an..3 ML Marking/label number
        /// </summary>
        public string MLIdentityNumberQualifier { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// Label ID of handling unit.
        /// </summary>
        public string MLFirstIdentityNumber1 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string MLLastIdentityNumber1 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// Label ID of handling unit.
        /// </summary>
        public string MLFirstIdentityNumber2 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string MLLastIdentityNumber2 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// Label ID of handling unit.
        /// </summary>
        public string MLFirstIdentityNumber3 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string MLLastIdentityNumber3 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// Label ID of handling unit.
        /// </summary>
        public string MLFirstIdentityNumber4 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string MLLastIdentityNumber4 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// Label ID of handling unit.
        /// </summary>
        public string MLFirstIdentityNumber5 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string MLLastIdentityNumber5 { get; set; }

        #endregion

        #region GIN - AW Serial shipping container code
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0530 27 GIN M 1 4 Goods identity number -7405 Identity number qualifier M an..3 M an..3 ML Marking/label number
        /// </summary>
        public string AWIdentityNumberQualifier { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string AWFirstIdentityNumber1 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string AWLastIdentityNumber1 { get; set; }

        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string AWFirstIdentityNumber2 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string AWLastIdentityNumber2 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string AWFirstIdentityNumber3 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string AWLastIdentityNumber3 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string AWFirstIdentityNumber4 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string AWLastIdentityNumber4 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string AWFirstIdentityNumber5 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string AWLastIdentityNumber5 { get; set; }
        #endregion

        #region CPS-Inner
        /// <summary>
        /// 0370 SG10 C 9999 1 CPS-SG11-SG15
        ///
        /// 0380 29 CPS M 1 1 Consignment packing sequence - 7164 Hierarchical id. number M an..12 M an..12 
        /// </summary>
        public string InnerHierarchicalIdNumber { get; set; }
        /// <summary>
        /// 0370 SG10 C 9999 1 CPS-SG11
        /// 0380 19 CPS M 1 1 Consignment packing sequence
        /// 7075 Packaging level, coded C an..3 M an..3
        /// </summary>
        public string InnerPackagingLevelCoded { get; set; }
        #endregion

        #region PAC-Inner
        /// <summary>
        /// 0400 SG11 C 9999 2 Packaging material group inner packaging material
        /// 0410 20 PAC M 1 2 Package
        /// 7224 Number of packages C n..8 M n..8
        /// </summary>
        public string InnerNumberOfPackages { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Packaging material group inner packaging material
        /// 0410 20 PAC M 1 2 Package
        /// C531 Packaging details C - 7233 Packaging related information, coded C an..3 M an..3 35 Type of package
        /// </summary>
        public string InnerPackagingRelatedInformationCoded { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Packaging material group inner packaging material
        /// 0410 20 PAC M 1 2 Package
        /// C531 Packaging details C - 7073 Packaging terms and conditions, coded C an..3 M an..3
        /// </summary>
        public string InnerPackagingTermsConditionsCoded { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Packaging material group inner packaging material
        /// 0410 20 PAC M 1 2 Package
        /// C202 Package type C C - 7065 Type of packages identification C an..17 M an..17
        /// </summary>
        public string InnerTypeOfPackagesIdentification { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Packaging material group inner packaging material
        /// 0410 20 PAC M 1 2 Package
        /// C202 Package type C C - 3055 Code list responsible agency,coded C an..3 M an..3
        /// </summary>
        public string InnerPACCodeListResponsibleAgencyCoded { get; set; }
        #endregion


        #region MEA -Gross-Inner
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// 6311 Measurement application qualifier M an..3 M an..3
        /// </summary>
        public string InnerGrossMeasurementApplicationQualifier { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C502 Measurement details C M - 6313 Measurement dimension, coded C an..3 M an..3
        /// </summary>
        public string InnerGrossMeasurementDimensionCoded { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C174 Value/range C M - 6411 Measure unit qualifier M an..3 M an..3 KGM Kilogram *
        /// </summary>
        public string InnerGrossMeasureUnitQualifier { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C174 Value/range C M - 6314 Measurement value C n..18 M n..18 Gross weight
        /// </summary>
        public string InnerGrossMeasurementValue { get; set; }

        #endregion

        #region MEA -Net-Inner
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// 6311 Measurement application qualifier M an..3 M an..3
        /// </summary>
        public string InnerNetMeasurementApplicationQualifier { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C502 Measurement details C M - 6313 Measurement dimension, coded C an..3 M an..3
        /// </summary>
        public string InnerNetMeasurementDimensionCoded { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C174 Value/range C M - 6411 Measure unit qualifier M an..3 M an..3 KGM Kilogram *
        /// </summary>
        public string InnerNetMeasureUnitQualifier { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C174 Value/range C M - 6314 Measurement value C n..18 M n..18 Net weight
        /// </summary>
        public string InnerNetMeasurementValue { get; set; }

        #endregion

        #region MEA -Volume - Inner
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// 6311 Measurement application qualifier M an..3 M an..3
        /// </summary>
        public string InnerVolumeMeasurementApplicationQualifier { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C502 Measurement details C M - 6313 Measurement dimension, coded C an..3 M an..3
        /// </summary>
        public string InnerVolumeMeasurementDimensionCoded { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C174 Value/range C M - 6411 Measure unit qualifier M an..3 M an..3 MTQ Cubic metre *
        /// </summary>
        public string InnerVolumeMeasureUnitQualifier { get; set; }
        /// <summary>
        /// 0400 SG11 C 9999 2 Handling unit group details
        /// 0420 21 MEA C 1 3 Measurements
        /// C174 Value/range C M - 6314 Measurement value C n..18 M n..18 Volume
        /// </summary>
        public string InnerVolumeMeasurementValue { get; set; }

        #endregion

        #region Quantity-Maximum-Inner
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6063 Quantity qualifier M an..3
        ///
        /// 21 Ordered quantity
        /// </summary>
        public string InnerMaximumQuantityQualifier { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6060 Quantity M n..15
        ///
        /// </summary>
        public decimal? InnerMaximumQuantity { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6411 Measure unit qualifier C an..3
        ///
        /// Code specifying the unit of measurement, use UN/ECE
        /// Recommendation 20, Common code.
        ///     PCE Piece
        ///     MTR Metre*
        ///     KGM Kilogram*
        /// </summary>
        public string InnerMaximumQTYMeasureUnitQualifier { get; set; }
        #endregion

        #region Quantity- Per packages
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6063 Quantity qualifier M an..3
        ///
        /// 21 Ordered quantity
        /// </summary>
        public string InnerPackageQuantityQualifier { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6060 Quantity M n..15
        ///
        /// </summary>
        public decimal? InnerPackageQuantity { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6411 Measure unit qualifier C an..3
        ///
        /// Code specifying the unit of measurement, use UN/ECE
        /// Recommendation 20, Common code.
        ///     PCE Piece
        ///     MTR Metre*
        ///     KGM Kilogram*
        /// </summary>
        public string InnerPackageQTYMeasureUnitQualifier { get; set; }
        #endregion

        #region PCI- Package identification - Inner
        /// <summary>
        /// 0470 SG13 C 1000 3 PCI-SG14
        ///
        /// 0480 26 PCI M 1 3 Package identification -4233 Marking instructions, coded C an..3 M an..3 17 Seller's instructions
        /// </summary>
        public string InnerMarkingInstructionsCoded { get; set; }
        /// <summary>
        /// 0470 SG13 C 1000 3 PCI-SG14
        /// 0480 26 PCI M 1 3 Package identification - 7511 Type of marking, coded M an..3 M an..3
        /// </summary>
        public string InnerTypeOfMarkingCoded { get; set; }
        /// <summary>
        /// 0470 SG13 C 1000 3 PCI-SG14
        /// 0480 26 PCI M 1 3 Package identification - 3055 Code list responsible agency, coded C an..3 M an..3
        /// </summary>
        public string InnerPCICodeListResponsibleAgencyCoded { get; set; }
        #endregion

        #region GIN -ML Marking/label number -Inner
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// 0530 27 GIN M 1 4 Goods identity number -7405 Identity number qualifier M an..3 M an..3 ML Marking/label number
        /// </summary>
        public string InnerMLIdentityNumberQualifier { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// Label number or ID of a individual package or handling unit. In case of a range of IDs this is the first ID.
        /// </summary>
        public string InnerMLFirstIdentityNumber1 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// C208 Identity number range M M - 7402 Identity number C an..35 C an..35
        /// Last (serial) label ID of a range of consecutive labels
        /// </summary>
        public string InnerMLLastIdentityNumber1 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// Label number or ID of a individual package or handling unit. In case of a range of IDs this is the first ID.
        /// </summary>
        public string InnerMLFirstIdentityNumber2 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// C208 Identity number range M M - 7402 Identity number C an..35 C an..35
        /// Last (serial) label ID of a range of consecutive labels
        /// </summary>
        public string InnerMLLastIdentityNumber2 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// Label number or ID of a individual package or handling unit. In case of a range of IDs this is the first ID.
        /// </summary>
        public string InnerMLFirstIdentityNumber3 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// C208 Identity number range M M - 7402 Identity number C an..35 C an..35
        /// Last (serial) label ID of a range of consecutive labels
        /// </summary>
        public string InnerMLLastIdentityNumber3 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// Label number or ID of a individual package or handling unit. In case of a range of IDs this is the first ID.
        /// </summary>
        public string InnerMLFirstIdentityNumber4 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// C208 Identity number range M M - 7402 Identity number C an..35 C an..35
        /// Last (serial) label ID of a range of consecutive labels
        /// </summary>
        public string InnerMLLastIdentityNumber4 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// Label number or ID of a individual package or handling unit. In case of a range of IDs this is the first ID.
        /// </summary>
        public string InnerMLFirstIdentityNumber5 { get; set; }
        /// <summary>
        /// 0520 SG14 C 99 4 GIN
        ///
        /// C208 Identity number range M M - 7402 Identity number C an..35 C an..35
        /// Last (serial) label ID of a range of consecutive labels
        /// </summary>
        public string InnerMLLastIdentityNumber5 { get; set; }

        public List<LineItemDeliveryNote> LineItems { get; set; }

        #endregion

        public void init(TSDESADV tsdesadv)
        {

            base.init(tsdesadv.BGM);
            base.init(tsdesadv.UNH);
            if (tsdesadv.DTM != null)
            {
                base.initDocDate(tsdesadv.DTM.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "137"));
                var deliveryDtm = tsdesadv.DTM.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "2");
                if (deliveryDtm != null)
                    DeliveryDate = deliveryDtm.DATETIMEPERIOD_01.asDateTime();
                var arrivalDtm = tsdesadv.DTM.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "132");
                if (arrivalDtm != null)
                    ArrivalDate = arrivalDtm.DATETIMEPERIOD_01.asDateTime();
                var despatchDtm = tsdesadv.DTM.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "11");
                if (despatchDtm != null)
                    DespatchDate = despatchDtm.DATETIMEPERIOD_01.asDateTime();

            }

            if (tsdesadv.RFFLoop != null)
            {
                var transport = tsdesadv.RFFLoop.FirstOrDefault(x => x.RFF?.REFERENCE_01?.Referencequalifier_01 == "AAJ");
                if (transport != null)
                {
                    TransportReferenceQualifier = transport.RFF?.REFERENCE_01?.Referencequalifier_01;
                    TransportReferenceNumber = transport.RFF?.REFERENCE_01?.Referencenumber_02;
                }
                var conveyance = tsdesadv.RFFLoop.FirstOrDefault(x => x.RFF?.REFERENCE_01?.Referencequalifier_01 == "CRN");
                if (conveyance != null)
                {
                    ConveyanceReferenceQualifier = conveyance.RFF?.REFERENCE_01?.Referencequalifier_01;
                    ConveyanceReferenceNumber = conveyance.RFF?.REFERENCE_01?.Referencenumber_02;
                }

            }

            if (tsdesadv.NADLoop != null)
            {
                var supplier = tsdesadv.NADLoop.FirstOrDefault(x => x.NAD.Partyqualifier_01 == "SU");
                var carrier = tsdesadv.NADLoop.FirstOrDefault(x => x.NAD.Partyqualifier_01 == "CA");
                var freightForwarder = tsdesadv.NADLoop.FirstOrDefault(x => x.NAD.Partyqualifier_01 == "FW");
                var delivery = tsdesadv.NADLoop.FirstOrDefault(x => x.NAD.Partyqualifier_01 == "DP");
                if (supplier != null)
                    base.initNADSU(supplier.NAD);

                if (carrier != null)
                {
                    initCarrier(carrier.NAD);
                }
                if (freightForwarder != null)
                {
                    initFreightForwarder(freightForwarder.NAD);
                }

                if (delivery != null)
                {
                    base.initNADDP(delivery.NAD);
                    DPLoc(delivery.LOC.FirstOrDefault(x => x.Placelocationqualifier_01 == "11"));
                }

            }

            if (tsdesadv.TODLoop != null)
            {
                var todLoop = tsdesadv.TODLoop.FirstOrDefault(x => x.TOD.Termsofdeliveryortransportfunctioncoded_01 == "5");
                initTOD1(todLoop?.TOD);
                initConditionLOC1(todLoop?.LOC?.FirstOrDefault(x => x.Placelocationqualifier_01 == "1"));
            }
            if (tsdesadv.TDTLoop != null)
                initTDT(tsdesadv.TDTLoop.FirstOrDefault(x => x.TDT.Transportstagequalifier_01 == "12")?.TDT);


            initHandlingUnitGroup(tsdesadv.CPSLoop.FirstOrDefault(x => x.CPS.Packaginglevelcoded_03 == "3"));
            initInnerPackagingMaterialGroup(tsdesadv.CPSLoop.FirstOrDefault(x => x.CPS.Packaginglevelcoded_03 != "3"));


            base.init(tsdesadv.UNT);

        }

        public override EdiMessage CreateEdiDocument()
        {

            var result = new TSDESADV();
            result.UNH = base.generateUNH();
            result.BGM = base.generateBGM();

            result.DTM = new List<DTM>();
            result.DTM.Add(base.generateDocumentDTM());

            DTM deliveryDate = new DTM();
            deliveryDate.DATETIMEPERIOD_01 = new C507();
            deliveryDate.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "2";
            if (DeliveryDate != null)
            {
                deliveryDate.DATETIMEPERIOD_01.Datetimeperiod_02 = DeliveryDate.Value.ToString("yyyyMMdd");
                deliveryDate.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";
            }
            result.DTM.Add(deliveryDate);

            DTM arrivalDate = new DTM();
            arrivalDate.DATETIMEPERIOD_01 = new C507();
            arrivalDate.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "132";
            if (ArrivalDate != null)
            {
                arrivalDate.DATETIMEPERIOD_01.Datetimeperiod_02 = ArrivalDate.Value.ToString("yyyyMMddHHmm");
                arrivalDate.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "203";
            }
            result.DTM.Add(arrivalDate);

            DTM despatchDate = new DTM();
            despatchDate.DATETIMEPERIOD_01 = new C507();
            despatchDate.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "11";
            if (DespatchDate != null)
            {
                despatchDate.DATETIMEPERIOD_01.Datetimeperiod_02 = DespatchDate.Value.ToString("yyyyMMddHHmm");
                despatchDate.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "203";
            }
            result.DTM.Add(despatchDate);

            result.RFFLoop = new List<Loop_RFF_DESADV>();
            var rffTransportLoop = new Loop_RFF_DESADV();
            rffTransportLoop.RFF = generateTransportRFF();
            result.RFFLoop.Add(rffTransportLoop);

            var rffConveyanceLoop = new Loop_RFF_DESADV();
            rffConveyanceLoop.RFF = generateConveyanceRFF();
            result.RFFLoop.Add(rffConveyanceLoop);

            result.NADLoop = new List<Loop_NAD_DESADV>();


            #region Supplier
            var nadLoopSU = new Loop_NAD_DESADV();
            nadLoopSU.NAD = base.generateSupplier();
            result.NADLoop.Add(nadLoopSU);
            #endregion

            #region Carrier
            var nadLoopCA = new Loop_NAD_DESADV();
            nadLoopCA.NAD = generateCarrier();
            result.NADLoop.Add(nadLoopCA);
            #endregion

            #region Freight forwarder
            var nadLoopFW = new Loop_NAD_DESADV();
            nadLoopFW.NAD = generateFreightForwarder();
            result.NADLoop.Add(nadLoopFW);
            #endregion


            #region Delivery
            var nadLoopDP = new Loop_NAD_DESADV();
            nadLoopDP.NAD = base.generateDelivery();
            nadLoopDP.LOC = new List<LOC>();
            nadLoopDP.LOC.Add(generateDeliveryLOC());
            result.NADLoop.Add(nadLoopDP);

            #endregion


            #region DeliveryOrTransport Term
            result.TODLoop = new List<Loop_TOD_DESADV>();
            var todLoop = new Loop_TOD_DESADV();
            todLoop.TOD = generateDeliveryCondition1();
            var todLoc = generateDeliveryConditionLocation1();
            if (todLoc != null)
            {
                todLoop.LOC = new List<LOC>();
                todLoop.LOC.Add(todLoc);
            }

            result.TODLoop.Add(todLoop);

            #endregion
            result.TDTLoop = new List<Loop_TDT_DESADV>();
            var tdtLoop = new Loop_TDT_DESADV();
            tdtLoop.TDT = generateTDT();
            result.TDTLoop.Add(tdtLoop);
            result.CPSLoop = new List<Loop_CPS_DESADV>();
            result.CPSLoop.Add(generateHandlingUnitGroup());
            result.CPSLoop.Add(generatePackagingMaterialGroup());



            //result.UNS = base.generateUNS();
            //result.UNT = base.generateUNT();

            return result;


        }



        public void initCarrier(NAD nad)
        {
            Carrier_PartyQualifier = nad?.Partyqualifier_01;
            Carrier_PartyId = nad?.PARTYIDENTIFICATIONDETAILS_02?.Partyididentification_01;
            Carrier_ResponsibleAgency = nad?.PARTYIDENTIFICATIONDETAILS_02?.Codelistresponsibleagencycoded_03;
            Carrier_CompanyName = nad?.PARTYNAME_04?.Partyname_01;
            Carrier_Street = nad?.STREET_05?.Streetandnumberpobox_01;
            Carrier_CityName = nad?.Cityname_06;
            Carrier_Postcode = nad?.Postcodeidentification_08;
            Carrier_CountryCode = nad?.Countrycoded_09;
        }

        public void initFreightForwarder(NAD nad)
        {
            FreightForwarder_PartyQualifier = nad?.Partyqualifier_01;
            FreightForwarder_PartyId = nad?.PARTYIDENTIFICATIONDETAILS_02?.Partyididentification_01;
            FreightForwarder_ResponsibleAgency = nad?.PARTYIDENTIFICATIONDETAILS_02?.Codelistresponsibleagencycoded_03;
            FreightForwarder_CompanyName = nad?.PARTYNAME_04?.Partyname_01;
            FreightForwarder_Street = nad?.STREET_05?.Streetandnumberpobox_01;
            FreightForwarder_CityName = nad?.Cityname_06;
            FreightForwarder_Postcode = nad?.Postcodeidentification_08;
            FreightForwarder_CountryCode = nad?.Countrycoded_09;
        }

        public void DPLoc(LOC loc)
        {
            Delivery_PlaceLocationQualifier = loc?.Placelocationqualifier_01;
            Delivery_PlaceLocationIdentification = loc?.LOCATIONIDENTIFICATION_02?.Placelocationidentification_01;
        }
        public void initTOD1(TOD tod)
        {

            TermsOfDeliveryFunctionCode = tod?.Termsofdeliveryortransportfunctioncoded_01;
            TermsOfDeliveryIncoterms = tod?.TERMSOFDELIVERYORTRANSPORT_03?.Termsofdeliveryortransportcoded_01;

        }
        public void initConditionLOC1(LOC loc)
        {
            TermsOfDeliveryPlaceLocationQualifier = loc?.Placelocationqualifier_01;
            TermsOfDeliveryPlaceLocationIdentification = loc?.LOCATIONIDENTIFICATION_02?.Placelocationidentification_01;

        }

        public void initTDT(TDT tdt)
        {
            TransportStageQualifier = tdt.Transportstagequalifier_01;
            ModeOfTransportCoded = tdt.MODEOFTRANSPORT_03.Modeoftransportcoded_01;
            TypeOfMeansTransportCoded = tdt.TRANSPORTMEANS_04.Typeofmeansoftransportidentification_01;
        }

        public void initHandlingUnitGroup(Loop_CPS_DESADV loopCps)
        {
            if (loopCps.CPS is var cps && cps != null)
            {
                HierarchicalIdNumber = cps?.Hierarchicalidnumber_01;
                PackagingLevelCoded = cps?.Packaginglevelcoded_03;
            }
            if (loopCps.PACLoop is var pacLoop && pacLoop != null)
            {
                if (loopCps.PACLoop.Count > 1)
                {
                    AddEdiConvertError("Outer PAC more than one");
                }

                NumberOfPackages = loopCps.PACLoop[0].PAC.Numberofpackages_01;
                PackagingRelatedInformationCoded = loopCps.PACLoop[0].PAC.PACKAGINGDETAILS_02.Packagingrelatedinformationcoded_02;
                PackagingTermsConditionsCoded = loopCps.PACLoop[0].PAC.PACKAGINGDETAILS_02.Packagingtermsandconditionscoded_03;
                TypeOfPackagesIdentification = loopCps.PACLoop[0].PAC.PACKAGETYPE_03.Typeofpackagesidentification_01;
                PACCodeListResponsibleAgencyCoded = loopCps.PACLoop[0].PAC.PACKAGETYPE_03.Codelistresponsibleagencycoded_03;
                if (loopCps.PACLoop[0].MEA is var MEADesadv && MEADesadv != null)
                {
                    var meaGross = MEADesadv.FirstOrDefault(x => x.Measurementapplicationqualifier_01 == "AAZ" && x.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01 == "AAB");
                    var meaNet = MEADesadv.FirstOrDefault(x => x.Measurementapplicationqualifier_01 == "AAZ" && x.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01 == "AAA");
                    var meaVolume = MEADesadv.FirstOrDefault(x => x.Measurementapplicationqualifier_01 == "AAZ" && x.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01 == "ABJ");
                    if (meaGross != null)
                    {
                        GrossMeasurementApplicationQualifier = meaGross.Measurementapplicationqualifier_01;
                        GrossMeasurementDimensionCoded = meaGross.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01;
                        GrossMeasureUnitQualifier = meaGross.VALUERANGE_03.Measureunitqualifier_01;
                        GrossMeasurementValue = meaGross.VALUERANGE_03.Measurementvalue_02;
                    }

                    if (meaNet != null)
                    {

                        NetMeasurementApplicationQualifier = meaNet.Measurementapplicationqualifier_01;
                        NetMeasurementDimensionCoded = meaNet.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01;
                        NetMeasureUnitQualifier = meaNet.VALUERANGE_03.Measureunitqualifier_01;
                        NetMeasurementValue = meaNet.VALUERANGE_03.Measurementvalue_02;
                    }

                    if (meaVolume != null)
                    {
                        VolumeMeasurementApplicationQualifier = meaVolume.Measurementapplicationqualifier_01;
                        VolumeMeasurementDimensionCoded = meaVolume.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01;
                        VolumeMeasureUnitQualifier = meaVolume.VALUERANGE_03.Measureunitqualifier_01;
                        VolumeMeasurementValue = meaVolume.VALUERANGE_03.Measurementvalue_02;
                    }

                    if (loopCps.PACLoop[0].QTY is var QTYList && QTYList != null)
                    {
                        if (QTYList.FirstOrDefault(x => x.QUANTITYDETAILS_01.Quantityqualifier_01 == "171") is var maxQty && maxQty != null)
                        {
                            MaximumQuantityQualifier = maxQty.QUANTITYDETAILS_01.Quantityqualifier_01;
                            MaximumQuantity = decimal.Parse(maxQty.QUANTITYDETAILS_01.Quantity_02);
                            MaximumQTYMeasureUnitQualifier = maxQty.QUANTITYDETAILS_01.Measureunitqualifier_03;

                        }
                        if (QTYList.FirstOrDefault(x => x.QUANTITYDETAILS_01.Quantityqualifier_01 == "189") is var packageQty && packageQty != null)
                        {
                            PackageQuantityQualifier = packageQty.QUANTITYDETAILS_01.Quantityqualifier_01;
                            PackageQuantity = decimal.Parse(packageQty.QUANTITYDETAILS_01.Quantity_02);
                            PackageQTYMeasureUnitQualifier = packageQty.QUANTITYDETAILS_01.Measureunitqualifier_03;
                        }

                    }

                    if (loopCps.PACLoop[0].PCILoop is var PCIList && PCIList != null)
                    {
                        if (PCIList.FirstOrDefault(x => x.PCI.Markinginstructionscoded_01 == "17") is var pci && pci != null)
                        {
                            MarkingInstructionsCoded = pci.PCI?.Markinginstructionscoded_01;
                            TypeOfMarkingCoded = pci.PCI?.TYPEOFMARKING_04?.Typeofmarkingcoded_01;
                            PCICodeListResponsibleAgencyCoded = pci.PCI?.TYPEOFMARKING_04?.Codelistresponsibleagencycoded_03;

                            if (pci.GINLoop?.FirstOrDefault(x => x.GIN.Identitynumberqualifier_01 == "ML") is var mlGin && mlGin != null)
                            {
                                MLIdentityNumberQualifier = mlGin.GIN?.Identitynumberqualifier_01;
                                MLFirstIdentityNumber1 = mlGin.GIN?.IDENTITYNUMBERRANGE_02?.Identitynumber_01;
                                MLLastIdentityNumber1 = mlGin.GIN?.IDENTITYNUMBERRANGE_02?.Identitynumber_02;
                                MLFirstIdentityNumber2 = mlGin.GIN?.IDENTITYNUMBERRANGE_03?.Identitynumber_01;
                                MLLastIdentityNumber2 = mlGin.GIN?.IDENTITYNUMBERRANGE_03?.Identitynumber_02;
                                MLFirstIdentityNumber3 = mlGin.GIN?.IDENTITYNUMBERRANGE_04?.Identitynumber_01;
                                MLLastIdentityNumber3 = mlGin.GIN?.IDENTITYNUMBERRANGE_04?.Identitynumber_02;
                                MLFirstIdentityNumber4 = mlGin.GIN?.IDENTITYNUMBERRANGE_05?.Identitynumber_01;
                                MLLastIdentityNumber4 = mlGin.GIN?.IDENTITYNUMBERRANGE_05?.Identitynumber_02;
                                MLFirstIdentityNumber5 = mlGin.GIN?.IDENTITYNUMBERRANGE_06?.Identitynumber_01;
                                MLLastIdentityNumber5 = mlGin.GIN?.IDENTITYNUMBERRANGE_06?.Identitynumber_02;
                            }
                            if (pci.GINLoop?.FirstOrDefault(x => x.GIN.Identitynumberqualifier_01 == "AW") is var awGin && awGin != null)
                            {
                                AWIdentityNumberQualifier = awGin.GIN?.Identitynumberqualifier_01;
                                AWFirstIdentityNumber1 = awGin.GIN?.IDENTITYNUMBERRANGE_02?.Identitynumber_01;
                                AWLastIdentityNumber1 = awGin.GIN?.IDENTITYNUMBERRANGE_02?.Identitynumber_02;
                                AWFirstIdentityNumber2 = awGin.GIN?.IDENTITYNUMBERRANGE_03?.Identitynumber_01;
                                AWLastIdentityNumber2 = awGin.GIN?.IDENTITYNUMBERRANGE_03?.Identitynumber_02;
                                AWFirstIdentityNumber3 = awGin.GIN?.IDENTITYNUMBERRANGE_04?.Identitynumber_01;
                                AWLastIdentityNumber3 = awGin.GIN?.IDENTITYNUMBERRANGE_04?.Identitynumber_02;
                                AWFirstIdentityNumber4 = awGin.GIN?.IDENTITYNUMBERRANGE_05?.Identitynumber_01;
                                AWLastIdentityNumber4 = awGin.GIN?.IDENTITYNUMBERRANGE_05?.Identitynumber_02;
                                AWFirstIdentityNumber5 = awGin.GIN?.IDENTITYNUMBERRANGE_06?.Identitynumber_01;
                                AWLastIdentityNumber5 = awGin.GIN?.IDENTITYNUMBERRANGE_06?.Identitynumber_02;
                            }
                        }
                    }
                }

            }

        }

        public void initInnerPackagingMaterialGroup(Loop_CPS_DESADV loopCps)
        {
            if (loopCps.CPS is var cps && cps != null)
            {
                InnerHierarchicalIdNumber = cps?.Hierarchicalidnumber_01;
                InnerPackagingLevelCoded = cps?.Packaginglevelcoded_03;
            }
            if (loopCps.PACLoop is var pacLoop && pacLoop != null)
            {
                if (loopCps.PACLoop.Count > 1)
                {
                    AddEdiConvertError("Outer PAC more than one");
                }

                InnerNumberOfPackages = loopCps.PACLoop[0].PAC.Numberofpackages_01;
                InnerPackagingRelatedInformationCoded = loopCps.PACLoop[0].PAC.PACKAGINGDETAILS_02.Packagingrelatedinformationcoded_02;
                InnerPackagingTermsConditionsCoded = loopCps.PACLoop[0].PAC.PACKAGINGDETAILS_02.Packagingtermsandconditionscoded_03;
                InnerTypeOfPackagesIdentification = loopCps.PACLoop[0].PAC.PACKAGETYPE_03.Typeofpackagesidentification_01;
                InnerPACCodeListResponsibleAgencyCoded = loopCps.PACLoop[0].PAC.PACKAGETYPE_03.Codelistresponsibleagencycoded_03;
                if (loopCps.PACLoop[0].MEA is var MEADesadv && MEADesadv != null)
                {
                    var meaGross = MEADesadv.FirstOrDefault(x => x.Measurementapplicationqualifier_01 == "AAY" && x.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01 == "AAB");
                    var meaNet = MEADesadv.FirstOrDefault(x => x.Measurementapplicationqualifier_01 == "AAY" && x.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01 == "AAA");
                    var meaVolume = MEADesadv.FirstOrDefault(x => x.Measurementapplicationqualifier_01 == "AAY" && x.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01 == "ABJ");
                    if (meaGross != null)
                    {
                        InnerGrossMeasurementApplicationQualifier = meaGross.Measurementapplicationqualifier_01;
                        InnerGrossMeasurementDimensionCoded = meaGross.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01;
                        InnerGrossMeasureUnitQualifier = meaGross.VALUERANGE_03.Measureunitqualifier_01;
                        InnerGrossMeasurementValue = meaGross.VALUERANGE_03.Measurementvalue_02;
                    }

                    if (meaNet != null)
                    {

                        InnerNetMeasurementApplicationQualifier = meaNet.Measurementapplicationqualifier_01;
                        InnerNetMeasurementDimensionCoded = meaNet.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01;
                        InnerNetMeasureUnitQualifier = meaNet.VALUERANGE_03.Measureunitqualifier_01;
                        InnerNetMeasurementValue = meaNet.VALUERANGE_03.Measurementvalue_02;
                    }

                    if (meaVolume != null)
                    {
                        InnerVolumeMeasurementApplicationQualifier = meaVolume.Measurementapplicationqualifier_01;
                        InnerVolumeMeasurementDimensionCoded = meaVolume.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01;
                        InnerVolumeMeasureUnitQualifier = meaVolume.VALUERANGE_03.Measureunitqualifier_01;
                        InnerVolumeMeasurementValue = meaVolume.VALUERANGE_03.Measurementvalue_02;
                    }

                    if (loopCps.PACLoop[0].QTY is var QTYList && QTYList != null)
                    {
                        if (QTYList.FirstOrDefault(x => x.QUANTITYDETAILS_01.Quantityqualifier_01 == "171") is var maxQty && maxQty != null)
                        {
                            InnerMaximumQuantityQualifier = maxQty.QUANTITYDETAILS_01.Quantityqualifier_01;
                            InnerMaximumQuantity = decimal.Parse(maxQty.QUANTITYDETAILS_01.Quantity_02);
                            InnerMaximumQTYMeasureUnitQualifier = maxQty.QUANTITYDETAILS_01.Measureunitqualifier_03;

                        }
                        if (QTYList.FirstOrDefault(x => x.QUANTITYDETAILS_01.Quantityqualifier_01 == "52") is var packageQty && packageQty != null)
                        {
                            InnerPackageQuantityQualifier = packageQty.QUANTITYDETAILS_01.Quantityqualifier_01;
                            InnerPackageQuantity = decimal.Parse(packageQty.QUANTITYDETAILS_01.Quantity_02);
                            InnerPackageQTYMeasureUnitQualifier = packageQty.QUANTITYDETAILS_01.Measureunitqualifier_03;
                        }

                    }

                    if (loopCps.PACLoop[0].PCILoop is var PCIList && PCIList != null)
                    {
                        if (PCIList.FirstOrDefault(x => x.PCI.Markinginstructionscoded_01 == "17") is var pci && pci != null)
                        {
                            InnerMarkingInstructionsCoded = pci.PCI?.Markinginstructionscoded_01;
                            InnerTypeOfMarkingCoded = pci.PCI?.TYPEOFMARKING_04?.Typeofmarkingcoded_01;
                            InnerPCICodeListResponsibleAgencyCoded = pci.PCI?.TYPEOFMARKING_04?.Codelistresponsibleagencycoded_03;

                            if (pci.GINLoop?.FirstOrDefault(x => x.GIN.Identitynumberqualifier_01 == "ML") is var mlGin && mlGin != null)
                            {
                                InnerMLIdentityNumberQualifier = mlGin.GIN?.Identitynumberqualifier_01;
                                InnerMLFirstIdentityNumber1 = mlGin.GIN?.IDENTITYNUMBERRANGE_02?.Identitynumber_01;
                                InnerMLLastIdentityNumber1 = mlGin.GIN?.IDENTITYNUMBERRANGE_02?.Identitynumber_02;

                                InnerMLFirstIdentityNumber2 = mlGin.GIN?.IDENTITYNUMBERRANGE_03?.Identitynumber_01;
                                InnerMLLastIdentityNumber2 = mlGin.GIN?.IDENTITYNUMBERRANGE_03?.Identitynumber_02;

                                InnerMLFirstIdentityNumber3 = mlGin.GIN?.IDENTITYNUMBERRANGE_04?.Identitynumber_01;
                                InnerMLLastIdentityNumber3 = mlGin.GIN?.IDENTITYNUMBERRANGE_04?.Identitynumber_02;

                                InnerMLFirstIdentityNumber4 = mlGin.GIN?.IDENTITYNUMBERRANGE_05?.Identitynumber_01;
                                InnerMLLastIdentityNumber4 = mlGin.GIN?.IDENTITYNUMBERRANGE_05?.Identitynumber_02;

                                InnerMLFirstIdentityNumber5 = mlGin.GIN?.IDENTITYNUMBERRANGE_06?.Identitynumber_01;
                                InnerMLLastIdentityNumber5 = mlGin.GIN?.IDENTITYNUMBERRANGE_06?.Identitynumber_02;
                            }

                        }
                    }
                }

            }

            if (loopCps.LINLoop != null)
            {
                LineItems = GenerateLineItems(loopCps.LINLoop);
            }
            else
            {
                AddEdiConvertError("Line items for Delivery Note is empty.");
            }

        }
        private List<LineItemDeliveryNote> GenerateLineItems(List<Loop_LIN_DESADV> linOrders)
        {
            List<LineItemDeliveryNote> lineItems = new List<LineItemDeliveryNote>();
            if (linOrders.Any())
            {
                foreach (var lin in linOrders)
                {
                    var lineItem = new LineItemDeliveryNote();
                    lineItem.init(lin);
                    lineItems.Add(lineItem);
                }

            }
            return lineItems;
        }

        public RFF generateTransportRFF()
        {
            RFF rff = new RFF();
            rff.REFERENCE_01 = new C506();
            rff.REFERENCE_01.Referencequalifier_01 = TransportReferenceQualifier;
            rff.REFERENCE_01.Referencenumber_02 = TransportReferenceNumber;
            return rff;
        }
        public RFF generateConveyanceRFF()
        {
            RFF rff = new RFF();
            rff.REFERENCE_01 = new C506();
            rff.REFERENCE_01.Referencequalifier_01 = ConveyanceReferenceQualifier;
            rff.REFERENCE_01.Referencenumber_02 = ConveyanceReferenceNumber;
            return rff;
        }


        public NAD generateCarrier()
        {
            NAD nad = new NAD();
            nad.Partyqualifier_01 = Carrier_PartyQualifier;
            nad.PARTYIDENTIFICATIONDETAILS_02 = new C082();
            nad.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01 = Carrier_PartyId;
            nad.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03 = Carrier_ResponsibleAgency;
            nad.PARTYNAME_04 = new C080();
            nad.PARTYNAME_04.Partyname_01 = Carrier_CompanyName;
            nad.STREET_05 = new C059();
            nad.STREET_05.Streetandnumberpobox_01 = Carrier_Street;
            nad.Cityname_06 = Carrier_CityName;
            nad.Postcodeidentification_08 = Carrier_Postcode;
            nad.Countrycoded_09 = Carrier_CountryCode;
            return nad;
        }
        public NAD generateFreightForwarder()
        {
            NAD nad = new NAD();
            nad.Partyqualifier_01 = FreightForwarder_PartyQualifier;
            nad.PARTYIDENTIFICATIONDETAILS_02 = new C082();
            nad.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01 = FreightForwarder_PartyId;
            nad.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03 = FreightForwarder_ResponsibleAgency;
            nad.PARTYNAME_04 = new C080();
            nad.PARTYNAME_04.Partyname_01 = FreightForwarder_CompanyName;
            nad.STREET_05 = new C059();
            nad.STREET_05.Streetandnumberpobox_01 = FreightForwarder_Street;
            nad.Cityname_06 = FreightForwarder_CityName;
            nad.Postcodeidentification_08 = FreightForwarder_Postcode;
            nad.Countrycoded_09 = FreightForwarder_CountryCode;
            return nad;
        }
        public LOC generateDeliveryLOC()
        {
            LOC deliveryRecipientLoc = new LOC();
            deliveryRecipientLoc.Placelocationqualifier_01 = Delivery_PlaceLocationQualifier; //.DeliveryRecipient.Location.PlaceLocationQualifier;
            deliveryRecipientLoc.LOCATIONIDENTIFICATION_02 = new C517();
            deliveryRecipientLoc.LOCATIONIDENTIFICATION_02.Placelocationidentification_01 = Delivery_PlaceLocationIdentification;
            return deliveryRecipientLoc;
        }
        public TOD generateDeliveryCondition1()
        {
            TOD tod = new TOD();
            tod.Termsofdeliveryortransportfunctioncoded_01 = TermsOfDeliveryFunctionCode;
            tod.TERMSOFDELIVERYORTRANSPORT_03 = new C100();
            tod.TERMSOFDELIVERYORTRANSPORT_03.Termsofdeliveryortransportcoded_01 = TermsOfDeliveryIncoterms;
            return tod;
        }

        public TDT generateTDT()
        {
            TDT tdt = new TDT();
            tdt.Transportstagequalifier_01 = TransportStageQualifier;
            tdt.MODEOFTRANSPORT_03 = new C220();
            tdt.MODEOFTRANSPORT_03.Modeoftransportcoded_01 = ModeOfTransportCoded;
            tdt.TRANSPORTMEANS_04 = new C228();
            tdt.TRANSPORTMEANS_04.Typeofmeansoftransportidentification_01 = TypeOfMeansTransportCoded;
            return tdt;
        }

        public LOC generateDeliveryConditionLocation1()
        {
            if (!string.IsNullOrEmpty(TermsOfDeliveryPlaceLocationQualifier))
            {
                var loc = new LOC();
                loc.Placelocationqualifier_01 = TermsOfDeliveryPlaceLocationQualifier;
                loc.LOCATIONIDENTIFICATION_02 = new C517();
                loc.LOCATIONIDENTIFICATION_02.Placelocationidentification_01 = TermsOfDeliveryPlaceLocationIdentification;
                return loc;
            }

            return null;
        }

        public Loop_CPS_DESADV generateHandlingUnitGroup()
        {
            Loop_CPS_DESADV loopCps = new Loop_CPS_DESADV();
            loopCps.CPS = new CPS();
            loopCps.CPS.Hierarchicalidnumber_01 = HierarchicalIdNumber;
            loopCps.CPS.Packaginglevelcoded_03 = PackagingLevelCoded;

            loopCps.PACLoop = new List<Loop_PAC_DESADV>();
            Loop_PAC_DESADV pacDesadv = new Loop_PAC_DESADV();
            pacDesadv.PAC = new PAC();
            pacDesadv.PAC.Numberofpackages_01 = NumberOfPackages;
            pacDesadv.PAC.PACKAGINGDETAILS_02 = new C531();
            pacDesadv.PAC.PACKAGINGDETAILS_02.Packagingrelatedinformationcoded_02 = PackagingRelatedInformationCoded;
            pacDesadv.PAC.PACKAGINGDETAILS_02.Packagingtermsandconditionscoded_03 = PackagingTermsConditionsCoded;
            pacDesadv.PAC.PACKAGETYPE_03 = new C202();
            pacDesadv.PAC.PACKAGETYPE_03.Typeofpackagesidentification_01 = TypeOfPackagesIdentification;
            pacDesadv.PAC.PACKAGETYPE_03.Codelistresponsibleagencycoded_03 = PACCodeListResponsibleAgencyCoded;

           
            if (!string.IsNullOrEmpty(GrossMeasurementApplicationQualifier) || !string.IsNullOrEmpty(NetMeasurementApplicationQualifier) || !string.IsNullOrEmpty(VolumeMeasurementApplicationQualifier))
            {
                pacDesadv.MEA = new List<MEA>();
                if (!string.IsNullOrEmpty(GrossMeasurementApplicationQualifier))
                {
                    MEA meaGross = new MEA();
                    meaGross.Measurementapplicationqualifier_01 = GrossMeasurementApplicationQualifier;
                    meaGross.MEASUREMENTDETAILS_02 = new C502();
                    meaGross.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01 = GrossMeasurementDimensionCoded;
                    meaGross.VALUERANGE_03 = new C174();
                    meaGross.VALUERANGE_03.Measureunitqualifier_01 = GrossMeasureUnitQualifier;
                    meaGross.VALUERANGE_03.Measurementvalue_02 = GrossMeasurementValue;
                    pacDesadv.MEA.Add(meaGross);
                }

                if (!string.IsNullOrEmpty(NetMeasurementApplicationQualifier))
                {
                    MEA meaNet = new MEA();
                    meaNet.Measurementapplicationqualifier_01 = NetMeasurementApplicationQualifier;
                    meaNet.MEASUREMENTDETAILS_02 = new C502();
                    meaNet.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01 = NetMeasurementDimensionCoded;
                    meaNet.VALUERANGE_03 = new C174();
                    meaNet.VALUERANGE_03.Measureunitqualifier_01 = NetMeasureUnitQualifier;
                    meaNet.VALUERANGE_03.Measurementvalue_02 = NetMeasurementValue;
                    pacDesadv.MEA.Add(meaNet);
                }
                if (!string.IsNullOrEmpty(VolumeMeasurementApplicationQualifier))
                {
                    MEA meaVolume = new MEA();
                    meaVolume.Measurementapplicationqualifier_01 = VolumeMeasurementApplicationQualifier;
                    meaVolume.MEASUREMENTDETAILS_02 = new C502();
                    meaVolume.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01 = VolumeMeasurementDimensionCoded;
                    meaVolume.VALUERANGE_03 = new C174();
                    meaVolume.VALUERANGE_03.Measureunitqualifier_01 = VolumeMeasureUnitQualifier;
                    meaVolume.VALUERANGE_03.Measurementvalue_02 = VolumeMeasurementValue;
                    pacDesadv.MEA.Add(meaVolume);
                }
            }

            if (!string.IsNullOrEmpty(MaximumQuantityQualifier)|| !string.IsNullOrEmpty(PackageQuantityQualifier))
            {
                pacDesadv.QTY = new List<QTY>();
                if (!string.IsNullOrEmpty(MaximumQuantityQualifier))
                {
                    QTY maxQty = new QTY();
                    maxQty.QUANTITYDETAILS_01 = new C186();
                    maxQty.QUANTITYDETAILS_01.Quantityqualifier_01 = MaximumQuantityQualifier;
                    if (MaximumQuantity != null)
                        maxQty.QUANTITYDETAILS_01.Quantity_02 = MaximumQuantity.Value.ToString("G29", CultureInfo.InvariantCulture);
                    maxQty.QUANTITYDETAILS_01.Measureunitqualifier_03 = MaximumQTYMeasureUnitQualifier;
                    pacDesadv.QTY.Add(maxQty);
                }
                if (!string.IsNullOrEmpty(PackageQuantityQualifier))
                {
                    QTY packageQty = new QTY();
                    packageQty.QUANTITYDETAILS_01 = new C186();
                    packageQty.QUANTITYDETAILS_01.Quantityqualifier_01 = PackageQuantityQualifier;
                    if (PackageQuantity != null)
                        packageQty.QUANTITYDETAILS_01.Quantity_02 = PackageQuantity.Value.ToString("G29", CultureInfo.InvariantCulture);
                    packageQty.QUANTITYDETAILS_01.Measureunitqualifier_03 = PackageQTYMeasureUnitQualifier;
                    pacDesadv.QTY.Add(packageQty);
                }
            }

            pacDesadv.PCILoop = new List<Loop_PCI_DESADV>();
            Loop_PCI_DESADV pciLoop = new Loop_PCI_DESADV();
            pciLoop.PCI = new PCI();
            pciLoop.PCI.Markinginstructionscoded_01 = MarkingInstructionsCoded;
            pciLoop.PCI.TYPEOFMARKING_04 = new C827();
            pciLoop.PCI.TYPEOFMARKING_04.Typeofmarkingcoded_01 = TypeOfMarkingCoded;
            pciLoop.PCI.TYPEOFMARKING_04.Codelistresponsibleagencycoded_03 = PCICodeListResponsibleAgencyCoded;

            pciLoop.GINLoop = new List<Loop_GIN_DESADV>();
            Loop_GIN_DESADV mlGin = new Loop_GIN_DESADV();
            mlGin.GIN = new GIN();
            mlGin.GIN.Identitynumberqualifier_01 = MLIdentityNumberQualifier;
            if (MLFirstIdentityNumber1 != null || MLLastIdentityNumber1 != null)
            {
                mlGin.GIN.IDENTITYNUMBERRANGE_02 = new C208();
                mlGin.GIN.IDENTITYNUMBERRANGE_02.Identitynumber_01 = MLFirstIdentityNumber1;
                mlGin.GIN.IDENTITYNUMBERRANGE_02.Identitynumber_02 = MLLastIdentityNumber1;
            }
            if (MLFirstIdentityNumber2 != null || MLLastIdentityNumber2 != null)
            {
                mlGin.GIN.IDENTITYNUMBERRANGE_03 = new C208();
                mlGin.GIN.IDENTITYNUMBERRANGE_03.Identitynumber_01 = MLFirstIdentityNumber2;
                mlGin.GIN.IDENTITYNUMBERRANGE_03.Identitynumber_02 = MLLastIdentityNumber2;
            }
            if (MLFirstIdentityNumber3 != null || MLLastIdentityNumber3 != null)
            {
                mlGin.GIN.IDENTITYNUMBERRANGE_04 = new C208();
                mlGin.GIN.IDENTITYNUMBERRANGE_04.Identitynumber_01 = MLFirstIdentityNumber3;
                mlGin.GIN.IDENTITYNUMBERRANGE_04.Identitynumber_02 = MLLastIdentityNumber3;
            }
            if (MLFirstIdentityNumber4 != null || MLLastIdentityNumber4 != null)
            {
                mlGin.GIN.IDENTITYNUMBERRANGE_05 = new C208();
                mlGin.GIN.IDENTITYNUMBERRANGE_05.Identitynumber_01 = MLFirstIdentityNumber4;
                mlGin.GIN.IDENTITYNUMBERRANGE_05.Identitynumber_02 = MLLastIdentityNumber4;
            }
            if (MLFirstIdentityNumber5 != null || MLLastIdentityNumber5 != null)
            {
                mlGin.GIN.IDENTITYNUMBERRANGE_06 = new C208();
                mlGin.GIN.IDENTITYNUMBERRANGE_06.Identitynumber_01 = MLFirstIdentityNumber5;
                mlGin.GIN.IDENTITYNUMBERRANGE_06.Identitynumber_02 = MLLastIdentityNumber5;
            }

            pciLoop.GINLoop.Add(mlGin);

            Loop_GIN_DESADV awGin = new Loop_GIN_DESADV();
            awGin.GIN = new GIN();
            awGin.GIN.Identitynumberqualifier_01 = AWIdentityNumberQualifier;
            if (AWFirstIdentityNumber1 != null || AWLastIdentityNumber1 != null)
            {
                awGin.GIN.IDENTITYNUMBERRANGE_02 = new C208();
                awGin.GIN.IDENTITYNUMBERRANGE_02.Identitynumber_01 = AWFirstIdentityNumber1;
                awGin.GIN.IDENTITYNUMBERRANGE_02.Identitynumber_02 = AWLastIdentityNumber1;
            }
            if (AWFirstIdentityNumber2 != null || AWLastIdentityNumber2 != null)
            {
                awGin.GIN.IDENTITYNUMBERRANGE_03 = new C208();
                awGin.GIN.IDENTITYNUMBERRANGE_03.Identitynumber_01 = AWFirstIdentityNumber2;
                awGin.GIN.IDENTITYNUMBERRANGE_03.Identitynumber_02 = AWLastIdentityNumber2;
            }
            if (AWFirstIdentityNumber3 != null || AWLastIdentityNumber3 != null)
            {
                awGin.GIN.IDENTITYNUMBERRANGE_04 = new C208();
                awGin.GIN.IDENTITYNUMBERRANGE_04.Identitynumber_01 = AWFirstIdentityNumber3;
                awGin.GIN.IDENTITYNUMBERRANGE_04.Identitynumber_02 = AWLastIdentityNumber3;
            }
            if (AWFirstIdentityNumber4 != null || AWLastIdentityNumber4 != null)
            {
                awGin.GIN.IDENTITYNUMBERRANGE_05 = new C208();
                awGin.GIN.IDENTITYNUMBERRANGE_05.Identitynumber_01 = AWFirstIdentityNumber4;
                awGin.GIN.IDENTITYNUMBERRANGE_05.Identitynumber_02 = AWLastIdentityNumber4;
            }
            if (AWFirstIdentityNumber5 != null || AWLastIdentityNumber5 != null)
            {
                awGin.GIN.IDENTITYNUMBERRANGE_06 = new C208();
                awGin.GIN.IDENTITYNUMBERRANGE_06.Identitynumber_01 = AWFirstIdentityNumber5;
                awGin.GIN.IDENTITYNUMBERRANGE_06.Identitynumber_02 = AWLastIdentityNumber5;
            }

            pciLoop.GINLoop.Add(awGin);

            pacDesadv.PCILoop.Add(pciLoop);
            loopCps.PACLoop.Add(pacDesadv);
            return loopCps;

        }
        public Loop_CPS_DESADV generatePackagingMaterialGroup()
        {
            Loop_CPS_DESADV loopCps = new Loop_CPS_DESADV();
            loopCps.CPS = new CPS();
            loopCps.CPS.Hierarchicalidnumber_01 = InnerHierarchicalIdNumber;
            loopCps.CPS.Packaginglevelcoded_03 = InnerPackagingLevelCoded;

            loopCps.PACLoop = new List<Loop_PAC_DESADV>();
            Loop_PAC_DESADV pacDesadv = new Loop_PAC_DESADV();
            pacDesadv.PAC = new PAC();
            pacDesadv.PAC.Numberofpackages_01 = InnerNumberOfPackages;
            pacDesadv.PAC.PACKAGINGDETAILS_02 = new C531();
            pacDesadv.PAC.PACKAGINGDETAILS_02.Packagingrelatedinformationcoded_02 = InnerPackagingRelatedInformationCoded;
            pacDesadv.PAC.PACKAGINGDETAILS_02.Packagingtermsandconditionscoded_03 = InnerPackagingTermsConditionsCoded;
            pacDesadv.PAC.PACKAGETYPE_03 = new C202();
            pacDesadv.PAC.PACKAGETYPE_03.Typeofpackagesidentification_01 = InnerTypeOfPackagesIdentification;
            pacDesadv.PAC.PACKAGETYPE_03.Codelistresponsibleagencycoded_03 = InnerPACCodeListResponsibleAgencyCoded;

            if (!string.IsNullOrEmpty(InnerGrossMeasurementApplicationQualifier) || !string.IsNullOrEmpty(InnerNetMeasurementApplicationQualifier) || !string.IsNullOrEmpty(InnerVolumeMeasurementApplicationQualifier))
            {
                pacDesadv.MEA = new List<MEA>();
                if (!string.IsNullOrEmpty(InnerGrossMeasurementApplicationQualifier))
                {
                    MEA meaGross = new MEA();
                    meaGross.Measurementapplicationqualifier_01 = InnerGrossMeasurementApplicationQualifier;
                    meaGross.MEASUREMENTDETAILS_02 = new C502();
                    meaGross.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01 = InnerGrossMeasurementDimensionCoded;
                    meaGross.VALUERANGE_03 = new C174();
                    meaGross.VALUERANGE_03.Measureunitqualifier_01 = InnerGrossMeasureUnitQualifier;
                    meaGross.VALUERANGE_03.Measurementvalue_02 = InnerGrossMeasurementValue;
                    pacDesadv.MEA.Add(meaGross);
                }

                if (!string.IsNullOrEmpty(InnerNetMeasurementApplicationQualifier))
                {
                    MEA meaNet = new MEA();
                    meaNet.Measurementapplicationqualifier_01 = InnerNetMeasurementApplicationQualifier;
                    meaNet.MEASUREMENTDETAILS_02 = new C502();
                    meaNet.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01 = InnerNetMeasurementDimensionCoded;
                    meaNet.VALUERANGE_03 = new C174();
                    meaNet.VALUERANGE_03.Measureunitqualifier_01 = InnerNetMeasureUnitQualifier;
                    meaNet.VALUERANGE_03.Measurementvalue_02 = InnerNetMeasurementValue;
                    pacDesadv.MEA.Add(meaNet);
                }
                if (!string.IsNullOrEmpty(InnerVolumeMeasurementApplicationQualifier))
                {
                    MEA meaVolume = new MEA();
                    meaVolume.Measurementapplicationqualifier_01 = InnerVolumeMeasurementApplicationQualifier;
                    meaVolume.MEASUREMENTDETAILS_02 = new C502();
                    meaVolume.MEASUREMENTDETAILS_02.Measurementdimensioncoded_01 = InnerVolumeMeasurementDimensionCoded;
                    meaVolume.VALUERANGE_03 = new C174();
                    meaVolume.VALUERANGE_03.Measureunitqualifier_01 = InnerVolumeMeasureUnitQualifier;
                    meaVolume.VALUERANGE_03.Measurementvalue_02 = InnerVolumeMeasurementValue;
                    pacDesadv.MEA.Add(meaVolume);
                }
            }

            if (!string.IsNullOrEmpty(InnerMaximumQuantityQualifier) || !string.IsNullOrEmpty(InnerPackageQuantityQualifier))
            {
                pacDesadv.QTY = new List<QTY>();
                if (!string.IsNullOrEmpty(InnerMaximumQuantityQualifier))
                {
                    QTY maxQty = new QTY();
                    maxQty.QUANTITYDETAILS_01 = new C186();
                    maxQty.QUANTITYDETAILS_01.Quantityqualifier_01 = InnerMaximumQuantityQualifier;
                    if (InnerMaximumQuantity != null)
                        maxQty.QUANTITYDETAILS_01.Quantity_02 = InnerMaximumQuantity.Value.ToString("G29", CultureInfo.InvariantCulture);
                    maxQty.QUANTITYDETAILS_01.Measureunitqualifier_03 = InnerMaximumQTYMeasureUnitQualifier;
                    pacDesadv.QTY.Add(maxQty);
                }

                if (!string.IsNullOrEmpty(InnerPackageQuantityQualifier))
                {
                    QTY packageQty = new QTY();
                    packageQty.QUANTITYDETAILS_01 = new C186();
                    packageQty.QUANTITYDETAILS_01.Quantityqualifier_01 = InnerPackageQuantityQualifier;
                    if (InnerPackageQuantity != null)
                        packageQty.QUANTITYDETAILS_01.Quantity_02 = InnerPackageQuantity.Value.ToString("G29", CultureInfo.InvariantCulture);
                    packageQty.QUANTITYDETAILS_01.Measureunitqualifier_03 = InnerPackageQTYMeasureUnitQualifier;
                    pacDesadv.QTY.Add(packageQty);
                }
            }

            pacDesadv.PCILoop = new List<Loop_PCI_DESADV>();
            Loop_PCI_DESADV pciLoop = new Loop_PCI_DESADV();
            pciLoop.PCI = new PCI();
            pciLoop.PCI.Markinginstructionscoded_01 = InnerMarkingInstructionsCoded;
            pciLoop.PCI.TYPEOFMARKING_04 = new C827();
            pciLoop.PCI.TYPEOFMARKING_04.Typeofmarkingcoded_01 = InnerTypeOfMarkingCoded;
            pciLoop.PCI.TYPEOFMARKING_04.Codelistresponsibleagencycoded_03 = InnerPCICodeListResponsibleAgencyCoded;

            pciLoop.GINLoop = new List<Loop_GIN_DESADV>();
            Loop_GIN_DESADV mlGin = new Loop_GIN_DESADV();
            mlGin.GIN = new GIN();
            mlGin.GIN.Identitynumberqualifier_01 = InnerMLIdentityNumberQualifier;
            if (InnerMLFirstIdentityNumber1 != null || InnerMLLastIdentityNumber1 != null)
            {
                mlGin.GIN.IDENTITYNUMBERRANGE_02 = new C208();
                mlGin.GIN.IDENTITYNUMBERRANGE_02.Identitynumber_01 = InnerMLFirstIdentityNumber1;
                mlGin.GIN.IDENTITYNUMBERRANGE_02.Identitynumber_02 = InnerMLLastIdentityNumber1;
            }
            if (InnerMLFirstIdentityNumber2 != null || InnerMLLastIdentityNumber2 != null)
            {
                mlGin.GIN.IDENTITYNUMBERRANGE_03 = new C208();
                mlGin.GIN.IDENTITYNUMBERRANGE_03.Identitynumber_01 = InnerMLFirstIdentityNumber2;
                mlGin.GIN.IDENTITYNUMBERRANGE_03.Identitynumber_02 = InnerMLLastIdentityNumber2;
            }
            if (InnerMLFirstIdentityNumber3 != null || InnerMLLastIdentityNumber3 != null)
            {
                mlGin.GIN.IDENTITYNUMBERRANGE_04 = new C208();
                mlGin.GIN.IDENTITYNUMBERRANGE_04.Identitynumber_01 = InnerMLFirstIdentityNumber3;
                mlGin.GIN.IDENTITYNUMBERRANGE_04.Identitynumber_02 = InnerMLLastIdentityNumber3;
            }
            if (InnerMLFirstIdentityNumber4 != null || InnerMLLastIdentityNumber4 != null)
            {
                mlGin.GIN.IDENTITYNUMBERRANGE_05 = new C208();
                mlGin.GIN.IDENTITYNUMBERRANGE_05.Identitynumber_01 = InnerMLFirstIdentityNumber4;
                mlGin.GIN.IDENTITYNUMBERRANGE_05.Identitynumber_02 = InnerMLLastIdentityNumber4;
            }
            if (InnerMLFirstIdentityNumber5 != null || InnerMLLastIdentityNumber5 != null)
            {
                mlGin.GIN.IDENTITYNUMBERRANGE_06 = new C208();
                mlGin.GIN.IDENTITYNUMBERRANGE_06.Identitynumber_01 = InnerMLFirstIdentityNumber5;
                mlGin.GIN.IDENTITYNUMBERRANGE_06.Identitynumber_02 = InnerMLLastIdentityNumber5;
            }

            pciLoop.GINLoop.Add(mlGin);

            pacDesadv.PCILoop.Add(pciLoop);
            loopCps.PACLoop.Add(pacDesadv);

            loopCps.LINLoop = generateLineItems();
            return loopCps;

        }

        private List<Loop_LIN_DESADV> generateLineItems()
        {
            #region Line Item
            List<Loop_LIN_DESADV> lineList = new List<Loop_LIN_DESADV>();
           
            foreach (var lineItem in LineItems)
            {
                var linLoop1 = new Loop_LIN_DESADV();
                linLoop1.LIN = lineItem.generateLIN();
                var pia = lineItem.generatePIA();
                if (pia != null)
                {
                    linLoop1.PIA = new List<PIA>();
                    linLoop1.PIA.Add(pia);
                }
                var imd = lineItem.generateIMD();
                if (imd != null)
                {
                    linLoop1.IMD = new List<EdiFabric.Templates.EdifactD96A.IMD>();
                    linLoop1.IMD.Add(imd);
                }
                var qty = lineItem.generateQTY();
                if (qty != null)
                {
                    linLoop1.QTY = new List<QTY>();
                    linLoop1.QTY.Add(qty);
                }
                
                var ali = lineItem.generateALI();
                if (ali != null)
                {
                    linLoop1.ALI = new List<ALI>();
                    linLoop1.ALI.Add(ali);
                }

                var gin = lineItem.generateGIN();
                if (gin!=null)
                {
                    linLoop1.GIN = new List<GIN>();
                    linLoop1.GIN.Add(gin);
                }

                var gir = lineItem.generateGIR();
                if (gir != null)
                {
                    linLoop1.GIR = new List<GIR>();
                    linLoop1.GIR.Add(gir);
                }

                var manufacturingDtm = lineItem.generateManufacturingDTM();
                if (manufacturingDtm != null)
                {
                    linLoop1.DTM = new List<DTM>();
                    linLoop1.DTM.Add(manufacturingDtm);
                }

                var moa = lineItem.generateMOA();
                if (moa != null)
                {
                    linLoop1.MOA = new List<MOA>();
                    linLoop1.MOA.Add(moa);
                }

                linLoop1.RFFLoop = new List<Loop_RFF_DESADV>();
                Loop_RFF_DESADV rffPurchaseLoop = new Loop_RFF_DESADV();
                rffPurchaseLoop.RFF = lineItem.generatePurchaseRFF();
                rffPurchaseLoop.DTM = lineItem.generatePurchaseDTM();

                linLoop1.RFFLoop.Add(rffPurchaseLoop);

                Loop_RFF_DESADV rffDespatchLoop = new Loop_RFF_DESADV();
                rffDespatchLoop.RFF = lineItem.generateDespatchRFF();
                rffDespatchLoop.DTM = lineItem.generateDespatchDTM();
                linLoop1.RFFLoop.Add(rffDespatchLoop);


                lineList.Add(linLoop1);
            }
            #endregion

            return lineList;
        }
    }
}
