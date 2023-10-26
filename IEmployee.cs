using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Project
{
    internal interface IEmployee
    {
        public int Id { get; set; }
        public string? CreatedDate { get; set; }
        public string? ModifyDate { get; set; }
        public string? DeletedDate { get; set; }
    }
}
