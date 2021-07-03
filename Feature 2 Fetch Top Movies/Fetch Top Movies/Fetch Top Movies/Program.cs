using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fetch_Top_Movies
{
    class Program
    {
        //Now, we need to build a criterion so the top movies from multiple countries will combine into a single list of top-rated movies.
        //In order to scale, the content search is performed in a distributed fashion.
        //Search results for each country are produced in separate lists.
        //Each member of a given list is ranked by popularity, with 1 being most popular and popularity decreasing as the rank number increases.
        static void Main(string[] args)
        {
            LinkedListNode l1 = new LinkedListNode(11);
            l1.next = new LinkedListNode(41);
            l1.next.next = new LinkedListNode(51);

            LinkedListNode l2 = new LinkedListNode(21);
            l2.next = new LinkedListNode(23);
            l2.next.next = new LinkedListNode(42);

            LinkedListNode l3 = new LinkedListNode(25);
            l3.next = new LinkedListNode(56);
            l3.next.next = new LinkedListNode(66);
            l3.next.next.next = new LinkedListNode(72);

            List<LinkedListNode> list = new List<LinkedListNode>();
            list.Add(l1);
            list.Add(l2);
            list.Add(l3);

            var result = MergeKCounty(list);

            while(result !=null)
            {
                Console.WriteLine(result.data);
                result = result.next;
            }
        }

        static LinkedListNode MergeKCounty(List<LinkedListNode> lists) 
        {
            if (lists.Count > 0){
              LinkedListNode res = lists[0];

              for (int i = 1; i < lists.Count; i++)
                res = MergeHelper(res, lists[i]);
              return res;
            }
            return new LinkedListNode(-1);
        }

        static LinkedListNode MergeHelper(LinkedListNode l1, LinkedListNode l2) 
        {
            LinkedListNode dummy = new LinkedListNode(-1);
            LinkedListNode prev = dummy;
            while (l1 != null && l2 != null) {
                if (l1.data <= l2.data) {
                    prev.next = l1;
                    l1 = l1.next;
                } else {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }
    
            if (l1 == null)
              prev.next = l2;
            else
              prev.next = l1;

            return dummy.next;
        }

        public class LinkedListNode 
        {
            public int data{get;set;}
            public LinkedListNode next{get;set;}

            public LinkedListNode(int data) 
            {
                this.data = data;
                this.next = null;
            }
        }
    }
}
