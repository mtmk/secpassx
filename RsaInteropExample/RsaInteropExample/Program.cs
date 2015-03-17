using System;
using Org.BouncyCastle.Crypto.Parameters;

namespace RsaInteropExample
{
    public class Program
    {
        // http://travistidwell.com/jsencrypt/
        
        static void Main()
        {
            const string rsaKey = @"-----BEGIN RSA PRIVATE KEY-----
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
            const string rsaPub = @"-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDOFfwbqHOmQWYc50XxsR+dLyNU
SwsaQ3tx225AvYEOs9bSS3VVngL5z7nCaqLm0WFLqPs2Cncxzt6d6XkJVR78KDop
iYV1v5Qq3JngrzZHaoj7qJpd8bJQpWcMcgviPjJnkWwa0FMUsxPOhEfdw8EfFxla
XJhrmjPD3Yoq8NqBAwIDAQAB
-----END PUBLIC KEY-----
";

            // echo "Text to encript" | openssl rsautl -encrypt -inkey rsa_pub.pem -pubin -out out.enc
            // openssl base64 -e -in out.enc -out encText.txt
            //const string encText = @"iX/3BFQbVMW0l3WeDjBhYuBs2JLHxnCWT+GrHQI/mVLCslAc1az4WSCAcq3QX6UZeC8XGDKIhhhDlDDdWIrw3C1wZIMB8ataJfIS+cBIZka7GtOdT5JcBWuAHUnYCFKuOEs6nSuyYLKxgLVCAUBLdqwQTT2HyAhQWLdUq+KYliM=";
            const string encText = @"GXMbSl0v5g52RE2wLk3zDylUc1a12427ytc7CJaE017m4ujcPqDbK5CF9f0FXHjWDIXCe5oDw7SBzIPFpKB8KPaSPxCF4Cd4x4LhkGwcP6WS6EmZDZEpTL7tY7WKW/EycZLkj8DHj6nVPMH2twJuaWKNiHeufm24UPWNV1ZAgcA=";

            string rsaDecrypt = new EncryptionClass().RsaDecrypt(encText, rsaKey);
            Console.WriteLine(rsaDecrypt);

            Console.ReadLine();
        }
    }
}