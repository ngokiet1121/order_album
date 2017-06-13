using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CodeSales
/// </summary>
public class CodeSales
{
	public CodeSales()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int codeId { get; set; }
    public DateTime beginDate { get; set; }
    public DateTime endDate { get; set; }
    public int percentSales { get; set; }
    public int status { get; set; }
    public string code { get; set; }
}