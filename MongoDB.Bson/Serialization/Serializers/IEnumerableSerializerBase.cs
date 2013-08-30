﻿/* Copyright 2010-2013 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System.Collections;
using System.Collections.Generic;

namespace MongoDB.Bson.Serialization.Serializers
{
    /// <summary>
    /// Represents a serializer for enumerable values.
    /// </summary>
    public abstract class IEnumerableSerializerBase<TValue> : EnumerableSerializerBase<TValue>, IBsonArraySerializer where TValue : class, IEnumerable
    {
        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="IEnumerableSerializerBase{TValue}"/> class.
        /// </summary>
        protected IEnumerableSerializerBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IEnumerableSerializerBase{TValue}"/> class.
        /// </summary>
        /// <param name="itemSerializer">The item serializer.</param>
        protected IEnumerableSerializerBase(IBsonSerializer itemSerializer)
            : base(itemSerializer)
        {
        }

        // protected methods
        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="accumulator">The accumulator.</param>
        /// <param name="item">The item.</param>
        protected override void AddItem(object accumulator, object item)
        {
            ((IList)accumulator).Add(item);
        }

        /// <summary>
        /// Enumerates the items in serialization order.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The items.</returns>
        protected override IEnumerable EnumerateItemsInSerializationOrder(TValue value)
        {
            return value;
        }

        /// <summary>
        /// Finalizes the result.
        /// </summary>
        /// <param name="accumulator">The accumulator.</param>
        /// <returns>The result.</returns>
        protected override TValue FinalizeResult(object accumulator)
        {
            return (TValue)accumulator;
        }
    }

    /// <summary>
    /// Represents a serializer for enumerable values.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <typeparam name="TItem">The type of the items.</typeparam>
    public abstract class IEnumerableSerializerBase<TValue, TItem> : EnumerableSerializerBase<TValue, TItem>, IBsonArraySerializer where TValue : class, IEnumerable<TItem>
    {
        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="IEnumerableSerializerBase{TValue, TItem}"/> class.
        /// </summary>
        public IEnumerableSerializerBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IEnumerableSerializerBase{TValue, TItem}"/> class.
        /// </summary>
        /// <param name="itemSerializer">The item serializer.</param>
        public IEnumerableSerializerBase(IBsonSerializer<TItem> itemSerializer)
            : base(itemSerializer)
        {
        }

        // protected methods
        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="accumulator">The accumulator.</param>
        /// <param name="item">The item.</param>
        protected override void AddItem(object accumulator, TItem item)
        {
            ((ICollection<TItem>)accumulator).Add(item);
        }

        /// <summary>
        /// Enumerates the items in serialization order.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The items.</returns>
        protected override IEnumerable<TItem> EnumerateItemsInSerializationOrder(TValue value)
        {
            return value;
        }

        /// <summary>
        /// Finalizes the result.
        /// </summary>
        /// <param name="accumulator">The accumulator.</param>
        /// <returns>The result.</returns>
        protected override TValue FinalizeResult(object accumulator)
        {
            return (TValue)accumulator;
        }
    }

}
