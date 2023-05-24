using System;

namespace Lab7 {
  class Program {
    static void Main(string[] args) {
      BinaryTree<int> Tree = new BinaryTree<int>(100);

      Tree.Add(123);
      Tree.Add(1);
      Tree.Add(12);
      Tree.Add(3);
      Tree.Add(100);


      foreach (var item in Tree) {
        Console.WriteLine(item);
      }

      Console.ReadKey();
    }
  }
}
