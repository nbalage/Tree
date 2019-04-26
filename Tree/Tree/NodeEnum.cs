using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class NodeEnum : IEnumerator
    {
        IList<Child> children;
        private int position;

        public NodeEnum(IList<Child> children)
        {
            position = -1;
            this.children = children;
        }

        public object Current
        {
            get
            {
                return children[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < children.Count);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
