using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Entities
{
    public class Relationship
    {
        public RelationType Type { get; set; }

        public int RelationValue { get; set; }

        public Relationship(RelationType type, int relationValue)
        {
            Type = type;
            RelationValue = relationValue;
        }
    }
}
