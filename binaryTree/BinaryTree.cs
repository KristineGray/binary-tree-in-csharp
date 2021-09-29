using System;
namespace binaryTree
{
    public class BinaryTree
    {
        private int[] _orderedList;
        private int _currentDepth = 1;
        private int _nodesInTree = 1; // Initial value of 1 for the root node

        public int Depth { get; set; }
        public Node RootNode { get; set;}


        public BinaryTree(int[] orderedList)
        {
            this._orderedList = orderedList;
            this.Depth = GetDepth(orderedList.Length);
            this.RootNode = new Node(orderedList[orderedList.Length/2]);
            this._currentDepth = 2;

            ConvertOrderedListToTree();
            
            //SetChildrenNodes(this.RootNode);
            
            // Set current depth to 2; 1 for root & 1 for root's children

            // Check current levels vs tree depth
            //while (this._currentDepth < this.Depth) 
            //{
            //    int currentLevelNodeCount = 0;
            //    int maxNodesForLevel = 2 ^ (this._currentDepth - 1); // Minus 1 b/c 2^0 = 1

            //    while (currentLevelNodeCount < maxNodesForLevel)
            //    {
            //        Node currentParentNode = GetParentNode();
            //        if (currentLevelNodeCount == 0)
            //        {

            //        }

            //        currentLevelNodeCount++;
            //    }

            //    this._currentDepth++;
            //}

            // Create further nodes if necessary

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

            // Gets the index of parent node
            int parentIndex = Array.IndexOf(this._orderedList, parentNode.Value);

            // Set left child node
            int leftEndIndex = parentIndex - 1;
            this.RootNode.LeftChild = new Node(this._orderedList[leftEndIndex/2]);
            this.RootNode.LeftChild.Parent = this.RootNode;

            // Set right child node
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
            this.RootNode.LeftChild.Parent = this.RootNode;
        }

        // Trying to figure out how to go about populating entire tree using int[] length and tree depth...

        

        private void ConvertOrderedListToTree()
        {
            // Set variables
            int grandparentIndex;
            int parentIndex = this._orderedList.Length / 2;
            Node parentNode = this.RootNode;
            int[] leftSegment = new ArraySegment<int>(this._orderedList, 0, parentIndex).ToArray();
            int[] rightSegment = new ArraySegment<int>(this._orderedList, parentIndex + 1, this._orderedList.Length - parentIndex - 1).ToArray();
            bool isLeft = true;

            // Check level  |  Root is already created on level 1
            while (this._currentDepth > 1 && this._currentDepth <= this.Depth)
            {
                if ((parentNode.LeftChild != null && parentNode.RightChild != null) || (parentNode.LeftChild != null && rightSegment.Length == 0) || (leftSegment.Length == 0 && parentNode.RightChild != null) || (leftSegment.Length == 0 && rightSegment.Length == 0))
                {
                    // Check if grandparent has another child
                    if (parentNode.Parent == null) // If parent doesn't exist, next level
                    {
                        this._currentDepth++;
                        grandparentIndex = parentIndex;
                        parentIndex = Array.IndexOf(this._orderedList, parentNode.LeftChild.Value);
                        parentNode = parentNode.LeftChild;
                        leftSegment = new ArraySegment<int>(this._orderedList, 0, parentIndex).ToArray(); // Always starting from leftmost child
                        rightSegment = new ArraySegment<int>(this._orderedList, parentIndex + 1, rightSegment.Length - parentIndex - 1).ToArray();
                        isLeft = true; // isLeft should already be true
                    }
                    else // (parentNode.Parent != null) // If does have parent, check for another child
                    {
                        if ((parentNode.Parent.LeftChild != null || leftSegment.Length == 0) && (parentNode.Parent.RightChild != null || rightSegment.Length == 0)) // Move to the next level & reset vars
                        {
                            this._currentDepth++;
                            grandparentIndex = parentIndex;
                            parentIndex = Array.IndexOf(this._orderedList, parentNode.LeftChild.Value);
                            parentNode = parentNode.LeftChild;
                            leftSegment = new ArraySegment<int>(this._orderedList, 0, parentIndex).ToArray(); // Always starting from leftmost child
                            rightSegment = new ArraySegment<int>(this._orderedList, parentIndex + 1, rightSegment.Length - parentIndex - 1).ToArray();
                            isLeft = true; // isLeft should already be true
                        }
                    }
                    

                }
                else if (isLeft && parentNode.LeftChild == null) // Creates left child
                {
                    int centerIndex = FindCenterIndex(leftSegment, isLeft);
                    parentNode.LeftChild = new Node(leftSegment[centerIndex]);
                    parentNode.LeftChild.Parent = parentNode;
                    this._nodesInTree++;
                    isLeft = !isLeft;
                }
                else if (!isLeft && parentNode.RightChild == null) // Creates right child
                {
                    int centerIndex = FindCenterIndex(rightSegment, isLeft);
                    parentNode.RightChild = new Node(rightSegment[centerIndex]);
                    parentNode.RightChild.Parent = parentNode;
                    this._nodesInTree++;
                    isLeft = !isLeft;
                }
                else
                {
                    break;
                }


            }
        }

        private int FindCenterIndex(int[] segment, bool whatSide)
        {
            if (segment.Length == 1)
            {
                return 0;
            }
            else if (segment.Length % 2 == 0)
            {
                if (segment.Length == 2 && whatSide)
                {
                    return 1;
                }
                else if (segment.Length == 2 && !whatSide)
                {
                    return 0;
                }
                else
                {
                    return (segment.Length / 2) + 1;
                }
            }
            else
            {
                return (segment.Length / 2);
            }
        }
    
        //public void PrintTreeNodes()
        //{
            
        //    Console.WriteLine();
        //}
    }
}
