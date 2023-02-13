using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nipendo.Evaluation
{
    public class ApplicationNotifier
    {
        private List<INotifier> notifiers;
        public ApplicationNotifier(IEnumerable<INotifier> notifiers = null) 
        {
            this.notifiers = notifiers.ToList() ?? Enumerable.Empty<INotifier>().ToList();
        }
        public void Notify(object message)
        {
            foreach(var notifier in notifiers)
                notifier.Notify(message);
        }
        public void AddNotifier(INotifier notifier)
        {
            notifiers.Add(notifier);
        }
    }
}
