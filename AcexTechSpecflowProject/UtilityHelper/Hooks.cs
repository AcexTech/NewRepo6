using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace AcexTechSpecflowProject.UtilityHelper
{
    [Binding]
    public class Hooks
    {
        public static IWebDriver driver;

        //Implementing Specflow Extent report
        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario, step;

        static string reportpath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Results"
            + Path.DirectorySeparatorChar + "ExtentReport - " + DateTime.Now.ToString("ddMMyyy HHmmss")
            + Path.DirectorySeparatorChar;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //generating Extent report 
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
            extent.AddSystemInfo("Environment", "UAT");
            extent.AddSystemInfo("os", Environment.OSVersion.VersionString);

            htmlReport.Config.DocumentTitle = "AcexTech Selenium Automation Training";
            htmlReport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReport.Config.ReportName = "Regression Testing";
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {

            scenario = feature.CreateNode(context.ScenarioInfo.Title);  

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if(context.TestError == null)
            {
                string screenshot = GetScreenshot();
                step.Log(Status.Pass, context.StepContext.StepInfo.Text, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build());
            }
            else if (context.TestError != null)
            {
                string screenshot = GetScreenshot();
                step.Log(Status.Fail, context.StepContext.StepInfo.Text, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build());
            }

        }

        
        [AfterScenario]
        public void AfterScenario()
        {
            //driver.Quit();
            //driver.Dispose();
            
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }

        public string GetScreenshot()
        {
            return ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
        }
    }
}