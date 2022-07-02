using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLoanMVC.DataService
{
    public class Document
    {
        [Key]
        public Guid DocumentId { get; set; }
        public string DocumentType { get; set; }
        public byte[] DocumentUpload { get; set; }

    }
}
