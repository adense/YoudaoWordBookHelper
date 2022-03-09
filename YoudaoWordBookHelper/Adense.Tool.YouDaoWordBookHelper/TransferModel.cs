//-----------------------------------------------------------------------
// <copyright file="TransferModel.cs" company="Pisen Enterprises">
//      Copyright (c) Pisen Enterprises. All rights reserved.
// </copyright>
// <date> 2022/3/8 16:14:33 </date>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adense.Tool.YouDaoWordBookHelper
{
    public class TransferModel
    {
        /// <summary>
        /// 单词
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// 音标
        /// </summary>
        public string Phonetic { get; set; }

        /// <summary>
        /// 释义
        /// </summary>
        public string Trans { get; set; }

    }
}
