using System;
using MvcTaskManager.DomainModels;

namespace MvcTaskManager.ViewModels
{
    public class ProjectViewModel
    {
        

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime DateOfStart { get; set; }
        public int? TeamSize { get; set; }

        public bool Active { get; set; }

        public string Status { get; set; }

        public int ClientLocationID { get; set; }

        public ClientLocation ClientLocation { get; set; }

    }
}
