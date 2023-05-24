using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7 {
  public class BinaryTree<T> : IEnumerable where T : IComparable<T> {
    private BinaryTree<T> Parent, LeftSubTree, RightSubTree;
    public readonly T Value;

    public BinaryTree(T Value) {
      this.Value = Value;
      Parent = null;
    }

    private BinaryTree(T Value, BinaryTree<T> Parent) {
      this.Value = Value;
      this.Parent = Parent;
    }

    public void Add(T Value) {
      if (Value.CompareTo(this.Value) < 0) {
        if (LeftSubTree == null) {
          LeftSubTree = new BinaryTree<T>(Value, this);
        } else if (LeftSubTree != null) {
          LeftSubTree.Add(Value);
        }
      } else {
        if (RightSubTree == null) {
          RightSubTree = new BinaryTree<T>(Value, this);
        } else if (RightSubTree != null) {
          RightSubTree.Add(Value);
        }
      }
    }

    public BinaryTree<T> Current() {
      return this;
    }

    public BinaryTree<T> Previous() {
      if (Parent == null) {
        return this;
      }

      return Parent;
    }

    public BinaryTree<T> Next() {
      if (LeftSubTree != null) {
        return LeftSubTree;
      } else if (RightSubTree != null) {
        return RightSubTree;
      } else {
        BinaryTree<T> AvailabilityParent(BinaryTree<T> CurrentElement, BinaryTree<T> RightNeighbour) {
          if (CurrentElement == RightNeighbour) {
            return AvailabilityParent(RightNeighbour, RightNeighbour.Parent.RightSubTree);
          } else {
            return RightNeighbour;
          }
        }
        
        return AvailabilityParent(this, Parent.RightSubTree);
      }
    }

    public static BinaryTree<T> operator ++(BinaryTree<T> Current) {
      return Current.Next();
    }

    public static BinaryTree<T> operator --(BinaryTree<T> Current) {
      return Current.Previous();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      if (LeftSubTree != null) {
        foreach (var item in LeftSubTree) {
          yield return item;
        }
      }

      yield return Value;

      if (RightSubTree != null) {
        foreach (var item in RightSubTree) {
          yield return item;
        }
      }
    }
  }
}
