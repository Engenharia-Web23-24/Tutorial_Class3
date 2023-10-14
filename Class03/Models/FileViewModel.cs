using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Class03.Models
{
    public class FileViewModel
    {
        [Required]
        [RegularExpression(@"^.+\.([pP][dD][fF])$",ErrorMessage ="Only Pdf files")]
        public string? Name { get; set; }

        [DisplayName("Size in Bytes")]
        public long Size { get; set; }
    }
}
