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
        internal static ExecutiveListResponse GetAllExecutive()
        {
            ExecutiveListResponse executiveList = new ExecutiveListResponse();
            List<Executive> executives = new List<Executive>();
         
                executives = ExecutiveData.AllExecutiveList();
                if (executives != null)
                {
                executiveList.statusCode = 00;
                executiveList.status = "Successful";
                executiveList.executives = executives;

                }
                else
                {
                executiveList.statusCode = 01;
                executiveList.status = "Unsuccessful";
                executiveList.executives = null;

                }
                return executiveList;
            }

        internal static ExecutiveResponse GetExecutiveByID(int id)
        {
            ExecutiveResponse executiveResponse= new ExecutiveResponse();
            Executive executive = new Executive();
            executive = ExecutiveData.GetExecutiveByID(id);
            if (executive!= null)
            {
                executiveResponse.statusCode = 00;
                executiveResponse.status = "Successful";
                executiveResponse.executive = executive;
            }
            else
            {
                executiveResponse.statusCode = 01;
                executiveResponse.status = "UnSuccessful";
                executiveResponse.executive= null;
            }
            return executiveResponse;
        }

        internal static ExecutiveResponse CreateExecutive(ExecutiveRequest value)
        {
            ExecutiveResponse executiveResponse = new ExecutiveResponse();
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
                    executiveResponse.executive = exe;
                }
                else
                { 
                    executiveResponse.executive = null;
                }
            }
            else
            {
                executiveResponse.statusCode = 01;
                executiveResponse.status = "UnSuccessful";
                executiveResponse.executive = null;
            }

            return executiveResponse;
        }

        internal static ExecutiveResponse EditExecutive(ExecutiveEditRequest value)
        {

            ExecutiveResponse executiveResponse = new ExecutiveResponse();
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
                    executiveResponse.executive = executive;
                }
                else
                {
                    executiveResponse.statusCode = 01;
                    executiveResponse.status = "UnSuccessful, not found";
                    executiveResponse.executive = null;
                }
            }
            else
            {
                executiveResponse.statusCode = 01;
                executiveResponse.status = "UnSuccessful, not found";
                executiveResponse.executive = null;
            }

            return executiveResponse;
        }

        internal static ExecutiveResponse DeleteExecutive(int id)
        {
            ExecutiveResponse executiveResponse = new ExecutiveResponse();

            string result = string.Empty;
            result = ExecutiveData.DeleteExecutive(id);
            if (result == "00")
            {
                executiveResponse.statusCode = 00;
                executiveResponse.status = "Successful";
                executiveResponse.executive = null;
            }
            else
            {
                executiveResponse.statusCode = 01;
                executiveResponse.status = "UnSuccessful";
                executiveResponse.executive = null;
            }

            return executiveResponse;
        }
    }
}
