using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Contracts
{
    public interface IEditable
    {
        DateTime? Modified { get; set; }

        int? ModifiedBy { get; set; }
    }
}
