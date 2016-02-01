using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Wedding.Models
{
    public class Attendee
    {
        [ScaffoldColumn(false)]
        public int AttendeeID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        public bool IsAttending { get; set; }

        [StringLength(2048, ErrorMessage = "Note cannot exceed 2048 characters.")]
        public string Note { get; set; }


    }
}
