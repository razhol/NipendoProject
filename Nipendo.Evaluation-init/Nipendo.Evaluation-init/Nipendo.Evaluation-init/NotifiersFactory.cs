using Nipendo.Evaluation.Notifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nipendo.Evaluation
{
    public class NotifiersFactory
    {
        public static IEnumerable<INotifier> GetNotifiers()
        {
            yield return new ConsoleNotifier();
        }
    }
}
