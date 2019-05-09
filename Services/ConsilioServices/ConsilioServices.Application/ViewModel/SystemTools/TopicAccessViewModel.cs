using System;
using System.Collections.Generic;
using System.Text;

namespace ConsilioServices.Application.ViewModel.SystemTools
{
    public class TopicAccessViewModel
    {
        public string Label { get; set; } 

        public int Value { get; set; }
        
        public IEnumerable<MenuAccessViewModel> Children { get; set; }
    }    
}
