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



        public static cls_model_row frmAPI(int _paymentid, string _currency, double _amount, DateTime _paymentDate, bool _settled)
        {
            cls_model_row mr = new cls_model_row();
            mr.paymentid = _paymentid;
            mr.currency = _currency;
            mr.amount = _amount;
            mr.paymentDate = _paymentDate;
            mr.settled = _settled;
            return mr;
        }
    }
}

