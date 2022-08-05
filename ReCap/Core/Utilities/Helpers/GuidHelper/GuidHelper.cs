using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.GuidHelper
{
    public class GuidsHelper
    {
        public static string CreateGuild()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
