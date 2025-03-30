using Jenina.Static.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Jenina.Static.Securities
{
    public static class RSAEncrypt
    {
        /// <summary>获取密钥对</summary>
        /// <returns></returns>
        public static KeyValuePair<string, string> GetKeyPair()
        {
            var rsaCryptoService = new RSACryptoServiceProvider();
            var publicKey = rsaCryptoService.ToXmlString(false);
            var privateKey = rsaCryptoService.ToXmlString(true);
            return new KeyValuePair<string, string>(publicKey, privateKey);
        }

        /// <summary>加密</summary>
        /// <param name="content">需要加密的内容</param>
        /// <param name="publicKey">加密的密钥</param>
        /// <returns></returns>
        public static string Encrypt(string content, string publicKey)
        {
            var rsaCryptoService = new RSACryptoServiceProvider();
            rsaCryptoService.FromXmlString(publicKey);
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(content);
            byte[] resultBytes = rsaCryptoService.Encrypt(dataToEncrypt, false);
            return Convert.ToBase64String(resultBytes);
        }

        /// <summary>解密</summary>
        /// <param name="content">需要解密的内容</param>
        /// <param name="privateKey">解密的密钥</param>
        /// <returns></returns>
        public static string Decrypt(string content, string privateKey)
        {
            var rsaCryptoService = new RSACryptoServiceProvider();
            rsaCryptoService.FromXmlString(privateKey);
            byte[] dataToDecrypt = Convert.FromBase64String(content);
            byte[] resultBytes = rsaCryptoService.Decrypt(dataToDecrypt, false);
            return Encoding.UTF8.GetString(resultBytes);
        }

        public static Task<string> GetPublicKey()
        {
            var xml = new XmlDocument();
            string xmlPath = Path.Combine(AppContext.BaseDirectory, @$"Xmls{Path.DirectorySeparatorChar}publicKey.xml");
            if (!File.Exists(xmlPath))
            {
                throw new Exception($"公钥不存在!!!{xmlPath}");
            }
            xml.Load(xmlPath);
            xml.RemoveChild(xml.FirstChild);
            if (xml.InnerXml.IsNullOrWhiteSpace())
            {
                throw new Exception("公钥值为空!!!");
            }
            return Task.FromResult(xml.InnerXml);
        }
    }
}
