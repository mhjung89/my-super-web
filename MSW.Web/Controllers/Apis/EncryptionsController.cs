using Microsoft.AspNetCore.Mvc;
using MSW.Web.Models.Encryption.Dtos;
using MSW.Web.Models.Encryption.Types;
using MSW.Web.Services;

namespace MSW.Web.Controllers.Apis;

[ApiController]
[Route("api/[controller]")]
public class EncryptionsController : ControllerBase
{
    private readonly AesEncryptor _aesEncryptor;

    public EncryptionsController(AesEncryptor aesEncryptor)
    {
        _aesEncryptor = aesEncryptor;
    }

    [HttpPost]
    public IActionResult Encrypt([FromBody] EncryptionAesRequest request)
    {
        string result;

        switch (request.EncryptionType)
        {
            case EEncryptionType.Encryption:
                result = _aesEncryptor.Encrypt(request.Text, request.Key, request.Iv);
                break;
            case EEncryptionType.Decryption:
                result = _aesEncryptor.Decrypt(request.Text, request.Key, request.Iv);
                break;
            default:
                throw new Exception("잘못된 요청입니다.");
        }
        
        return Ok(new EncryptionAesResponse(result));
    }
}