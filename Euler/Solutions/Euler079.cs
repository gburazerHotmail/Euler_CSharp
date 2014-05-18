using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Euler.Solutions
{
    class Euler079 : Euler
    {
        public override long Exec()
        {
            var list = File.ReadAllLines(FilePath("Euler079.txt")).Select(l => l.ToCharArray()).ToArray();
            _new.Add(new LinkedList<char>(list.First()));
            foreach (var n in list.Skip(1))
            {
                Add(n[0], null);
                Add(n[1], n[0]);
                Add(n[2], n[1]);
            }
            return long.Parse(String.Join("", _new.First()));
        }

        private static List<LinkedList<char>> _old, 
            _new = new List<LinkedList<char>>();

        private static void Add(char n, char? rightOf)
        {
            _old = new List<LinkedList<char>>(_new.Where(el => el.Count == _new.Min(e => e.Count)));
            _new = new List<LinkedList<char>>();

            foreach (var old in _old)
            {
                if (rightOf == null && old.Find(n) != null)
                {
                    _new.Add(old);
                    continue;
                }
                var pos = rightOf == null ? null : old.Find(rightOf.Value);
                if (pos == null)
                {
                    old.AddFirst(n);
                    var @new = new LinkedList<char>(old);
                    old.RemoveFirst();
                    _new.Add(@new);
                    pos = old.First;
                }
                if (ContainsAtOrAfter(old, pos.Next, n))
                {
                    _new.Add(old);
                    continue;
                }
                while (pos != null)
                {
                    var added = old.AddAfter(pos, n);
                    var @new = new LinkedList<char>(old);
                    old.Remove(added);
                    _new.Add(@new);
                    pos = pos.Next;
                }
            }
        }

        private static bool ContainsAtOrAfter(LinkedList<char> el, LinkedListNode<char> pos, char n)
        {
            while (pos != null)
                if (pos.Value == n)
                    return true;
                else
                    pos = pos.Next;
            return false;
        }
    }
}
