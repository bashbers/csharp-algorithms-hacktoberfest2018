using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sleepsort
{
    public class SleepSorter
    {
        public List<int> Sort(List<int> unsortedList)
        {
            if (unsortedList.Any(a => a < 0))
                throw new ArgumentException("Array items must be greater than 0");

            var sortedList = new List<int>();
            var taskList = new List<Task>();

            foreach (var item in unsortedList)
            {
                taskList.Add(Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1000 * item);

                    sortedList.Add(item);
                }));
            }

            Task.WaitAll(taskList.ToArray());

            return sortedList;
        }
    }
}
