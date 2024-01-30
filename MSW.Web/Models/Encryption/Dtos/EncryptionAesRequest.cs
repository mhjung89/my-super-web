using MSW.Web.Models.Encryption.Types;

namespace MSW.Web.Models.Encryption.Dtos;

public record EncryptionAesRequest(EEncryptionType EncryptionType, string Key, string Iv, string Text);