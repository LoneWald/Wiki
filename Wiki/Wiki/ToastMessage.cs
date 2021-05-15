using System;
using System.Collections.Generic;
using System.Text;

namespace Wiki
{
    public interface ToastMessage
    {
        void LongTime(string message);
        void ShortTime(string message);
    }
}
