using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class CommonConstrant
    {

        public const string save = "Data Saved Successfully";
        public const string Delete = "Data Deleted Successfully";
        public const string Edit = "Data Edited Successfully";

    }

    public enum ShippingStatus
    {
        NONE = 0,
        PENDING = 1,
        SHIPPED = 2,
        CANCELLED = 3
    }
}