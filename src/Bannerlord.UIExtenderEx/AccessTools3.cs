﻿using HarmonyLib;

using System;
using System.Reflection;

namespace Bannerlord.UIExtenderEx
{
    internal static class AccessTools3
    {
        /// <summary>Creates an instance field reference delegate for a private type</summary>
        /// <typeparam name="TF">The type of the field</typeparam>
        /// <param name="type">The class/type</param>
        /// <param name="fieldName">The name of the field</param>
        /// <returns>A read and writable <see cref="T:HarmonyLib.AccessTools.FieldRef`2" /> delegate</returns>
        public static AccessTools.FieldRef<object, TF>? FieldRefAccess<TF>(Type type, string fieldName)
        {
            var field = AccessTools.Field(type, fieldName);
            return field is null ? null : AccessTools.FieldRefAccess<object, TF>(field);
        }

        /// <summary>Creates an instance field reference</summary>
        /// <typeparam name="T">The class the field is defined in</typeparam>
        /// <typeparam name="TF">The type of the field</typeparam>
        /// <param name="fieldName">The name of the field</param>
        /// <returns>A read and writable field reference delegate</returns>
        public static AccessTools.FieldRef<T, TF>? FieldRefAccess<T, TF>(string fieldName)
        {
            var field = typeof(T).GetField(fieldName, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);
            return field is null ? null : AccessTools.FieldRefAccess<T, TF>(field);
        }
    }
}