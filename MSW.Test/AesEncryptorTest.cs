namespace MSW.Test;

public class AesEncryptorTest
{
    [Fact]
    public void Encryption_Test()
    {
        var aes = new AesEncryptor();

        string key = "MySuperWebKey123MySuperWebKey123";
        string iv = "MySuperWebVector";

        string plainText = "My Super Web";

        string encryptedText = aes.Encrypt(plainText, key, iv);

        string decryptedText = aes.Decrypt(encryptedText, key, iv);
        
        Assert.Equal(plainText, decryptedText);
    }
}