using System;
using System.Collections.Generic;
using System.Text;

namespace MvcTaskManager.ViewModels
{
    public class ResponseViewModel
    {
        public bool Status { get; set; }
        public object Result { get; set; }
        public string Messege { get; set; }
    }
}
