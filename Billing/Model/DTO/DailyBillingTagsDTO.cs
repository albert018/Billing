using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class DailyBillingTagsDTO
    {
        [Display(Name = "序號")]
        public string Serial { get; set; }

        [Display(Name = "標籤名稱")]
        public string BillTagName { get; set; }
    }
}
