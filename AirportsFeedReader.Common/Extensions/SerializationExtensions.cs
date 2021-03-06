﻿// <copyright file="SerializationExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AirportsFeedReader.Common.Extensions
{
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;

    public static class SerializationExtensions
    {
        public static string ToJson<T>(this T model)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));

            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, model);
                var jsonData = Encoding.UTF8.GetString(ms.ToArray());

                return jsonData;
            }
        }

        public static T ToModelList<T>(this string jsonData)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonData)))
            {
                var modelArray = (T)serializer.ReadObject(stream);
                return modelArray;
            }
        }
    }
}
