using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using NSec.Cryptography;

namespace PeykOn.Federation
{
    public static class MxCrypto
    {
        public static JObject GetSignedJson(object obj, object unsigned = default)
        {
            var jObject = JObject.FromObject(obj);
            string signature = SignCanonicalJson(jObject);
            jObject.Add("signatures", JToken.FromObject(new Dictionary<string, object>
            {
                {Program.ServerName, new Dictionary<string, object> {{"ed25519:foo", signature}}}
            }));
            if (unsigned != null)
            {
                jObject.Add("unsigned", JToken.FromObject(unsigned));
            }

            return jObject;
        }

        public static string EncodeToUnpaddedBase64(byte[] data) =>
            Convert.ToBase64String(data).TrimEnd('=');

        public static string GetAuthorizationHeaderValue(
            string method,
            string uri,
            object body = default
        )
        {
            var jObject = JObject.FromObject(new
            {
                method,
                uri,
                origin = "peykon.herokuapp.com",
                destination = "matrix.org"
            });

            if (body != null)
            {
                jObject.Add("content", JToken.FromObject(body));
            }

            string signature = SignCanonicalJson(jObject);
            return $@"X-Matrix origin=peykon.herokuapp.com,key=""ed25519:foo"",sig=""{signature}""";
        }

        /* def authorization_headers(origin_name, origin_signing_key,
                          destination_name, request_method, request_target,
                          content=None):
            request_json = {
                 "method": request_method,
                 "uri": request_target,
                 "origin": origin_name,
                 "destination": destination_name,
            }
        
            if content_json is not None:
                request["content"] = content
        
            signed_json = sign_json(request_json, origin_name, origin_signing_key)
        
            authorization_headers = []
        
            for key, sig in signed_json["signatures"][origin_name].items():
                authorization_headers.append(bytes(
                    "X-Matrix origin=%s,key=\"%s\",sig=\"%s\"" % (
                        origin_name, key, sig,
                    )
                ))
        
            return ("Authorization", authorization_headers)
         */

        private static string SignCanonicalJson(JObject jObject)
        {
            var algorithm = SignatureAlgorithm.Ed25519;
            using (var key = Key.Import(
                algorithm,
                Convert.FromBase64String(Program.PrivateKeyBase64),
                KeyBlobFormat.RawPrivateKey
            ))
            {
                byte[] data = Encoding.UTF8.GetBytes(jObject.ToString());
                byte[] signature = algorithm.Sign(key, data);
                return EncodeToUnpaddedBase64(signature);
            }
        }

        /* def sign_json(json_object, signing_key, signing_name):
            signatures = json_object.pop("signatures", {})
            unsigned = json_object.pop("unsigned", None)
        
            signed = signing_key.sign(encode_canonical_json(json_object))
            signature_base64 = encode_base64(signed.signature)
        
            key_id = "%s:%s" % (signing_key.alg, signing_key.version)
            signatures.setdefault(signing_name, {})[key_id] = signature_base64
        
            json_object["signatures"] = signatures
            if unsigned is not None:
                json_object["unsigned"] = unsigned
        
            return json_object
         */
    }
}