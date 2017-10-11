using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class BillTypeDTO
    {
        [Display(Name ="類型名稱")]
        public string BillTypeName { get; set; }
    }
}
