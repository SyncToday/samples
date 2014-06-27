/// <reference path="../App.js" />
var outlook;
var mailbox;
var settings;

(function () {
    "use strict";

    // The Office initialize function must be run each time a new page is loaded
    Office.initialize = function (reason) {
        $(document).ready(function () {
            app.initialize();

            mailbox = Office.context.mailbox
            settings = Office.context.roamingSettings;

            $('#senderDisplayName').text(mailbox.item.sender.displayName);
            $('#senderEmailAddress').text(mailbox.item.sender.emailAddress);
            $('#recipientDisplayName').text(mailbox.item.to[0].displayName);
            $('#recipientEmailAddress').text(mailbox.item.to[0].emailAddress);

            displayItemDetails();
        });
    };

    // Displays the "Subject" and "From" fields, based on the current mail item
    function displayItemDetails() {
        var item = Office.cast.item.toItemRead(Office.context.mailbox.item);
        $('#subject').text(item.subject);

        var from;
        if (item.itemType === Office.MailboxEnums.ItemType.Message) {
            from = Office.cast.item.toMessageRead(item).from;
        } else if (item.itemType === Office.MailboxEnums.ItemType.Appointment) {
            from = Office.cast.item.toAppointmentRead(item).organizer;
        }

        if (from) {
            $('#from').text(from.displayName);
            $('#from').click(function () {
                app.showNotification(from.displayName, from.emailAddress);
            });
        }
    }
})();