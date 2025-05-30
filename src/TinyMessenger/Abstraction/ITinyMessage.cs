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
    /// A TinyMessage to be published/delivered by TinyMessenger
    /// </summary>
    public interface ITinyMessage
    {
        /// <summary>
        /// The sender of the message, or null if not supported by the message implementation.
        /// </summary>
        object Sender { get; }
    }
}
