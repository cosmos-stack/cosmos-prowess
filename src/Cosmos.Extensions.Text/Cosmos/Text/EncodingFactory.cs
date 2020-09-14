#if !NET451 && !NET452

using System.Text;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace Cosmos.Text
{
    /// <summary>
    /// Cosmos <see cref="Encoding"/> factory.<br />
    /// References to:
    ///     https://docs.microsoft.com/zh-cn/dotnet/api/system.text.encodinginfo.name?view=netcore-3.1 <br />
    /// and
    ///     https://github.com/zmjack/NStandard/blob/master/NStandard.Encoding/EncodingEx.cs ,<br />
    ///     Author: zmjack
    /// </summary>
    public static class EncodingFactory
    {
        static EncodingFactory()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// Arabic (ASMO 708)
        /// </summary>
        public static Encoding ASMO_708 => Encoding.GetEncoding(708);

        /// <summary>
        /// Chinese Traditional (Big5)
        /// </summary>
        public static Encoding BIG5 => Encoding.GetEncoding(950);

        /// <summary>
        /// IBM EBCDIC (Cyrillic Serbian-Bulgarian)
        /// </summary>
        public static Encoding CP1025 => Encoding.GetEncoding(21025);

        /// <summary>
        /// Cyrillic (DOS)
        /// </summary>
        public static Encoding CP866 => Encoding.GetEncoding(866);

        /// <summary>
        /// IBM EBCDIC (Greek Modern)
        /// </summary>
        public static Encoding CP875 => Encoding.GetEncoding(875);

        /// <summary>
        /// Japanese (JIS-Allow 1 byte Kana)
        /// </summary>
        public static Encoding CSISO2022JP => Encoding.GetEncoding(50221);
        
        /// <summary>
        /// Arabic (DOS)
        /// </summary>
        public static Encoding DOS_720 => Encoding.GetEncoding(720);
        
        /// <summary>
        /// Hebrew (DOS)
        /// </summary>
        public static Encoding DOS_862 => Encoding.GetEncoding(862);
        
        /// <summary>
        /// Chinese Simplified (EUC)
        /// </summary>
        public static Encoding EUC_CN => Encoding.GetEncoding(51936);
        
        /// <summary>
        /// Japanese (EUC)
        /// </summary>
        public static Encoding EUC_JP => Encoding.GetEncoding(51932);
        
        /// <summary>
        /// Japanese (JIS 0208-1990 and 0212-1990)
        /// </summary>
        public static Encoding EUC_JP_1990 => Encoding.GetEncoding(20932);
        
        /// <summary>
        /// Korean (EUC)
        /// </summary>
        public static Encoding EUC_KR => Encoding.GetEncoding(51949);
        
        /// <summary>
        /// Chinese Simplified (GB18030)
        /// </summary>
        public static Encoding GB18030 => Encoding.GetEncoding(54936);
        
        /// <summary>
        /// Chinese Simplified (GB2312)
        /// </summary>
        public static Encoding GB2312 => Encoding.GetEncoding(936);
        
        /// <summary>
        /// Chinese Simplified (HZ)
        /// </summary>
        public static Encoding HZ_GB_2312 => Encoding.GetEncoding(52936);
        
        /// <summary>
        /// OEM Multilingual Latin I
        /// </summary>
        public static Encoding IBM00858 => Encoding.GetEncoding(858);
        
        /// <summary>
        /// IBM Latin-1
        /// </summary>
        public static Encoding IBM00924 => Encoding.GetEncoding(20924);
        
        /// <summary>
        /// IBM Latin-1
        /// </summary>
        public static Encoding IBM01047 => Encoding.GetEncoding(1047);
        
        /// <summary>
        /// IBM EBCDIC (US-Canada-Euro)
        /// </summary>
        public static Encoding IBM01140 => Encoding.GetEncoding(1140);
        
        /// <summary>
        /// IBM EBCDIC (Germany-Euro)
        /// </summary>
        public static Encoding IBM01141 => Encoding.GetEncoding(1141);
        
        /// <summary>
        /// IBM EBCDIC (Denmark-Norway-Euro)
        /// </summary>
        public static Encoding IBM01142 => Encoding.GetEncoding(1142);
        
        /// <summary>
        /// IBM EBCDIC (Finland-Sweden-Euro)
        /// </summary>
        public static Encoding IBM01143 => Encoding.GetEncoding(1143);
        
        /// <summary>
        /// IBM EBCDIC (Italy-Euro)
        /// </summary>
        public static Encoding IBM01144 => Encoding.GetEncoding(1144);
        
        /// <summary>
        /// IBM EBCDIC (Spain-Euro)
        /// </summary>
        public static Encoding IBM01145 => Encoding.GetEncoding(1145);
        
        /// <summary>
        /// IBM EBCDIC (UK-Euro)
        /// </summary>
        public static Encoding IBM01146 => Encoding.GetEncoding(1146);
        
        /// <summary>
        /// IBM EBCDIC (France-Euro)
        /// </summary>
        public static Encoding IBM01147 => Encoding.GetEncoding(1147);
        
        /// <summary>
        /// IBM EBCDIC (International-Euro)
        /// </summary>
        public static Encoding IBM01148 => Encoding.GetEncoding(1148);
        
        /// <summary>
        /// IBM EBCDIC (Icelandic-Euro)
        /// </summary>
        public static Encoding IBM01149 => Encoding.GetEncoding(1149);
        
        /// <summary>
        /// IBM EBCDIC (US-Canada)
        /// </summary>
        public static Encoding IBM037 => Encoding.GetEncoding(37);
        
        /// <summary>
        /// IBM EBCDIC (Turkish Latin-5)
        /// </summary>
        public static Encoding IBM1026 => Encoding.GetEncoding(1026);
        
        /// <summary>
        /// IBM EBCDIC (Germany)
        /// </summary>
        public static Encoding IBM273 => Encoding.GetEncoding(20273);
        
        /// <summary>
        /// IBM EBCDIC (Denmark-Norway)
        /// </summary>
        public static Encoding IBM277 => Encoding.GetEncoding(20277);
        
        /// <summary>
        /// IBM EBCDIC (Finland-Sweden)
        /// </summary>
        public static Encoding IBM278 => Encoding.GetEncoding(20278);
        
        /// <summary>
        /// IBM EBCDIC (Italy)
        /// </summary>
        public static Encoding IBM280 => Encoding.GetEncoding(20280);
        
        /// <summary>
        /// IBM EBCDIC (Spain)
        /// </summary>
        public static Encoding IBM284 => Encoding.GetEncoding(20284);
        
        /// <summary>
        /// IBM EBCDIC (UK)
        /// </summary>
        public static Encoding IBM285 => Encoding.GetEncoding(20285);
        
        /// <summary>
        /// IBM EBCDIC (Japanese katakana)
        /// </summary>
        public static Encoding IBM290 => Encoding.GetEncoding(20290);
        
        /// <summary>
        /// IBM EBCDIC (France)
        /// </summary>
        public static Encoding IBM297 => Encoding.GetEncoding(20297);
        
        /// <summary>
        /// IBM EBCDIC (Arabic)
        /// </summary>
        public static Encoding IBM420 => Encoding.GetEncoding(20420);
        
        /// <summary>
        /// IBM EBCDIC (Greek)
        /// </summary>
        public static Encoding IBM423 => Encoding.GetEncoding(20423);
        
        /// <summary>
        /// IBM EBCDIC (Hebrew)
        /// </summary>
        public static Encoding IBM424 => Encoding.GetEncoding(20424);
        
        /// <summary>
        /// OEM United States
        /// </summary>
        public static Encoding IBM437 => Encoding.GetEncoding(437);
        
        /// <summary>
        /// IBM EBCDIC (International)
        /// </summary>
        public static Encoding IBM500 => Encoding.GetEncoding(500);
        
        /// <summary>
        /// Greek (DOS)
        /// </summary>
        public static Encoding IBM737 => Encoding.GetEncoding(737);
        
        /// <summary>
        /// Baltic (DOS)
        /// </summary>
        public static Encoding IBM775 => Encoding.GetEncoding(775);
        
        /// <summary>
        /// Western European (DOS)
        /// </summary>
        public static Encoding IBM850 => Encoding.GetEncoding(850);
        
        /// <summary>
        /// Central European (DOS)
        /// </summary>
        public static Encoding IBM852 => Encoding.GetEncoding(852);
        
        /// <summary>
        /// OEM Cyrillic
        /// </summary>
        public static Encoding IBM855 => Encoding.GetEncoding(855);
        
        /// <summary>
        /// Turkish (DOS)
        /// </summary>
        public static Encoding IBM857 => Encoding.GetEncoding(857);
        
        /// <summary>
        /// Portuguese (DOS)
        /// </summary>
        public static Encoding IBM860 => Encoding.GetEncoding(860);
        
        /// <summary>
        /// Icelandic (DOS)
        /// </summary>
        public static Encoding IBM861 => Encoding.GetEncoding(861);
        
        /// <summary>
        /// French Canadian (DOS)
        /// </summary>
        public static Encoding IBM863 => Encoding.GetEncoding(863);
        
        /// <summary>
        /// Arabic (864)
        /// </summary>
        public static Encoding IBM864 => Encoding.GetEncoding(864);
        
        /// <summary>
        /// Nordic (DOS)
        /// </summary>
        public static Encoding IBM865 => Encoding.GetEncoding(865);
        
        /// <summary>
        /// Greek, Modern (DOS)
        /// </summary>
        public static Encoding IBM869 => Encoding.GetEncoding(869);
        
        /// <summary>
        /// IBM EBCDIC (Multilingual Latin-2)
        /// </summary>
        public static Encoding IBM870 => Encoding.GetEncoding(870);
        
        /// <summary>
        /// IBM EBCDIC (Icelandic)
        /// </summary>
        public static Encoding IBM871 => Encoding.GetEncoding(20871);
        
        /// <summary>
        /// IBM EBCDIC (Cyrillic Russian)
        /// </summary>
        public static Encoding IBM880 => Encoding.GetEncoding(20880);
        
        /// <summary>
        /// IBM EBCDIC (Turkish)
        /// </summary>
        public static Encoding IBM905 => Encoding.GetEncoding(20905);
        
        /// <summary>
        /// IBM EBCDIC (Thai)
        /// </summary>
        public static Encoding IBM_THAI => Encoding.GetEncoding(20838);
        
        /// <summary>
        /// Japanese (JIS)
        /// </summary>
        public static Encoding ISO_2022_JP => Encoding.GetEncoding(50220);
        
        /// <summary>
        /// Japanese (JIS-Allow 1 byte Kana - SO/SI)
        /// </summary>
        public static Encoding ISO_2022_JP_AllowOneByteKana => Encoding.GetEncoding(50222);
        
        /// <summary>
        /// Korean (ISO)
        /// </summary>
        public static Encoding ISO_2022_KR => Encoding.GetEncoding(50225);
        
        /// <summary>
        /// Western European (ISO)
        /// </summary>
        public static Encoding ISO_8859_1 => Encoding.GetEncoding(28591);
        
        /// <summary>
        /// Estonian (ISO)
        /// </summary>
        public static Encoding ISO_8859_13 => Encoding.GetEncoding(28603);
        
        /// <summary>
        /// Latin 9 (ISO)
        /// </summary>
        public static Encoding ISO_8859_15 => Encoding.GetEncoding(28605);
        
        /// <summary>
        /// Central European (ISO)
        /// </summary>
        public static Encoding ISO_8859_2 => Encoding.GetEncoding(28592);
        
        /// <summary>
        /// Latin 3 (ISO)
        /// </summary>
        public static Encoding ISO_8859_3 => Encoding.GetEncoding(28593);
        
        /// <summary>
        /// Baltic (ISO)
        /// </summary>
        public static Encoding ISO_8859_4 => Encoding.GetEncoding(28594);
        
        /// <summary>
        /// Cyrillic (ISO)
        /// </summary>
        public static Encoding ISO_8859_5 => Encoding.GetEncoding(28595);
        
        /// <summary>
        /// Arabic (ISO)
        /// </summary>
        public static Encoding ISO_8859_6 => Encoding.GetEncoding(28596);
        
        /// <summary>
        /// Greek (ISO)
        /// </summary>
        public static Encoding ISO_8859_7 => Encoding.GetEncoding(28597);
        
        /// <summary>
        /// Hebrew (ISO-Visual)
        /// </summary>
        public static Encoding ISO_8859_8 => Encoding.GetEncoding(28598);
        
        /// <summary>
        /// Hebrew (ISO-Logical)
        /// </summary>
        public static Encoding ISO_8859_8_I => Encoding.GetEncoding(38598);
        
        /// <summary>
        /// Turkish (ISO)
        /// </summary>
        public static Encoding ISO_8859_9 => Encoding.GetEncoding(28599);
        
        /// <summary>
        /// Korean (Johab)
        /// </summary>
        public static Encoding JOHAB => Encoding.GetEncoding(1361);
        
        /// <summary>
        /// Cyrillic (KOI8-R)
        /// </summary>
        public static Encoding KOI8_R => Encoding.GetEncoding(20866);
        
        /// <summary>
        /// Cyrillic (KOI8-U)
        /// </summary>
        public static Encoding KOI8_U => Encoding.GetEncoding(21866);
        
        /// <summary>
        /// Korean
        /// </summary>
        public static Encoding KS_C_5601_1987 => Encoding.GetEncoding(949);
        
        /// <summary>
        /// Western European (Mac)
        /// </summary>
        public static Encoding MACINTOSH => Encoding.GetEncoding(10000);
        
        /// <summary>
        /// Japanese (Shift-JIS)
        /// </summary>
        public static Encoding SHIFT_JIS => Encoding.GetEncoding(932);
        
        /// <summary>
        /// US-ASCII
        /// </summary>
        public static Encoding US_ASCII => Encoding.GetEncoding(20127);
        
        /// <summary>
        /// Unicode
        /// </summary>
        public static Encoding UTF_16 => Encoding.GetEncoding(1200);
        
        /// <summary>
        /// Unicode (Big-Endian)
        /// </summary>
        public static Encoding UTF_16BE => Encoding.GetEncoding(1201);
        
        /// <summary>
        /// Unicode (UTF-32)
        /// </summary>
        public static Encoding UTF_32 => Encoding.GetEncoding(12000);
        
        /// <summary>
        /// Unicode (UTF-32 Big-Endian)
        /// </summary>
        public static Encoding UTF_32BE => Encoding.GetEncoding(12001);
        
        /// <summary>
        /// Unicode (UTF-7)
        /// </summary>
        public static Encoding UTF_7 => Encoding.GetEncoding(65000);
        
        /// <summary>
        /// Unicode (UTF-8)
        /// </summary>
        public static Encoding UTF_8 => Encoding.GetEncoding(65001);
        
        /// <summary>
        /// Central European (Windows)
        /// </summary>
        public static Encoding WINDOWS_1250 => Encoding.GetEncoding(1250);
        
        /// <summary>
        /// Cyrillic (Windows)
        /// </summary>
        public static Encoding WINDOWS_1251 => Encoding.GetEncoding(1251);
        
        /// <summary>
        /// Western European (Windows)
        /// </summary>
        public static Encoding WINDOWS_1252 => Encoding.GetEncoding(1252);
        
        /// <summary>
        /// Greek (Windows)
        /// </summary>
        public static Encoding WINDOWS_1253 => Encoding.GetEncoding(1253);
        
        /// <summary>
        /// Turkish (Windows)
        /// </summary>
        public static Encoding WINDOWS_1254 => Encoding.GetEncoding(1254);
        
        /// <summary>
        /// Hebrew (Windows)
        /// </summary>
        public static Encoding WINDOWS_1255 => Encoding.GetEncoding(1255);
        
        /// <summary>
        /// Arabic (Windows)
        /// </summary>
        public static Encoding WINDOWS_1256 => Encoding.GetEncoding(1256);
        
        /// <summary>
        /// Baltic (Windows)
        /// </summary>
        public static Encoding WINDOWS_1257 => Encoding.GetEncoding(1257);
        
        /// <summary>
        /// Vietnamese (Windows)
        /// </summary>
        public static Encoding WINDOWS_1258 => Encoding.GetEncoding(1258);
        
        /// <summary>
        /// Thai (Windows)
        /// </summary>
        public static Encoding WINDOWS_874 => Encoding.GetEncoding(874);
        
        /// <summary>
        /// Chinese Traditional (CNS)
        /// </summary>
        public static Encoding X_CHINESE_CNS => Encoding.GetEncoding(20000);
        
        /// <summary>
        /// Chinese Traditional (Eten)
        /// </summary>
        public static Encoding X_CHINESE_ETEN => Encoding.GetEncoding(20002);
        
        /// <summary>
        /// TCA Taiwan
        /// </summary>
        public static Encoding X_CP20001 => Encoding.GetEncoding(20001);
        
        /// <summary>
        /// IBM5550 Taiwan
        /// </summary>
        public static Encoding X_CP20003 => Encoding.GetEncoding(20003);
        
        /// <summary>
        /// TeleText Taiwan
        /// </summary>
        public static Encoding X_CP20004 => Encoding.GetEncoding(20004);
        
        /// <summary>
        /// Wang Taiwan
        /// </summary>
        public static Encoding X_CP20005 => Encoding.GetEncoding(20005);
        
        /// <summary>
        /// T.61
        /// </summary>
        public static Encoding X_CP20261 => Encoding.GetEncoding(20261);
        
        /// <summary>
        /// ISO-6937
        /// </summary>
        public static Encoding X_CP20269 => Encoding.GetEncoding(20269);
        
        /// <summary>
        /// Chinese Simplified (GB2312-80)
        /// </summary>
        public static Encoding X_CP20936 => Encoding.GetEncoding(20936);
        
        /// <summary>
        /// Korean Wansung
        /// </summary>
        public static Encoding X_CP20949 => Encoding.GetEncoding(20949);
        
        /// <summary>
        /// Chinese Simplified (ISO-2022)
        /// </summary>
        public static Encoding X_CP50227 => Encoding.GetEncoding(50227);
        
        /// <summary>
        /// IBM EBCDIC (Korean Extended)
        /// </summary>
        public static Encoding X_EBCDIC_KOREANEXTENDED => Encoding.GetEncoding(20833);
        
        /// <summary>
        /// Europa
        /// </summary>
        public static Encoding X_EUROPA => Encoding.GetEncoding(29001);
        
        /// <summary>
        /// Western European (IA5)
        /// </summary>
        public static Encoding X_IA5 => Encoding.GetEncoding(20105);
        
        /// <summary>
        /// German (IA5)
        /// </summary>
        public static Encoding X_IA5_GERMAN => Encoding.GetEncoding(20106);
        
        /// <summary>
        /// Norwegian (IA5)
        /// </summary>
        public static Encoding X_IA5_NORWEGIAN => Encoding.GetEncoding(20108);
        
        /// <summary>
        /// Swedish (IA5)
        /// </summary>
        public static Encoding X_IA5_SWEDISH => Encoding.GetEncoding(20107);
        
        /// <summary>
        /// ISCII Assamese
        /// </summary>
        public static Encoding X_ISCII_AS => Encoding.GetEncoding(57006);
        
        /// <summary>
        /// ISCII Bengali
        /// </summary>
        public static Encoding X_ISCII_BE => Encoding.GetEncoding(57003);
        
        /// <summary>
        /// ISCII Devanagari
        /// </summary>
        public static Encoding X_ISCII_DE => Encoding.GetEncoding(57002);
        
        /// <summary>
        /// ISCII Gujarati
        /// </summary>
        public static Encoding X_ISCII_GU => Encoding.GetEncoding(57010);
        
        /// <summary>
        /// ISCII Kannada
        /// </summary>
        public static Encoding X_ISCII_KA => Encoding.GetEncoding(57008);
        
        /// <summary>
        /// ISCII Malayalam
        /// </summary>
        public static Encoding X_ISCII_MA => Encoding.GetEncoding(57009);
        
        /// <summary>
        /// ISCII Oriya
        /// </summary>
        public static Encoding X_ISCII_OR => Encoding.GetEncoding(57007);
        
        /// <summary>
        /// ISCII Punjabi
        /// </summary>
        public static Encoding X_ISCII_PA => Encoding.GetEncoding(57011);
        
        /// <summary>
        /// ISCII Tamil
        /// </summary>
        public static Encoding X_ISCII_TA => Encoding.GetEncoding(57004);
        
        /// <summary>
        /// ISCII Telugu
        /// </summary>
        public static Encoding X_ISCII_TE => Encoding.GetEncoding(57005);
        
        /// <summary>
        /// Arabic (Mac)
        /// </summary>
        public static Encoding X_MAC_ARABIC => Encoding.GetEncoding(10004);
        
        /// <summary>
        /// Central European (Mac)
        /// </summary>
        public static Encoding X_MAC_CE => Encoding.GetEncoding(10029);
        
        /// <summary>
        /// Chinese Simplified (Mac)
        /// </summary>
        public static Encoding X_MAC_CHINESESIMP => Encoding.GetEncoding(10008);
        
        /// <summary>
        /// Chinese Traditional (Mac)
        /// </summary>
        public static Encoding X_MAC_CHINESETRAD => Encoding.GetEncoding(10002);
        
        /// <summary>
        /// Croatian (Mac)
        /// </summary>
        public static Encoding X_MAC_CROATIAN => Encoding.GetEncoding(10082);
        
        /// <summary>
        /// Cyrillic (Mac)
        /// </summary>
        public static Encoding X_MAC_CYRILLIC => Encoding.GetEncoding(10007);
        
        /// <summary>
        /// Greek (Mac)
        /// </summary>
        public static Encoding X_MAC_GREEK => Encoding.GetEncoding(10006);
        
        /// <summary>
        /// Hebrew (Mac)
        /// </summary>
        public static Encoding X_MAC_HEBREW => Encoding.GetEncoding(10005);
        
        /// <summary>
        /// Icelandic (Mac)
        /// </summary>
        public static Encoding X_MAC_ICELANDIC => Encoding.GetEncoding(10079);
        
        /// <summary>
        /// Japanese (Mac)
        /// </summary>
        public static Encoding X_MAC_JAPANESE => Encoding.GetEncoding(10001);
        
        /// <summary>
        /// Korean (Mac)
        /// </summary>
        public static Encoding X_MAC_KOREAN => Encoding.GetEncoding(10003);
        
        /// <summary>
        /// Romanian (Mac)
        /// </summary>
        public static Encoding X_MAC_ROMANIAN => Encoding.GetEncoding(10010);
        
        /// <summary>
        /// Thai (Mac)
        /// </summary>
        public static Encoding X_MAC_THAI => Encoding.GetEncoding(10021);
        
        /// <summary>
        /// Turkish (Mac)
        /// </summary>
        public static Encoding X_MAC_TURKISH => Encoding.GetEncoding(10081);
        
        /// <summary>
        /// Ukrainian (Mac)
        /// </summary>
        public static Encoding X_MAC_UKRAINIAN => Encoding.GetEncoding(10017);
    }
}

#endif