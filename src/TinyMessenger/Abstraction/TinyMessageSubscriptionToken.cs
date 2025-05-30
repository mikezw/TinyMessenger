//===============================================================================
// TinyMessenger
//
// A simple messenger/event aggregator.
//
// https://github.com/grumpydev/TinyMessenger
//===============================================================================
// Copyright © Steven Robbins.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyMessenger.Abstraction
{
    /// <summary>
    /// Represents an active subscription to a message
    /// </summary>
    public sealed class TinyMessageSubscriptionToken : IDisposable
    {
        private WeakReference _Hub;
        private Type _MessageType;

        /// <summary>
        /// Initializes a new instance of the TinyMessageSubscriptionToken class.
        /// </summary>
        public TinyMessageSubscriptionToken(ITinyMessengerHub hub, Type messageType)
        {
            if (hub == null)
                throw new ArgumentNullException("hub");

            if (!typeof(ITinyMessage).IsAssignableFrom(messageType))
                throw new ArgumentOutOfRangeException("messageType");

            _Hub = new WeakReference(hub);
            _MessageType = messageType;
        }

        public void Dispose()
        {
            if (_Hub.IsAlive)
            {
                var hub = _Hub.Target as ITinyMessengerHub;

                if (hub != null)
                {
                    //There is a none generic "Unsubscribe" too.
                    var unsubscribeMethod = typeof(ITinyMessengerHub).GetMethods().Where(x=>x.IsGenericMethod&&string.Equals( x.Name, "Unsubscribe")).FirstOrDefault();
                    //var unsubscribeMethod = typeof(ITinyMessengerHub).GetMethod("Unsubscribe", new Type[] { typeof(TinyMessageSubscriptionToken) });
                    unsubscribeMethod = unsubscribeMethod.MakeGenericMethod(_MessageType);
                    unsubscribeMethod.Invoke(hub, new object[] { this });
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}
