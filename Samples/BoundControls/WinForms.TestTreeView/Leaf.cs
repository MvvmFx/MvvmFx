using System.Collections.Generic;

namespace WinForms.TestTreeView
{
    public class Leaf
    {
        private Leaf(int leafId, int? leafParentId, string leafName, string leafDescription, bool leafIsReadOnly)
        {
            LeafId = leafId;
            LeafParentId = leafParentId;
            LeafName = leafName;
            LeafDescription = leafDescription;
            LeafIsReadOnly = leafIsReadOnly;
        }

        public int LeafId { get; set; }
        public int? LeafParentId { get; set; }
        public string LeafName { get; set; }
        public string LeafDescription { get; set; }
        public bool LeafIsReadOnly { get; set; }

        public static List<Leaf> GetLeafList()
        {
            var leafList = new List<Leaf>();
            leafList.Add(new Leaf(10, 5, "Child 2.1.5 RO", "Description 10", true));
            leafList.Add(new Leaf(1, null, "A Root", "Description 1", false));
            leafList.Add(new Leaf(11, 4, "Child 1.2.1 RO", "Description 11", true));
            leafList.Add(new Leaf(2, null, "Z Another Root", "Description 2", false));
            leafList.Add(new Leaf(3, 1, "Child 1.1", "Description 3", false));
            leafList.Add(new Leaf(4, 1, "DRAG ME < < <", "Description 4", true));
            leafList.Add(new Leaf(15, 2, "Child 2.4 RO", "Description 15", true));
            leafList.Add(new Leaf(6, 5, "Child 2.1.1", "Description 6", false));
            leafList.Add(new Leaf(7, 5, "Child 2.1.2 RO", "Description 7", true));
            leafList.Add(new Leaf(8, 5, "Child 2.1.3", "Description 8", false));
            leafList.Add(new Leaf(9, 5, "Child 2.1.4 RO", "Description 9", true));
            leafList.Add(new Leaf(5, 2, "Child 2.1", "Description 5", false));
            leafList.Add(new Leaf(12, 4, "DROP HERE < < <", "Description 12", true));
            leafList.Add(new Leaf(13, 2, "Child 2.2 RO", "Description 13", true));
            leafList.Add(new Leaf(14, 2, "Child 2.3", "Description 14", false));

            return leafList;
        }
    }
}