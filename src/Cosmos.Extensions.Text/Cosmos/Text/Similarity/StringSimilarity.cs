namespace Cosmos.Text;

public static class StringSimilarity
{
    private const int MAX_DIF_TOLERADAS = 2;

    /// <summary>
    /// Evaluate string similarity and return quantitative results. <br />
    /// 评估字符串相似度并返回定量结果。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="comparisonText"></param>
    /// <param name="similarityMinimal"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double EvaluateSimilarity(string text, string comparisonText, double similarityMinimal)
    {
        const int diffFound = 0;
        return EvaluateSimilarity(text, comparisonText, similarityMinimal, diffFound);
    }

    /// <summary>
    /// Evaluate string similarity and return quantitative results. <br />
    /// 评估字符串相似度并返回定量结果。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="comparisonText"></param>
    /// <param name="similarityMinimal"></param>
    /// <param name="diffFound"></param>
    /// <returns></returns>
    public static double EvaluateSimilarity(string text, string comparisonText, double similarityMinimal, int diffFound)
    {
        //if you have too many differences and no longer comparing
        if (diffFound >= MAX_DIF_TOLERADAS)
            return 0.0;

        //ignore spaces
        text = Strings.RemoveWhiteSpace(text);
        comparisonText = Strings.RemoveWhiteSpace(comparisonText);

        //if they are equal 100%
        if (text.EqualsIgnoreCase(comparisonText))
            return 1;

        //ignore remaining text
        var portionText = text;
        var portionToCheck = comparisonText;
        if (text.Length != comparisonText.Length)
        {
            if (text.Length > comparisonText.Length)
                portionText = text.Substring(0, comparisonText.Length);
            else if (comparisonText.Length > text.Length)
                portionToCheck = comparisonText.Substring(0, text.Length);
            if (portionText.EqualsIgnoreCase(portionToCheck))
                return 0.75;
        }

        //evaluate the differences
        var totalDifferences = 0;
        var posDifference = -1;
        for (var i = 0; i < text.Length; i++)
        {
            if (i >= comparisonText.Length
             || text.ToCharArray()[i] != comparisonText.ToCharArray()[i])
                totalDifferences++;
            if (posDifference < 0 && totalDifferences == 1)
                posDifference = i;
        }

        //but return percentage according to the amount of differences
        var res = Convert.ToDouble(text.Length - totalDifferences) / Convert.ToDouble(text.Length);

        if (totalDifferences <= MAX_DIF_TOLERADAS)
            return res;

        //suppose that only 1 difference was found
        var differences = diffFound + 1;
        //Consider if the dif is a missing character in text2
        var resConCarAwayInText2 = EvaluateSimilarity(text.Substring(posDifference + 1), comparisonText.Substring(posDifference), similarityMinimal, differences);
        //Consider if the dif is a missing character in text1
        var resConCarAwayInText1 = EvaluateSimilarity(text.Substring(posDifference), comparisonText.Substring(posDifference + 1), similarityMinimal, differences);
        //Consider if the dif is a changed character
        var resConCarCharacter = EvaluateSimilarity(text.Substring(posDifference + 1), comparisonText.Substring(posDifference + 1), similarityMinimal, differences);
        //If any of the 3 is valid, calculate similarity as
        //  simParte1 + max(simParte2) - 0.1 / 2
        if (resConCarAwayInText2 > similarityMinimal || resConCarAwayInText1 > similarityMinimal || resConCarCharacter > similarityMinimal)
            return (1.0 + Math.Max(resConCarAwayInText2, Math.Max(resConCarAwayInText1, resConCarCharacter)) - 0.10) / 2.0;
        return res;
    }

    /// <summary>
    /// Evaluate string similarity and return qualitative results. <br />
    /// 评估字符串相似度并返回定量结果。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="comparisonText"></param>
    /// <returns></returns>
    public static StringSimilarityTypes EvaluateSimilarity(string text, string comparisonText)
    {
        //ignore spaces
        text = Strings.RemoveWhiteSpace(text);
        comparisonText = Strings.RemoveWhiteSpace(comparisonText);

        //if they are equal 100%
        if (text.EqualsIgnoreCase(comparisonText))
            return StringSimilarityTypes.Same;

        //ignore remaining text
        var portionText = text;
        var portionToCheck = comparisonText;
        if (text.Length != comparisonText.Length)
        {
            if (text.Length > comparisonText.Length)
                portionText = text.Substring(0, comparisonText.Length);
            else if (comparisonText.Length > text.Length)
                portionToCheck = comparisonText.Substring(0, text.Length);
            if (portionText.EqualsIgnoreCase(portionToCheck))
                return (text.Length > comparisonText.Length ? StringSimilarityTypes.MayorLong : StringSimilarityTypes.MinorLong);
        }

        return StringSimilarityTypes.Any;
    }
}

public static class StringSimilarityExtensions
{
    /// <summary>
    /// Evaluate string similarity and return quantitative results. <br />
    /// 评估字符串相似度并返回定量结果。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="comparisonText"></param>
    /// <param name="similarityMinimal"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double EvaluateSimilarity(this string text, string comparisonText, double similarityMinimal)
        => StringSimilarity.EvaluateSimilarity(text, comparisonText, similarityMinimal);

    /// <summary>
    /// Evaluate string similarity and return quantitative results. <br />
    /// 评估字符串相似度并返回定量结果。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="comparisonText"></param>
    /// <param name="similarityMinimal"></param>
    /// <param name="diffFound"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double EvaluateSimilarity(this string text, string comparisonText, double similarityMinimal, int diffFound)
        => StringSimilarity.EvaluateSimilarity(text, comparisonText, similarityMinimal, diffFound);

    /// <summary>
    /// Evaluate string similarity and return qualitative results. <br />
    /// 评估字符串相似度并返回定量结果。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="comparisonText"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringSimilarityTypes EvaluateSimilarity(this string text, string comparisonText)
        => StringSimilarity.EvaluateSimilarity(text, comparisonText);
}