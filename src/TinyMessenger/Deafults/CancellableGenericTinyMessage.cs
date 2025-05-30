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
using TinyMessenger.Abstraction;

namespace TinyMessenger.Deafults
{
    /// <summary>
    /// Basic "cancellable" generic message
    /// </summary>
    /// <typeparam name="TContent">Content type to store</typeparam>
    public class CancellableGenericTinyMessage<TContent> : TinyMessageBase
    {
        /// <summary>
        /// Cancel action
        /// </summary>
        public Action Cancel { get; protected set; }

        /// <summary>
        /// Contents of the message
        /// </summary>
        public TContent Content { get; protected set; }

        /// <summary>
        /// Create a new instance of the CancellableGenericTinyMessage class.
        /// </summary>
        /// <param name="sender">Message sender (usually "this")</param>
        /// <param name="content">Contents of the message</param>
        /// <param name="cancelAction">Action to call for cancellation</param>
        public CancellableGenericTinyMessage(object sender, TContent content, Action cancelAction)
            : base(sender)
        {
            if (cancelAction == null)
                throw new ArgumentNullException("cancelAction");

            Content = content;
            Cancel = cancelAction;
        }
    }
}
