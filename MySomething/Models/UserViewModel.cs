using MySomething.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySomething.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            List<SelectListItem> typeList = new List<SelectListItem>();
            SelectListItem typeListItem = new SelectListItem();
            typeListItem.Text = "Admin";
            typeListItem.Value = "0";
            typeListItem.Selected = false;
            typeList.Add(typeListItem);

            SelectListItem typeListItem1 = new SelectListItem();
            typeListItem1.Text = "Nomal";
            typeListItem1.Value = "1";
            typeListItem1.Selected = true;
            typeList.Add(typeListItem1);
            this.TypeList = typeList;
            this.CreateDate = DateTime.Now;
        }

        public List<SelectListItem> TypeList
        { get; set; }

        public int Id { get; set; }

        [Required]
        [MahmutOlmaz]
        public string Name { get; set; }

        [Required]
        [MahmutOlmaz]
        public string Surname { get; set; }

        [MinLength(5)]
        [Required]
        public string Username { get; set; }

        [MinLength(5)]
        [Required]
        [DataType(DataType.Password)]
        [MyPassword]
        public string Password { get; set; }

        [Range(0,1)]
        public int  Type { get; set; }

       // [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        public string FullName
        {
            get
            {
                return this.Name + " " + this.Surname;
            }
        }
        public string TypeStr
        {
            get
            {
                if (Type==0)
                {
                    return "Admin";
                }
                else
                {
                    return "Normal";
                }
            }
                
        }
    }
}