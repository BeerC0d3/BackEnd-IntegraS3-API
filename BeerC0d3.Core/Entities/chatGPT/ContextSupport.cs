using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.chatGPT
{
    public class ContextSupport:BaseEntity
    {
        public int parentId { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public string file { get; set; }
        public bool isActive { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime modifitationDate { get; set; }
    }
}
