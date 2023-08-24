using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UI_Automation_Playwright.Steps
{
    [Binding]
    public sealed class Weather_Steps
    {
        private IPage _page;

        public Weather_Steps(IPage page)
        {
            _page = page;
        }
        [Given(@"i navigate to ""(.*)""")]
        public async Task GivenINavigateTo(string p0)
        {
            await _page.GotoAsync(p0);
        }

        [When(@"i input the location ""(.*)""")]
        public async Task WhenIInputTheLocation(string p0)
        {
            await _page.FillAsync("//input[@placeholder='Enter a city']", p0);
        }

        [When(@"click search")]
        public async Task WhenClickSearch()
        {
            await Task.WhenAll(_page.PressAsync("//input[@placeholder='Enter a city']", "Enter"));
        }

        [Then(@"i see current weather for ""(.*)""")]
        public async Task ThenISeeCurrentWeatherFor(string p0)
        {
            string expected = await _page.InnerTextAsync("//*[@id='wr-location-name-id']");
            expected.Should().BeEquivalentTo(p0);
        }
    }
}
