using CompupharmLtd.Data;
using CompupharmLtd.Model;
using System.Collections.Generic;

namespace CompupharmLtd.Service
{
    public class ContactService
    {
        internal static Response GetAllMessages()
        {
            Response contactResponse = new Response();
            List<Contact> result = ContactData.GetAllContactMessage();
            if (result.Count != 0)
            {
                contactResponse.statusCode = 00;
                contactResponse.status = "successful";
                contactResponse.data = result;
            }
            else
            {
                contactResponse.statusCode = 01;
                contactResponse.status = "unsuccessful";
                contactResponse.data = null;
            }
            return contactResponse;
        }

        internal static Response EditMessage(Contact contact)
        {
            Contact editInfo = new Contact()
            {
                ticketID = contact.ticketID,
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Message = contact.Message,
            };
            Response contactResponse = new Response();
            string result = ContactData.EditContactMessage(editInfo);
            if (result == "00")
            {
                contactResponse.statusCode = 00;
                contactResponse.status = "successful";
                contactResponse.data = editInfo;
            }
            else
            {
                contactResponse.statusCode = 01;
                contactResponse.status = "unsuccessful";
                contactResponse.data = null;
            }
            return contactResponse;
        }

        internal static Response DeleteMessage(string id)
        {
            Response contactResponse = new Response();
            string result = ContactData.DeleteContactByID(id);
            if (result == "00")
            {
                contactResponse.statusCode = 00;
                contactResponse.status = "successful";
                contactResponse.data = null;
            }
            else
            {
                contactResponse.statusCode = 01;
                contactResponse.status = "unsuccessful";
                contactResponse.data = null;
            }
            return contactResponse;
        }

        internal static Response GetMessageByID(string id)
        {
            Response contactResponse = new Response();
            Contact result = ContactData.GetContactByID(id);
            if (result.ticketID != null)
            {
                contactResponse.statusCode = 00;
                contactResponse.status = "successful";
                contactResponse.data = result;
            }
            else
            {
                contactResponse.statusCode = 01;
                contactResponse.status = "unsuccessful";
                contactResponse.data = null;
            }
            return contactResponse;
        }

        internal static Response CreateMessage(ContactRequest contact)
        {
            Contact contactInfo = new Contact()
            {
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Message = contact.Message,
            };
            Response contactResponse = new Response();
            string result = ContactData.Create(contact);
            if (result != "01")
            {
                contactResponse.statusCode = 00;
                contactResponse.status = "successful";
                contactResponse.data = contactInfo;
                contactResponse.data = result;
            }
            else
            {
                contactResponse.statusCode = 01;
                contactResponse.status = "unsuccessful";
                contactResponse.data = null;
            }
            return contactResponse;

        }
    }
}
