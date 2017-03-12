using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class 商品名稱不能有Austin字串Attribute : DataTypeAttribute
    {
        public 商品名稱不能有Austin字串Attribute() : base(DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            string str = Convert.ToString(value);
            if (str.Contains("Austin"))
            {
                return false;
            }
            return true;
        }
    }
}