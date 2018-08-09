using System;

namespace IndigoBunting.Lang
{
    public class LanguageEventArgs : EventArgs
    {
        public Language Lang { get; private set; }

        public LanguageEventArgs(Language lang)
        {
            this.Lang = lang;
        }
    }
}