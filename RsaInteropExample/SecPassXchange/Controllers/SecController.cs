using System;
using System.IO;
using System.Text;
using System.Web.Http;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;

namespace SecPassXchange.Controllers
{
    public class SecController : ApiController
    {
        const string PrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
MIICXgIBAAKBgQDOFfwbqHOmQWYc50XxsR+dLyNUSwsaQ3tx225AvYEOs9bSS3VV
ngL5z7nCaqLm0WFLqPs2Cncxzt6d6XkJVR78KDopiYV1v5Qq3JngrzZHaoj7qJpd
8bJQpWcMcgviPjJnkWwa0FMUsxPOhEfdw8EfFxlaXJhrmjPD3Yoq8NqBAwIDAQAB
AoGAbA6U+P+TXBowa3lMcFT6CZXcxWbvtF6rzGBM5/81OztKqUtNg43ta4TilrEJ
J1Oj22MIDSbhpqkcitoPT7hlHMsvi2oMzJt+il2lDUaNEw7pib0f0N1f1i6DW697
HebVdza4pXVufqxkTa9wIwFgr2Z2+xm84aOdujo6hGINLPkCQQDmaEDCOnaG503f
K6ctyh60uK37PmKwdNncXLVTDn+lvaIWwAA0rBf80ENGSOm3ChiRfPTxVJH8GCup
p97CsFBtAkEA5PokPxPv/8WilsphUhVZOzi5NCc2zsZnR4687L3qtICOhwwtGRf2
tU2QPEqNJAckoDBxe4GChl6o0tvVf+aRLwJBAIvIlAFCFsahbc0HXtWY2igqIuNa
ZeVH/ySB2kAZe7fB5KSIt5c9ERCACVCKy8AQj/c0KCaBeE/JGjRDdBIJhcECQQCN
xwCYefzZrwLMQUVfMM7OZ4Htc/Zws9KRMSVzpOhlmVAm+HgYGIlumzcazcJ0s2OP
OE+b/IXYM1ZvMSUSC66LAkEAwbg9606JR4gsW6AlRJP86nUIUx8aZaqjWewzbryy
4/uGrlWiOG8EHeL1RUW/s5LezT1RFlL15RuSq4tHH/GI6w==
-----END RSA PRIVATE KEY-----
";

        readonly Lazy<IAsymmetricBlockCipher> _cipher = new Lazy<IAsymmetricBlockCipher>(() =>
        {
            var rsa = new Pkcs1Encoding(new RsaEngine());
            var pemReader = new PemReader(new StringReader(PrivateKey));
            var keyPair = (AsymmetricCipherKeyPair)pemReader.ReadObject();
            rsa.Init(false, keyPair.Private);
            return rsa;
        });

        public string Post(SecretData value)
        {
            string decryptedText = Decrypt(value.Password);

            return "OK " + DateTime.Now + " (secret was: " + decryptedText + ")";
        }

        string Decrypt(string base64Input)
        {
            var buf = Convert.FromBase64String(base64Input);
            byte[] block = _cipher.Value.ProcessBlock(buf, 0, buf.Length);

            return Encoding.UTF8.GetString(block);
        }
    }

    public class SecretData
    {
        public string Password { get; set; }
    }
}
