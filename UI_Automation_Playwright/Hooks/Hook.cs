using BoDi;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UI_Automation_Playwright.Hooks
{
    [Binding]
    public sealed class Hook
    {
        public IBrowser browser;
        public IBrowserContext context;
        public IPage page;
        public IPlaywright playwright;
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public Hook(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [AfterScenario()]
        public async Task closeBrowser()
        {
            if (_scenarioContext.TestError != null)
            {
                await Screenshot(page);
            }
            await browser.DisposeAsync();
        }

        [BeforeScenario()]
        public async Task createBrowser()
        {
            playwright = await Playwright.CreateAsync();
            BrowserTypeLaunchOptions typeLaunchOptions = new BrowserTypeLaunchOptions { Headless = false };
            browser = await playwright.Chromium.LaunchAsync(typeLaunchOptions);
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
            _objectContainer.RegisterInstanceAs(page);
        }

        public static async Task Screenshot(IPage page)
        {
            var date = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss");
            var title = await page.TitleAsync();
            var path = $"../../../screenshots/{date}_{title}-.png";
            var so = new PageScreenshotOptions()
            {
                Path = path,
                FullPage = true,
            };
            await page.ScreenshotAsync(so);
        }
    }
}
