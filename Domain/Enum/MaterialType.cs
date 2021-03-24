using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Enum
{
    public enum MaterialType
    {
        Undefined = 0,

        [Description("Готовая")]
        Product = 1,

        [Description("Густая")]
        Source = 2
    }


}
