using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Test
{
     public class cls_model_row
    {
        public int paymentid { get; set; }
        public string currency { get; set; }
        public double amount { get; set; }
        public DateTime paymentDate { get; set; }
        public bool settled { get; set; }



        public static cls_model_row frmAPI(string csvline)
        {
            cls_model_row mr = new cls_model_row();
            string[] values = csvline.Split(',');
            if (values.Length == 5)
            {                
                mr.paymentid = Convert.ToInt16(values[0]);
                mr.currency = Convert.ToString(values[1]);
                mr.amount = Convert.ToDouble(values[2]);
                mr.paymentDate = Convert.ToDateTime(values[3]);
                mr.settled = Convert.ToBoolean(values[4]);                
            }
            return mr;
        }
    }
}

