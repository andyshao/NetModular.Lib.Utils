﻿using System;
using System.IO;
using Nmr.Lib.Utils.Core.Attributes;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Nmr.Lib.Utils.Core.Helpers
{
    /// <summary>
    /// 验证码帮助类
    /// </summary>
    [Singleton]
    public class VerifyCodeHelper
    {
        //颜色列表，用于验证码、噪线、噪点 
        private readonly Color[] _colors = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };

        private readonly StringHelper _stringHelper;

        public VerifyCodeHelper(StringHelper stringHelper)
        {
            _stringHelper = stringHelper;
        }

        /// <summary>
        /// 生成随机字符串验证码
        /// </summary>
        /// <param name="code"></param>
        /// <param name="length"></param>
        public byte[] GenerateString(out string code, int length = 6)
        {
            code = _stringHelper.GenerateRandom(length);
            using var img = new Image<Rgba32>(4 + 16 * code.Length, 40);
            var font = SystemFonts.CreateFont("Arial", 16, FontStyle.Regular);
            var codeStr = code;
            img.Mutate(x =>
            {
                x.BackgroundColor(Color.WhiteSmoke);

                var r = new Random();

                //画噪线 
                for (var i = 0; i < 4; i++)
                {
                    int x1 = r.Next(img.Width);
                    int y1 = r.Next(img.Height);
                    int x2 = r.Next(img.Width);
                    int y2 = r.Next(img.Height);
                    x.DrawLines(new Pen(_colors.RandomGet(), 1L), new PointF(x1, y1), new PointF(x2, y2));
                }

                //画验证码字符串 
                for (int i = 0; i < codeStr.Length; i++)
                {
                    x.DrawText(codeStr[i].ToString(), font, _colors.RandomGet(), new PointF((float)i * 16 + 4, 8));
                }
            });

            using var stream = new MemoryStream();
            img.SaveAsPng(stream);
            return stream.GetBuffer();
        }

        /// <summary>
        /// 生成随机字符串验证码并返回图片的Base64格式
        /// </summary>
        /// <param name="code"></param>
        /// <param name="length"></param>
        public string GenerateString2Base64(out string code, int length = 6)
        {
            var bytes = GenerateString(out code, length);
            return "data:image/png;base64," + Convert.ToBase64String(bytes);
        }
    }
}
