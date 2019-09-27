﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBmanager
{
    interface DBConnect
    {
        List<TSource> FindAll<TSource>() where TSource : class;

    }
}
