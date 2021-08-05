using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PM7V1
{
    class Pagefunctions : BaseClass
    {

        public void Gotourl(string url)
        {
            dr.Url = url;
           
           //string act_title = dr.FindElement(logintitle).Text;
            //string exp_title = "PEOPLE HUB";


           // Console.WriteLine("The site title is " + act_title);
            //Assert.That(act_title, Is.EqualTo(exp_title));


            //Console.WriteLine("String Constraint Test Passed");

        }


        public void Login(string id, string pw)
        {
            dr.FindElement(By.Id("txtUserName")).SendKeys(id);
           // Console.WriteLine("String Constraint Passed: login");

            dr.FindElement(By.Id("txtPassword")).SendKeys(pw);
            //Console.WriteLine("String Constraint Passed:password");

            dr.FindElement(By.Id("btnLogin")).Click();
        }


        public void Clicksetup()
        {
            dr.FindElement(By.CssSelector("ul#side-menu>li:nth-of-type(4)>a")).Click();
            Thread.Sleep(2000);
            dr.FindElement(By.LinkText("Product")).Click();
        }
        public void Setup_search(string name)
        {
            Actions action = new Actions(dr);

            dr.FindElement(By.Id("select2-MainContent_ddlPName-container")).Click();
            Thread.Sleep(2000);
            dr.FindElement(By.ClassName("select2-search__field")).SendKeys(name);
            Thread.Sleep(2000);
            action.SendKeys(Keys.Enter).Perform();
            dr.FindElement(By.Id("MainContent_btnSearch")).Click();

        }

        public void Setup_addproduct(string name)
        {
            Actions action = new Actions(dr);

            dr.FindElement(By.LinkText("Add Product")).Click();
            // dr.SwitchTo().ActiveElement();
            Thread.Sleep(2000);
            dr.FindElement(By.Id("MainContent_txtPName")).SendKeys(name);
            dr.FindElement(By.Id("MainContent_btnAdd")).Click();
            Thread.Sleep(2000);
            dr.FindElement(By.ClassName("confirm")).Click();
            
            action.SendKeys(Keys.Escape).Perform();
            Thread.Sleep(2000);
            dr.Navigate().Refresh();
        }


        public void Setup_delete()
        {
            Actions action = new Actions(dr);
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(6));
            wait.Until(ExpectedConditions.ElementExists(By.Id("MainContent_rptClientAdd_btnDelete_0")));


            IWebElement xbtn = dr.FindElement(By.Id("MainContent_rptClientAdd_btnDelete_0"));
            xbtn.Click();
            Thread.Sleep(2000);
            dr.FindElement(By.Id("MainContent_btnOk")).Click();
            action.SendKeys(Keys.Enter).Perform();

        }

    }
}
