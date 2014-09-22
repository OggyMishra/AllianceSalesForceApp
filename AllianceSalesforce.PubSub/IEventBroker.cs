using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.W
using System.ServiceModel;

namespace AllianceSalesforce.PubSub
{
    public interface IEventBroker
    {
        void Subscribe(IEventType eventType, ThreadMode subscriptionType, object subscriber, Action action);
        void Subscribe(object subscriber, ThreadMode subscriptionType, params SubscribeEventAction[] eventActions);
        void Subscribe<T>(IEventType<T> eventType, ThreadMode subscriptionType, object subscriber, Action<T> action);

        void Publish(IEventType eventType);
        void Publish<T>(IEventType<T> eventType, T parameter);

        void Unsubscribe(IEventType eventType, object subscriber);
        void Unsubscribe<T>(IEventType<T> eventType, object subscriber);
        void Unsubscribe(object subscriber, params SubscribeEventAction[] eventActions);
        void UnsubscribeAll(params object[] subscriber);

        //Dispatcher Dispatcher { get; set; }
        void DispatcherBeginInvoke(Action action);
    }
    public class SubscribeEventAction
    {
        public static SubscribeEventAction Wrap(IEventType eventType, Action action)
        {
            return new SubscribeEventAction { EventTypeName = eventType.Name, Action = action };
        }
        public static SubscribeEventAction Wrap<T>(IEventType<T> eventType, Action<T> action)
        {
            return new SubscribeEventAction { EventTypeName = eventType.Name, Action = action };
        }
        public static SubscribeEventAction Wrap(IEventType eventType)
        {
            return new SubscribeEventAction { EventTypeName = eventType.Name };
        }
        public static SubscribeEventAction Wrap<T>(IEventType<T> eventType)
        {
            return new SubscribeEventAction { EventTypeName = eventType.Name };
        }
        public string EventTypeName;
        public object Action;

        private SubscribeEventAction()
        {
        }
    }
    public enum ThreadMode
    {
        OnPublishThread,
        OnNewThread,
        OnUIThreadAsynch,
        OnUIThreadSynch
    }
}
