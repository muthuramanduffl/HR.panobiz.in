using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StringExtension
/// </summary>
public static class StringExtension
{
    public static bool ContainsInt(this string str, int value)
    {
        return str.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x.Trim()))
            .Contains(value);
    }
}