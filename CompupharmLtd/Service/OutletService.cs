using CompupharmLtd.Data;
using CompupharmLtd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Service
{
    public class OutletService
    {
        internal static Response GetAllOutlet()
        {
            Response outletList = new Response();
            List<Outlet> executives = new List<Outlet>();

            executives = OutletData.AllOutletList();
            if (executives != null)
            {
                outletList.statusCode = 00;
                outletList.status = "Successful";
                outletList.data = executives;

            }
            else
            {
                outletList.statusCode = 01;
                outletList.status = "Unsuccessful";
                outletList.data = null;

            }
            return outletList;
        }

        internal static Response GetOutletByID(int id)
        {
            Response executiveResponse = new Response();
            Outlet outlet = new Outlet();
            outlet = OutletData.GetOutletByID(id);
            if (outlet != null)
            {
                executiveResponse.statusCode = 00;
                executiveResponse.status = "Successful";
                executiveResponse.data = outlet;
            }
            else
            {
                executiveResponse.statusCode = 01;
                executiveResponse.status = "UnSuccessful";
                executiveResponse.data = null;
            }
            return executiveResponse;
        }
    

    internal static Response CreateOutlet(OutletRequest value)
        {
            Response outletResponse = new Response();
            string result = string.Empty;
            Outlet outletCreate = new Outlet()
            {

                Name = value.Name,
                State = value.State,
                Street = value.Street,
                City = value.City,
                Country = value.Email,                
                PhoneNumber = value.PhoneNumber,
                ZipCode = value.ZipCode,
                Email = value.Email,
            };


            result = OutletData.CreateOutlet(outletCreate);
            if (result == "00")
            {
                outletResponse.statusCode = 00;
                outletResponse.status = "Successful";

                outletResponse.data = outletCreate;
               
            }
            else
            {
                outletResponse.statusCode = 01;
                outletResponse.status = "UnSuccessful";
                outletResponse.data = null;
            }

            return outletResponse;
        }

        internal static Response EditOutlet(OutletEditRequest value)
        {

            Response outletResponse = new Response();
            string result = string.Empty;
            Outlet outlet = new Outlet();
            outlet = OutletData.GetOutletByID(value.OutletID);

            //ProductData.EditProduct(id);
            if (outlet != null)
            {
                Outlet outletEdit = new Outlet()
                {

                    DateAdded=value.DateAdded,
                    Name = value.Name,
                    State = value.State,
                    Street = value.Street,
                    City = value.City,
                    Country = value.Email,
                    PhoneNumber = value.PhoneNumber,
                    ZipCode = value.ZipCode,
                    Email = value.Email,
                    OutletID = value.OutletID
                };


                result = OutletData.EditOutlet(outletEdit);
                if (result == "00")
                {


                    outletResponse.statusCode = 00;
                    outletResponse.status = "Successful";
                    outletResponse.data = outlet;
                }
                else
                {
                    outletResponse.statusCode = 01;
                    outletResponse.status = "UnSuccessful, not found";
                    outletResponse.data = null;
                }
            }
            else
            {
outletResponse.statusCode = 01;
                outletResponse.status = "UnSuccessful, not found";
                outletResponse.data = null;
            }

            return outletResponse;
        }

        internal static Response DeleteOutlet(int id)
        {
            Response outletResponse = new Response();

            string result = string.Empty;
            result = OutletData.DeleteOutlet(id);
            if (result == "00")
            {
                outletResponse.statusCode = 00;
                outletResponse.status = "Successful";
                outletResponse.data = null;
            }
            else
            {
                outletResponse.statusCode = 01;
                outletResponse.status = "UnSuccessful";
                outletResponse.data = null;
            }

            return outletResponse;
        }
    }
}
