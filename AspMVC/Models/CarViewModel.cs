using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AspMVC.Data;
using AspMVC.Migrations;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace AspMVC.Models
{
    public class CarViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }


        public int Miles { get; set; }

        public string Image { get; set; }

       
       
    }
}
