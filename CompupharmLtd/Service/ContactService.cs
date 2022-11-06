using CompupharmLtd.Data;
using CompupharmLtd.Model;
using System.Collections.Generic;

namespace CompupharmLtd.Service
{
    public class ContactService
    {
        internal static ContactListResponse GetAllMessages()
        {
            ContactListResponse contactResponse = new ContactListResponse();
            List<Contact> result = ContactData.GetAllContactMessage();
            if (result.Count != 0)
            {
                contactResponse.statusCode = 00;
                contactResponse.status = "successful";
                contactResponse.contact = result;
            }
            else
            {
                contactResponse.statusCode = 01;
                contactResponse.status = "unsuccessful";
                contactResponse.contact = null;
            }
            return contactResponse;
        }

        internal static ContactResponse EditMessage(Contact contact)
        {
            Contact editInfo = new Contact()
            {
                ticketID = contact.ticketID,
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Message = contact.Message,
            };
            ContactResponse contactResponse = new ContactResponse();
            string result = ContactData.EditContactMessage(editInfo);
            if (result == "00")
            {
                contactResponse.statusCode = 00;
                contactResponse.status = "successful";
                contactResponse.contact = editInfo;
                contactResponse.contact.DateCreated = editInfo.DateCreated;
            }
            else
            {
                contactResponse.statusCode = 01;
                contactResponse.status = "unsuccessful";
                contactResponse.contact = null;
            }
            return contactResponse;
        }

        internal static ContactResponse DeleteMessage(string id)
        {
            ContactResponse contactResponse = new ContactResponse();
            string result = ContactData.DeleteContactByID(id);
            if (result == "00")
            {
                contactResponse.statusCode = 00;
                contactResponse.status = "successful";
                contactResponse.contact = null;
            }
            else
            {
                contactResponse.statusCode = 01;
                contactResponse.status = "unsuccessful";
                contactResponse.contact = null;
            }
            return contactResponse;
        }

        internal static ContactResponse GetMessageByID(string id)
        {
            ContactResponse contactResponse = new ContactResponse();
            Contact result = ContactData.GetContactByID(id);
            if (result.ticketID != null)
            {
                contactResponse.statusCode = 00;
                contactResponse.status = "successful";
                contactResponse.contact = result;
            }
            else
            {
                contactResponse.statusCode = 01;
                contactResponse.status = "unsuccessful";
                contactResponse.contact = null;
            }
            return contactResponse;
        }

        internal static ContactResponse CreateMessage(ContactRequest contact)
        {
            Contact contactInfo = new Contact()
            {
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Message = contact.Message,
            };
            ContactResponse contactResponse = new ContactResponse();
            string result = ContactData.Create(contact);
            if (result != "01")
            {
                contactResponse.statusCode = 00;
                contactResponse.status = "successful";
                contactResponse.contact = contactInfo;
                contactResponse.contact.ticketID = result;
            }
            else
            {
                contactResponse.statusCode = 01;
                contactResponse.status = "unsuccessful";
                contactResponse.contact = null;
            }
            return contactResponse;

        }
    }
}
