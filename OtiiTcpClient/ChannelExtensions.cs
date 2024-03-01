﻿using System;
using System.Reflection;

namespace OtiiTcpClient {

    /// <summary>
    /// Provides extension methods for <see cref="Channel"/>.
    /// </summary>
    public static class ChannelExtensions {

        /// <summary>
        /// Gets the <see cref="DataType"/> of the channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns>The <see cref="DataType"/> of the channel.</returns>
        public static DataType GetDataType(this Channel channel) {
            return GetEnumValueAttribute<ChannelTypeAttribute>(channel)?.DataType ?? default;
        }

        /// <summary>
        /// Returns a value indicating whether the channel value can be retrieved using <see cref="Arc.GetValue"/>.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns><see langword="true"/> if the channel value can be retrieved; otherwise, <see langword="false"/>.</returns>
        public static bool CanGetValue(this Channel channel) {
            return GetEnumValueAttribute<ChannelTypeAttribute>(channel)?.CanGetValue ?? true;
        }

        /// <summary>
        /// Gets the value of an attribute in <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type to return.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static T GetEnumValueAttribute<T>(Enum value)
            where T : Attribute {
            if (value == null) {
                throw new ArgumentNullException(nameof(value), "The value is null.");
            }
            var type = value.GetType();
            var name = Enum.GetName(type, value) ?? throw new ArgumentException("The value is not defined in the enum.", nameof(value));
            return type.GetMember(name)[0].GetCustomAttribute<T>();
        }
    }
}