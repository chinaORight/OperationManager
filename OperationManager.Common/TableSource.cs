using System.Collections.Generic;

namespace OperationManager.Common
{
    public class TableSource<T> where T : class, new()
    {
        public long Total { get; set; }

        public List<T> Rows { get; set; }
    }
}