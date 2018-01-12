using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace CustomValidator
{
    public class CheckPassword : UserNamePasswordValidator
    {
        // MUST NOT be used in a production environment because it is NOT secure.
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "u" && password == "p"))
            {
                throw new SecurityTokenException("Unknown Username or Password");
            }
        }
    }
}