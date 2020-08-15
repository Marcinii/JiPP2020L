﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Model.Queries
{
    public class QueryResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; } = 0;
    }
}
