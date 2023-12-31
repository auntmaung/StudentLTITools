﻿using Abp.AutoMapper;
using NUS.StudentIntegrity.LTICanvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUS.StudentIntegrity.Authorization.LtiCanvas.Dto
{
    [AutoMapTo(typeof(Platform))]
    public class PlatformDto
    {
        /// <summary>
        /// Primary key for this platform configuration
        /// </summary>
        public int Id { get; set; }

        #region Platform properties

        /// <summary>
        /// Platform's access token endpoint
        /// </summary>
        public string AccessTokenUrl { get; set; }

        /// <summary>
        /// Platform's authorize endpoint
        /// </summary>
        public string AuthorizeUrl { get; set; }

        /// <summary>
        /// Platform display name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Platform's issuer
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Platform's JWKS endpoint
        /// </summary>
        public string JwkSetUrl { get; set; }

        /// <summary>
        /// Unique identifier for the platform / authorization server.
        /// Used to create AS-specific redirect URIs as a means to
        /// identify the AS a particular response came from. See BCP
        /// Protecting Redirect-Based Flows.
        /// </summary>
        public string PlatformId { get; set; }

        #endregion

        #region Tool Properties

        /// <summary>
        /// Tool's OpenID Client ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The Key ID (kid) for the private/public key pair.
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// Tool's private key in PEM format
        /// </summary>
        public string PrivateKey { get; set; }

        #endregion

        public LtiToolUser User { get; set; }
        //public ICollection<LtiToolUser> User { get; set; }
    }
}
