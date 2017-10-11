using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class DailyBillingDTO
    {
        [Display(Name = "標籤")]
        public IEnumerable<DailyBillingTagsDTO> BillTags { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "序號")]
        public string Serial { get; set; }

        [Display(Name = "日期")]
        public Nullable<System.DateTime> BillDate { get; set; }

        [Display(Name = "金額")]
        public Nullable<decimal> Amount { get; set; }

        [Display(Name = "類型")]
        public string BillType { get; set; }

        [Display(Name = "備註")]
        public string Remark { get; set; }
    }
}
