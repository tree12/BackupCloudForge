using System;
using System.Collections.Generic;
using System.Linq;
using EDI.DataAccess.Entities.Interfaces;
using EdiFabric.Templates.EdifactD96A;
using Portal.Common.Entity.Abstracts;

namespace EDI.DataAccess.Entities
{
    public abstract class EdiOrderBase<TType> : EdiMessage<TType>, IDeliveryLocation, IBuyerContact where TType:BaseEdiObject<TType>
    {

        public string Delivery_PlaceLocationQualifier { get; set; }

        public string Delivery_PlaceLocationIdentification { get; set; }

        public string Buyer_ContactCode { get; set; }

        public string Buyer_Name { get; set; }

        public string Buyer_Email { get; set; }

        public string Buyer_Phone { get; set; }

        public void initCTABY(CTA cta)
        {
            Buyer_ContactCode = cta?.Contactfunctioncoded_01;
            Buyer_Name = cta?.DEPARTMENTOREMPLOYEEDETAILS_02?.Departmentoremployee_02;
        }

        public void initContactBY(List<COM> coms)
        {
            Buyer_Email = coms?.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("EM")).COMMUNICATIONCONTACT_01?.Communicationnumber_01;
            Buyer_Phone = coms?.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("TE")).COMMUNICATIONCONTACT_01?.Communicationnumber_01;
        }

        public void DPLoc(LOC loc)
        {
            Delivery_PlaceLocationQualifier = loc?.Placelocationqualifier_01;
            Delivery_PlaceLocationIdentification = loc?.LOCATIONIDENTIFICATION_02?.Placelocationidentification_01;
        }

        public EdiOrderBase()
        {
        }

        public CTA generateBuyerCTA()
        {
            CTA cta = new CTA();
            cta.Contactfunctioncoded_01 = Buyer_ContactCode;
            cta.DEPARTMENTOREMPLOYEEDETAILS_02 = new C056();
            cta.DEPARTMENTOREMPLOYEEDETAILS_02.Departmentoremployee_02 = Buyer_Name;
            return cta;
        }

        public COM generateBuyerPhone()
        {
            if (!string.IsNullOrEmpty(Buyer_Phone))
            {
                var comPhone = new COM();
                comPhone.COMMUNICATIONCONTACT_01 = new C076();
                comPhone.COMMUNICATIONCONTACT_01.Communicationnumber_01 = Buyer_Phone;
                comPhone.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02 = "TE";
                return comPhone;
            }

            return null;
        }

        public COM generateBuyerEmail()
        {
            if (!string.IsNullOrEmpty(Buyer_Email))
            {
                var comEmail = new COM();
                comEmail.COMMUNICATIONCONTACT_01 = new C076();
                comEmail.COMMUNICATIONCONTACT_01.Communicationnumber_01 = Buyer_Email;
                comEmail.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02 = "EM";
                return comEmail;
            }

            return null;
        }

        public LOC generateDeliveryLOC()
        {
            if (!string.IsNullOrEmpty(Delivery_PlaceLocationQualifier))
            {
                LOC deliveryRecipientLoc = new LOC();
                deliveryRecipientLoc.Placelocationqualifier_01 = Delivery_PlaceLocationQualifier; //.DeliveryRecipient.Location.PlaceLocationQualifier;
                deliveryRecipientLoc.LOCATIONIDENTIFICATION_02 = new C517();
                deliveryRecipientLoc.LOCATIONIDENTIFICATION_02.Placelocationidentification_01 = Delivery_PlaceLocationIdentification;
                return deliveryRecipientLoc;
            }

            return null;

        }

    }
}