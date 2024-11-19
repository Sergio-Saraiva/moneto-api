using System.Text;
using Konscious.Security.Cryptography;

namespace Moneto.Application.Helpers;

public static class Argon2Helper
{
    public static string HashPassword(string password, string salt) 
    {
        var argon2id = new Argon2id(Encoding.ASCII.GetBytes(password));
        argon2id.DegreeOfParallelism = 1;
        argon2id.MemorySize = 1024 * 19;
        argon2id.Salt = Encoding.ASCII.GetBytes(salt);
        argon2id.Iterations = 2;

        return Convert.ToBase64String(argon2id.GetBytes(128));
    }
}