using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class BillTagDTO
    {
        [Display(Name = "標籤名稱")]
        public string BillTagName { get; set; }
    }
}
