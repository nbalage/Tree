using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Tree
    {
        public Child Root { get; set; }

        public string DeptFirstDraw(int level = 1)
        {
            var sb = new StringBuilder();
            sb.Append(Root.DeptFirstDraw());
            return sb.ToString();
        }

        public string BreadthFirstDraw()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Root.Value.ToString());

            foreach (var pair in GetBreadthFirstList())
            {
                foreach (var item in pair.Value)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            return sb.ToString();
        }

        public Dictionary<int, IList<Child>> GetBreadthFirstList() // Dictionary<int, IList<Child>>
        {
            var dict = Root.GetBreadthFirstList(0, Root.Children);
            return dict;
        }
    }
}
