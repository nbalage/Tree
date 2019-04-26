using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Child : ICollection
    {
        public object Value { get; set; }

        public IList<Child> Children { get; set; }

        public object this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                if (value is Child)
                {
                    Children[index] = value as Child;
                }
            }
        }

        public Child()
        {
            this.Children = new List<Child>();
        }

        public Child(IList<Child> children)
        {
            this.Children = children;
        }

        public int Count
        {
            get
            {
                return Children.Count();
            }
        }

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public void Add(Child child)
        {
            this.Children.Add(child);
        }

        public void Remove(Child child)
        {
            this.Children.Remove(child);
        }

        public IEnumerator GetEnumerator()
        {
            return new NodeEnum(Children);
        }

        public bool Contains(Child child)
        {
            return child.Contains(child);
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public string DeptFirstDraw(int level = 1)
        {
            var sb = new StringBuilder();
            sb.AppendLine(Value.ToString());
            foreach (var item in Children)
            {
                for (int i = 0; i < level - 1; i++)
                {
                    sb.Append(" ");
                }
                sb.Append("└");
                //sb.AppendLine(item.ToString());
                sb.Append(item.DeptFirstDraw(level + 1));
            }
            return sb.ToString();
        }

        public Dictionary<int, IList<Child>> GetBreadthFirstList(int i, IList<Child> children)
        {
            var dict = new Dictionary<int, IList<Child>>();
            dict.Add(i, children);
            i++;

            var ch = GetChildren(children);
            if (ch.Count > 0)
            {
                //dict.Add(i, ch);
                dict = dict.Concat(GetBreadthFirstList(i, ch)).ToDictionary(k => k.Key, k => k.Value);
            }

            return dict;
        }

        //public IEnumerable<Child> GetBreadthFirstList(int i, IList<Child> children) // Dictionary<int, IList<Child>>
        //{
        //    //var dict = new Dictionary<int, IList<Child>>();
        //    IEnumerable<Child> dict = new List<Child>();
        //    dict = dict.Concat(children);
        //    i++;

        //    var ch = GetChildren(children);
        //    if (ch.Count > 0)
        //    {
        //        //dict.Add(ch);
        //        dict = dict.Concat(GetBreadthFirstList(i, ch));
        //    }

        //    return dict;
        //}

        private IList<Child> GetChildren(IList<Child> parents)
        {
            List<Child> children = new List<Child>();
            foreach (Child parent in parents)
            {
                foreach (Child child in parent.Children)
                {
                    children.Add(child);
                }
            }
            return children;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
