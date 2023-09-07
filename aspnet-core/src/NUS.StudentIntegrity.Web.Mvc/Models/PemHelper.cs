using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NUS.StudentIntegrity.Web.Models
{
    public static class PemHelper
    {

        public class RsaKeyPair
        {
            public RsaKeyPair()
            {
                KeyId = CryptoRandom.CreateUniqueId(8);
            }

            /// <summary>
            /// The KeyId for this key pair.
            /// </summary>
            public string KeyId { get; set; }

            /// <summary>
            /// The private key.
            /// </summary>
            public string PrivateKey { get; set; }

            /// <summary>
            /// The public key.
            /// </summary>
            public string PublicKey { get; set; }
        }


        public static RsaKeyPair GenerateRsaKeyPair()
        {
            var rsaGenerator = new RsaKeyPairGenerator();
            rsaGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
            var keyPair = rsaGenerator.GenerateKeyPair();

            var rsaKeyPair = new RsaKeyPair();

            using (var privateKeyTextWriter = new StringWriter())
            {
                var pemWriter = new PemWriter(privateKeyTextWriter);
                pemWriter.WriteObject(keyPair.Private);
                pemWriter.Writer.Flush();

                rsaKeyPair.PrivateKey = privateKeyTextWriter.ToString();
            }

            using (var publicKeyTextWriter = new StringWriter())
            {
                var pemWriter = new PemWriter(publicKeyTextWriter);
                pemWriter.WriteObject(keyPair.Public);
                pemWriter.Writer.Flush();

                rsaKeyPair.PublicKey = publicKeyTextWriter.ToString();
            }

            return rsaKeyPair;
        }

        public static SigningCredentials SigningCredentialsFromPemString(string privateKey)
        {
            using (var keyTextReader = new StringReader(privateKey))
            {
                var cipherKeyPair = (AsymmetricCipherKeyPair)new PemReader(keyTextReader).ReadObject();

                var keyParameters = (RsaPrivateCrtKeyParameters)cipherKeyPair.Private;
                var parameters = new RSAParameters
                {
                    Modulus = keyParameters.Modulus.ToByteArrayUnsigned(),
                    P = keyParameters.P.ToByteArrayUnsigned(),
                    Q = keyParameters.Q.ToByteArrayUnsigned(),
                    DP = keyParameters.DP.ToByteArrayUnsigned(),
                    DQ = keyParameters.DQ.ToByteArrayUnsigned(),
                    InverseQ = keyParameters.QInv.ToByteArrayUnsigned(),
                    D = keyParameters.Exponent.ToByteArrayUnsigned(),
                    Exponent = keyParameters.PublicExponent.ToByteArrayUnsigned()
                };
                var key = new RsaSecurityKey(parameters);
                return new SigningCredentials(key, SecurityAlgorithms.RsaSha256);
            }
        }

        #region
        public static dynamic GetUserRoles(this string[] roles)
        {
            var userRoles = new List<string>();
            foreach (var cuRoles in roles.ToList())
            {
                string uRoles = cuRoles.Substring(cuRoles.LastIndexOf('#') + 1);
                userRoles.Add(uRoles);
            }
            return userRoles.ToArray();

        }

        public static dynamic GetUserCourseRoles(this string[] roles)
        {
            var courseRoles = new List<string>();

            foreach (var cuRoles in roles.ToList())
            {
                if (cuRoles.Contains("membership#"))
                {
                    string cRoles = cuRoles.Substring(cuRoles.LastIndexOf('#') + 1);
                    courseRoles.Add(cRoles);
                }
            }
            return courseRoles.ToArray();

        }

        #endregion

    }
    public static class SessionHelper
    {
        public static void SetObjectInSession(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetCustomObjectFromSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
