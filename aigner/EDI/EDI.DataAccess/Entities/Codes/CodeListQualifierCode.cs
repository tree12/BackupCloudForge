using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeListQualifierCode : BaseCodeEntity<CodeListQualifierCode>
    {
        public override string CodeDefinitionText => @"
12	Telephone directory
	Self explanatory.
16	Postcode directory
	[3251] Code defining postal zones or addresses.
23	Clearing house automated payment
	Self explanatory.
25	Bank identification
	Code for identification of banks.
35	Rail additional charges
	Self explanatory.
36	Railways networks
	Self explanatory.
37	Railway locations
	Code identifying a location in railway environment.
38	Rail customers
	Self explanatory.
39	Rail unified nomenclature of goods
	Self explanatory.
42	Business function
	Self explanatory.
43	Clearing House Interbank Payment System Participants ID
	Participants identification of the automated clearing house of the New York Clearing House Association (CHIPS).
44	Clearing House Interbank Payment System Universal ID
	Universal identification of the automated clearing house of the New York Clearing House Association (CHAPS).
52	Value added tax identification
	Value added tax identification code.
53	Passport number
	Number assigned to a passport.
54	Statistical object
	A statistical object such as a statistical concept, array structure component or statistical nomenclature.
55	Quality conformance
	A code list specifying the quality standard a product complies with, e.g. ISO9000, BS5750, etc.
56	Safety regulation
	A code list specifying the safety regulations which apply to a product, such as UK COSHH (control of substances hazardous to health) regulations.
57	Product code
	Code assigned to a specific product by a controlling agency.
58	Business account number
	An identifying number or code assigned by issuing authorities to manage business activities.
59	Railway services harmonized code
	Services provided by the different railway organizations.
60	Type of financial account
	Identification of the type of financial account.
61	Type of assets and liabilities
	Identification of the type of assets and liabilities.
62	Requirements indicator
	A code list which specifies various requirements that a customer may have when fulfilling a purchase order.
63	Handling action
	Codes for handling action.
64	Freight forwarder
	Codes for freight forwarders.
65	Shipping agent
	Codes for shipping agents.
67	Type of package
	Indication of the type of package codes.
68	Type of industrial activity
	Identification of the type of industrial activity.
69	Type of survey question
	Identification of the type of survey question.
70	Customs inspection type
	A code to indicate the type of inspection performed by customs.
71	Nature of transaction
	Identification of the nature of the transaction.
100	Enhanced party identification
	Self explanatory.
101	Air carrier
	Self explanatory.
102	Size and type
	Self explanatory.
103	Call sign directory
	Self explanatory.
104	Customs area of transaction
	Customs code to indicate the different types of declarations according to the countries involved in the transaction (e.g. box 1/1 of SAD: inter EC Member States, EC-EFTA, EC-third countries, etc.).
105	Customs declaration type
	Customs code to indicate the type of declaration according to the different Customs procedures requested (e.g.: import, export, transit).
106	Incoterms 1980
	(4110) Code to indicate applicable Incoterm (1980 edition) under which seller undertakes to deliver merchandise to buyer (ICC). Incoterms 1990: use 4053 only.
107	Excise duty
	Customs or fiscal authorities code to identify a specific or ad valorem levy on a specific commodity, applied either domestically or at time of importation.
108	Tariff schedule
	Self explanatory.
109	Customs indicator
	Customs code for circumstances where only an indication is needed.
110	Customs special codes
	Customs code to indicate an exemption to a regulation or a special Customs treatment.
112	Statistical nature of transaction
	Indication of the type of contract under which goods are supplied.
113	Customs office
	Customs administrative unit competent for the performance of Customs formalities, and the premises or other areas approved for the purpose by the competent authorities (CCC).
114	Railcar letter marking
	Codes for all marking codes (in letters) for railcars specifying the type, series, order number, check digit and some technical characteristics.
115	Examination facility
	Building or location where merchandise is examined by Customs.
116	Customs preference
	Customs code to identify a specific tariff preference.
117	Customs procedure
	(9380) Customs code to identify goods which are subject to Customs control (e.g. home use, Customs warehousing, temporary admission, Customs transit).
118	Government agency procedure
	Treatment applied by a government agency other than Customs to merchandise under their control.
119	Customs simplified procedure
	Customs code to indicate the type of simplified Customs procedure requested by a declarant (CCC).
120	Customs status of goods
	Customs code to specify the status accorded by Customs to a consignment e.g. release without further formality, present supporting documents for inspection, etc (CCC).
121	Shipment description
	Code to indicate whether a shipment is a total, part or split consignment.
122	Commodity
	(7357) Code identifying types of goods for Customs, transport or statistical purposes (generic term).
123	Entitlement
	Code to indicate the recipient of a charge amount (IATA).
125	Customs transit guarantee
	Customs code to identify the type of guarantee used in a transit movement.
126	Accounting information identifier
	Identification of a specific kind of accounting information.
127	Customs valuation method
	Customs code to identify the valuation method used to determine the dutiable value of the declared goods.
128	Service
	Identification of services.
129	Customs warehouse
	Identification and/or location of the Customs warehouse in which goods will be or have been deposited (CCC).
130	Special handling
	Code to indicate that the nature of the consignment may necessitate use of special handling procedures (IATA).
131	Free zone
	Code identifying the zone within a state where any goods introduced are generally regarded, insofar as import duties and taxes are concerned, as being outside the Customs territory and are not subject to the usual Customs control.
132	Charge
	Identification of a type of charge.
133	Financial regime
	Nature and methods of a transaction from financial viewpoint.
134	Duty, tax or fee payment method
	[4390] Method by which a duty or tax is paid to the relevant administration.
135	Rate class
	Code to identify a specific rate category.
136	Restrictions/prohibitions on re-use of certain wagons
	Self explanatory.
137	Rail harmonized codification of tariffs
	Self explanatory.
139	Port
	A location having facilities for means of transport to load or discharge cargo.
140	Area
	Codes for specific geographic areas e.g. seas, straits, basins etc.
141	Forwarding restrictions
	Self explanatory.
142	Train identification
	Self explanatory.
143	Removable accessories and special equipment on railcars
	Self explanatory.
144	Rail routes
	Self explanatory.
145	Airport/city
	As described and published by IATA.
146	Means of transport identification
	Code identifying the name or number of a means of transport (vessel, vehicle).
147	Document requested by Customs
	Customs code to identify documents requested by Customs in an information interchange.
148	Customs release notification
	Authorisation given by Customs to move the goods or not move the goods from the place of registration.
149	Customs transit type
	Customs code to indicate the different kinds of transit movement of the goods (e.g. Box 1/3 of the SAD).
150	Financial routing
	Self explanatory.
151	Locations for tariff calculation
	Self explanatory.
152	Materials
	Self explanatory.
153	Methods of payment
	Identification of methods of payment.
154	Bank branch sorting identification
	Identification of a specific branch of a bank.
155	Automated clearing house
	Identification of automated clearing houses.
156	Location of goods
	(3384) Indication of the place where goods are located and where they are available for examination.
157	Clearing code
	Identification of the responsible bank/clearing house which has cleared or is ordered to do the clearing.
158	Terms of delivery
	Code to identify terms of delivery.
160	Party identification
	Identification of parties, corporates, etc.
161	Goods description
	Identification of a type of goods description.
162	Country
	Identification of a country.
163	Country sub-entity
	(3228) Identification of country sub-entity (region, department, state, province) defined by appropriate authority.
164	Member organizations
	Identification of member organizations.
165	Amendment code (Customs)
	Customs code indicating the reason for transmitting an amendment to Customs.
166	Social security identification
	Code assigned by the authority competent to issue social security identification to identify a person.
167	Tax party identification
	Code assigned by a tax authority to identify a party.
168	Rail document names
	Rail specific identifications of documents.
169	Harmonized system
	Identification of commodities according to the Harmonized System.
170	Bank securities code
	Self explanatory.
172	Carrier code
	Self explanatory.
173	Export requirements
	Identification of requirements and regulations established by relevant authorities concerning exportation.
174	Citizen identification
	Self explanatory.
175	Account analysis codes
	Account service charges list.
176	Flow of the goods
	List of statistical codes covering the movement of the goods to be declared (e.g. despatch, arrival).
177	Statistical procedures
	Indication of the statistical procedure to which the goods are subject.
178	Standard text according US embargo regulations
	US government regulations prescribe specific standard text usage. Using codes from this code list prevents full text transmission.
179	Standard text for export according national prescriptions
	National export regulations prescribe specific standard text usage. Using codes from this code list prevents full text transmission.
180	Airport terminal
	Code identifying terminals or other sub-locations at airports.
181	Activity
	Code identifying activities.
182	Combiterms 1990
	Code to indicate the applicable Combiterm (1990 edition), used for the purpose of cost distribution between seller according to Incoterms 1990.
183	Dangerous goods packing type
	Identification of package types for the description related to dangerous goods.
184	Tax assessment method
	A code to identify the tax assessment method.
185	Item type
	A code list defining the level of elaboration of a item such as raw material, component, tooling, etc.
186	Product supply condition
	A code list specifying the rules according to which a product is supplied, e.g. from stock, available on demand, make on order, etc.
187	Supplier's stock turnover
	A code list giving an indication about the level of the supplier's stock turnover.
188	Article status
	A code list defining the status of an article from the procurement point of view, e.g. new article, critical article, etc.
189	Quality control code
	A code list specifying how the article is classified according to the quality control point of view, e.g. safety item, subject to regulation, etc.
190	Item sourcing category
	A code list to specify details related to the sourcing of the corresponding item such as provided by the buyer, from a mandatory source, etc.
191	Dumping or countervailing assessment method
	A code to identify the method used to determine the dumping or countervailing duty.
192	Dumping specification
	Code list to identify types of goods for dumping purposes.
";

        public override string StringCodeDefinitionText => @"
ZZZ	Mutually defined";

	}
}
