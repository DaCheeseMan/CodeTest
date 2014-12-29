using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Model
{
    public class Message
    {        
        public int Id { get; set; }
        public string Text { get; set; }
        public Person Owner { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
