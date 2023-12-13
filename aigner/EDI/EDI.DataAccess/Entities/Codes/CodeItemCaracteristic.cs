using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeItemCaracteristic : BaseCodeEntity<CodeItemCaracteristic>
    {
        public override string CodeDefinitionText => @"
        1 Certificate of conformity
             Product in conformity with specifications.
        2 General product form
             Description of general product form.
        3 Ship to stock
             Product without quality control when received.
        4 Finish
             Description of the finish required/available on the
             product.
        5 End use application
             Description of what the end use application of the
             product will be.
        8 Product
             Self explanatory.
        9 Sub-product
             Description of a sub-product.
       11 Customs specifications
             Item characteristic is described following Customs
             specifications.
       12 Type and/or process
             Description of the type and/or process involved in making
             the product. E.g. in steel, description of the
             steelmaking process.
       13 Quality
             Self explanatory.
       14 Surface condition
             Description of the surface condition (e.g. roughness)
             of the product.
       15 Heat treat/anneal
             Description of any heat treatment or annealing
             required/performed on the product.
       17 Coating
             Description of any special coating required/available on
             the product.
       18 Surface treatment, chemical
             Description of any chemical surface treatment
             required/performed on the product.
       19 Surface treatment, mechanical
             Description of any mechanical surface treatment
             required/performed on the product.
       21 Forming
             Description of any forming required/performed on the
             product.
       22 Edge treatment
             Description of any special edge treatment
             required/performed on the product.
       23 Welds/splices
             Description of any special welds and or splices
             required/performed on the product.
       24 Control item
             Security relevant product with special quality control
             and control documentation prescriptions.
       25 End treatment
             Description of any special treatment required/performed
             on the ends the product.
       26 Ship to line
             Product without quality control at customer's, and packed
             according production needs.
       28 Test sample frequency
             Indication of test sample frequency. Used when ordering
             special testing requirements on a product.
       30 Test sample direction
             Description of test sample direction. Used when ordering
             special testing requirements on a product.
       32 Type of test/inspection
             Description of type of test or inspection. Used to order
             special tests to be performed on the product.
       35 Colour
             Description of the colour required/available on the
             product.
       38 Grade
             Specification of the grade required/available for the
             product.
       43 Twist
             Description of any special twisting requirements for the
             product.
       54 Section profile
             Description of the section and profile of the product.
       56 Special processing
             Description of any special processing requirements
             performed/require on the product.
       58 Winding instructions
             Description of any special winding instructions for the
             product.
       59 Surface protection
             Description of the surface protection required/available
             for the product.
       61 New article
             Self explanatory.
       62 Obsolete article
             Self explanatory.
       63 Current article
             Self explanatory.
       64 Revised design
             Self explanatory.
       65 Reinstated article
             Self explanatory.
       66 Current article spares
             Self explanatory.
       67 Balance out article
             Self explanatory.
       68 Initial sample
             Self explanatory.
       69 Field test
             First series of a new item to be tested by end users.
       70 Revised article
             Item design revised.
       71 Refurbished article
             Description to be provided.
+      72 Vintage
             The harvest year of the grapes that are part of the
             composition of a particular wine.
+      73 Beverage age
             The period during which, after distillation and before
             bottling, distilled spirits have been stored in
             containers.
+      74 Beverage brand
             A grouping of beverage products similar in name only, but
             of different size, age, proof, quality and flavour.
+      75 Artist
             The performing artist(es) of a recorded song or piece of
             music.
+      76 Author
             The author of a written work.
+      77 Binding
             A description of the type of binding used for a written
             work.
+      78 Edition
             Description of the edition of a written work.
+      79 Other physical description
             Any other relevant physical description.
+      80 Publisher
             The publisher of a written piece of work as part of the
             item description.
+      81 Title
             The title of a work.
+      82 Series title
             Title of a series of works.
+      83 Volume title
             The title of a volume of work.
+      84 Composer
             The composer of a recorded song or piece of music.
+      85 Recording medium
             The medium on which a musical recording is made.
+      86 Music style
             The style of music.
+      87 Promotional event
             Describes the promotional event associated with a
             product.
+      88 Promotional offer
             Describes the additions to the basic product for a
             promotional event.
+      89 Alcohol beverage class
             Class characteristics for different compositions of
             alcoholic beverages.
+      90 Alcohol beverage type
             A descriptive term that further defines the class of an
             alcoholic beverage.
+      91 Secondary grape
             The grape that comprises the second largest percentage of
             the ingredients used in wine product.
+      92 Primary grape
             The type of grape that comprises the largest percentage
             of grape in the wine product.
+      93 Beverage category
             A description to designate the beverage category.
+      94 Beverage flavour
             Distinctions from the base product that results in a
             different taste.
+      95 Wine growing region
             The area where the grape used to produce a wine was
             harvested.
+      96 Wine fruit
             The fruit that is used as a base to produce a wine.
+      97 Beverage container characteristics
             A description of various beverage container
             characteristics.
+      98 Size
             Description of size in non-numeric terms.";

        public override string StringCodeDefinitionText { get; }

    }
}
