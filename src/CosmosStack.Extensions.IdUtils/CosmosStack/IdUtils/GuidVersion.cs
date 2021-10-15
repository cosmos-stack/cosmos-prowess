﻿using System;

/*
 * Reference to:
 *      Nito.Guids
 *      Author: Stephen Cleary
 *      URL: https://github.com/StephenCleary/Guids
 *      MIT
 */

namespace CosmosStack.IdUtils
{
    /// <summary>
    /// Known values for the <see cref="Guid"/> Version field. <br />
    /// 已知值的 GUID 版本字段
    /// </summary>
    public enum GuidVersion
    {
        /// <summary>
        /// Time-based (sequential) GUID.
        /// </summary>
        TimeBased = 1,

        /// <summary>
        /// DCE Security GUID with embedded POSIX UID/GID. See "DCE 1.1: Authentication and Security Services", Chapter 5 and "DCE 1.1: RPC", Appendix A.
        /// </summary>
        DceSecurity = 2,

        /// <summary>
        /// Name-based GUID using the MD5 hashing algorithm.
        /// </summary>
        NameBasedMd5 = 3,

        /// <summary>
        /// Random GUID.
        /// </summary>
        Random = 4,

        /// <summary>
        /// Name-based GUID using the SHA-1 hashing algorithm.
        /// </summary>
        NameBasedSha1 = 5,
    }
}