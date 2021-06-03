using System;
using System.ComponentModel.DataAnnotations;
using VidlyApp.Models;

namespace VidlyApp.Dtos
{
    public class CustomerDto
    {

            public int Id { get; set; }
            [Required]
            [StringLength(225)]
            public string Name { get; set; }
            public bool IsSubscribedToNewsletter { get; set; }

            public byte MembershipTypeId { get; set; }
            //[Min18Years]
            public DateTime? BirthDate { get; set; }
    }
}