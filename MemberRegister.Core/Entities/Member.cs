using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegister.Core.Entities
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Postcode { get; set; }

        public string Postaladdress { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime LastUpdatedDate { get; set; }

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder("Id: " + this.Id);
            strBuild.Append(System.Environment.NewLine);

            strBuild.Append(this.Firstname + " " + this.Lastname);
            strBuild.Append(System.Environment.NewLine);

            strBuild.Append(this.Address);
            strBuild.Append(System.Environment.NewLine);

            strBuild.Append(this.Postcode);
            strBuild.Append(" ");
            strBuild.Append(this.Postaladdress);

            strBuild.Append(System.Environment.NewLine);
            strBuild.Append("Creation date: " + this.CreationDate.ToShortDateString());

            strBuild.Append(System.Environment.NewLine);
            strBuild.Append("Latest update date: " + this.LastUpdatedDate.ToShortDateString());

            return strBuild.ToString();
        }
    }
}