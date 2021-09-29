using System;
namespace binaryTree
{
    public class BinaryTree
    {
        private int[] _orderedList;
        private int[] _binarySearchSortedList;

        public int Depth { get; set; }
        public Node RootNode { get; set;}


        public BinaryTree(int[] orderedList)
        {
            this._orderedList = orderedList;
            this.Depth = GetDepth(orderedList.Length);
            this.RootNode = new Node(orderedList[orderedList.Length/2]);
            SetChildrenNodes(this.RootNode);
        }

        private int GetDepth(int listLength)
        {
            double logarithm = Math.Log2(listLength);
            if (logarithm == Math.Truncate(logarithm))
            {
                return Convert.ToInt32(logarithm);
            }
            else
            {
                return Convert.ToInt32(Math.Ceiling(logarithm));
            }
        }

        private void SetChildrenNodes(Node parentNode)
        {
            // Should set both children of the node specified
            int parentIndex = Array.IndexOf(this._orderedList, parentNode.Value);

            int leftEndIndex = parentIndex - 1;
            this.RootNode.LeftChild = new Node(this._orderedList[leftEndIndex/2]);


            int rightStartIndex = parentIndex + 1;
            int rightLength = this._orderedList.Length - rightStartIndex;
            int rightCtrIndex;
            if (rightLength % 2 == 0)
            {
                rightCtrIndex = parentIndex + (rightLength / 2);
            }
            else
            {
                rightCtrIndex = parentIndex + (rightLength / 2) + 1;
            }
            this.RootNode.RightChild = new Node(this._orderedList[rightCtrIndex]);
        }


        private void ConvertOrderedListToTree()
        {
            
        }












        //private void ConvertOrderedListToTree()
        //{
        //    this.SplitListInHalf = this._orderedList;
        //    int firstItemInList = this._orderedList[0];

        //    int[] lowerBoundArray; //1, 2, 3, 4, 8,
        //    int[] upperBoundArray; //10, 14, 18, 20, 30

        //    Node rootNode = new Node(firstItemInList);

        //    Console.WriteLine(rootNode.Value);
        //    Console.WriteLine(rootNode);
        //}

        //private void SplitListInHalf()
        //{

        //int orderListLength = orderedList.Length;
        //int upperBoundStartSlicePoint = (orderListLength / 2) + 1;
        //int amountOfIndicesToSlice = orderListLength - upperBoundStartSlicePoint;


        //var lowerBoundList = new ArraySegment<int>(orderedList, upperBoundStartSlicePoint, amountOfIndicesToSlice);

        //Console.WriteLine(lowerBoundList);

        //    foreach (var item in lowerBoundList)
        //    {
        //        Console.WriteLine(item); 
        //    }
    //    Console.WriteLine(orderListLength / 2);

    //}

}
}
