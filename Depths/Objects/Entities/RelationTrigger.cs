using Depths.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Entities
{
    class RelationTrigger : ITalk
    {
        public string Name => "RelationTrigger";

        public RelationType Type { get; }

        public int Value { get; }

        public Character c { get; }

        public RelationTrigger(RelationType type, int value, Character c)
        {

            Type = type;
            Value = value;
            this.c = c;
        }

        public void Activate()
        {

                if (c.Relationship.Type == RelationType.FRIENDSHIP)
                {
                    c.Relationship.RelationValue += Value;
                }
                else
                {
                    c.Relationship.Type = RelationType.ROMANCE;
                }
                if (c.Relationship.Type == RelationType.ROMANCE)
                {
                     c.Relationship.RelationValue += Value;
                }
                else
                {
                    c.Relationship.Type = RelationType.FRIENDSHIP;
                }
           
        }
    }
}
