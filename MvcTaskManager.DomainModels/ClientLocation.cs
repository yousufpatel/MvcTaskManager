using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MvcTaskManager.DomainModels
{
    public class ClientLocation
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientLocationID { get; set; }
        public string ClientLocationName { get; set; }
    }
}
