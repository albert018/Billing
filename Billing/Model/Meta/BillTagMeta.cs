using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [MetadataType(typeof(BillTagMeta))]
    partial class BillTag
    {
        public class BillTagMeta
        {
            [Display(Name ="標籤名稱")]
            public string BillTagName { get; set; }
        }
    }
}
