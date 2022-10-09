using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberRegister.Core.Dto
{
    public class MemberDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to write a first name")]       
        public string Firstname { get; set; }

        [Required(ErrorMessage = "You have to write a last name")]
        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Postcode { get; set; }

        public string Postaladdress { get; set; }

        public DateTime CreationDate { get; set; }

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
