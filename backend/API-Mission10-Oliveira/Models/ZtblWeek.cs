using System;
using System.Collections.Generic;

namespace AAPI_Mission10_Oliveira.Data;

public partial class ZtblWeek
{
    public DateOnly WeekStart { get; set; }

    public DateOnly? WeekEnd { get; set; }
}
