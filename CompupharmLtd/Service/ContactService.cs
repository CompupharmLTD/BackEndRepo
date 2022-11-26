using CompupharmLtd.Data;
using CompupharmLtd.Interface;
using CompupharmLtd.Model;
using System;
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
                Response = contact.Response,
                Responder = contact.Responder

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

        internal static Response CreateResponseMessage(ContactResponse contact)
        {
            Response response = new Response();
            var res = ContactData.GetContactByID(contact.MessageID);
            if (res != null) { 
            if (!string.IsNullOrEmpty(res.Email))
                {
                    IEmailSending emailSending = new EmailSendingService();
                 int result =   emailSending.Send("mipoolugbenga@gmail.com",res.Email,contact.Message,res.Name,"Compupharm"  ); 
                    if(result == 1)
                    {
                        res.Response = contact.Message;
                        res.Responder = contact.Name;
                        
                        string responseSave = ContactData.EditContactMessage(res);
                        if (responseSave == "00")
                        {
                            response.statusCode = 00;
                            response.status = "OK"; 
                        }
                    }
                    else
                    {
                        response.statusCode = 01;
                        response.status = "Unsuccssful";
                    }

                }
            }
            return response;

        }
    }
}
