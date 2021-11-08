using System;
using System.Text;

namespace Practice3
{
    class List
    {
        public int Count { get; private set; } = 0;
        private Node first;
        private Node last;

        public void AddLast(Object value)
        {
            Node newEl = new Node(last, null, value);
            if (last != null)
                last.Next = newEl;
            last = newEl;
            if (first == null)
                first = newEl;

            Count++;
        }
        public void AddFirst(Object value)
        {
            Node newEl = new Node(null, first, value);
            if (first != null)
                first.Previous = newEl;
            first = newEl;
            if (last == null)
                last = newEl;

            Count++;
        }

        public void Remove(object value)
        {
            Node node = first;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    DeliteNode(node);
                    return;
                }
                node = node.Next;
            }
        }
        public void RemoveAt(int index)
        {
            Node node = first;
            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    DeliteNode(node);
                    return;
                }
                node = node.Next;
            }
        }
        public void RemoveFirst()
        {
            DeliteNode(first);
        }
        public void RemoveLast()
        {
            DeliteNode(last);
        }
        private void DeliteNode(Node node)
        {
            if (first == last)
            {
                first = null;
                last = null;
            }
            else if (node == first)
            {
                first = node.Next;
                node.Next.Previous = null;
            }
            else if (node == last)
            {
                last = node.Previous;
                node.Previous.Next = null;
            }
            else
            {
                node.Next.Previous = node.Previous;
                node.Previous.Next = node.Next;
            }

            Count--;
        }

        private void InsertBefore(Node node, Object value)
        {
            if (node.Previous == null)
            {
                AddFirst(value);
            }
            else
            {
                Node newNode = new Node(node.Previous, node, value);
                newNode.Next.Previous = newNode;
                newNode.Previous.Next = newNode;
                Count++;
            }
        }

        public Object this[int index]
        {
            get
            {
                Node node = first;
                for (int i = 0; i < Count; i++)
                {
                    if (i == index)
                        return node.Value;
                    else
                        node = node.Next;
                }
                return null;
            }
            set
            {
                Node node = first;
                for (int i = 0; i < Count; i++)
                {
                    if (i == index)
                        node.Value = value;
                    else
                        node = node.Next;
                }
            }
        }

        public Object GetFirst()
        {
            return first != null ? first.Value : null;
        }
        public Object GetLast()
        {
            return last != null ? last.Value : null;
        }

        public void PrintToConsole()
        {
            Node node = first;
            Console.Write("[");
            for (int i = 0; i < Count; i++)
            {
                Console.Write(node.Value + ",");
                node = node.Next;
            }
            if (Count > 0)
                Console.Write("\b]");
            else
                Console.Write("]");
        }

        public bool Contains(Object value)
        {
            Node curNode = first;
            while(curNode != null)
            {
                if (curNode.Value.Equals(value))
                    return true;

                curNode = curNode.Next;
            }
            return false;
        }

        #region //Регион доп функций
        public void Reverse()
        {
            Node curNode = first;
            Node nextNode;
            Node temp;

            while(curNode != null)
            {
                nextNode = curNode.Next;

                temp = curNode.Previous;
                curNode.Previous = curNode.Next;
                curNode.Next = temp;

                curNode = nextNode;
            }

            temp = first;
            first = last;
            last = temp;
        }

        public void MoveFirstToEnd()
        {
            if (Count > 0)
            {
                Object temp = first.Value;
                RemoveFirst();
                AddLast(temp);
            }
        }
        public void MoveLastToStart()
        {
            if (Count > 0)
            {
                Object temp = last.Value;
                RemoveLast();
                AddFirst(temp);
            }
        }

        //Выводит список соотведствий каждого числа и того, сколько раз он встречается в списке
        //Список обязан состоять только из int чисел
        public void PrintUnicNumbersWithCounts()
        {
            List numbers = new List();
            List counts = new List();

            Node curNode = first;

            while(curNode != null)
            {
                int num = (int)curNode.Value;  //возникнет ошибка, если список содержит не int элемент
                bool wasFound = false;
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (num == (int)numbers[i])
                    {
                        counts[i] = (int)counts[i] + 1;
                        wasFound = true;
                        break;
                    }
                }

                if (!wasFound)
                {
                    numbers.AddLast(num);
                    counts.AddLast(1);
                }

                curNode = curNode.Next;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i] + ": " + counts[i]);
            }
        }

        public void RemoveSecondUnicElement()
        {
            Node curNode = first;

            while (curNode != null)
            {
                Node subNode = curNode.Next; 
                while(subNode != null)
                {
                    if (curNode.Value.Equals(subNode.Value))
                    {
                        DeliteNode(subNode);
                        return;
                    }

                    subNode = subNode.Next;
                }

                curNode = curNode.Next;
            }
        }

        public void DublicateAfter(Object value)
        {
            Node curNode = first;

            while(curNode != null)
            {
                if (curNode.Value.Equals(value))
                {
                    Node subNode = first;
                    Node preNode = curNode;
                    Node nextNode = curNode.Next;
                    while(subNode != null)
                    {
                        Node node = new Node(preNode, null, subNode.Value);
                        preNode.Next = node;
                        preNode = node;

                        if (subNode != curNode)
                            subNode = subNode.Next;
                        else
                            subNode = nextNode;
                    }
                    preNode.Next = nextNode;

                    if (nextNode == null)
                        last = preNode;
                    else
                        nextNode.Previous = preNode;

                    Count *= 2;

                    return;
                }

                curNode = curNode.Next;
            }    
        }

        //Список обязан состоять только из элементов, реализующих интерфейс IComparable (int, string, char, т.д.) одного типа
        public void AddInIncreasingOrder(IComparable value)
        {
            Node curNode = first;
            while(curNode != null)
            {
                if (((IComparable)curNode.Value).CompareTo(value) >= 0)
                {
                    InsertBefore(curNode, value);
                    return;
                }
                curNode = curNode.Next;
            }
            AddLast(value);
        }

        public void RemoveAll(Object value)
        {
            Node node = first;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    DeliteNode(node);
                }
                node = node.Next;
            }
        }

        ///<summary> Добавляет элемент addedValue перед первым вхождением элемента value </summary>
        public void AddBefore(Object value, Object addedValue)
        {
            Node curNode = first;
            while(curNode != null)
            {
                if (curNode.Value.Equals(value))
                {
                    InsertBefore(curNode, addedValue);
                    return;
                }
                curNode = curNode.Next;
            }
        }

        public void AddList(List list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                AddLast(list[i]);
            }
        }

        /// <summary> Возвращает 2 списка, являющиеся результатом разбитя исходного по первому вхождению числа.
        /// Список обязан содержать только элементы типа int. </summary>
        public void SplitByFirstNumber(int number, out List first, out List second)
        {
            first = new List();
            second = new List();

            Node curNode = this.first;
            while(curNode != null && ((int)curNode.Value) != number)
            {
                first.AddLast(curNode.Value);
                curNode = curNode.Next;
            }
            while(curNode != null)
            {
                second.AddLast(curNode.Value);
                curNode = curNode.Next;
            }
        }

        public void DublicateAtEnd()
        {
            if (Count > 0)
            {
                Node curNode = first;
                Node oldLast = last;
                while (curNode != oldLast.Next)
                {
                    AddLast(curNode.Value);

                    curNode = curNode.Next;
                }
            }
        }

        /// <summary> Меняет местами 2 элемента по первому их вхождению. </summary>
        public void Replace(Object value1, Object value2)
        {
            Node curNode = first;
            while(curNode != null)
            {
                if (curNode.Value.Equals(value1))
                {
                    Node subNode = first;
                    while(subNode != null)
                    {
                        if (subNode.Value.Equals(value2))
                        {
                            Object temp = curNode.Value;
                            curNode.Value = subNode.Value;
                            subNode.Value = temp;
                            return;
                        }

                        subNode = subNode.Next;
                    }
                    throw new Exception("Не найден второй элемент");
                }

                curNode = curNode.Next;
            }
            throw new Exception("Не найден первый элемент");
        }

        #endregion
        class Node
        {
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public Object Value { get; set; }
            public Node(Node previous, Node next, Object value)
            {
                Previous = previous;
                Next = next;
                Value = value;
            }
        }
    }
    
}
