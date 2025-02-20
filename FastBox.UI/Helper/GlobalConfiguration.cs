using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBox.UI.Helper;

public class GlobalConfiguration
{
    public static bool IsDevelopment = true;

	public static string connectionString = IsDevelopment ? Configuration.GetConnectionString("LocalDbConnection") : Configuration.GetConnectionString("FastBoxDbConnection");

	public static int debounceTimeMiliseconds => 1000;

    public static int PageSize => 31;

    public static decimal IVA => 0.23m;
}
