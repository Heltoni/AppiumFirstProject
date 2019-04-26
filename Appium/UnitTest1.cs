using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;

namespace Appium
{
    public class UnitTest1
    {
        AndroidDriver<AndroidElement> driver;
        bool usaRemoteWebDriver = false;
        string urlRemoteWebDriver = "http://191.238.223.58:4444/wd/hub";

        public IWebElement Um { get { return driver.FindElement(By.Id("digit_1")); } }
        public IWebElement Dois { get { return driver.FindElement(By.Id("digit_2")); } }
        public IWebElement Tres { get { return driver.FindElement(By.Id("digit_3")); } }
        public IWebElement Quatro { get { return driver.FindElement(By.Id("digit_4")); } }
        public IWebElement Cinco { get { return driver.FindElement(By.Id("digit_5")); } }
        public IWebElement Seis { get { return driver.FindElement(By.Id("digit_6")); } }
        public IWebElement Sete { get { return driver.FindElement(By.Id("digit_7")); } }
        public IWebElement Oito { get { return driver.FindElement(By.Id("digit_8")); } }
        public IWebElement Nove { get { return driver.FindElement(By.Id("digit_9")); } }
        public IWebElement Dez { get { return driver.FindElement(By.Id("digit_10")); } }
        public IWebElement Mais { get { return driver.FindElement(By.Id("op_add")); } }
        public IWebElement Menos { get { return driver.FindElement(By.Id("op_sub")); } }
        public IWebElement Vezes { get { return driver.FindElement(By.Id("op_mul")); } }
        public IWebElement Divisao { get { return driver.FindElement(By.Id("op_div")); } }
        public IWebElement Igual { get { return driver.FindElement(By.Id("eq")); } }
        public IWebElement Resultado { get { return driver.FindElement(By.Id("result")); } }
        public IWebElement Limpar { get { return driver.FindElement(By.Id("clr")); } }
        public IWebElement NovaMSG { get { return driver.FindElement(By.Id("start_new_conversation_button")); } }
        public IWebElement Para { get { return driver.FindElement(By.Id("recipient_text_view")); } }
        public AndroidElement BotaoEntrar { get { return driver.FindElementByAccessibilityId("ENTRAR"); } }
        public AndroidElement CampoXY { get { return driver.FindElementByAccessibilityId("content"); } }
        

        [SetUp]
        public void IniciarTeste()
        {
            var options = new AppiumOptions();
            AppiumServiceBuilder builder = new AppiumServiceBuilder();
            AppiumLocalService service = builder.Build();
            service.Start();

            options.AddAdditionalCapability("platformName", "Android");
            //options.AddAdditionalCapability("deviceName", "nexus_5_7.1.1");
            options.AddAdditionalCapability("deviceName", "Emulator");
            options.AddAdditionalCapability("automationName", "UiAutomator2");
            //options.AddAdditionalCapability("app", "<path to apk>");
            /*
            options.AddAdditionalCapability("appPackage", "com.android.calculator2");
            options.AddAdditionalCapability("appActivity", "com.android.calculator2.Calculator");
            
            //*
            options.AddAdditionalCapability("appPackage", "com.google.android.apps.messaging");
            options.AddAdditionalCapability("appActivity", "com.google.android.apps.messaging.ui.ConversationListActivity");
            */

            options.AddAdditionalCapability("appPackage", "br.com.unimed.pr.hom.cliente");
            options.AddAdditionalCapability("appActivity", "br.com.unimed.pr.hom.cliente.MainActivity");

            if (usaRemoteWebDriver)
            {
                driver = new AndroidDriver<AndroidElement>(new Uri(urlRemoteWebDriver), options, TimeSpan.FromMinutes(3));
            }
            else
            {
                driver = new AndroidDriver<AndroidElement>(builder, options, TimeSpan.FromMinutes(3));
            }
        }

        [Test]
        public void RealizarSoma()
        {
            int i = 1;

            do
            {
                Dois.Click();
                Mais.Click();
                Quatro.Click();
                Igual.Click();

                StringAssert.Contains("6", Resultado.Text);

                Limpar.Click();

                i++;

            } while (i <= 3);

        }

        [Test]
        public void AbrirNovaMensagem()
        {
            NovaMSG.Click();
            Para.SendKeys("Contato de um amigo");
        }

        [Test]
        public void JaSeRegistrou()
        {
            //com.android.packageinstaller:id/permission_allow_button

            Thread.Sleep(TimeSpan.FromSeconds(15));
            BotaoEntrar.Click();
            
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void FinalizarTeste()
        {
            driver.Quit();
        }
    }
}
