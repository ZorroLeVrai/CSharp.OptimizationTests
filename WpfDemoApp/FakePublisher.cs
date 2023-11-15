using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemoApp;

public class FakePublisher
{
    public EventHandler<EventArgs>? PublishEvent;

    public void Invoke()
    {
        PublishEvent?.Invoke(this, EventArgs.Empty);
    }
}
