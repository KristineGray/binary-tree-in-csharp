using System;


//     ____9______ 
//    /           \
//    3             18
//   / \           /  \
//  2   4         14   30
// /     \       /    /
//1       8     10   20




namespace binaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] orderedList = { 1, 2, 3, 4, 8, 9, 10, 14, 18, 20, 30};

            BinaryTree testTree = new(orderedList);

            Console.WriteLine($"The length is {orderedList.Length} items\nThe depth of the binary tree is {testTree.Depth} levels\nThe value of the Root Node is {testTree.RootNode.Value}");
            
            Console.WriteLine($"\nThe value of the left child node is {testTree.RootNode.LeftChild.Value}\nThe value of the right child node is {testTree.RootNode.RightChild.Value}");
            
            //Console.WriteLine($"\nThe value of the left-left grandchild node is {testTree.RootNode.LeftChild.LeftChild.Value}");
           // Console.WriteLine($"\nThe value of the left-right grandchild node is {testTree.RootNode.LeftChild.RightChild.Value}");
           // Console.WriteLine($"\nThe value of the right-left grandchild node is {testTree.RootNode.RightChild.LeftChild.Value}");
          //  Console.WriteLine($"\nThe value of the right-right grandchild node is {testTree.RootNode.RightChild.RightChild.Value}");
            
            Console.ReadKey();















            // ==============================================================


            //int orderListLength = orderedList.Length;
            //int centerMark = orderListLength;

            

            //Console.WriteLine(centerMark / 2);


            //centerMark = centerMark / 2;
            //int currentMark = centerMark / 2;

            //int rootNode = orderedList[centerMark];
            //int leftChild = orderedList[centerMark - (currentMark / 2)];
            //int rightChild = orderedList[centerMark + (currentMark / 2)];

            //Console.WriteLine(leftChild);
            //Console.WriteLine(rightChild);

            //while (centerMark > 1)
            //{
            //    centerMark = centerMark / 2;
            //    int currentMark = centerMark / 2;

            //    int rootNode = orderedList[centerMark];
            //    int leftChild = orderedList[centerMark - (currentMark / 2)];
            //    int rightChild = orderedList[centerMark + (currentMark / 2)];
            //}

        }
    }
}
