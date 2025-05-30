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
using System.Text;

namespace TinyMessenger.Abstraction
{
    /// <summary>
    /// Message proxy definition.
    /// 
    /// A message proxy can be used to intercept/alter messages and/or
    /// marshall delivery actions onto a particular thread.
    /// </summary>
    public interface ITinyMessageProxy
    {
        void Deliver(ITinyMessage message, ITinyMessageSubscription subscription);
    }
}
