using CompupharmLtd.Data;
using CompupharmLtd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Service
{
    public class ExecutiveService
    {
        internal static Response GetAllExecutive()
        {
            Response  executiveList = new Response();
            List<Executive> executives = new List<Executive>();
         
                executives = ExecutiveData.AllExecutiveList();
                if (executives != null)
                {
                executiveList.statusCode = 00;
                executiveList.status = "Successful";
                executiveList.data = executives;

                }
                else
                {
                executiveList.statusCode = 01;
                executiveList.status = "Unsuccessful";
                executiveList.data = null;

                }
                return executiveList;
            }

        internal static Response GetExecutiveByID(int id)
        {
            Response executiveResponse= new Response();
            Executive executive = new Executive();
            executive = ExecutiveData.GetExecutiveByID(id);
            if (executive!= null)
            {
                executiveResponse.statusCode = 00;
                executiveResponse.status = "Successful";
                executiveResponse.data = executive;
            }
            else
            {
                executiveResponse.statusCode = 01;
                executiveResponse.status = "UnSuccessful";
                executiveResponse.data= null;
            }
            return executiveResponse;
        }

        internal static Response CreateExecutive(ExecutiveRequest value)
        {
          Response executiveResponse = new Response();
            string result = string.Empty;
            Executive executiveEdit = new Executive()
            {

                Name = value.Name,
                ShortDescription = value.ShortDescription,
                FullDescription = value.FullDescription,
                AcademmicQualifications = value.AcademmicQualifications,
                Position = value.Position,
                DateOfBirth = value.DateOfBirth,
                Title = value.Title,
                DateEmployed = value.DateEmployed,
                ResignationDate = value.ResignationDate,
                Image = value.Image,
                Email = value.Email,
            };


            result = ExecutiveData.CreateExecutive(executiveEdit);
            if (result == "00")
            {
                executiveResponse.statusCode = 00;
                executiveResponse.status = "Successful";
                Executive exe = ExecutiveData.GetExecutiveUsingEmail(value.Email);
                if (exe.ExecutiveID != 0)
                {
                    executiveResponse.data = exe;
                }
                else
                { 
                    executiveResponse.data = null;
                }
            }
            else
            {
                executiveResponse.statusCode = 01;
                executiveResponse.status = "UnSuccessful";
                executiveResponse.data = null;
            }

            return executiveResponse;
        }

        internal static Response EditExecutive(ExecutiveEditRequest value)
        {

            Response executiveResponse = new Response();
            string result = string.Empty;
            Executive executive = new Executive();
            executive = ExecutiveData.GetExecutiveByID(value.ExecutiveID);

            //ProductData.EditProduct(id);
            if (executive != null)
            {
                Executive executiveEdit = new Executive()
                {

                    ExecutiveID = value.ExecutiveID,
                    Name = value.Name,
                    ShortDescription = value.ShortDescription,
                    FullDescription = value.FullDescription,
                    AcademmicQualifications = value.AcademmicQualifications,
                    Position = value.Position,
                    DateOfBirth = value.DateOfBirth,
                    Title = value.Title,
                    DateEmployed = value.DateEmployed,
                    ResignationDate = value.ResignationDate,
                    Image = value.Image,
                    DateCreated = value.DateCreated,
                    DateUpdated = value.DateUpdated,
                    Email =value.Email,
                };


                result = ExecutiveData.EditExecutive(executiveEdit);
                if (result == "00")
                {


                    executiveResponse.statusCode = 00;
                    executiveResponse.status = "Successful";
                    executiveResponse.data = executive;
                }
                else
                {
                    executiveResponse.statusCode = 01;
                    executiveResponse.status = "UnSuccessful, not found";
                    executiveResponse.data = null;
                }
            }
            else
            {
                executiveResponse.statusCode = 01;
                executiveResponse.status = "UnSuccessful, not found";
                executiveResponse.data = null;
            }

            return executiveResponse;
        }

        internal static Response DeleteExecutive(int id)
        {
             Response executiveResponse = new Response();

            string result = string.Empty;
            result = ExecutiveData.DeleteExecutive(id);
            if (result == "00")
            {
                executiveResponse.statusCode = 00;
                executiveResponse.status = "Successful";
                executiveResponse.data = null;
            }
            else
            {
                executiveResponse.statusCode = 01;
                executiveResponse.status = "UnSuccessful";
                executiveResponse.data = null;
            }

            return executiveResponse;
        }
    }
}
