// ==++==
// 
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// 
// ==--==
// <OWNER>Microsoft</OWNER>
// 
#if NET40
namespace System.Collections.ObjectModel
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Runtime;

  [Serializable]
  [DebuggerDisplay("Count = {Count}")]
  public class ReadOnlyCollectionX<T> : IList<T>, IList, IReadOnlyList<T>
  {
    IList<T> list;
    [NonSerialized]
    private Object _syncRoot;

    public ReadOnlyCollectionX(IList<T> list)
    {
      if (list == null) { throw new ArgumentNullException(nameof(list)); }
      this.list = list;
    }

    public int Count
    {
      get { return list.Count; }
    }

    public T this[int index]
    {
      get { return list[index]; }
    }

    public bool Contains(T value)
    {
      return list.Contains(value);
    }

    public void CopyTo(T[] array, int index)
    {
      list.CopyTo(array, index);
    }

    public IEnumerator<T> GetEnumerator()
    {
      return list.GetEnumerator();
    }

    public int IndexOf(T value)
    {
      return list.IndexOf(value);
    }

    protected IList<T> Items
    {
      get
      {
        return list;
      }
    }

    bool ICollection<T>.IsReadOnly
    {
      get { return true; }
    }

    T IList<T>.this[int index]
    {
      get { return list[index]; }
      set { throw new NotSupportedException(); }
    }

    void ICollection<T>.Add(T value)
    {
      throw new NotSupportedException();
    }

    void ICollection<T>.Clear()
    {
      throw new NotSupportedException();
    }

    void IList<T>.Insert(int index, T value)
    {
      throw new NotSupportedException();
    }

    bool ICollection<T>.Remove(T value)
    {
      throw new NotSupportedException();
    }

    void IList<T>.RemoveAt(int index)
    {
      throw new NotSupportedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IEnumerable)list).GetEnumerator();
    }

    bool ICollection.IsSynchronized
    {
      get { return false; }
    }

    object ICollection.SyncRoot
    {
      get
      {
        if (_syncRoot == null)
        {
          ICollection c = list as ICollection;
          if (c != null)
          {
            _syncRoot = c.SyncRoot;
          }
          else
          {
            System.Threading.Interlocked.CompareExchange<Object>(ref _syncRoot, new Object(), null);
          }
        }
        return _syncRoot;
      }
    }

    void ICollection.CopyTo(Array array, int index)
    {
      if (array == null)
      {
        throw new ArgumentNullException(nameof(array));
      }

      if (array.Rank != 1)
      {
        throw new ArgumentException("Arg_RankMultiDimNotSupported");
      }

      if (array.GetLowerBound(0) != 0)
      {
        throw new ArgumentException("Arg_NonZeroLowerBound");
      }

      if (index < 0)
      {
        throw new ArgumentOutOfRangeException("ArgumentOutOfRange_NeedNonNegNum");
      }

      if (array.Length - index < Count)
      {
        throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
      }

      T[] items = array as T[];
      if (items != null)
      {
        list.CopyTo(items, index);
      }
      else
      {
        //
        // Catch the obvious case assignment will fail.
        // We can found all possible problems by doing the check though.
        // For example, if the element type of the Array is derived from T,
        // we can't figure out if we can successfully copy the element beforehand.
        //
        Type targetType = array.GetType().GetElementType();
        Type sourceType = typeof(T);
        if (!(targetType.IsAssignableFrom(sourceType) || sourceType.IsAssignableFrom(targetType)))
        {
          throw new ArgumentException("Invalid Array Type");
        }

        //
        // We can't cast array of value type to object[], so we don't support 
        // widening of primitive types here.
        //
        object[] objects = array as object[];
        if (objects == null)
        {
          throw new ArgumentException("Invalid Array Type");
        }

        int count = list.Count;
        try
        {
          for (int i = 0; i < count; i++)
          {
            objects[index++] = list[i];
          }
        }
        catch (ArrayTypeMismatchException)
        {
          throw new ArgumentException("Invalid Array Type");
        }
      }
    }

    bool IList.IsFixedSize
    {
      get { return true; }
    }

    bool IList.IsReadOnly
    {
      get { return true; }
    }

    object IList.this[int index]
    {
      get { return list[index]; }
      set { throw new NotSupportedException(); }
    }

    int IList.Add(object value)
    {
      throw new NotSupportedException();
    }

    void IList.Clear()
    {
      throw new NotSupportedException();
    }

    private static bool IsCompatibleObject(object value)
    {
      // Non-null values are fine.  Only accept nulls if T is a class or Nullable<U>.
      // Note that default(T) is not equal to null for value types except when T is Nullable<U>. 
      return ((value is T) || (value == null && default(T) == null));
    }

    bool IList.Contains(object value)
    {
      if (IsCompatibleObject(value))
      {
        return Contains((T)value);
      }
      return false;
    }

    int IList.IndexOf(object value)
    {
      if (IsCompatibleObject(value))
      {
        return IndexOf((T)value);
      }
      return -1;
    }

    void IList.Insert(int index, object value)
    {
      throw new NotSupportedException();
    }

    void IList.Remove(object value)
    {
      throw new NotSupportedException();
    }

    void IList.RemoveAt(int index)
    {
      throw new NotSupportedException();
    }
  }
}
#endif