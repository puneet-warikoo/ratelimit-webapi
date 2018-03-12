using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApi.RateLimits.Interfaces;

namespace WebApi.RateLimits.Defaults.Identifier
{

    class ClientCertificateRequestIdentifier : IRateLimitRequestIdentifier
    {
        private CertificateProperty _property;
        /// <summary>
        /// Initializes the Client Certificate based request Identifier
        /// </summary>
        /// <param name="property" cref="CertificateProperty">Defines the property of certificate to use for identifying the request</param>
        ClientCertificateRequestIdentifier(CertificateProperty property)
        {
            _property = property;
        }
        public string GetIdentifier(HttpRequestMessage requestMessage)
        {
            X509Certificate2 clientCert = requestMessage.GetClientCertificate();
            if (clientCert != null)
            {
                switch (this._property)
                {
                    case CertificateProperty.CommonName: return clientCert.Subject;
                    case CertificateProperty.SerialNumber: return clientCert.SerialNumber;
                    case CertificateProperty.Thumbprint: return clientCert.Thumbprint;
                }
            }
            return null;
        }
        public enum CertificateProperty
        {
            Thumbprint,
            SerialNumber,
            CommonName
        }
    }
}
