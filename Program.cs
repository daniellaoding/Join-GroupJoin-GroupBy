using System;

namespace Joins
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupByDemo.GroupByExample();

            JoinDemo.JoinExample();

            GroupJoinDemo.GroupJoinExample();

            GroupByDemo.AdvancedGroupByExample();

            Console.ReadKey();
        }
    }

}
