using System;
using System.Collections.Generic;
using System.Text;
using TruncksProject.Domain.Entities;
using TruncksProject.Domain.Repository;
using TruncksProject.Infra.DataContext;

namespace TruncksProject.Infra.Repository
{
    public class TrunckRepository : BaseRepository<Trunck>,ITrunckRepository
    {
        public TrunckRepository(Context context) : base(context)
        {
        }
    }
}
