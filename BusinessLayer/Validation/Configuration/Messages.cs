using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.Configuration
{
    internal static class Messages
    {
        public const string NotNullMessage = 
            "Zorunlu.";

        public const string LengthMessage = 
            "En az {MinLength}, " +
            "en fazla {MaxLength} karakter olmalı.";

        public const string MaximumLengthMessage = 
            "En fazla {MaxLength} karakter olmalı.";


        public const string ContainsLowercaseMessage = 
            "Küçük harf içermeli.";

        public const string ContainsUppercaseMessage = 
            "Büyük harf içermeli.";

        public const string ContainsDigitMessage = 
            "Rakam içermeli.";

        public const string ContainsNonAlphanumericMessage = 
            "Özel karakter içermeli.";

        public const string OnlyAlphaNumericMessage = 
            "İngilizce harf, rakam, \".\" ve \"_\" " +
            "dışında karakter içermemeli.";

        public const string OnlyPrintableAsciiMessage = 
            "Yazdırılabilir ASCII karakterleri " +
            "dışında karakter içermemeli.";

        public const string EmailFormatMessage = 
            "Geçerli bir mail adresi olmalı.";
    }
}
