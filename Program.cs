using System;
using System.Collections.Generic;

namespace Lab7 {
  class Program {
    delegate void IncreasingTree(List<int> Tree);
    delegate void DescendingTree(List<int> Tree);
    static void Main(string[] args) {
      // Печатает элементы дерева в порядке возрастания
      IncreasingTree Increase = (ListTree) => {
        ListTree.Sort();
        foreach (var item in ListTree) {
          Console.WriteLine(item);
        }
      };

      // Печатает элементы дерева в порядке увания
      DescendingTree Descend = (ListTree) => {
        ListTree.Sort();
        ListTree.Reverse();
        foreach (var Element in ListTree) {
          Console.WriteLine(Element);
        }
      };

      //
      // Блок пользовательского меню
      //

      Console.Write("Введите количество элементов в дереве: ");
      int TreeElementCount = int.Parse(Console.ReadLine());

      List<int> TreeList = new List<int>();

      Console.WriteLine("Введите начальное значение: ");
      int ElementBase = int.Parse(Console.ReadLine());

      BinaryTree<int> Tree = new BinaryTree<int>(ElementBase); // Установка начального значения
      TreeList.Add(ElementBase);

      Console.WriteLine($"Введите поочерёдно {TreeElementCount - 1} элементов:\n");
      for (int TreeElement = 0; TreeElement < TreeElementCount - 1; ++TreeElement) {
        int Element = int.Parse(Console.ReadLine());
        Tree.Add(Element);
        TreeList.Add(Element);
      }

      void SortTree() {
        Console.Write("Как хотите отсортировать матрицу?\n\t1. По возрастанию\n\t2. По убыванию\nВведите желаемый пункт: ");
        int UserChoice = int.Parse(Console.ReadLine());

        switch (UserChoice) {
          case 1:
            Console.WriteLine("Дерево в порядке возрастания: \n");
            Increase(TreeList);
            break;
          case 2:
            Console.WriteLine("Дерево в порядке убывания: \n");
            Descend(TreeList);
            break;
          default:
            Console.WriteLine("Неверно введён пункт! Попробуйте ещё!");
            SortTree();
            break;
        }
      }

      SortTree();
      Console.ReadKey();
    }
  }
}
