using System;
using System.Collections.Generic;
using System.Text;
using TruncksProject.Domain.Enums;

namespace TruncksProject.Domain.Entities
{
    public class ModelTrunck
    {
        public ModelTrunck(ETruncksModel name)
        {
            Name = name;
        }

        public ETruncksModel Name { get; set; }

        public IList<Trunck> Truncks { get; set; }
    }
}
