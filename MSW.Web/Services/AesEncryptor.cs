using System.Security.Cryptography;
using System.Text;

namespace MSW.Web.Services;

public class AesEncryptor
{
    public string Encrypt(string plainText, string key, string iv)
    {
        using Aes aesAlg = Aes.Create();
        
        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        aesAlg.IV = Encoding.UTF8.GetBytes(iv);

        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
        
        using var msEncrypt = new MemoryStream();

        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        {
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(plainText);
            }
        }
        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    public string Decrypt(string cipherText, string key, string iv)
    {
        using Aes aesAlg = Aes.Create();
        
        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        aesAlg.IV = Encoding.UTF8.GetBytes(iv);

        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));

        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

        using var srDecrypt = new StreamReader(csDecrypt);
        
        return srDecrypt.ReadToEnd();
    }
}