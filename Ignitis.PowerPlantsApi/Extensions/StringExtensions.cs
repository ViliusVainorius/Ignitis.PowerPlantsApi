using System.Globalization;
using System.Text;

namespace Ignitis.PowerPlantsApi.Extensions;

public static class StringExtensions
{
    public static string NormalizeWithoutAccents(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        var normalizedText = text.Normalize(NormalizationForm.FormD);

        var sb = new StringBuilder();

        foreach (var ch in normalizedText)
        {
            var uc = CharUnicodeInfo.GetUnicodeCategory(ch);

            if (uc != UnicodeCategory.NonSpacingMark)
                sb.Append(ch);
        }

        return sb.ToString().Normalize(NormalizationForm.FormC);
    }
}
