// Copyright (C) 2015-2023 The Neo Project.
//
// The Neo.Plugins.RestServer is free software distributed under the MIT software license,
// see the accompanying file LICENSE in the main directory of the
// project or http://www.opensource.org/licenses/mit-license.php
// for more details.
//
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

using Neo.SmartContract.Manifest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Neo.Plugins.RestServer.Newtonsoft.Json
{
    public class ContractPermissionDescriptorJsonConverter : JsonConverter<ContractPermissionDescriptor>
    {
        public override ContractPermissionDescriptor ReadJson(JsonReader reader, Type objectType, ContractPermissionDescriptor existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, ContractPermissionDescriptor value, JsonSerializer serializer)
        {
            var contractPermissionDescriptorObject = new JObject()
            {
                ["group"] = JToken.Parse(JsonConvert.SerializeObject(value.Group, RestServerSettings.Default.JsonSerializerSettings)),
                ["hash"] = JToken.Parse(JsonConvert.SerializeObject(value.Hash, RestServerSettings.Default.JsonSerializerSettings)),
                ["isGroup"] = value.IsGroup,
                ["isHash"] = value.IsHash,
                ["isWildcard"] = value.IsWildcard,
            };
            contractPermissionDescriptorObject.WriteTo(writer);
        }
    }
}
