﻿/*
 * This is example for article: 
 * http://kbyte.ru/ru/Programming/Articles.aspx?id=65&mode=art
 * (only russian language)
 * Author: Aleksey S Nemiro
 * http://aleksey.nemiro.ru
 * http://kbyte.ru
 * August 27, 2011
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Pop3Lib.MIME
{

  public class ContentDisposition : ParametersBase
  {

    public string FileName
    {
      get
      {
        if (this.Parameters != null && this.Parameters.ContainsKey("filename"))
        {
          return this.Parameters["filename"];
        }
        return String.Empty;
      }
    }

    public ContentDisposition(string source) : base(source) 
    { 
    }

  }
}
