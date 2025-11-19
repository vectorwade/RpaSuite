using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpaSuite.Infrastructure.Automation.Selenium;

public interface ISeleniumRunner
{
    void Navigate(string url);
    object InjectJs(string script, params object[] args);
}
