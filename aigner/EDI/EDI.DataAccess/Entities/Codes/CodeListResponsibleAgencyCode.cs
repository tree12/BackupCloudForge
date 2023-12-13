using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeListResponsibleAgencyCode : BaseCodeEntity<CodeListResponsibleAgencyCode>
    {
        public override string CodeDefinitionText => @"
1	CCC (Customs Co-operation Council)
	Self explanatory.
2	CEC (Commission of the European Communities)
	Generic: see also 140, 141, 142, 162.
3	IATA (International Air Transport Association)
	Self explanatory.
4	ICC (International Chamber of Commerce)
	Self explanatory.
5	ISO (International Organization for Standardization)
	Self explanatory.
6	UN/ECE (United Nations - Economic Commission for Europe)
	Self explanatory.
7	CEFIC (Conseil Europeen des Federations de l'Industrie Chimique)
	EDI project for chemical industry.
8	EDIFICE
	EDI Forum for companies with Interest in Computing and Electronics (EDI project for EDP/ADP sector).
9	EAN (International Article Numbering association)
	Self explanatory.
10	ODETTE
	Organization for Data Exchange through Tele-Transmission in Europe (European automotive industry project).
11	Lloyd's register of shipping
	Self explanatory.
12	UIC (International union of railways)
	Western and Eastern European railways association (35 networks). UIC with its legal body (CIT) produce codes and reglementations that are internationally recognized and accepted by all European railways and official bodies.
13	ICAO (International Civil Aviation Organisation)
	Self explanatory.
14	ICS (International Chamber of Shipping)
	Self explanatory.
15	RINET (Reinsurance and Insurance Network)
	Self explanatory.
16	DUNS (Dun & Bradstreet)
	Self explanatory.
17	S.W.I.F.T.
	Society for Worldwide Interbank Financial Telecommunications s.c.
18	Conventions on SAD and transit (EC and EFTA)
	SAD = Single Administrative Document.
19	FRRC (Federal Reserve Routing Code)
	Self explanatory.
20	BIC (Bureau International des Containeurs)
	Self explanatory.
21	Assigned by transport company
	Codes assigned by a transport company.
22	US, ISA (Information Systems Agreement)
	Codes assigned by the ISA for use by its members.
23	FR, EDITRANSPORT
	French association developing EDI in transport logistics.
24	AU, ROA (Railways of Australia)
	Maintains code lists which are accepted by Australian government railways.
25	EDITEX (Europe)
	EDI group for the textile and clothing industry.
26	NL, Foundation Uniform Transport Code
	Foundation Uniform Transport Code is the EDI organisation for shippers, carriers and other logistic service providers in the Netherlands.
27	US, FDA (Food and Drug Administration)
	U.S. food and drug administration.
28	EDITEUR (European book sector electronic data interchange group)
	Code identifying the pan European user group for the book industry as an organisation responsible for code values in the book industry.
29	GB, FLEETNET
	Association of fleet vehicle hiring and leasing companies in the UK.
30	GB, ABTA (Association of British Travel Agencies)
	ABTA, Association of British Travel Agencies.
31	FI, Finish State Railway
	Finish State Railway.
32	PL, Polish State Railway
	Polish State Railway.
33	BG, Bulgaria State Railway
	Bulgaria State Railway.
34	RO, Rumanian State Railway
	Rumanian State Railway.
35	CZ, Tchechian State Railway
	Tchechian State Railway.
36	HU, Hungarian State Railway
	Hungarian State Railway.
37	GB, British Railways
	British Railways.
38	ES, Spanish National Railway
	Spanish National Railway.
39	SE, Swedish State Railway
	Swedish State Railway.
40	NO, Norwegian State Railway
	Norwegian State Railway.
41	DE, German Railway
	German Railway.
42	AT, Austrian Federal Railways
	Austrian Federal Railways.
43	LU, Luxembourg National Railway Company
	Luxembourg National Railway Company.
44	IT, Italian State Railways
	Italian State Railways.
45	NL, Netherlands Railways
	Netherlands Railways.
46	CH, Swiss Federal Railways
	Swiss Federal Railways.
47	DK, Danish State Railways
	Danish State Railways.
48	FR, French National Railway Company
	French National Railway Company.
49	BE, Belgian National Railway Company
	Belgian National Railway Company.
50	PT, Portuguese Railways
	Portuguese Railways.
51	SK, Slovacian State Railways
	Slovacian State Railways.
52	IE, Irish Transport Company
	Irish Transport Company.
53	FIATA (International Federation of Freight Forwarders Associations)
	International Federation of Freight Forwarders Associations.
54	IMO (International Maritime Organisation)
	International Maritime Organisation.
55	US, DOT (United States Department of Transportation)
	United States Department of Transportation.
56	TW, Trade-van
	Trade-van is an EDI/VAN service centre for customs, transport, and insurance in national and international trade.
57	TW, Chinese Taipei Customs
	Customs authorities of Chinese Taipei responsible for collecting import duties and preventing smuggling.
58	EUROFER
	European steel organisation - EDI project for the European steel industry.
59	DE, EDIBAU
	National body responsible for the German codification in the construction area.
60	Assigned by national trade agency
	The code list is from a national agency.
61	Association Europeenne des Constructeurs de Materiel Aerospatial (AECMA)
	A code to identify the Association Europeenne des Constructeurs de Materiel Aeropsatial (European Association of Aerospace Products Manufacturers) as an authorizing agency for code lists.
62	US, DIstilled Spirits Council of the United States (DISCUS)
	United States DIstilled Spirits Council of the United States (DISCUS).
63	North Atlantic Treaty Organization (NATO)
	A code to identify the North Atlantic Treaty Organization (NATO) as an authorizing agency for code lists.
64	FR, EDIFRANCE
	French association responsible for coordination and promotion of EDI application in France.
65	FR, GENCOD
	French organization responsible for EDI and Barcoding application in the retail sector.
66	MY, Malaysian Customs and Excise
	Malaysia Royal Customs and Excise.
67	MY, Malaysia Central Bank
	Malaysia Central Bank is a regulatory body set up by the government to charge with promoting economic monetary and credit condition favourable to commercial and industrial activity.
68	US, Bureau of Alcohol, Tobacco and Firearms (BATF)
	United States Bureau of Alcohol, Tobacco and Firearms (BATF).
69	US, National Alcohol Beverage Control Association (NABCA)
	United States National Alcohol Beverage Control Association (NABCA).
70	MY, Dagang.Net
	Malaysia, Dagang.Net is a national clearing house which provide EDI/VAN service for customs, transport, retail and financial and other industries in the national and international trade.
86	Assigned by party originating the message
	Codes assigned by the party originating the message.
87	Assigned by carrier
	Codes assigned by the carrier.
88	Assigned by owner of operation
	Assigned by owner of operation (e.g. used in construction).
89	Assigned by distributor
	Self explanatory.
90	Assigned by manufacturer
	Self explanatory.
91	Assigned by seller or seller's agent
	Self explanatory.
92	Assigned by buyer or buyer's agent
	Self explanatory.
93	AT, Austrian Customs
	Self explanatory.
94	AT, Austrian PTT
	Self explanatory.
95	AU, Australian Customs Services
	Self explanatory.
96	CA, Revenue Canada, Customs and Excise
	Self explanatory.
97	CH, Administration federale des contributions
	Indirect taxation (e.g. turn-over/sales taxes).
98	CH, Direction generale des douanes
	Customs (incl. ISO alpha 2 country code).
99	CH, Division des importations et exportations, OFAEE
	Import and export licences.
100	CH, Entreprise des PTT
	Telephone (voice/data) + telex numbers, postcodes, postal account numbers.
101	CH, Carbura
	Centrale suisse pour l'importation de carburants et combustibles liquides (Oil products).
102	CH, Centrale suisse pour l'importation du charbon
	Coal.
103	CH, Office fiduciaire des importateurs de denrees alimentaires
	Foodstuff.
104	CH, Association suisse code des articles
	Swiss article numbering association.
105	DK, Ministry of taxation, Central Customs and Tax Administration
	Danish Customs administration.
106	FR, Direction generale des douanes et droits indirects
	French Customs.
107	FR, INSEE
	Institut National de la Statistique et des Etudes Economiques.
108	FR, Banque de France
	Self explanatory.
109	GB, H.M. Customs & Excise
	Self explanatory.
110	IE, Revenue Commissionners, Customs AEP project
	Self explanatory.
111	US, U.S. Customs Service
	Self explanatory.
112	US, U.S. Census Bureau
	The Bureau of the Census of the U.S. Dept. of Commerce.
113	US, UPC (Uniform product code)
	Self explanatory.
114	US, ABA (American Bankers Association)
	Self explanatory.
115	US, DODAAC (Department Of Defense Active Agency Code)
	Self explanatory.
116	US, ANSI ASC X12
	American National Standards Institute ASC X12.
117	AT, Geldausgabeautomaten-Service Gesellschaft m.b.H.
	Description to be provided.
118	SE, Svenska Bankfoereningen
	Swedish bankers association.
119	IT, Associazione Bancaria Italiana
	Self explanatory.
120	IT, Socieata' Interbancaria per l'Automazione
	Self explanatory.
121	CH, Telekurs AG
	Self explanatory.
122	CH, Swiss Securities Clearing Corporation
	Self explanatory.
123	NO, Norwegian Interbank Research Organization
	Self explanatory.
124	NO, Norwegian Bankers Ass.
	Self explanatory.
125	FI, The Finnish Bankers' Association
	Self explanatory.
126	US, NCCMA (Account Analysis Codes)
	Self explanatory.
128	BE, Belgian Bankers' Association
	Self explanatory.
129	BE, Belgian Ministry of Finance
	VAT numbers.
130	DK, PBS (Pengainstitutternes Betalings Service)
	Self explanatory.
131	DE, German Bankers Association
	Self explanatory.
132	GB, BACS Limited
	Self explanatory.
133	GB, Association for Payment Clearing Services
	Self explanatory.
134	GB, CHAPS and Town Clearing Company Ltd.
	Self explanatory.
135	GB, The Clearing House
	Self explanatory.
136	GB, Article Number Association (UK) Limited
	EAN bar-coding.
137	AT, Verband oesterreichischer Banken und Bankiers
	Austrian bankers association.
138	FR, CFONB (Comite francais d'organ. et de normalisation bancaires)
	National body responsible for the french codification in banking activity.
139	UPU (Universal Postal Union)
	(a..3 country code).
140	CEC (Commission of the European Communities), DG/XXI-01
	(Computerization within Customs area).
141	CEC (Commission of the European Communities), DG/XXI-B-1
	Description to be provided.
142	CEC (Commission of the European Communities), DG/XXXIV
	Statistical Office of the European Communities: e.g. Geonomenclature.
143	NZ, New Zealand Customs
	Self explanatory.
144	NL, Netherlands Customs
	Self explanatory.
145	SE, Swedish Customs
	Self explanatory.
146	DE, German Customs
	Self explanatory.
147	BE, Belgian Customs
	Self explanatory.
148	ES, Spanish Customs
	Self explanatory.
149	IL, Israel Customs
	Self explanatory.
150	HK, Hong Kong Customs
	Self explanatory.
151	JP, Japan Customs
	Self explanatory.
152	SA, Saudi Arabia Customs
	Self explanatory.
153	IT, Italian Customs
	Self explanatory.
154	GR, Greek Customs
	Self explanatory.
155	PT, Portuguese Customs
	Self explanatory.
156	LU, Luxembourg Customs
	Self explanatory.
157	NO, Norwegian Customs
	Self explanatory.
158	FI, Finnish Customs
	Self explanatory.
159	IS, Iceland Customs
	Self explanatory.
160	LI, Liechtenstein authority
	(Identification of relevant responsible agency for e.g. banking/financial matters still pending. For e.g. Customs, currency, post/telephone: see relevant CH entry).
161	UNCTAD (United Nations - Conference on Trade And Development)
	Self explanatory.
162	CEC (Commission of the European Communities), DG/XIII-D-5
	(TEDIS - incl. CEBIS -, INSIS and CADDIA projects).
163	US, FMC (Federal Maritime Commission)
	Self explanatory.
164	US, DEA (Drug Enforcement Agency)
	Self explanatory.
165	US, DCI (Distribution Codes, INC.)
	Self explanatory.
166	US, National Motor Freight Classification Association
	Self explanatory.
167	US, AIAG (Automotive Industry Action Group)
	Self explanatory.
168	US, FIPS (Federal Information Publishing Standard)
	Self explanatory.
169	CA, SCC (Standards Council of Canada)
	Self explanatory.
170	CA, CPA (Canadian Payment Association)
	Self explanatory.
171	NL, Bank Girocentrale BV
	Self explanatory.
172	NL, BEANET BV
	Self explanatory.
173	NO, NORPRO
	Self explanatory.
174	DE, DIN (Deutsches Institut fuer Normung)
	German standardization institute.
175	FCI (Factors Chain International)
	Self explanatory.
176	BR, Banco Central do Brazil
	Self-explanatory.
177	AU, LIFA (Life Insurance Federation of Australia)
	Life Insurance Federation of Australia.
178	AU, SAA (Standards Association of Australia)
	Standards Association of Australia.
179	US, Air transport association of America
	U.S. -based trade association representing the major North American scheduled airlines.
181	Edibuild
	EDI organization for companies in the construction industry.
182	US, Standard Carrier Alpha Code (Motor)
	Organisation maintaining the SCAC lists and transportation operating in North America.
183	US, American Petroleum Institute
	US-based trade association representing oil and natural gas producers, shippers, refineries, marketers, and major suppliers to the industry.
184	AU, ACOS (Australian Chamber of Shipping)
	Self explanatory.";

        public override string StringCodeDefinitionText => @"
ZZZ	Mutually defined";
    }
}
