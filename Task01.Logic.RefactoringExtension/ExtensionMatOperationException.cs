using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.Logic.RefactoringExtension
{
    class ExtensionMatOperationException:Exception
    {
        public ExtensionMatOperationException()
        {
        }

        public ExtensionMatOperationException(string message) : base(message)
        {
        }
    }
}
