using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesForceWeb.Domain.Base
{
    public class EntidadeBase
    {
        public int Id { get; set; }

        [Display(Name="Data")]
        public DateTime DtInclusao { get; set; }

        public DateTime? DtAlteracao { get; set; }

    }
}
