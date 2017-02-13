using IBM.WatsonDeveloperCloud.LanguageTranslator.v2;
using IBM.WatsonDeveloperCloud.LanguageTranslator.v2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageTranslatorDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TranslatorExample translatorExample = new TranslatorExample();
        }
    }

    public class TranslatorExample
    {
        LanguageTranslatorService languageTranslator = new LanguageTranslatorService();

        public TranslatorExample()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            languageTranslator.SetCredential("", "");

            AskForInput();
        }

        private void AskForInput()
        {
            Console.WriteLine("\nTranslate english to spanish: ");
            var input = Console.ReadLine();

            if(string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please type a phrase to translate from english to spanish.");
                AskForInput();
            }

            Translate(input);
        }

        private void Translate(string input)
        {
            var response = languageTranslator.Translate("en-es", input);

            if (response != null)
            {
                if (response.Translations != null && response.Translations.Count > 0)
                {
                    foreach (Translations translation in response.Translations)
                    {
                        if (!string.IsNullOrEmpty(translation.Translation))
                        {
                            Console.WriteLine(string.Format("response: {0}", translation.Translation.ToString()));
                        }
                        else
                        {
                            Console.WriteLine("Translation is empty.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There are no translations.");
                }
            }
            else
            {
                Console.WriteLine("Response is null.");
            }

            AskForInput();
        }
    }
}
