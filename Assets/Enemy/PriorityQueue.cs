using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue<TItem, TPriority>
    where TPriority : System.IComparable<TPriority>
{
    private class Node
    {
        public TItem Data { get; set; }
        public Node(TItem data)
        {
            Data = data;
        }
    }


}
