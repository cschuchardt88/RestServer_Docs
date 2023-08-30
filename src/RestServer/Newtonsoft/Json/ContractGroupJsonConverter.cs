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
    public class ContractGroupJsonConverter : JsonConverter<ContractGroup>
    {
        public override ContractGroup ReadJson(JsonReader reader, Type objectType, ContractGroup existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, ContractGroup value, JsonSerializer serializer)
        {
            var contractGroupObject = new JObject()
            {
                ["pubkey"] = JToken.Parse(JsonConvert.SerializeObject(value.PubKey, RestServerSettings.Default.JsonSerializerSettings)),
                ["signature"] = JToken.Parse(JsonConvert.SerializeObject(value.Signature, RestServerSettings.Default.JsonSerializerSettings)),
            };
            contractGroupObject.WriteTo(writer);
        }
    }
}
