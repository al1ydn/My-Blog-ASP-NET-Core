using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.Configuration
{
    public class CustomLanguageManager : FluentValidation.Resources.LanguageManager
    {
        public CustomLanguageManager()
        {
            #region tr
            AddTranslation(
                "tr",
                "NotNullValidator",
                Messages.NotNullMessage);

            AddTranslation(
                "tr",
                "LengthValidator",
                Messages.LengthMessage);

            AddTranslation(
                "tr",
                "MaximumLengthValidator",
                Messages.MaximumLengthMessage);
            #endregion
        }
    }
}
