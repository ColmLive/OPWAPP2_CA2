﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OPWAPP2.Models
{
    


    public enum Status
    {
        [Display(Name = "Pending Approval")] Pending_Approval,
        [Display(Name = "Rejected")] Rejected,
        [Display(Name = "Approved pending Funding")] Approved,
        [Display(Name = "Funded")] Funded,
        [Display(Name = "Closed")] Closed
    }

    public class Work
    {
        private const double AutoAppLimit = 750;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_ID { get; set; }

        [Required]
        //[ForeignKey("Property_ID")]
        public int Property_ID { get; set; }
        
        /*
        [ForeignKey("OPW_Building_Code")]
        public ICollection<Property> Propertys { get; set; }
        */

        [Required]
        //[ForeignKey("User_ID")]
        public int User_ID { get; set; }

    
        [Required]
        // [ConcurrencyCheck, MaxLength(3, ErrorMessage = "Project code must be 3 Char long."), MinLength(3)]
        public string Proj_Code { get; set; }
        [Required]
        public string Project_Desc { get; set; }
        [Required]
        public double Proj_budget_Requested { get; set; }
        //[Required]
        public double Proj_budget_Approved { get; set; }
        //[Required]
        public double Proj_funds_issued { get; set; }
        //[Required]
        public double Proj_Act_Cost { get; set; }
        [Required]
        public Status Status { get; set; }



        //Collective Navigation Property
        public virtual Property Property { get; set; }
        

        public virtual Authorisation Authorisation { get; set; }



        // Constructor for Building works
        //public Work(int Property_ID, string Proj_Code, string Project_Desc,double Proj_budget_Requested)
        public Work()
        {
            Property_ID = this.Property_ID;
            User_ID = this.User_ID;
            Proj_Code = this.Proj_Code;
            Project_Desc = this.Project_Desc;
            Proj_budget_Requested = this.Proj_budget_Requested;
            Proj_budget_Approved = 0;
            Proj_funds_issued = 0;
            Proj_Act_Cost = 0;
            Status = Status.Pending_Approval;
            
        }

       /*
        * public Work()
       {
       }
       */
    }
}