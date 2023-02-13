using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nipendo.Evaluation.Notifiers
{
    public class ConsoleNotifier : INotifier
    {
        public void Notify(object message)
        {
            Console.WriteLine(message);
        }
    }
}
