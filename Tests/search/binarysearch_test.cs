using binarysearch;
using tem.Collections.Generic;
using csharp_algorithms;
 namespace binary_search
 {
  public class BinarySearchTest
  {
    public void search()
    {
        List<Node> list = new List<Node>;
        {
          new Node(10);
          new Node(77);
          new Node(9);
          new Node(6);
          new Node(4);
          new Node(99);
        };
        BS _test = new BS(list);
        //just for a testing value ;
        Node testnode = new Node(11);
        var case1 = _test.binary_search(testnode);
        searchValue = new Node(12);
        var case2 = _test.binary_search(testnode);
    }
  }
 }
