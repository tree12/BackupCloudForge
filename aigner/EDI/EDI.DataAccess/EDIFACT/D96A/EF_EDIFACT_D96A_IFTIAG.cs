namespace EdiFabric.Templates.EdifactD96A
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using EdiFabric.Core.Annotations.Edi;
    using EdiFabric.Core.Annotations.Validation;
    using EdiFabric.Core.Model.Edi;
    using EdiFabric.Core.Model.Edi.Edifact;
    using System.Xml.Serialization;
    
    
    /// <summary>
    /// Loop for CONSIGNMENT INFORMATION
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(CNI))]
    public class Loop_CNI_IFTIAG
    {
        
        [XmlIgnore]
        [IgnoreDataMember]
        public int Id { get; set; }
        /// <summary>
        /// CONSIGNMENT INFORMATION
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public virtual CNI CNI { get; set; }
        /// <summary>
        /// PLACE/LOCATION IDENTIFICATION
        /// </summary>
        [DataMember]
        [ListCount(2)]
        [Pos(2)]
        public virtual List<LOC> LOC { get; set; }
        /// <summary>
        /// REFERENCE
        /// </summary>
        [DataMember]
        [ListCount(2)]
        [Pos(3)]
        public virtual List<RFF> RFF { get; set; }
        /// <summary>
        /// NAME AND ADDRESS
        /// </summary>
        [DataMember]
        [ListCount(2)]
        [Pos(4)]
        public virtual List<NAD> NAD { get; set; }
        /// <summary>
        /// Loop for GOODS ITEM DETAILS
        /// </summary>
        [DataMember]
        [Required]
        [ListCount(9999)]
        [Pos(5)]
        public virtual List<Loop_GID_IFTIAG> GIDLoop { get; set; }
    }
    
    /// <summary>
    /// Loop for DANGEROUS GOODS
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(DGS))]
    public class Loop_DGS_IFTIAG
    {
        
        [XmlIgnore]
        [IgnoreDataMember]
        public int Id { get; set; }
        /// <summary>
        /// DANGEROUS GOODS
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public virtual DGS DGS { get; set; }
        /// <summary>
        /// FREE TEXT
        /// </summary>
        [DataMember]
        [ListCount(5)]
        [Pos(2)]
        public virtual List<FTX> FTX { get; set; }
        /// <summary>
        /// MEASUREMENTS
        /// </summary>
        [DataMember]
        [ListCount(2)]
        [Pos(3)]
        public virtual List<MEA> MEA { get; set; }
        /// <summary>
        /// Loop for SPLIT GOODS PLACEMENT
        /// </summary>
        [DataMember]
        [Required]
        [ListCount(9999)]
        [Pos(4)]
        public virtual List<Loop_SGP_IFTIAG> SGPLoop { get; set; }
    }
    
    /// <summary>
    /// Loop for EQUIPMENT DETAILS
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(EQD))]
    public class Loop_EQD_IFTIAG
    {
        
        [XmlIgnore]
        [IgnoreDataMember]
        public int Id { get; set; }
        /// <summary>
        /// EQUIPMENT DETAILS
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public virtual EQD EQD { get; set; }
        /// <summary>
        /// SEAL NUMBER
        /// </summary>
        [DataMember]
        [Pos(2)]
        public virtual SEL SEL { get; set; }
    }
    
    /// <summary>
    /// Loop for GOODS ITEM DETAILS
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(GID))]
    public class Loop_GID_IFTIAG
    {
        
        [XmlIgnore]
        [IgnoreDataMember]
        public int Id { get; set; }
        /// <summary>
        /// GOODS ITEM DETAILS
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public virtual GID GID { get; set; }
        /// <summary>
        /// FREE TEXT
        /// </summary>
        [DataMember]
        [Required]
        [ListCount(5)]
        [Pos(2)]
        public virtual List<FTX> FTX { get; set; }
        /// <summary>
        /// PACKAGE IDENTIFICATION
        /// </summary>
        [DataMember]
        [Pos(3)]
        public virtual PCI PCI { get; set; }
        /// <summary>
        /// Loop for DANGEROUS GOODS
        /// </summary>
        [DataMember]
        [Required]
        [Pos(4)]
        public virtual Loop_DGS_IFTIAG DGSLoop { get; set; }
    }
    
    /// <summary>
    /// Loop for PLACE/LOCATION IDENTIFICATION
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(LOC))]
    public class Loop_LOC_IFTIAG
    {
        
        [XmlIgnore]
        [IgnoreDataMember]
        public int Id { get; set; }
        /// <summary>
        /// PLACE/LOCATION IDENTIFICATION
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public virtual LOC LOC { get; set; }
        /// <summary>
        /// NAME AND ADDRESS
        /// </summary>
        [DataMember]
        [Pos(2)]
        public virtual NAD NAD { get; set; }
        /// <summary>
        /// REFERENCE
        /// </summary>
        [DataMember]
        [Pos(3)]
        public virtual RFF RFF { get; set; }
        /// <summary>
        /// DATE/TIME/PERIOD
        /// </summary>
        [DataMember]
        [Pos(4)]
        public virtual DTM DTM { get; set; }
    }
    
    /// <summary>
    /// Loop for SPLIT GOODS PLACEMENT
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(SGP))]
    public class Loop_SGP_IFTIAG
    {
        
        [XmlIgnore]
        [IgnoreDataMember]
        public int Id { get; set; }
        /// <summary>
        /// SPLIT GOODS PLACEMENT
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public virtual SGP SGP { get; set; }
        /// <summary>
        /// PLACE/LOCATION IDENTIFICATION
        /// </summary>
        [DataMember]
        [Pos(2)]
        public virtual LOC LOC { get; set; }
        /// <summary>
        /// MEASUREMENTS
        /// </summary>
        [DataMember]
        [ListCount(2)]
        [Pos(3)]
        public virtual List<MEA> MEA { get; set; }
    }
    
    /// <summary>
    /// Loop for DETAILS OF TRANSPORT
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Group(typeof(TDT))]
    public class Loop_TDT_IFTIAG
    {
        
        [XmlIgnore]
        [IgnoreDataMember]
        public int Id { get; set; }
        /// <summary>
        /// DETAILS OF TRANSPORT
        /// </summary>
        [DataMember]
        [Required]
        [Pos(1)]
        public virtual TDT TDT { get; set; }
        /// <summary>
        /// DATE/TIME/PERIOD
        /// </summary>
        [DataMember]
        [Pos(2)]
        public virtual DTM DTM { get; set; }
        /// <summary>
        /// CONTACT INFORMATION
        /// </summary>
        [DataMember]
        [Pos(3)]
        public virtual CTA CTA { get; set; }
    }
    
    /// <summary>
    /// Dangerous cargo list message
    /// </summary>
    [Serializable()]
    [DataContract()]
    [Message("EDIFACT", "IFTIAG")]
    public class TSIFTIAG : EdiMessage
    {
        
        [XmlIgnore]
        [IgnoreDataMember]
        public int Id { get; set; }
        /// <summary>
        /// Message Header
        /// </summary>
        [DataMember]
        [Pos(1)]
        public virtual UNH UNH { get; set; }
        /// <summary>
        /// BEGINNING OF MESSAGE
        /// </summary>
        [DataMember]
        [Required]
        [Pos(2)]
        public virtual BGM BGM { get; set; }
        /// <summary>
        /// CONTROL TOTAL
        /// </summary>
        [DataMember]
        [Required]
        [Pos(3)]
        public virtual CNT CNT { get; set; }
        /// <summary>
        /// FREE TEXT
        /// </summary>
        [DataMember]
        [ListCount(5)]
        [Pos(4)]
        public virtual List<FTX> FTX { get; set; }
        /// <summary>
        /// REFERENCE
        /// </summary>
        [DataMember]
        [Pos(5)]
        public virtual RFF RFF { get; set; }
        /// <summary>
        /// Loop for DETAILS OF TRANSPORT
        /// </summary>
        [DataMember]
        [Required]
        [Pos(6)]
        public virtual Loop_TDT_IFTIAG TDTLoop { get; set; }
        /// <summary>
        /// Loop for PLACE/LOCATION IDENTIFICATION
        /// </summary>
        [DataMember]
        [Required]
        [ListCount(3)]
        [Pos(7)]
        public virtual List<Loop_LOC_IFTIAG> LOCLoop { get; set; }
        /// <summary>
        /// Loop for EQUIPMENT DETAILS
        /// </summary>
        [DataMember]
        [Required]
        [ListCount(9999)]
        [Pos(8)]
        public virtual List<Loop_EQD_IFTIAG> EQDLoop { get; set; }
        /// <summary>
        /// Loop for CONSIGNMENT INFORMATION
        /// </summary>
        [DataMember]
        [Required]
        [ListCount(9999)]
        [Pos(9)]
        public virtual List<Loop_CNI_IFTIAG> CNILoop { get; set; }
        /// <summary>
        /// Message Trailer
        /// </summary>
        [DataMember]
        [Pos(10)]
        public virtual UNT UNT { get; set; }
    }
}
