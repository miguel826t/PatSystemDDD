using PatSystem.Domain.Entities.SegDesemprego;
using System.Collections.Generic;

namespace PatSystem.UI.ViewModels
{
    public class SegCreateViewModel
    {
        public Seguro Seguro { get; set; }
        public Empresa Empresa { get; set; }

        public Cbo Cbo { get; set; }
        public IList<Cbo> Cbos { get; set; }
    }
}
