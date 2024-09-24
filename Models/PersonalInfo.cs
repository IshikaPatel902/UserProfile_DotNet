using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Task_Profile.Models
{
    public class Persons
    {

        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Provide Name")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Provide yyyy/mm/dd")]
        //[MaxLength(20)]

        public string ResidentialAddress { get; set; }
        
        public string PermanentAddress { get; set; }
        [AllowNull]
        public string PhoneNumber { get; set; }
        //[MaxLength(11)]
        public string EmailAddress { get; set; }
        [AllowNull]

        public string MaritalStatus { get; set; }

        public string Gender { get; set; }

        public string Occupation { get; set; }

        public string AadharCardNumber { get; set; }
        [Required]

        public string PanNumber { get; set; }

    }
}
//[Range(1, 5, ErrorMessage = "StarRating can be within  the range 1-5")]