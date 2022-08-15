#if !NET451 && !NET452

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace Cosmos.Text.EncodingServices;

/// <summary>
/// Cosmos <see cref="Encoding"/> factory.<br />
/// Encoding 工厂 <br />
/// </summary>
public static class EncodingFactory
{
    static EncodingFactory()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Z = Encoding.GetEncoding;
    }

    private static readonly Func<int, Encoding> Z;

    /// <summary>
    /// Arabic (ASMO 708)
    /// </summary>
    public static Encoding ASMO_708 => Z(708);

    /// <summary>
    /// Chinese Traditional (Big5)
    /// </summary>
    public static Encoding BIG5 => Z(950);

    /// <summary>
    /// IBM EBCDIC (Cyrillic Serbian-Bulgarian)
    /// </summary>
    public static Encoding CP1025 => Z(21025);

    /// <summary>
    /// Cyrillic (DOS)
    /// </summary>
    public static Encoding CP866 => Z(866);

    /// <summary>
    /// IBM EBCDIC (Greek Modern)
    /// </summary>
    public static Encoding CP875 => Z(875);

    /// <summary>
    /// Japanese (JIS-Allow 1 byte Kana)
    /// </summary>
    public static Encoding CSISO2022JP => Z(50221);

    /// <summary>
    /// Arabic (DOS)
    /// </summary>
    public static Encoding DOS_720 => Z(720);

    /// <summary>
    /// Hebrew (DOS)
    /// </summary>
    public static Encoding DOS_862 => Z(862);

    /// <summary>
    /// Chinese Simplified (EUC)
    /// </summary>
    public static Encoding EUC_CN => Z(51936);

    /// <summary>
    /// Japanese (EUC)
    /// </summary>
    public static Encoding EUC_JP => Z(51932);

    /// <summary>
    /// Japanese (JIS 0208-1990 and 0212-1990)
    /// </summary>
    public static Encoding EUC_JP_1990 => Z(20932);

    /// <summary>
    /// Korean (EUC)
    /// </summary>
    public static Encoding EUC_KR => Z(51949);

    /// <summary>
    /// Chinese Simplified (GB18030)
    /// </summary>
    public static Encoding GB18030 => Z(54936);

    /// <summary>
    /// Chinese Simplified (GB2312)
    /// </summary>
    public static Encoding GB2312 => Z(936);

    /// <summary>
    /// Chinese Simplified (HZ)
    /// </summary>
    public static Encoding HZ_GB_2312 => Z(52936);

    /// <summary>
    /// OEM Multilingual Latin I
    /// </summary>
    public static Encoding IBM00858 => Z(858);

    /// <summary>
    /// IBM Latin-1
    /// </summary>
    public static Encoding IBM00924 => Z(20924);

    /// <summary>
    /// IBM Latin-1
    /// </summary>
    public static Encoding IBM01047 => Z(1047);

    /// <summary>
    /// IBM EBCDIC (US-Canada-Euro)
    /// </summary>
    public static Encoding IBM01140 => Z(1140);

    /// <summary>
    /// IBM EBCDIC (Germany-Euro)
    /// </summary>
    public static Encoding IBM01141 => Z(1141);

    /// <summary>
    /// IBM EBCDIC (Denmark-Norway-Euro)
    /// </summary>
    public static Encoding IBM01142 => Z(1142);

    /// <summary>
    /// IBM EBCDIC (Finland-Sweden-Euro)
    /// </summary>
    public static Encoding IBM01143 => Z(1143);

    /// <summary>
    /// IBM EBCDIC (Italy-Euro)
    /// </summary>
    public static Encoding IBM01144 => Z(1144);

    /// <summary>
    /// IBM EBCDIC (Spain-Euro)
    /// </summary>
    public static Encoding IBM01145 => Z(1145);

    /// <summary>
    /// IBM EBCDIC (UK-Euro)
    /// </summary>
    public static Encoding IBM01146 => Z(1146);

    /// <summary>
    /// IBM EBCDIC (France-Euro)
    /// </summary>
    public static Encoding IBM01147 => Z(1147);

    /// <summary>
    /// IBM EBCDIC (International-Euro)
    /// </summary>
    public static Encoding IBM01148 => Z(1148);

    /// <summary>
    /// IBM EBCDIC (Icelandic-Euro)
    /// </summary>
    public static Encoding IBM01149 => Z(1149);

    /// <summary>
    /// IBM EBCDIC (US-Canada)
    /// </summary>
    public static Encoding IBM037 => Z(37);

    /// <summary>
    /// IBM EBCDIC (Turkish Latin-5)
    /// </summary>
    public static Encoding IBM1026 => Z(1026);

    /// <summary>
    /// IBM EBCDIC (Germany)
    /// </summary>
    public static Encoding IBM273 => Z(20273);

    /// <summary>
    /// IBM EBCDIC (Denmark-Norway)
    /// </summary>
    public static Encoding IBM277 => Z(20277);

    /// <summary>
    /// IBM EBCDIC (Finland-Sweden)
    /// </summary>
    public static Encoding IBM278 => Z(20278);

    /// <summary>
    /// IBM EBCDIC (Italy)
    /// </summary>
    public static Encoding IBM280 => Z(20280);

    /// <summary>
    /// IBM EBCDIC (Spain)
    /// </summary>
    public static Encoding IBM284 => Z(20284);

    /// <summary>
    /// IBM EBCDIC (UK)
    /// </summary>
    public static Encoding IBM285 => Z(20285);

    /// <summary>
    /// IBM EBCDIC (Japanese katakana)
    /// </summary>
    public static Encoding IBM290 => Z(20290);

    /// <summary>
    /// IBM EBCDIC (France)
    /// </summary>
    public static Encoding IBM297 => Z(20297);

    /// <summary>
    /// IBM EBCDIC (Arabic)
    /// </summary>
    public static Encoding IBM420 => Z(20420);

    /// <summary>
    /// IBM EBCDIC (Greek)
    /// </summary>
    public static Encoding IBM423 => Z(20423);

    /// <summary>
    /// IBM EBCDIC (Hebrew)
    /// </summary>
    public static Encoding IBM424 => Z(20424);

    /// <summary>
    /// OEM United States
    /// </summary>
    public static Encoding IBM437 => Z(437);

    /// <summary>
    /// IBM EBCDIC (International)
    /// </summary>
    public static Encoding IBM500 => Z(500);

    /// <summary>
    /// Greek (DOS)
    /// </summary>
    public static Encoding IBM737 => Z(737);

    /// <summary>
    /// Baltic (DOS)
    /// </summary>
    public static Encoding IBM775 => Z(775);

    /// <summary>
    /// Western European (DOS)
    /// </summary>
    public static Encoding IBM850 => Z(850);

    /// <summary>
    /// Central European (DOS)
    /// </summary>
    public static Encoding IBM852 => Z(852);

    /// <summary>
    /// OEM Cyrillic
    /// </summary>
    public static Encoding IBM855 => Z(855);

    /// <summary>
    /// Turkish (DOS)
    /// </summary>
    public static Encoding IBM857 => Z(857);

    /// <summary>
    /// Portuguese (DOS)
    /// </summary>
    public static Encoding IBM860 => Z(860);

    /// <summary>
    /// Icelandic (DOS)
    /// </summary>
    public static Encoding IBM861 => Z(861);

    /// <summary>
    /// French Canadian (DOS)
    /// </summary>
    public static Encoding IBM863 => Z(863);

    /// <summary>
    /// Arabic (864)
    /// </summary>
    public static Encoding IBM864 => Z(864);

    /// <summary>
    /// Nordic (DOS)
    /// </summary>
    public static Encoding IBM865 => Z(865);

    /// <summary>
    /// Greek, Modern (DOS)
    /// </summary>
    public static Encoding IBM869 => Z(869);

    /// <summary>
    /// IBM EBCDIC (Multilingual Latin-2)
    /// </summary>
    public static Encoding IBM870 => Z(870);

    /// <summary>
    /// IBM EBCDIC (Icelandic)
    /// </summary>
    public static Encoding IBM871 => Z(20871);

    /// <summary>
    /// IBM EBCDIC (Cyrillic Russian)
    /// </summary>
    public static Encoding IBM880 => Z(20880);

    /// <summary>
    /// IBM EBCDIC (Turkish)
    /// </summary>
    public static Encoding IBM905 => Z(20905);

    /// <summary>
    /// IBM EBCDIC (Thai)
    /// </summary>
    public static Encoding IBM_THAI => Z(20838);

    /// <summary>
    /// Japanese (JIS)
    /// </summary>
    public static Encoding ISO_2022_JP => Z(50220);

    /// <summary>
    /// Japanese (JIS-Allow 1 byte Kana - SO/SI)
    /// </summary>
    public static Encoding ISO_2022_JP_AllowOneByteKana => Z(50222);

    /// <summary>
    /// Korean (ISO)
    /// </summary>
    public static Encoding ISO_2022_KR => Z(50225);

    /// <summary>
    /// Western European (ISO)
    /// </summary>
    public static Encoding ISO_8859_1 => Z(28591);

    /// <summary>
    /// Estonian (ISO)
    /// </summary>
    public static Encoding ISO_8859_13 => Z(28603);

    /// <summary>
    /// Latin 9 (ISO)
    /// </summary>
    public static Encoding ISO_8859_15 => Z(28605);

    /// <summary>
    /// Central European (ISO)
    /// </summary>
    public static Encoding ISO_8859_2 => Z(28592);

    /// <summary>
    /// Latin 3 (ISO)
    /// </summary>
    public static Encoding ISO_8859_3 => Z(28593);

    /// <summary>
    /// Baltic (ISO)
    /// </summary>
    public static Encoding ISO_8859_4 => Z(28594);

    /// <summary>
    /// Cyrillic (ISO)
    /// </summary>
    public static Encoding ISO_8859_5 => Z(28595);

    /// <summary>
    /// Arabic (ISO)
    /// </summary>
    public static Encoding ISO_8859_6 => Z(28596);

    /// <summary>
    /// Greek (ISO)
    /// </summary>
    public static Encoding ISO_8859_7 => Z(28597);

    /// <summary>
    /// Hebrew (ISO-Visual)
    /// </summary>
    public static Encoding ISO_8859_8 => Z(28598);

    /// <summary>
    /// Hebrew (ISO-Logical)
    /// </summary>
    public static Encoding ISO_8859_8_I => Z(38598);

    /// <summary>
    /// Turkish (ISO)
    /// </summary>
    public static Encoding ISO_8859_9 => Z(28599);

    /// <summary>
    /// Korean (Johab)
    /// </summary>
    public static Encoding JOHAB => Z(1361);

    /// <summary>
    /// Cyrillic (KOI8-R)
    /// </summary>
    public static Encoding KOI8_R => Z(20866);

    /// <summary>
    /// Cyrillic (KOI8-U)
    /// </summary>
    public static Encoding KOI8_U => Z(21866);

    /// <summary>
    /// Korean
    /// </summary>
    public static Encoding KS_C_5601_1987 => Z(949);

    /// <summary>
    /// Western European (Mac)
    /// </summary>
    public static Encoding MACINTOSH => Z(10000);

    /// <summary>
    /// Japanese (Shift-JIS)
    /// </summary>
    public static Encoding SHIFT_JIS => Z(932);

    /// <summary>
    /// US-ASCII
    /// </summary>
    public static Encoding US_ASCII => Z(20127);

    /// <summary>
    /// Unicode
    /// </summary>
    public static Encoding UTF_16 => Z(1200);

    /// <summary>
    /// Unicode (Big-Endian)
    /// </summary>
    public static Encoding UTF_16BE => Z(1201);

    /// <summary>
    /// Unicode (UTF-32)
    /// </summary>
    public static Encoding UTF_32 => Z(12000);

    /// <summary>
    /// Unicode (UTF-32 Big-Endian)
    /// </summary>
    public static Encoding UTF_32BE => Z(12001);

    /// <summary>
    /// Unicode (UTF-7)
    /// </summary>
    public static Encoding UTF_7 => Z(65000);

    /// <summary>
    /// Unicode (UTF-8)
    /// </summary>
    public static Encoding UTF_8 => Z(65001);

    /// <summary>
    /// Central European (Windows)
    /// </summary>
    public static Encoding WINDOWS_1250 => Z(1250);

    /// <summary>
    /// Cyrillic (Windows)
    /// </summary>
    public static Encoding WINDOWS_1251 => Z(1251);

    /// <summary>
    /// Western European (Windows)
    /// </summary>
    public static Encoding WINDOWS_1252 => Z(1252);

    /// <summary>
    /// Greek (Windows)
    /// </summary>
    public static Encoding WINDOWS_1253 => Z(1253);

    /// <summary>
    /// Turkish (Windows)
    /// </summary>
    public static Encoding WINDOWS_1254 => Z(1254);

    /// <summary>
    /// Hebrew (Windows)
    /// </summary>
    public static Encoding WINDOWS_1255 => Z(1255);

    /// <summary>
    /// Arabic (Windows)
    /// </summary>
    public static Encoding WINDOWS_1256 => Z(1256);

    /// <summary>
    /// Baltic (Windows)
    /// </summary>
    public static Encoding WINDOWS_1257 => Z(1257);

    /// <summary>
    /// Vietnamese (Windows)
    /// </summary>
    public static Encoding WINDOWS_1258 => Z(1258);

    /// <summary>
    /// Thai (Windows)
    /// </summary>
    public static Encoding WINDOWS_874 => Z(874);

    /// <summary>
    /// Chinese Traditional (CNS)
    /// </summary>
    public static Encoding X_CHINESE_CNS => Z(20000);

    /// <summary>
    /// Chinese Traditional (Eten)
    /// </summary>
    public static Encoding X_CHINESE_ETEN => Z(20002);

    /// <summary>
    /// TCA Taiwan
    /// </summary>
    public static Encoding X_CP20001 => Z(20001);

    /// <summary>
    /// IBM5550 Taiwan
    /// </summary>
    public static Encoding X_CP20003 => Z(20003);

    /// <summary>
    /// TeleText Taiwan
    /// </summary>
    public static Encoding X_CP20004 => Z(20004);

    /// <summary>
    /// Wang Taiwan
    /// </summary>
    public static Encoding X_CP20005 => Z(20005);

    /// <summary>
    /// T.61
    /// </summary>
    public static Encoding X_CP20261 => Z(20261);

    /// <summary>
    /// ISO-6937
    /// </summary>
    public static Encoding X_CP20269 => Z(20269);

    /// <summary>
    /// Chinese Simplified (GB2312-80)
    /// </summary>
    public static Encoding X_CP20936 => Z(20936);

    /// <summary>
    /// Korean Wansung
    /// </summary>
    public static Encoding X_CP20949 => Z(20949);

    /// <summary>
    /// Chinese Simplified (ISO-2022)
    /// </summary>
    public static Encoding X_CP50227 => Z(50227);

    /// <summary>
    /// IBM EBCDIC (Korean Extended)
    /// </summary>
    public static Encoding X_EBCDIC_KOREANEXTENDED => Z(20833);

    /// <summary>
    /// Europa
    /// </summary>
    public static Encoding X_EUROPA => Z(29001);

    /// <summary>
    /// Western European (IA5)
    /// </summary>
    public static Encoding X_IA5 => Z(20105);

    /// <summary>
    /// German (IA5)
    /// </summary>
    public static Encoding X_IA5_GERMAN => Z(20106);

    /// <summary>
    /// Norwegian (IA5)
    /// </summary>
    public static Encoding X_IA5_NORWEGIAN => Z(20108);

    /// <summary>
    /// Swedish (IA5)
    /// </summary>
    public static Encoding X_IA5_SWEDISH => Z(20107);

    /// <summary>
    /// ISCII Assamese
    /// </summary>
    public static Encoding X_ISCII_AS => Z(57006);

    /// <summary>
    /// ISCII Bengali
    /// </summary>
    public static Encoding X_ISCII_BE => Z(57003);

    /// <summary>
    /// ISCII Devanagari
    /// </summary>
    public static Encoding X_ISCII_DE => Z(57002);

    /// <summary>
    /// ISCII Gujarati
    /// </summary>
    public static Encoding X_ISCII_GU => Z(57010);

    /// <summary>
    /// ISCII Kannada
    /// </summary>
    public static Encoding X_ISCII_KA => Z(57008);

    /// <summary>
    /// ISCII Malayalam
    /// </summary>
    public static Encoding X_ISCII_MA => Z(57009);

    /// <summary>
    /// ISCII Oriya
    /// </summary>
    public static Encoding X_ISCII_OR => Z(57007);

    /// <summary>
    /// ISCII Punjabi
    /// </summary>
    public static Encoding X_ISCII_PA => Z(57011);

    /// <summary>
    /// ISCII Tamil
    /// </summary>
    public static Encoding X_ISCII_TA => Z(57004);

    /// <summary>
    /// ISCII Telugu
    /// </summary>
    public static Encoding X_ISCII_TE => Z(57005);

    /// <summary>
    /// Arabic (Mac)
    /// </summary>
    public static Encoding X_MAC_ARABIC => Z(10004);

    /// <summary>
    /// Central European (Mac)
    /// </summary>
    public static Encoding X_MAC_CE => Z(10029);

    /// <summary>
    /// Chinese Simplified (Mac)
    /// </summary>
    public static Encoding X_MAC_CHINESESIMP => Z(10008);

    /// <summary>
    /// Chinese Traditional (Mac)
    /// </summary>
    public static Encoding X_MAC_CHINESETRAD => Z(10002);

    /// <summary>
    /// Croatian (Mac)
    /// </summary>
    public static Encoding X_MAC_CROATIAN => Z(10082);

    /// <summary>
    /// Cyrillic (Mac)
    /// </summary>
    public static Encoding X_MAC_CYRILLIC => Z(10007);

    /// <summary>
    /// Greek (Mac)
    /// </summary>
    public static Encoding X_MAC_GREEK => Z(10006);

    /// <summary>
    /// Hebrew (Mac)
    /// </summary>
    public static Encoding X_MAC_HEBREW => Z(10005);

    /// <summary>
    /// Icelandic (Mac)
    /// </summary>
    public static Encoding X_MAC_ICELANDIC => Z(10079);

    /// <summary>
    /// Japanese (Mac)
    /// </summary>
    public static Encoding X_MAC_JAPANESE => Z(10001);

    /// <summary>
    /// Korean (Mac)
    /// </summary>
    public static Encoding X_MAC_KOREAN => Z(10003);

    /// <summary>
    /// Romanian (Mac)
    /// </summary>
    public static Encoding X_MAC_ROMANIAN => Z(10010);

    /// <summary>
    /// Thai (Mac)
    /// </summary>
    public static Encoding X_MAC_THAI => Z(10021);

    /// <summary>
    /// Turkish (Mac)
    /// </summary>
    public static Encoding X_MAC_TURKISH => Z(10081);

    /// <summary>
    /// Ukrainian (Mac)
    /// </summary>
    public static Encoding X_MAC_UKRAINIAN => Z(10017);
}

#endif