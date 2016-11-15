using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Swagger.Models
{
    public class MetaDataExtension : Attribute
    {
        private string _description;
        /// <summary>
        /// The PGSQL Comment.  Used for columns with entity framework. 
        /// </summary>
        public virtual string Description { get { return _description; } set { _description = value; } }
    
    }
}
