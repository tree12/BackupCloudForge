using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeMessageFunction : BaseCodeEntity<CodeMessageFunction>
    {
        public override string CodeDefinitionText => @"  
        1 Cancellation
             Message cancelling a previous transmission for a given
             transaction.
        2 Addition
             Message containing items (e.g. line items, goods items,
             Customs items, equipment items) to be added to a
             previously sent message.
        3 Deletion
             Message containing items (e.g. line items, goods items,
             Customs items, equipment items) to be deleted from a
             previously sent message.
        4 Change
             Message containing items (e.g. line items, goods items,
             Customs items, equipment items) to be changed in a
             previously sent message.
        5 Replace
             Message replacing a previous message.
        6 Confirmation
             Message confirming the details of a previous transmission
             where such confirmation is required or recommended under
             the terms of a trading partner agreement.
        7 Duplicate
             The message is a duplicate of a previously generated
             message.
        8 Status
             Description to be provided.
        9 Original
             Initial transmission related to a given transaction.
       10 Not found
             Message whose reference number is not filed.
       11 Response
             Message responding to a previous message or document.
       12 Not processed
             Message indicating that the referenced message was
             received but not yet processed.
       13 Request
             Self explanatory.
       14 Advance notification
             Self explanatory.
       15 Reminder
             Repeated message transmission for reminding purposes.
       16 Proposal
             Message content is a proposal.
       17 Cancel, to be reissued
             Referenced transaction cancelled, reissued message will
             follow.
       18 Reissue
             New issue of a previous message (maybe cancelled).
       19 Seller initiated change
             Change information submitted by buyer but initiated by
             seller.
       20 Replace heading section only
             Message to replace the heading of a previous message.
       21 Replace item detail and summary only
             Message to replace item detail and summary of a previous
             message.
       22 Final transmission
             Final message in a related series of messages together
             making up a commercial, administrative or transport
             transaction.
       23 Transaction on hold
             Message not to be processed until further release
             information.
       24 Delivery instruction
             Delivery schedule message only used to transmit short-
             term delivery instructions.
       25 Forecast
             Delivery schedule message only used to transmit long-term
             schedule information.
       26 Delivery instruction and forecast
             Combination of codes '24' and '25'.
       27 Not accepted
             Message to inform that the referenced message is not
             accepted by the recipient.
       28 Accepted, with amendment in heading section
             Message accepted but amended in heading section.
       29 Accepted without amendment
             Referenced message is entirely accepted.
       30 Accepted, with amendment in detail section
             Referenced message is accepted but amended in detail
             section.
       31 Copy
             Indicates that the message is a copy of an original
             message that has been sent, e.g. for action or
             information.
       32 Approval
             A message releasing an existing referenced message for
             action to the receiver.
       33 Change in heading section
             Message changing the referenced message heading section.
       34 Accepted with amendment
             The referenced message is accepted but amended.
       35 Retransmission
             Change-free transmission of a message previously sent.
       36 Change in detail section
             Message changing referenced detail section.
       37 Reversal of a debit
             Reversal of a previously posted debit.
       38 Reversal of a credit
             Reversal of a previously posted credit.
       39 Reversal for cancellation
             Description to be provided.
       40 Request for deletion
             The message is given to inform the recipient to delete
             the referenced transaction.
       41 Finishing/closing order
             Last of series of call-offs.
       42 Confirmation via specific means
             Message confirming a transaction previously agreed via
             other means (e.g. phone).
       43 Additional transmission
             Message already transmitted via another communication
             channel. This transmission is to provide electronically
             processable data only.
       44 Accepted without reserves
             Message accepted without reserves.
       45 Accepted with reserves
             Message accepted with reserves.
       46 Provisional
             Message content is provisional.
       47 Definitive
             Message content is definitive.
       48 Accepted, contents rejected
             Message to inform that the previous message is received,
             but it cannot be processed due to regulations, laws, etc.
       49 Settled dispute
             The reported dispute is settled.
       50 Withdraw
             Message withdrawing a previously approved message.
       51 Authorisation
             Message authorising a message or transaction(s).
       52 Proposed amendment
             A code used to indicate an amendment suggested by the
             sender.
       53 Test
             Code indicating the message is to be considered as a
             test.
+      54 Extract
             A subset of the original.";

        public override string StringCodeDefinitionText { get; }
    }
}
