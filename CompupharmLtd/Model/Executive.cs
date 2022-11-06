using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Model
{
    public class Executive
    {
        public int ExecutiveID { get; set; }
        public int ExecutiveYear { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AcademmicQualifications { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateEmployed { get; set; }
        public DateTime ResignationDate { get; set; }
    }
    public class ExecutiveRequest
    {
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string AcademmicQualifications { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateEmployed { get; set; }
        public DateTime ResignationDate { get; set; }

    }
    public class ExecutiveEditRequest
    {
        public int ExecutiveID { get; set; }
        public int ExecutiveYear { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AcademmicQualifications { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateEmployed { get; set; }
        public DateTime ResignationDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }



    }
}
