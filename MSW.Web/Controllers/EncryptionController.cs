using Microsoft.AspNetCore.Mvc;
using MSW.Web.Services;

namespace MSW.Web.Controllers;

public class EncryptionController : Controller
{
    private readonly AesEncryptor _aesEncryptor;

    public EncryptionController(AesEncryptor aesEncryptor)
    {
        _aesEncryptor = aesEncryptor;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Aes()
    {
        return View();
    }
}