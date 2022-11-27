public enum Language
{
    English,
    Turkish,
    Azerbaijani,
    Japanese,
    Russian,
    Arabic,
    Spanish,
    Chinese,
    German
}


public interface ITranslator
{
    void SetNext(ITranslator next);
    bool IsTranslated(Language translateFrom, Language translateTo);
}


public class TranslatorEngToAz : ITranslator
{
    private ITranslator? _next;
    private Language _languageFrom = Language.English;
    private Language _languageTo = Language.Azerbaijani;

    public void SetNext(ITranslator next) => _next = next;

    public bool IsTranslated(Language languageFrom, Language languageTo)
    {
        if (languageFrom == _languageFrom && languageTo == _languageTo)
            return true;

        return _next is null ? false : _next.IsTranslated(languageFrom, languageTo);
    }
}


public class TranslatorGerToAz : ITranslator
{
    private ITranslator? _next;
    private Language _languageFrom = Language.German;
    private Language _languageTo = Language.Azerbaijani;


    public void SetNext(ITranslator next) => _next = next;

    public bool IsTranslated(Language languageFrom, Language languageTo)
    {
        if (languageFrom == _languageFrom && languageTo == _languageTo)
            return true;

        return _next is null ? false : _next.IsTranslated(languageFrom, languageTo);
    }
}


public class TranslatorJapToAz : ITranslator
{
    private ITranslator? _next;
    private Language _languageFrom = Language.Japanese;
    private Language _languageTo = Language.Azerbaijani;

    public void SetNext(ITranslator next) => _next = next;

    public bool IsTranslated(Language languageFrom, Language languageTo)
    {
        if (languageFrom == _languageFrom && languageTo == _languageTo)
            return true;

        return _next is null ? false : _next.IsTranslated(languageFrom, languageTo);
    }
}
public class TranslatorArabToAz : ITranslator
{
    private ITranslator? _next;
    private Language _languageFrom = Language.Arabic;
    private Language _languageTo = Language.Azerbaijani;

    public void SetNext(ITranslator next) => _next = next;

    public bool IsTranslated(Language languageFrom, Language languageTo)
    {
        if (languageFrom == _languageFrom && languageTo == _languageTo)
            return true;

        return _next is null ? false : _next.IsTranslated(languageFrom, languageTo);
    }
}
public class Program
{
    static void Main()
    {
        ITranslator engToAzTranslator = new TranslatorEngToAz();
        ITranslator japToAzTranslator = new TranslatorJapToAz();
        ITranslator arabToAzTranslator = new TranslatorArabToAz();
        ITranslator gerToAzTranslator = new TranslatorGerToAz();

        engToAzTranslator.SetNext(japToAzTranslator);
        japToAzTranslator.SetNext(arabToAzTranslator);
        arabToAzTranslator.SetNext(gerToAzTranslator);

        var result = engToAzTranslator.IsTranslated(Language.German, Language.Azerbaijani);
        Console.WriteLine(result);
    }
}
