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

using MongoDB.Bson.Serialization.Options;

namespace MongoDB.Bson.Serialization
{
    /// <summary>
    /// Represents a serializer that has a DictionaryRepresentation property.
    /// </summary>
    public interface IBsonSerializerWithDictionaryRepresentation
    {
        /// <summary>
        /// Returns a serializer that has been reconfigured with the specified dictionary representation.
        /// </summary>
        /// <param name="dictionaryRepresentation">The dictionary representation.</param>
        /// <returns>The reconfigured serializer.</returns>
        IBsonSerializer WithDictionaryRepresentation(DictionaryRepresentation dictionaryRepresentation);
    }

    /// <summary>
    /// Represents a serializer that has a DictionaryRepresentation property.
    /// </summary>
    public interface IBsonSerializerWithDictionaryRepresentation<TSerializer> : IBsonSerializerWithDictionaryRepresentation where TSerializer : IBsonSerializer
    {
        /// <summary>
        /// Returns a serializer that has been reconfigured with the specified dictionary representation.
        /// </summary>
        /// <param name="dictionaryRepresentation">The dictionary representation.</param>
        /// <returns>The reconfigured serializer.</returns>
        new TSerializer WithDictionaryRepresentation(DictionaryRepresentation dictionaryRepresentation);
    }
}
