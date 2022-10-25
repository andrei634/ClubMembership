using System.ComponentModel.DataAnnotations;

namespace ClubMembership.Models
{
    public class AnnouncementModel
    {
        public Guid Idannouncemment { get; set; }

        //[DisplayFormat(DataFormatString="0:MM/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }

        //[DisplayFormat(DataFormatString = "0:MM/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime ValidTo { get; set; }

        [StringLength(250, ErrorMessage = "The maximum length is 250")]
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;

        //[DisplayFormat(DataFormatString = "0:MM/dd/yyyy")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? EventDateTime { get; set; }
        public string? Tags { get; set; }
    }
}
