using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Models.Paginated
{
    public class EntityList<TEntity>
    {
        public int TotalCount { get; set; }
        public int FilteredCount { get; set; }
        public IReadOnlyList<TEntity> PageData { get; set; }
    }
}
